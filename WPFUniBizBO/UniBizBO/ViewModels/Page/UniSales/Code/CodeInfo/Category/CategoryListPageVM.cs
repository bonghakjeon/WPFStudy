// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Category.CategoryListPageVM
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.CommonCode;
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
namespace UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Category
{
  public class CategoryListPageVM : 
    PageBase<
    #nullable disable
    CategoryView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private CategoryListPageVM.InitParam _InitControlParam = new CategoryListPageVM.InitParam();
    private CategoryListPageVM.SearchParam param = new CategoryListPageVM.SearchParam();
    private string _FooterRemark = string.Empty;
    private Hashtable _SearchCategoryContion = new Hashtable();
    private IList<CommonCodeView> _CtgDepthList;
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public CategoryListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public CategoryListPageVM.SearchParam Param
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

    public CategoryListPageVM.SearchParam ParamBackup { get; set; } = new CategoryListPageVM.SearchParam();

    public string FooterRemark
    {
      get => this._FooterRemark;
      set
      {
        this._FooterRemark = value;
        this.NotifyOfPropertyChange(nameof (FooterRemark));
      }
    }

    public Hashtable SearchCategoryContion
    {
      get => this._SearchCategoryContion;
      set
      {
        this._SearchCategoryContion = value;
        this.NotifyOfPropertyChange(nameof (SearchCategoryContion));
      }
    }

    public IList<CommonCodeView> CtgDepthList
    {
      get => this._CtgDepthList;
      set
      {
        this._CtgDepthList = value;
        this.NotifyOfPropertyChange(nameof (CtgDepthList));
      }
    }

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public CategoryListPageVM(StyletIoC.IContainer container)
      : base(container)
    {
      this.CtgDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth].ToArray<CommonCodeView>();
      this.Param.CtgDepth = this.CtgDepthList[3];
      this.SearchCategoryContion.Add((object) "CtgDepth", (object) this.Param.CtgDepth);
      this.SearchCategoryContion.Add((object) "dt_date", (object) this.Param.DtDate);
      this.Param.PropertyChanged += new PropertyChangedEventHandler(this.Param_PropertyChanged);
    }

    private void Param_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case "CtgDepth":
          if (!(sender is CategoryListPageVM.SearchParam searchParam1))
            break;
          searchParam1.Action<CategoryListPageVM.SearchParam>((Action<CategoryListPageVM.SearchParam>) (p =>
          {
            if (this.SearchCategoryContion.ContainsKey((object) "CtgDepth"))
              this.SearchCategoryContion[(object) "CtgDepth"] = (object) p.CtgDepth;
            else
              this.SearchCategoryContion.Add((object) "CtgDepth", (object) p.CtgDepth);
          }));
          break;
        case "DtDate":
          if (!(sender is CategoryListPageVM.SearchParam searchParam2))
            break;
          searchParam2.Action<CategoryListPageVM.SearchParam>((Action<CategoryListPageVM.SearchParam>) (p =>
          {
            if (this.SearchCategoryContion.ContainsKey((object) "dt_date"))
              this.SearchCategoryContion[(object) "dt_date"] = (object) p.DtDate;
            else
              this.SearchCategoryContion.Add((object) "dt_date", (object) p.DtDate);
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
      this.ParamBackup = ParamBase<CategoryListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
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
      if (!this.CanCreateCode() || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 34)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageCategoryPartConVM viewModel = this.Container.Get<PageCategoryPartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) null;
      viewModel.SavedAsync = (Func<PageCategoryPartConVM, Task>) (async con => await Task.Yield());
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
      CategoryListPageVM categoryListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (categoryListPageVm.Job).CreateJob(__nonvirtual (categoryListPageVm.MenuInfo).Title + " 검색", (string) null))
        {
          categoryListPageVm.Datas.Clear();
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<IList<CategoryView>> success = (await CategoryRestServer.GetCategoryList(categoryListPageVm.LogInPackInfo.sendType, categoryListPageVm.LogInPackInfo.siteID, __nonvirtual (categoryListPageVm.MenuInfo).Code, 0, ctg_UseYn: categoryListPageVm.Param.UseYn, ctg_Depth: categoryListPageVm.Param.CtgDepth.comm_TypeNo, KeyWord: categoryListPageVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<CategoryView>>>((UniBizHttpClient) __nonvirtual (categoryListPageVm.App).Api)).GetSuccess<UbRes<IList<CategoryView>>>();
          categoryListPageVm.Datas.AddRange((IEnumerable<CategoryView>) success.response);
          if (categoryListPageVm.Datas.Count > 0)
            categoryListPageVm.FooterRemark = "[" + success.response.Count.ToString("n0") + "] 건 조회";
          categoryListPageVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (categoryListPageVm.Container)).Set(__nonvirtual (categoryListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanDataOpen(CategoryView item) => item != null;

    public void DataOpen(CategoryView item)
    {
      if (item == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == item.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageCategoryPartConVM viewModel = this.Container.Get<PageCategoryPartConVM>();
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageCategoryPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public WpfCommand<CategoryView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<CategoryView>>((Func<WpfCommand<CategoryView>>) (() => new WpfCommand<CategoryView>().AutoRefreshOn<WpfCommand<CategoryView>>().ApplyCanExecute<CategoryView>(new Func<CategoryView, bool>(this.CanDataOpen)).ApplyExecute<CategoryView>(new Action<CategoryView>(this.DataOpen))), nameof (CmdDataOpen));

    public WpfCommand<(object, object)> CmdColumnDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<(object, object)>>((Func<WpfCommand<(object, object)>>) (() => new WpfCommand<(object, object)>().ApplyExecute<(object, object)>(new Action<(object, object)>(this.NextTabColume))), nameof (CmdColumnDataOpen));

    public void NextTabColume((object, object) x)
    {
      CategoryView rowData = (CategoryView) x.Item1;
      string str = x.Item2 == null ? string.Empty : x.Item2.ToString();
      if (this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == rowData.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      int num;
      switch (str)
      {
        case "ctg_lv1":
          num = rowData.ctg_lv1_ID;
          break;
        case "ctg_lv2":
          num = rowData.ctg_lv2_ID;
          break;
        default:
          num = rowData.ctg_ID;
          break;
      }
      PageCategoryPartConVM viewModel = this.Container.Get<PageCategoryPartConVM>();
      viewModel.WorkDataKeys = new object[1]{ (object) num };
      viewModel.SavedAsync = (Func<PageCategoryPartConVM, Task>) (async con => await Task.Yield());
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
      CategoryListPageVM categoryListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await categoryListPageVm.\u003C\u003En__1(p_param);
      categoryListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
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
      CategoryListPageVM categoryListPageVm = this;
      if (!categoryListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (categoryListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (categoryListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = categoryListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      string keyword = categoryListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + categoryListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + categoryListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (categoryListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (categoryListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Portrait;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (categoryListPageVm.MenuInfo).Title,
        Top1Left = string.Empty,
        Top1Right = string.Empty,
        Top2Left = stringBuilder1.ToString(),
        Top2Right = string.Empty,
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (categoryListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (categoryListPageVm.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (categoryListPageVm.MenuInfo).Code;
      int count = categoryListPageVm.Datas.Count;
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
        __nonvirtual (categoryListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
    }

    public class InitParam : ParamBase<CategoryListPageVM.InitParam>
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

    public class SearchParam : ParamBase<CategoryListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private int _ExpandsCount = 2;
      private DateTime _DtDate = DateTime.Now;
      private string _dpt_ViewCode;
      private string _dpt_DeptName;
      private string _Keyword;
      private CategoryView _ChkCategory;
      private IList<CategoryView> _ChkCategoryList;
      private CommonCodeView _CtgDepth;

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

      public CategoryView ChkCategory
      {
        get => this._ChkCategory;
        set
        {
          this._ChkCategory = value;
          this.NotifyOfPropertyChange(nameof (ChkCategory));
        }
      }

      public IList<CategoryView> ChkCategoryList
      {
        get => this._ChkCategoryList;
        set
        {
          this._ChkCategoryList = value;
          this.NotifyOfPropertyChange(nameof (ChkCategoryList));
        }
      }

      public CommonCodeView CtgDepth
      {
        get => this._CtgDepth;
        set
        {
          this._CtgDepth = value;
          this.NotifyOfPropertyChange(nameof (CtgDepth));
        }
      }
    }
  }
}
