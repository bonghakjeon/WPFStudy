// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType.RegTypePageBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
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
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType
{
  [HiddenVm]
  public class RegTypePageBase<T> : PageBase<
  #nullable disable
  T>, IPrintElementDocumentVM, IExportUniDataGridVM
  {
    private RegTypePageBase<T>.InitParam _InitControlParam = new RegTypePageBase<T>.InitParam();
    private RegTypePageBase<T>.SearchParam param = new RegTypePageBase<T>.SearchParam();
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public RegTypePageBase<T>.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public RegTypePageBase<T>.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public RegTypePageBase<T>.SearchParam ParamBackup { get; set; } = new RegTypePageBase<T>.SearchParam();

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public RegTypePageBase(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      RegTypePageBase<T> regTypePageBase = this;
      // ISSUE: reference to a compiler-generated method
      regTypePageBase.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await regTypePageBase.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await regTypePageBase.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await regTypePageBase.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (regTypePageBase.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
        regTypePageBase.IsOpenExcelPopup = true;
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      regTypePageBase.CloseItem();
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
      if (this.App.User.User.Source.IsMemberTypeSave)
        defaultPageFuncList.Add(DefaultPageFunc.Create);
      if (this.App.User.User.Source.IsPermitPrint)
        defaultPageFuncList.Add(DefaultPageFunc.Print);
      if (this.App.User.User.Source.IsPermitExcel)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      defaultPageFuncList.Add(DefaultPageFunc.Close);
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected virtual void InitControl()
    {
      this.Param.Use = this.InitControlParam.Use;
      this.Param.IsDate = this.InitControlParam.IsDate;
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<RegTypePageBase<T>.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.IsDate = this.Param.IsDate;
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      RegTypePageBase<T> regTypePageBase = this;
      // ISSUE: reference to a compiler-generated method
      await regTypePageBase.\u003C\u003En__1(p_param);
      regTypePageBase.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsMemberTypeSave;

    public virtual async Task CreateAsync()
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

    public bool CanDownloadExcelSample() => this.App.User.User.Source.IsMemberTypeSave;

    public async Task DownloadExcelSampleAsync()
    {
      RegTypePageBase<T> regTypePageBase = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (regTypePageBase.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (regTypePageBase.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (regTypePageBase.Container)).Set(__nonvirtual (regTypePageBase.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsMemberTypeSave;

    public async Task UploadExcelFileAsync()
    {
      RegTypePageBase<T> regTypePageBase = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (regTypePageBase.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (regTypePageBase.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (regTypePageBase.Container)).Set(__nonvirtual (regTypePageBase.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public virtual async Task SearchAsync() => await Task.Yield();

    public override async Task OnReceiveParamAsync(
      IPage sender,
      ParamBase param,
      IDictionary<string, object> arg = null)
    {
      await base.OnReceiveParamAsync(sender, param, arg);
      this.Param = ParamBase<RegTypePageBase<T>.SearchParam>.Create(param, arg);
      this.Param.Keyword = (string) null;
      await this.SearchAsync();
    }

    public virtual bool CanDataOpen(T item) => (object) item != null;

    public virtual async void DataOpen(T item)
    {
      RegTypePageBase<T> sender = this;
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      // ISSUE: explicit non-virtual call
      await __nonvirtual (sender.SendParamAfterPageAsync((IPage) sender, (ParamBase) sender.Param, (IDictionary<string, object>) dictionary));
    }

    public WpfCommand<T> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<T>>((Func<WpfCommand<T>>) (() => new WpfCommand<T>().AutoRefreshOn<WpfCommand<T>>().ApplyCanExecute<T>(new Func<T, bool>(this.CanDataOpen)).ApplyExecute<T>(new Action<T>(this.DataOpen))), nameof (CmdDataOpen));

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      RegTypePageBase<T> regTypePageBase = this;
      if (!regTypePageBase.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str1 = __nonvirtual (regTypePageBase.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (regTypePageBase.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      bool? use = regTypePageBase.ParamBackup.Use;
      if (use.HasValue)
      {
        StringBuilder stringBuilder6 = stringBuilder5;
        use = regTypePageBase.ParamBackup.Use;
        string str2 = "[" + (use.Value ? "사용" : "미사용") + "]";
        stringBuilder6.Append(str2);
        StringBuilder stringBuilder7 = stringBuilder2;
        use = regTypePageBase.ParamBackup.Use;
        string str3 = "[" + (use.Value ? "사용" : "미사용") + "]";
        stringBuilder7.Append(str3);
      }
      if (regTypePageBase.ParamBackup.IsDate)
      {
        stringBuilder5.Append("[" + new DateTime?(regTypePageBase.Param.DtDate).GetDateToStr("yyMMdd") + "]");
        stringBuilder2.Append("조회:" + new DateTime?(regTypePageBase.Param.DtDate).GetDateToStr("yyyy-MM-dd"));
        stringBuilder2.Append('\n');
      }
      string keyword = regTypePageBase.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder5.Append("[키워드:" + regTypePageBase.ParamBackup.Keyword + "]");
        stringBuilder3.Append("[키워드:" + regTypePageBase.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (regTypePageBase.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (regTypePageBase.Duplicator));
      creater.Orientation = PageOrientation.Landscape;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (regTypePageBase.MenuInfo).Title,
        Top1Left = stringBuilder1.ToString(),
        Top1Right = stringBuilder3.ToString(),
        Top2Left = stringBuilder2.ToString(),
        Top2Right = stringBuilder4.ToString(),
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (regTypePageBase.App).User.User.Source.emp_Name, (object) __nonvirtual (regTypePageBase.App).User.User.Source.emp_Code, (object) str1),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (regTypePageBase.MenuInfo).Code;
      int count = regTypePageBase.Datas.Count;
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
        __nonvirtual (regTypePageBase.WindowManager)?.ShowDialog((object) viewModel);
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
      RegTypePageBase<T> regTypePageBase = this;
      if (!regTypePageBase.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (regTypePageBase.ParamBackup.Use.HasValue)
      {
        stringBuilder2.Append("[" + (regTypePageBase.ParamBackup.Use.Value ? "사용" : "미사용") + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + (regTypePageBase.ParamBackup.Use.Value ? "사용" : "미사용") + "]");
      }
      if (regTypePageBase.ParamBackup.IsDate)
      {
        stringBuilder2.Append("[" + new DateTime?(regTypePageBase.Param.DtDate).GetDateToStr("yyMMdd") + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("조회:" + new DateTime?(regTypePageBase.Param.DtDate).GetDateToStr("yyyy-MM-dd"));
      }
      string keyword = regTypePageBase.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder2.Append("[키워드:" + regTypePageBase.ParamBackup.Keyword + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + regTypePageBase.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (regTypePageBase.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (regTypePageBase.Exporter), __nonvirtual (regTypePageBase.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (regTypePageBase.MenuInfo).Code, applyRowCnt: regTypePageBase.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (regTypePageBase.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<RegTypePageBase<T>.InitParam>
    {
      private bool? use = new bool?(true);
      private bool _IsDate = true;

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

      public bool IsDate
      {
        get => this._IsDate;
        set
        {
          this._IsDate = value;
          this.NotifyOfPropertyChange(nameof (IsDate));
        }
      }
    }

    public class SearchParam : ParamBase<RegTypePageBase<T>.SearchParam>
    {
      private bool? use = new bool?(true);
      private string _Keyword;
      private bool _IsDate = true;
      private DateTime _DtDate = DateTime.Now;

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

      public bool IsDate
      {
        get => this._IsDate;
        set
        {
          this._IsDate = value;
          this.NotifyOfPropertyChange(nameof (IsDate));
        }
      }

      public DateTime DtDate
      {
        get => this._DtDate;
        set
        {
          this._DtDate = value;
          this.NotifyOfPropertyChange(nameof (DtDate));
        }
      }
    }
  }
}
