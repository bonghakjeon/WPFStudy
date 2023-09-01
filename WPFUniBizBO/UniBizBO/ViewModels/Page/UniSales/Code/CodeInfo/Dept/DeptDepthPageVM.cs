// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Dept.DeptDepthPageVM
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
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBizBO.Composition;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Dept
{
  public class DeptDepthPageVM : 
    PageBase<
    #nullable disable
    DeptView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private DeptDepthPageVM.InitParam _InitControlParam = new DeptDepthPageVM.InitParam();
    private DeptDepthPageVM.SearchParam param = new DeptDepthPageVM.SearchParam();
    private string _FooterRemark = string.Empty;
    private DeptView _selectedLv1Datas;
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public DeptDepthPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public DeptDepthPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public DeptDepthPageVM.SearchParam ParamBackup { get; set; }

    public string FooterRemark
    {
      get => this._FooterRemark;
      set
      {
        this._FooterRemark = value;
        this.NotifyOfPropertyChange(nameof (FooterRemark));
      }
    }

    public BindableCollection<DeptView> Lv1Datas { get; } = new BindableCollection<DeptView>();

    public DeptView SelectedLv1Datas
    {
      get => this._selectedLv1Datas;
      set => this.SetAndNotify<DeptView>(ref this._selectedLv1Datas, value, nameof (SelectedLv1Datas));
    }

    public bool IsDept { get; set; } = true;

    public IUniDataGridViewer GridViewerLv1 { get; set; }

    public IUniDataGridViewer GridViewerLv2 { get; set; }

    public IUniDataGridViewer GridViewerLv3 { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public DeptDepthPageVM(IContainer container)
      : base(container)
    {
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType) => !funcType.Equals((object) DefaultPageFunc.ExportExcel) || this.CanExcel();

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await this.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        this.CreateCode();
      if (!funcType.Equals((object) DefaultPageFunc.ExportExcel))
        return;
      this.IsOpenExcelPopup = true;
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
      if (this.App.User.User.Source.IsPermitExcel)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      else if (this.App.User.User.Source.IsMasterCommonSave)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      DeptDepthPageVM deptDepthPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await deptDepthPageVm.\u003C\u003En__1(p_param);
      deptDepthPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected void InitControl()
    {
      if (!this.InitControlParam.Use.HasValue)
        this.InitControlParam.Use = new bool?(true);
      this.Param.Use = this.InitControlParam.Use;
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<DeptDepthPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam() => this.InitControlParam.Use = this.Param.Use;

    public void CreateCode()
    {
      PageDeptPartConVM viewModel = this.Container.Get<PageDeptPartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) null;
      viewModel.SavedAsync = (Func<PageDeptPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public bool CanExcel() => this.App.User.User.Source.IsPermitExcel && this.GridViewerLv1 != null;

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
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsMasterCommonSave;

    public async Task UploadExcelFileAsync()
    {
    }

    public async Task SearchAsync()
    {
      DeptDepthPageVM deptDepthPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (deptDepthPageVm.Job).CreateJob(__nonvirtual (deptDepthPageVm.MenuInfo).Title + " 검색", (string) null))
        {
          deptDepthPageVm.Datas.Clear();
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<DeptLevel> success = (await DeptRestServer.GetDeptDepth(deptDepthPageVm.LogInPackInfo.sendType, deptDepthPageVm.LogInPackInfo.siteID, __nonvirtual (deptDepthPageVm.MenuInfo).Code, 0, deptDepthPageVm.Param.UseYn, deptDepthPageVm.Param.Keyword).ExecuteToReturnAsync<UbRes<DeptLevel>>((UniBizHttpClient) __nonvirtual (deptDepthPageVm.App).Api)).GetSuccess<UbRes<DeptLevel>>();
          deptDepthPageVm.Datas.AddRange((IEnumerable<DeptView>) success.response.Items);
          deptDepthPageVm.SetParamBackup();
          DeptLevel response = success.response;
          deptDepthPageVm.Lv1Datas.Clear();
          deptDepthPageVm.Lv1Datas.AddRange((IEnumerable<DeptView>) response.Items);
          if (deptDepthPageVm.Lv1Datas.Count > 0)
            deptDepthPageVm.FooterRemark = "[" + success.response.Count.ToString("n0") + "] 건 조회";
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (deptDepthPageVm.Container)).Set(__nonvirtual (deptDepthPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanDataDbClick(DeptView item) => item != null;

    public void DataDbClick(DeptView item) => this.IsDept = true;

    public WpfCommand<DeptView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public void DataOpen(DeptView item)
    {
      if (item == null)
        return;
      this.IsDept = false;
      PageDeptPartConVM viewModel = this.Container.Get<PageDeptPartConVM>();
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageDeptPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public void LvDataDbClick(DeptView item)
    {
      this.IsDept = false;
      this.SelectedData = item;
      this.OnInq();
    }

    public WpfCommand<DeptView> CmdLvDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.LvDataDbClick))), nameof (CmdLvDataDbClick));

    public void Lv2DataDbClick(DeptView item)
    {
      this.IsDept = false;
      this.SelectedData = item;
      this.OnInq();
    }

    public WpfCommand<DeptView> CmdLv2DataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.Lv2DataDbClick))), nameof (CmdLv2DataDbClick));

    public void Lv3DataDbClick(DeptView item)
    {
      this.IsDept = false;
      this.SelectedData = item;
      this.OnInq();
    }

    public WpfCommand<DeptView> CmdLv3DataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.Lv3DataDbClick))), nameof (CmdLv3DataDbClick));

    public void OnInq()
    {
      if (this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 31)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageDeptPartConVM viewModel = this.Container.Get<PageDeptPartConVM>();
      viewModel.WorkDataKeys = new object[1]
      {
        (object) this.SelectedData.dpt_ID
      };
      viewModel.SavedAsync = (Func<PageDeptPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      DeptDepthPageVM deptDepthPageVm = this;
      if (!deptDepthPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (deptDepthPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (deptDepthPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = deptDepthPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = deptDepthPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + deptDepthPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + deptDepthPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (deptDepthPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (deptDepthPageVm.Duplicator));
      creater.Orientation = PageOrientation.Portrait;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (deptDepthPageVm.MenuInfo).Title,
        Top1Left = string.Empty,
        Top1Right = string.Empty,
        Top2Left = stringBuilder1.ToString(),
        Top2Right = string.Empty,
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (deptDepthPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (deptDepthPageVm.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (deptDepthPageVm.MenuInfo).Code;
      int count = deptDepthPageVm.Datas.Count;
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
        __nonvirtual (deptDepthPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
      DeptDepthPageVM deptDepthPageVm = this;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = deptDepthPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = deptDepthPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + deptDepthPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + deptDepthPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (deptDepthPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (deptDepthPageVm.Exporter), __nonvirtual (deptDepthPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (deptDepthPageVm.MenuInfo).Code, applyRowCnt: deptDepthPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (deptDepthPageVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<DeptDepthPageVM.InitParam>
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

    public class SearchParam : ParamBase<DeptDepthPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private DateTime _DtDate = DateTime.Now;
      private string _dpt_ViewCode;
      private string _dpt_DeptName;
      private string _Keyword;

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

      public DateTime DtDate
      {
        get => this._DtDate;
        set
        {
          this._DtDate = value;
          this.NotifyOfPropertyChange(nameof (DtDate));
        }
      }

      public string dpt_ViewCode
      {
        get => this._dpt_ViewCode;
        set
        {
          this._dpt_ViewCode = value;
          this.NotifyOfPropertyChange(nameof (dpt_ViewCode));
        }
      }

      public string dpt_DeptName
      {
        get => this._dpt_DeptName;
        set
        {
          this._dpt_DeptName = value;
          this.NotifyOfPropertyChange(nameof (dpt_DeptName));
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
    }
  }
}
