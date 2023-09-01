// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Dept.DeptListPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
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
  public class DeptListPageVM : 
    PageBase<
    #nullable disable
    DeptView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private DeptListPageVM.InitParam _InitControlParam = new DeptListPageVM.InitParam();
    private DeptListPageVM.SearchParam param = new DeptListPageVM.SearchParam();
    private string _FooterRemark = string.Empty;
    private Hashtable _SearchDeptContion = new Hashtable();
    private IList<CommonCodeView> _DptDepthList;
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public DeptListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public DeptListPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        if (this.param != null)
          this.param.PropertyChanged -= new PropertyChangedEventHandler(this.Param_PropertyChanged);
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
        if (this.param == null)
          return;
        this.param.PropertyChanged += new PropertyChangedEventHandler(this.Param_PropertyChanged);
      }
    }

    public DeptListPageVM.SearchParam ParamBackup { get; set; } = new DeptListPageVM.SearchParam();

    public string FooterRemark
    {
      get => this._FooterRemark;
      set
      {
        this._FooterRemark = value;
        this.NotifyOfPropertyChange(nameof (FooterRemark));
      }
    }

    public Hashtable SearchDeptContion
    {
      get => this._SearchDeptContion;
      set
      {
        this._SearchDeptContion = value;
        this.NotifyOfPropertyChange(nameof (SearchDeptContion));
      }
    }

    public IList<CommonCodeView> DptDepthList
    {
      get => this._DptDepthList;
      set
      {
        this._DptDepthList = value;
        this.NotifyOfPropertyChange(nameof (DptDepthList));
      }
    }

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public DeptListPageVM(StyletIoC.IContainer container)
      : base(container)
    {
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) new DefaultPageFunc[1]
      {
        DefaultPageFunc.Search
      };
      this.DptDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.DeptDepth].ToArray<CommonCodeView>();
      this.Param.DptDepth = this.App.Sys.CommonCodes[CommonCodeTypes.DeptDepth][3];
      this.SearchDeptContion.Add((object) "DptDepth", (object) this.Param.DptDepth);
      this.SearchDeptContion.Add((object) "dt_date", (object) this.Param.DtDate);
      this.Param.PropertyChanged += new PropertyChangedEventHandler(this.Param_PropertyChanged);
    }

    private void Param_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case "DptDepth":
          if (!(sender is DeptListPageVM.SearchParam searchParam1))
            break;
          searchParam1.Action<DeptListPageVM.SearchParam>((Action<DeptListPageVM.SearchParam>) (p =>
          {
            if (this.SearchDeptContion.ContainsKey((object) "DptDepth"))
              this.SearchDeptContion[(object) "DptDepth"] = (object) p.DptDepth;
            else
              this.SearchDeptContion.Add((object) "DptDepth", (object) p.DptDepth);
          }));
          break;
        case "DtDate":
          if (!(sender is DeptListPageVM.SearchParam searchParam2))
            break;
          searchParam2.Action<DeptListPageVM.SearchParam>((Action<DeptListPageVM.SearchParam>) (p =>
          {
            if (this.SearchDeptContion.ContainsKey((object) "dt_date"))
              this.SearchDeptContion[(object) "dt_date"] = (object) p.DtDate;
            else
              this.SearchDeptContion.Add((object) "dt_date", (object) p.DtDate);
          }));
          break;
      }
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await this.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        this.CreateCode();
      if (funcType.Equals((object) DefaultPageFunc.Print))
        await this.PrintDocumentAsync();
      if (!funcType.Equals((object) DefaultPageFunc.ExportExcel))
        return;
      this.IsOpenExcelPopup = true;
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType)
    {
      if (funcType.Equals((object) DefaultPageFunc.Create))
        this.CanCreateCode();
      if (funcType.Equals((object) DefaultPageFunc.Print))
        return this.CanPrintDocument();
      return !funcType.Equals((object) DefaultPageFunc.ExportExcel) || this.CanExcel();
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
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl()
    {
      if (!this.InitControlParam.Use.HasValue)
        this.InitControlParam.Use = new bool?(true);
      this.Param.Use = this.InitControlParam.Use;
      this.Param.ExpandsCount = this.InitControlParam.ExpandsCount;
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<DeptListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.ExpandsCount = this.Param.ExpandsCount;
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsMasterCommonSave;

    public void CreateCode()
    {
      if (!this.CanCreateCode() || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 31)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageDeptPartConVM viewModel = this.Container.Get<PageDeptPartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) null;
      viewModel.SavedAsync = (Func<PageDeptPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public bool CanExcel() => this.App.User.User.Source.IsPermitExcel && this.GridViewer != null;

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
      DeptListPageVM deptListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (deptListPageVm.Job).CreateJob(__nonvirtual (deptListPageVm.MenuInfo).Title + " 검색", (string) null))
        {
          deptListPageVm.Datas.Clear();
          StringBuilder stringBuilder = new StringBuilder();
          if (deptListPageVm.Param.ChkDeptList != null)
          {
            foreach (DeptView chkDept in (IEnumerable<DeptView>) deptListPageVm.Param.ChkDeptList)
              stringBuilder.Append(chkDept.dpt_ViewCode).Append(",");
          }
          if (stringBuilder.Length > 1)
            --stringBuilder.Length;
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<IList<DeptView>> success = (await DeptRestServer.GetDeptList(deptListPageVm.LogInPackInfo.sendType, deptListPageVm.LogInPackInfo.siteID, __nonvirtual (deptListPageVm.MenuInfo).Code, 0, dpt_UseYn: deptListPageVm.Param.UseYn, dpt_Depth: deptListPageVm.Param.DptDepth.comm_TypeNo, KeyWord: deptListPageVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<DeptView>>>((UniBizHttpClient) __nonvirtual (deptListPageVm.App).Api)).GetSuccess<UbRes<IList<DeptView>>>();
          deptListPageVm.Datas.AddRange((IEnumerable<DeptView>) success.response);
          if (deptListPageVm.Datas.Count > 0)
            deptListPageVm.FooterRemark = "[" + success.response.Count.ToString("n0") + "] 건 조회";
          deptListPageVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (deptListPageVm.Container)).Set(__nonvirtual (deptListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanDataOpen(DeptView item) => item != null;

    public void DataOpen(DeptView item)
    {
      if (item == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == item.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageDeptPartConVM viewModel = this.Container.Get<PageDeptPartConVM>();
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageDeptPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public WpfCommand<DeptView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataOpen)).ApplyExecute<DeptView>(new Action<DeptView>(this.DataOpen))), nameof (CmdDataOpen));

    public WpfCommand<(object, object)> CmdColumnDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<(object, object)>>((Func<WpfCommand<(object, object)>>) (() => new WpfCommand<(object, object)>().ApplyExecute<(object, object)>(new Action<(object, object)>(this.NextTabColume))), nameof (CmdColumnDataOpen));

    public void NextTabColume((object, object) x)
    {
      DeptView rowData = (DeptView) x.Item1;
      string str = x.Item2 == null ? string.Empty : x.Item2.ToString();
      if (rowData == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == rowData.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      int num;
      switch (str)
      {
        case "dpt_lv1":
          num = rowData.dpt_lv1_ID;
          break;
        case "dpt_lv2":
          num = rowData.dpt_lv2_ID;
          break;
        default:
          num = rowData.dpt_ID;
          break;
      }
      if (num == 0)
        return;
      PageDeptPartConVM viewModel = this.Container.Get<PageDeptPartConVM>();
      viewModel.WorkDataKeys = new object[1]{ (object) num };
      viewModel.SavedAsync = (Func<PageDeptPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    private async Task OnKeyEnterAsync() => await this.SearchAsync();

    public WpfCommand CmdTextEnter => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        ExecuteAction = (Action<object>) (_ => await this.OnKeyEnterAsync())
      };
    }), nameof (CmdTextEnter));

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      DeptListPageVM deptListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await deptListPageVm.\u003C\u003En__1(p_param);
      deptListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    private void OnKeyDown()
    {
    }

    public WpfCommand CmdTextKeyDown => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        ExecuteAction = (Action<object>) (_ => this.OnKeyDown())
      };
    }), nameof (CmdTextKeyDown));

    protected void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
      object originalSource = e.OriginalSource;
      Key key = e.Key;
      if (key != 6)
      {
        if (key != 18)
          return;
        Log.Debug(" Space .");
      }
      else
        Log.Debug(" Enter .");
    }

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      DeptListPageVM deptListPageVm = this;
      if (!deptListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (deptListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (deptListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = deptListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = deptListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + deptListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + deptListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (deptListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (deptListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Portrait;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (deptListPageVm.MenuInfo).Title,
        Top1Left = string.Empty,
        Top1Right = string.Empty,
        Top2Left = stringBuilder1.ToString(),
        Top2Right = string.Empty,
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (deptListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (deptListPageVm.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (deptListPageVm.MenuInfo).Code;
      int count = deptListPageVm.Datas.Count;
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
        __nonvirtual (deptListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
      DeptListPageVM deptListPageVm = this;
      if (!deptListPageVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = deptListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = deptListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + deptListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + deptListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (deptListPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (deptListPageVm.Exporter), __nonvirtual (deptListPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (deptListPageVm.MenuInfo).Code, applyRowCnt: deptListPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (deptListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<DeptListPageVM.InitParam>
    {
      private bool? use = new bool?(true);
      private int _ExpandsCount = 2;

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

      public int ExpandsCount
      {
        get => this._ExpandsCount;
        set
        {
          this._ExpandsCount = value;
          this.NotifyOfPropertyChange(nameof (ExpandsCount));
        }
      }
    }

    public class SearchParam : ParamBase<DeptListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private int _ExpandsCount = 2;
      private DateTime _DtDate = DateTime.Now;
      private string _dpt_ViewCode;
      private string _dpt_DeptName;
      private string _Keyword;
      private DeptView _ChkDept;
      private IList<DeptView> _ChkDeptList;
      private CommonCodeView _DptDepth;

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

      public int ExpandsCount
      {
        get => this._ExpandsCount;
        set
        {
          this._ExpandsCount = value;
          this.NotifyOfPropertyChange(nameof (ExpandsCount));
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

      public DeptView ChkDept
      {
        get => this._ChkDept;
        set
        {
          this._ChkDept = value;
          this.NotifyOfPropertyChange(nameof (ChkDept));
        }
      }

      public IList<DeptView> ChkDeptList
      {
        get => this._ChkDeptList;
        set
        {
          this._ChkDeptList = value;
          this.NotifyOfPropertyChange(nameof (ChkDeptList));
        }
      }

      public CommonCodeView DptDepth
      {
        get => this._DptDepth;
        set
        {
          this._DptDepth = value;
          this.NotifyOfPropertyChange(nameof (DptDepth));
        }
      }
    }
  }
}
