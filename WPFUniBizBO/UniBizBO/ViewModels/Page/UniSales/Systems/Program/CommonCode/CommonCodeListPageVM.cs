// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Systems.Program.CommonCode.CommonCodeListPageVM
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
using UniBiz.Bo.Models.UniBase.CommonCode;
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
namespace UniBizBO.ViewModels.Page.UniSales.Systems.Program.CommonCode
{
  public class CommonCodeListPageVM : 
    PageBase<
    #nullable disable
    CommonCodeView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private CommonCodeListPageVM.InitParam _InitControlParam = new CommonCodeListPageVM.InitParam();
    private CommonCodeListPageVM.SearchParam _Param = new CommonCodeListPageVM.SearchParam();
    private List<CommonCodeView> _CommonTypeList = new List<CommonCodeView>();
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public CommonCodeListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public CommonCodeListPageVM.SearchParam Param
    {
      get => this._Param;
      set
      {
        this._Param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public CommonCodeListPageVM.SearchParam ParamBackup { get; set; } = new CommonCodeListPageVM.SearchParam();

    public List<CommonCodeView> CommonTypeList
    {
      get => this._CommonTypeList;
      set
      {
        this._CommonTypeList = value;
        this.NotifyOfPropertyChange(nameof (CommonTypeList));
      }
    }

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public CommonCodeListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      CommonCodeListPageVM commonCodeListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      commonCodeListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await commonCodeListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await commonCodeListPageVm.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await commonCodeListPageVm.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (commonCodeListPageVm.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
        commonCodeListPageVm.IsOpenExcelPopup = true;
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      commonCodeListPageVm.CloseItem();
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
      this.CommonTypeCreate();
    }

    protected void InitControl()
    {
      this.Param.Use = this.InitControlParam.Use;
      this.Param.comm_Type = this.InitControlParam.comm_Type;
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<CommonCodeListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.ParamBackup.comm_TypeMemo = this.CommonTypeList.FirstOrDefault<CommonCodeView>((Func<CommonCodeView, bool>) (it => it.comm_Type == this.Param.comm_Type)).comm_TypeMemo;
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.comm_Type = this.Param.comm_Type;
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      CommonCodeListPageVM commonCodeListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await commonCodeListPageVm.\u003C\u003En__1(p_param);
      commonCodeListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public void CommonTypeCreate()
    {
      try
      {
        using (this.Job.CreateJob(this.MenuInfo.Title + " 타입 검색", (string) null))
        {
          this.CommonTypeList.Clear();
          this.CommonTypeList = this.App.Sys.CommonCodes.Values.Select<CommonCodeGroup, CommonCodeView>((Func<CommonCodeGroup, CommonCodeView>) (x => x.Items[0])).ToList<CommonCodeView>();
          List<CommonCodeView> commonTypeList = this.CommonTypeList;
          CommonCodeView commonCodeView = new CommonCodeView();
          commonCodeView.comm_Type = 0;
          commonCodeView.comm_TypeMemo = "-공통코드-";
          commonTypeList.Insert(0, commonCodeView);
        }
      }
      catch (Exception ex)
      {
        Log.Error(this.MenuInfo.Title + " 오류=" + ex.Message);
      }
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
      CommonCodeListPageVM commonCodeListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (commonCodeListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (commonCodeListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (commonCodeListPageVm.Container)).Set(__nonvirtual (commonCodeListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsAdmin;

    public async Task UploadExcelFileAsync()
    {
      CommonCodeListPageVM commonCodeListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (commonCodeListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (commonCodeListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (commonCodeListPageVm.Container)).Set(__nonvirtual (commonCodeListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task SearchAsync()
    {
      CommonCodeListPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          int commType = sender.Param.comm_Type;
          string useYn = sender.Param.UseYn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          int comm_Type = commType;
          string comm_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<CommonCodeView>> success = (await CommonCodeRestServer.GetCommonCodeList(sendType, siteId, code, 0, comm_Type, comm_UseYn: comm_UseYn, orderBy: 3, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<CommonCodeView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<CommonCodeView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<CommonCodeView>) success.response);
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
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (sender.MenuInfo).Title + " 오류=" + ex.Message);
      }
    }

    public bool CanDataOpen(CommonCodeView item) => item != null;

    public void DataOpen(CommonCodeView item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }

    public WpfCommand<CommonCodeView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<CommonCodeView>>((Func<WpfCommand<CommonCodeView>>) (() => new WpfCommand<CommonCodeView>().AutoRefreshOn<WpfCommand<CommonCodeView>>().ApplyCanExecute<CommonCodeView>(new Func<CommonCodeView, bool>(this.CanDataOpen)).ApplyExecute<CommonCodeView>(new Action<CommonCodeView>(this.DataOpen))), nameof (CmdDataOpen));

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      CommonCodeListPageVM commonCodeListPageVm = this;
      if (!commonCodeListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str1 = __nonvirtual (commonCodeListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (commonCodeListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      bool? use = commonCodeListPageVm.ParamBackup.Use;
      if (use.HasValue)
      {
        StringBuilder stringBuilder6 = stringBuilder5;
        use = commonCodeListPageVm.ParamBackup.Use;
        string str2 = "[" + (use.Value ? "사용" : "미사용") + "]";
        stringBuilder6.Append(str2);
        StringBuilder stringBuilder7 = stringBuilder2;
        use = commonCodeListPageVm.ParamBackup.Use;
        string str3 = "[" + (use.Value ? "사용" : "미사용") + "]";
        stringBuilder7.Append(str3);
      }
      bool flag = false;
      if (commonCodeListPageVm.ParamBackup.comm_Type > 0)
      {
        stringBuilder5.Append("[" + commonCodeListPageVm.ParamBackup.comm_TypeMemo + "]");
        if (flag)
          stringBuilder4.Append("/");
        stringBuilder4.Append("[" + commonCodeListPageVm.ParamBackup.comm_TypeMemo + "]");
      }
      string keyword = commonCodeListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder5.Append("[키워드:" + commonCodeListPageVm.ParamBackup.Keyword + "]");
        stringBuilder3.Append("[키워드:" + commonCodeListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (commonCodeListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (commonCodeListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Landscape;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (commonCodeListPageVm.MenuInfo).Title,
        Top1Left = stringBuilder1.ToString(),
        Top1Right = stringBuilder3.ToString(),
        Top2Left = stringBuilder2.ToString(),
        Top2Right = stringBuilder4.ToString(),
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (commonCodeListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (commonCodeListPageVm.App).User.User.Source.emp_Code, (object) str1),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (commonCodeListPageVm.MenuInfo).Code;
      int count = commonCodeListPageVm.Datas.Count;
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
        __nonvirtual (commonCodeListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
      CommonCodeListPageVM commonCodeListPageVm = this;
      if (!commonCodeListPageVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (commonCodeListPageVm.ParamBackup.Use.HasValue)
      {
        stringBuilder2.Append("[" + (commonCodeListPageVm.ParamBackup.Use.Value ? "사용" : "미사용") + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + (commonCodeListPageVm.ParamBackup.Use.Value ? "사용" : "미사용") + "]");
      }
      if (commonCodeListPageVm.ParamBackup.comm_Type > 0)
      {
        stringBuilder2.Append("[" + commonCodeListPageVm.ParamBackup.comm_TypeMemo + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + commonCodeListPageVm.ParamBackup.comm_TypeMemo + "]");
      }
      string keyword = commonCodeListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder2.Append("[키워드:" + commonCodeListPageVm.ParamBackup.Keyword + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + commonCodeListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (commonCodeListPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (commonCodeListPageVm.Exporter), __nonvirtual (commonCodeListPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (commonCodeListPageVm.MenuInfo).Code, applyRowCnt: commonCodeListPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (commonCodeListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<CommonCodeListPageVM.InitParam>
    {
      private bool? use = new bool?(true);
      private int _comm_Type;
      private string _comm_TypeMemo;

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

      public int comm_Type
      {
        get => this._comm_Type;
        set
        {
          this._comm_Type = value;
          this.Changed(nameof (comm_Type));
        }
      }

      public string comm_TypeMemo
      {
        get => this._comm_TypeMemo;
        set
        {
          this._comm_TypeMemo = value;
          this.NotifyOfPropertyChange(nameof (comm_TypeMemo));
        }
      }
    }

    public class SearchParam : ParamBase<CommonCodeListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string _Keyword;
      private int _comm_Type;
      private string _comm_TypeMemo;

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

      public int comm_Type
      {
        get => this._comm_Type;
        set
        {
          this._comm_Type = value;
          this.Changed(nameof (comm_Type));
        }
      }

      public string comm_TypeMemo
      {
        get => this._comm_TypeMemo;
        set
        {
          this._comm_TypeMemo = value;
          this.NotifyOfPropertyChange(nameof (comm_TypeMemo));
        }
      }
    }
  }
}
