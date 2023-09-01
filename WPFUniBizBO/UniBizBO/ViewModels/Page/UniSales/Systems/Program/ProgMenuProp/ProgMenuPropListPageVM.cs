// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgMenuProp.ProgMenuPropListPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgMenuProp
{
  public class ProgMenuPropListPageVM : 
    PageBase<
    #nullable disable
    ProgMenuPropView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private ProgMenuPropListPageVM.InitParam _InitControlParam = new ProgMenuPropListPageVM.InitParam();
    private ProgMenuPropListPageVM.SearchParam _Param = new ProgMenuPropListPageVM.SearchParam();
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public ProgMenuPropListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public ProgMenuPropListPageVM.SearchParam Param
    {
      get => this._Param;
      set
      {
        this._Param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public ProgMenuPropListPageVM.SearchParam ParamBackup { get; set; } = new ProgMenuPropListPageVM.SearchParam();

    public BindableCollection<ProgMenuPropView> DepthDatas { get; } = new BindableCollection<ProgMenuPropView>();

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public ProgMenuPropListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      ProgMenuPropListPageVM menuPropListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      menuPropListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await menuPropListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await menuPropListPageVm.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await menuPropListPageVm.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (menuPropListPageVm.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
        menuPropListPageVm.IsOpenExcelPopup = true;
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      menuPropListPageVm.CloseItem();
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType)
    {
      if (funcType.Equals((object) DefaultPageFunc.Create))
        return this.CanCreateCode();
      if (funcType.Equals((object) DefaultPageFunc.Print))
        return this.CanPrintDocument();
      return funcType.Equals((object) DefaultPageFunc.ExportExcel) ? this.CanExportExcel() : base.OnQueryCanDefaultFunc(funcType);
    }

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
      if (this.App.User.User.Source.IsAdmin)
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
      this.Param.Use = this.InitControlParam.Use;
      this.Param.AppType = this.App.Sys.CommonCodes[CommonCodeTypes.AppType][this.InitControlParam.comm_TypeNo];
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<ProgMenuPropListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.comm_TypeNo = this.Param.AppType.comm_TypeNo;
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      ProgMenuPropListPageVM menuPropListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await menuPropListPageVm.\u003C\u003En__1(p_param);
      menuPropListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public List<ProgMenuPropView> CreateDepth(IEnumerable<ProgMenuPropView> items, string colName)
    {
      ProgMenuPropLevel progMenuPropLevel = new ProgMenuPropLevel(0);
      if (items.GroupBy<ProgMenuPropView, int>((Func<ProgMenuPropView, int>) (item => item.pmp_ProgKind)).Any<IGrouping<int, ProgMenuPropView>>())
      {
        foreach (IGrouping<int, ProgMenuPropView> source in items.GroupBy<ProgMenuPropView, int>((Func<ProgMenuPropView, int>) (item => item.pmp_ProgKind)))
        {
          CommonCodeView commonCodeView = this.App.Sys.CommonCodes[CommonCodeTypes.AppType][source.Key];
          ProgMenuPropView progMenuPropView1 = new ProgMenuPropView();
          progMenuPropView1.pmp_ProgKind = commonCodeView.comm_TypeNo;
          progMenuPropView1.pmp_PropDepth = 0;
          progMenuPropView1.pmp_PropName = commonCodeView.comm_TypeNoMemo;
          progMenuPropView1.pmp_ProgTitle = commonCodeView.comm_TypeNoMemo;
          ProgMenuPropView progMenuPropView2 = progMenuPropView1;
          List<ProgMenuPropView> progMenuPropViewList = new List<ProgMenuPropView>();
          progMenuPropViewList.AddRange((IEnumerable<ProgMenuPropView>) source.ToList<ProgMenuPropView>());
          progMenuPropView2.Lt_Detail = (IList<ProgMenuPropView>) progMenuPropViewList;
          progMenuPropLevel.Items.Add(progMenuPropView2);
        }
      }
      return progMenuPropLevel.Items;
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsAdmin;

    public async Task CreateAsync()
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }

    public bool CanExcel() => this.App.User.User.Source.IsPermitExcel && this.Exporter != null;

    public WpfCommand CmdExportExcel => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        CanDisplayFunc = (Func<object, bool>) (_ => this.CanExportExcel()),
        ExecuteAction = (Action<object>) (_ => await this.ExportExcelAsync())
      };
    }), nameof (CmdExportExcel));

    public WpfCommand CmdDownloadExcelSample => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        ExecuteAction = (Action<object>) (_ => _ = (object) this.DownloadExcelSampleAsync())
      };
    }), nameof (CmdDownloadExcelSample));

    public WpfCommand CmdUploadExcelFile => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        CanDisplayFunc = (Func<object, bool>) (_ => this.CanUploadExcelFile()),
        ExecuteAction = (Action<object>) (_ => _ = (object) this.UploadExcelFileAsync())
      };
    }), nameof (CmdUploadExcelFile));

    public bool CanDownloadExcelSample() => this.App.User.User.Source.IsAdmin;

    public async Task DownloadExcelSampleAsync()
    {
      ProgMenuPropListPageVM menuPropListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (menuPropListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (menuPropListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (menuPropListPageVm.Container)).Set(__nonvirtual (menuPropListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsAdmin;

    public async Task UploadExcelFileAsync()
    {
      ProgMenuPropListPageVM menuPropListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (menuPropListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (menuPropListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (menuPropListPageVm.Container)).Set(__nonvirtual (menuPropListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task SearchAsync()
    {
      ProgMenuPropListPageVM sender = this;
      try
      {
        UbRes<IList<ProgMenuPropView>> res;
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          int commTypeNo = sender.Param.AppType.comm_TypeNo;
          string useYn = sender.Param.UseYn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          int pmp_ProgKind = commTypeNo;
          string pmp_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          res = (await ProgMenuInfoRestServer.GetProgMenuPropList(sendType, siteId, code, 0, pmp_ProgKind, pmp_UseYn: pmp_UseYn, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<ProgMenuPropView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<ProgMenuPropView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<ProgMenuPropView>) res.response);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          ProgMenuPropLevel data = (await ProgMenuInfoRestServer.GetProgMenuPropDepth(sender.LogInPackInfo.sendType, sender.LogInPackInfo.siteID, __nonvirtual (sender.MenuInfo).Code, 0, sender.Param.AppType.comm_TypeNo, pmp_UseYn: sender.Param.UseYn).ExecuteToReturnAsync<UbRes<ProgMenuPropLevel>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetData<ProgMenuPropLevel>();
          List<ProgMenuPropView> depth = sender.CreateDepth((IEnumerable<ProgMenuPropView>) data.Items, string.Empty);
          sender.DepthDatas.Clear();
          sender.DepthDatas.AddRange((IEnumerable<ProgMenuPropView>) depth);
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
        res = (UbRes<IList<ProgMenuPropView>>) null;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (sender.MenuInfo).Title + " 오류=" + ex.Message);
      }
    }

    public bool CanDataOpen(ProgMenuPropView item) => item != null && item.pmp_PropCode > 0;

    public void DataOpen(ProgMenuPropView item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }

    public WpfCommand<ProgMenuPropView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<ProgMenuPropView>>((Func<WpfCommand<ProgMenuPropView>>) (() => new WpfCommand<ProgMenuPropView>().AutoRefreshOn<WpfCommand<ProgMenuPropView>>().ApplyCanExecute<ProgMenuPropView>(new Func<ProgMenuPropView, bool>(this.CanDataOpen)).ApplyExecute<ProgMenuPropView>(new Action<ProgMenuPropView>(this.DataOpen))), nameof (CmdDataOpen));

    public bool CanGoodsSearch(ProgMenuPropView p_item) => p_item != null && p_item.pmp_PropCode > 0;

    public void ViewDataOpen(ProgMenuPropView p_item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }

    public WpfCommand<ProgMenuPropView> CmdViewDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<ProgMenuPropView>>((Func<WpfCommand<ProgMenuPropView>>) (() =>
    {
      return new WpfCommand<ProgMenuPropView>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<ProgMenuPropView, bool>) (item => this.CanGoodsSearch(item)),
        ExecuteAction = (Action<ProgMenuPropView>) (item => this.ViewDataOpen(item))
      };
    }), nameof (CmdViewDataOpen));

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      ProgMenuPropListPageVM menuPropListPageVm = this;
      if (!menuPropListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str1 = __nonvirtual (menuPropListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (menuPropListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      bool? use = menuPropListPageVm.ParamBackup.Use;
      if (use.HasValue)
      {
        StringBuilder stringBuilder6 = stringBuilder5;
        use = menuPropListPageVm.ParamBackup.Use;
        string str2 = "[" + (use.Value ? "사용" : "미사용") + "]";
        stringBuilder6.Append(str2);
        StringBuilder stringBuilder7 = stringBuilder2;
        use = menuPropListPageVm.ParamBackup.Use;
        string str3 = "[" + (use.Value ? "사용" : "미사용") + "]";
        stringBuilder7.Append(str3);
      }
      bool flag = false;
      if (menuPropListPageVm.ParamBackup.AppType.comm_TypeNo > 0)
      {
        stringBuilder5.Append("[" + menuPropListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
        if (flag)
          stringBuilder4.Append("/");
        stringBuilder4.Append("[" + menuPropListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
      }
      string keyword = menuPropListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder5.Append("[키워드:" + menuPropListPageVm.ParamBackup.Keyword + "]");
        stringBuilder3.Append("[키워드:" + menuPropListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (menuPropListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (menuPropListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Landscape;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (menuPropListPageVm.MenuInfo).Title,
        Top1Left = stringBuilder1.ToString(),
        Top1Right = stringBuilder3.ToString(),
        Top2Left = stringBuilder2.ToString(),
        Top2Right = stringBuilder4.ToString(),
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (menuPropListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (menuPropListPageVm.App).User.User.Source.emp_Code, (object) str1),
        BottomRight = "UniBizSM : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (menuPropListPageVm.MenuInfo).Code;
      int count = menuPropListPageVm.Datas.Count;
      string memo1 = stringBuilder5.ToString();
      string empty = string.Empty;
      int pMenuInfoCode = code;
      int pApplyRowCnt = count;
      UniDataGridPrintSysBoardVM viewModel = gridPrintSysBoardVm.Set(creater, memo1, empty, pMenuInfoCode, pApplyRowCnt: pApplyRowCnt);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (menuPropListPageVm.WindowManager)?.ShowDialog((object) viewModel);
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      if (viewModel != null)
        await viewModel.DisposeAsync();
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return;
      obj = (object) null;
    }

    public IElementExporter Exporter { get; set; }

    public bool CanExportExcel() => this.App.User.User.Source.IsPermitExcel && this.Exporter != null && this.Datas.Count > 0;

    public async Task ExportExcelAsync()
    {
      ProgMenuPropListPageVM menuPropListPageVm = this;
      if (!menuPropListPageVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (menuPropListPageVm.ParamBackup.Use.HasValue)
      {
        stringBuilder2.Append("[" + (menuPropListPageVm.ParamBackup.Use.Value ? "사용" : "미사용") + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + (menuPropListPageVm.ParamBackup.Use.Value ? "사용" : "미사용") + "]");
      }
      if (menuPropListPageVm.ParamBackup.AppType.comm_TypeNo > 0)
      {
        stringBuilder2.Append("[" + menuPropListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + menuPropListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
      }
      string keyword = menuPropListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder2.Append("[키워드:" + menuPropListPageVm.ParamBackup.Keyword + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + menuPropListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (menuPropListPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (menuPropListPageVm.Exporter), __nonvirtual (menuPropListPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (menuPropListPageVm.MenuInfo).Code, applyRowCnt: menuPropListPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (menuPropListPageVm.WindowManager)?.ShowDialog((object) viewModel);
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      if (viewModel != null)
        await viewModel.DisposeAsync();
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return;
      obj = (object) null;
    }

    public class InitParam : ParamBase<ProgMenuPropListPageVM.InitParam>
    {
      private bool? use = new bool?(true);
      private int _comm_TypeNo;

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

      public int comm_TypeNo
      {
        get => this._comm_TypeNo;
        set
        {
          this._comm_TypeNo = value;
          this.NotifyOfPropertyChange(nameof (comm_TypeNo));
        }
      }
    }

    public class SearchParam : ParamBase<ProgMenuPropListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string _Keyword;
      private CommonCodeView _AppType;

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
        get => this._Keyword;
        set
        {
          this._Keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public CommonCodeView AppType
      {
        get => this._AppType;
        set
        {
          this._AppType = value;
          this.NotifyOfPropertyChange(nameof (AppType));
        }
      }
    }
  }
}
