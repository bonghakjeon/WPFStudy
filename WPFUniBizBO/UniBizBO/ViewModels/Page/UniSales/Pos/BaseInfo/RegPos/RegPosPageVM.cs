// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Pos.BaseInfo.RegPos.RegPosPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.PosInfo;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Pos.BaseInfo.RegPos
{
  public class RegPosPageVM : PageBase<
  #nullable disable
  PosInfoView>, ISystemPage
  {
    private RegPosPageVM.InitParam _InitControlParam = new RegPosPageVM.InitParam();
    private RegPosPageVM.SearchParam param = new RegPosPageVM.SearchParam();

    [ManagedStatus]
    public RegPosPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public RegPosPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public RegPosPageVM.SearchParam ParamBackup { get; set; } = new RegPosPageVM.SearchParam();

    public IUniDataGridViewer GridViewer { get; set; }

    public RegPosPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (!funcType.Equals((object) DefaultPageFunc.Search))
        return;
      await this.SearchAsync();
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
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl() => this.Param.Use = this.InitControlParam.Use;

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<RegPosPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam() => this.InitControlParam.Use = this.Param.Use;

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      RegPosPageVM regPosPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await regPosPageVm.\u003C\u003En__1(p_param);
      regPosPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
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
      RegPosPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<IList<PosInfoView>> success = (await PosInfoRestServer.GetPosInfoList(sender.LogInPackInfo.sendType, sender.LogInPackInfo.siteID, __nonvirtual (sender.MenuInfo).Code, 0, pos_UseYn: sender.Param.UseYn, KeyWord: sender.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<PosInfoView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<PosInfoView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<PosInfoView>) success.response);
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

    public class InitParam : ParamBase<RegPosPageVM.InitParam>
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

    public class SearchParam : ParamBase<RegPosPageVM.SearchParam>
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
