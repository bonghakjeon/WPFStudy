// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Store.StoreListPageVM
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
using System.Windows.Threading;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Store;
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
  public class StoreListPageVM : PageBase<
  #nullable disable
  StoreInfoView>, ISystemPage
  {
    private StoreListPageVM.InitParam _InitControlParam = new StoreListPageVM.InitParam();
    private StoreListPageVM.SearchParam param = new StoreListPageVM.SearchParam();

    [ManagedStatus]
    public StoreListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public StoreListPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public StoreListPageVM.SearchParam ParamBackup { get; set; } = new StoreListPageVM.SearchParam();

    public IUniDataGridViewer GridViewer { get; set; }

    public StoreListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      StoreListPageVM storeListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      storeListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await storeListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await storeListPageVm.SearchAsync();
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      storeListPageVm.CloseItem();
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
      if (this.App.User.User.Source.IsPermitPrint)
        defaultPageFuncList.Add(DefaultPageFunc.Print);
      if (this.App.User.User.Source.IsPermitExcel)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      defaultPageFuncList.Add(DefaultPageFunc.Close);
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl() => this.Param.Use = this.InitControlParam.Use;

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<StoreListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam() => this.InitControlParam.Use = this.Param.Use;

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      StoreListPageVM storeListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await storeListPageVm.\u003C\u003En__1(p_param);
      storeListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public async Task SearchAsync()
    {
      StoreListPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          string useYn = sender.Param.UseYn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          string si_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<StoreInfoView>> success = (await StoreRestServer.GetStoreInfoList(sendType, siteId, code, 0, si_UseYn: si_UseYn, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<StoreInfoView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<StoreInfoView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<StoreInfoView>) success.response);
          if (sender.Datas.Count >= 0)
          {
            sender.DisplaySearchCount = success.response.Count;
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
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public bool CanDataOpen(StoreInfoView item) => item != null;

    public void DataOpen(StoreInfoView item)
    {
      if (item == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == item.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageStorePartConVM viewModel = this.Container.Get<PageStorePartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageStorePartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public WpfCommand<StoreInfoView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<StoreInfoView>>((Func<WpfCommand<StoreInfoView>>) (() => new WpfCommand<StoreInfoView>().AutoRefreshOn<WpfCommand<StoreInfoView>>().ApplyCanExecute<StoreInfoView>(new Func<StoreInfoView, bool>(this.CanDataOpen)).ApplyExecute<StoreInfoView>(new Action<StoreInfoView>(this.DataOpen))), nameof (CmdDataOpen));

    public class InitParam : ParamBase<StoreListPageVM.InitParam>
    {
      private bool? use = new bool?(true);

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
    }

    public class SearchParam : ParamBase<StoreListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string keyword = string.Empty;

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
