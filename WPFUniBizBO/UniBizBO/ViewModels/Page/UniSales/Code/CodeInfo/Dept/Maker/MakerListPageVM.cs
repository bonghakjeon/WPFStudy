// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Maker.MakerListPageVM
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
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Maker;
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
namespace UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Maker
{
  public class MakerListPageVM : 
    PageBase<
    #nullable disable
    MakerView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private MakerListPageVM.InitParam _InitControlParam = new MakerListPageVM.InitParam();
    private MakerListPageVM.SearchParam param = new MakerListPageVM.SearchParam();
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public MakerListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public MakerListPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public MakerListPageVM.SearchParam ParamBackup { get; set; } = new MakerListPageVM.SearchParam();

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public MakerListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      MakerListPageVM makerListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      makerListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await makerListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await makerListPageVm.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await makerListPageVm.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (makerListPageVm.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
        makerListPageVm.IsOpenExcelPopup = true;
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      makerListPageVm.CloseItem();
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
      if (this.App.User.User.Source.IsMasterCommonSave)
        defaultPageFuncList.Add(DefaultPageFunc.Create);
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
      this.ParamBackup = ParamBase<MakerListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam() => this.InitControlParam.Use = this.Param.Use;

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      MakerListPageVM makerListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await makerListPageVm.\u003C\u003En__1(p_param);
      makerListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsMasterCommonSave;

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

    public bool CanDownloadExcelSample() => this.App.User.User.Source.IsMasterCommonSave;

    public async Task DownloadExcelSampleAsync()
    {
      MakerListPageVM makerListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (makerListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (makerListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (makerListPageVm.Container)).Set(__nonvirtual (makerListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsMasterCommonSave;

    public async Task UploadExcelFileAsync()
    {
      MakerListPageVM makerListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (makerListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (makerListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (makerListPageVm.Container)).Set(__nonvirtual (makerListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task SearchAsync()
    {
      MakerListPageVM sender = this;
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
          string mk_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<MakerView>> success = (await MakerRestServer.GetMakerList(sendType, siteId, code, 0, mk_UseYn: mk_UseYn, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<MakerView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<MakerView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<MakerView>) success.response);
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

    public bool CanDataOpen(MakerView item) => item != null;

    public void DataOpen(MakerView item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }

    public WpfCommand<MakerView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<MakerView>>((Func<WpfCommand<MakerView>>) (() => new WpfCommand<MakerView>().AutoRefreshOn<WpfCommand<MakerView>>().ApplyCanExecute<MakerView>(new Func<MakerView, bool>(this.CanDataOpen)).ApplyExecute<MakerView>(new Action<MakerView>(this.DataOpen))), nameof (CmdDataOpen));

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      MakerListPageVM makerListPageVm = this;
      if (!makerListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (makerListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (makerListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = makerListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = makerListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + makerListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + makerListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (makerListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (makerListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Portrait;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (makerListPageVm.MenuInfo).Title,
        Top1Left = string.Empty,
        Top1Right = string.Empty,
        Top2Left = stringBuilder1.ToString(),
        Top2Right = string.Empty,
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (makerListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (makerListPageVm.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (makerListPageVm.MenuInfo).Code;
      int count = makerListPageVm.Datas.Count;
      string memo1 = stringBuilder2.ToString();
      string empty = string.Empty;
      int pMenuInfoCode = code;
      int pApplyRowCnt = count;
      UniDataGridPrintSysBoardVM viewModel = gridPrintSysBoardVm.Set(creater, memo1, empty, pMenuInfoCode, pApplyRowCnt: pApplyRowCnt);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (makerListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
      MakerListPageVM makerListPageVm = this;
      if (!makerListPageVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = makerListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = makerListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + makerListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + makerListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (makerListPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (makerListPageVm.Exporter), __nonvirtual (makerListPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (makerListPageVm.MenuInfo).Code, applyRowCnt: makerListPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (makerListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<MakerListPageVM.InitParam>
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

    public class SearchParam : ParamBase<MakerListPageVM.SearchParam>
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
