// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Supplier.SupplierListPageVM
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
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Composition;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers.Code.Supplier;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Supplier
{
  public class SupplierListPageVM : 
    PageBase<
    #nullable disable
    SupplierView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private SupplierListPageVM.InitParam _InitControlParam = new SupplierListPageVM.InitParam();
    private SupplierListPageVM.SearchParam _Param = new SupplierListPageVM.SearchParam();
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public SupplierListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public SupplierListPageVM.SearchParam Param
    {
      get => this._Param;
      set
      {
        this._Param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public SupplierListPageVM.SearchParam ParamBackup { get; set; } = new SupplierListPageVM.SearchParam();

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public SupplierListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      SupplierListPageVM supplierListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      supplierListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await supplierListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await supplierListPageVm.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await supplierListPageVm.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (supplierListPageVm.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
        supplierListPageVm.IsOpenExcelPopup = true;
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      supplierListPageVm.CloseItem();
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType)
    {
      if (funcType.Equals((object) DefaultPageFunc.Create))
        return this.CanCreateCode();
      if (funcType.Equals((object) DefaultPageFunc.Print))
        return this.CanPrintDocument();
      return funcType.Equals((object) DefaultPageFunc.ExportExcel) ? this.CanExcel() : base.OnQueryCanDefaultFunc(funcType);
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
      if (this.App.User.User.Source.IsSupplierSave)
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
      this.Param.SupplierType = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierType][this.InitControlParam.Supplier_TypeNo];
      this.Param.SupplierKind = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierKind][this.InitControlParam.Supplier_KindNo];
      this.Param.StdPreTax = this.App.Sys.CommonCodes[CommonCodeTypes.StdPreTax][this.InitControlParam.StdPreTaxNo];
      this.Param.SupplierMulti = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierMulti][this.InitControlParam.Supplier_MultiNo];
      this.InitCategoryViews();
    }

    protected virtual void InitCategoryViews()
    {
      if (this.DataView.CategoryViews.Count != 0)
        return;
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "SU1_HeadInfo",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "TypeInfo",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "E1_TelInfo",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "SU1_BizInfo",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "E1_AddrInfo",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "SU1_TagInfo",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "BankInfo",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "Memo",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "E1_Email",
        IsDisplay = false
      });
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<SupplierListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.Supplier_TypeNo = this.Param.SupplierType.comm_TypeNo;
      this.InitControlParam.Supplier_KindNo = this.Param.SupplierKind.comm_TypeNo;
      this.InitControlParam.StdPreTaxNo = this.Param.StdPreTax.comm_TypeNo;
      this.InitControlParam.Supplier_MultiNo = this.Param.SupplierMulti.comm_TypeNo;
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      SupplierListPageVM supplierListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await supplierListPageVm.\u003C\u003En__1(p_param);
      supplierListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsSupplierSave;

    public async Task CreateAsync()
    {
      SupplierListPageVM supplierListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!supplierListPageVm.CanCreateCode() || __nonvirtual (supplierListPageVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 22)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageSupplierPartConVM viewModel = __nonvirtual (supplierListPageVm.Container).Get<PageSupplierPartConVM>();
        // ISSUE: explicit non-virtual call
        __nonvirtual (supplierListPageVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierListPageVm.Container)).Set(__nonvirtual (supplierListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
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

    public bool CanDownloadExcelSample() => this.App.User.User.Source.IsSupplierSave;

    public async Task DownloadExcelSampleAsync()
    {
      SupplierListPageVM supplierListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (supplierListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierListPageVm.Container)).Set(__nonvirtual (supplierListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsSupplierSave;

    public async Task UploadExcelFileAsync()
    {
      SupplierListPageVM supplierListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (supplierListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierListPageVm.Container)).Set(__nonvirtual (supplierListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand CmdUploadExcelFileSocket => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        CanDisplayFunc = (Func<object, bool>) (_ => this.CanUploadExcelFileSocket()),
        ExecuteAction = (Action<object>) (_ => this.UploadExcelFileSocket())
      };
    }), nameof (CmdUploadExcelFileSocket));

    public bool CanUploadExcelFileSocket() => this.App.User.User.Source.IsSupplierSave;

    public void UploadExcelFileSocket()
    {
      try
      {
        int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        Log.Error(this.MenuInfo.Title + " 오류=" + ex.Message);
        int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task SearchAsync()
    {
      SupplierListPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          int commTypeNo1 = sender.Param.SupplierType.comm_TypeNo;
          int commTypeNo2 = sender.Param.SupplierKind.comm_TypeNo;
          int commTypeNo3 = sender.Param.StdPreTax.comm_TypeNo;
          int commTypeNo4 = sender.Param.SupplierMulti.comm_TypeNo;
          string useYn = sender.Param.UseYn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          int su_SupplierType = commTypeNo1;
          int su_SupplierKind = commTypeNo2;
          int su_PreTaxDiv = commTypeNo3;
          int su_MultiSuplierDiv = commTypeNo4;
          string su_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<SupplierView>> success = (await SupplierRestServer.GetSupplierList(sendType, siteId, code, 0, su_SupplierType: su_SupplierType, su_SupplierKind: su_SupplierKind, su_PreTaxDiv: su_PreTaxDiv, su_MultiSuplierDiv: su_MultiSuplierDiv, su_UseYn: su_UseYn, is_origin_image: true, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<SupplierView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<SupplierView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<SupplierView>) success.response);
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

    public bool CanDataOpen(SupplierView item) => item != null;

    public void DataOpen(SupplierView item)
    {
      if (item == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == item.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageSupplierPartConVM viewModel = this.Container.Get<PageSupplierPartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageSupplierPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public WpfCommand<SupplierView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<SupplierView>>((Func<WpfCommand<SupplierView>>) (() => new WpfCommand<SupplierView>().AutoRefreshOn<WpfCommand<SupplierView>>().ApplyCanExecute<SupplierView>(new Func<SupplierView, bool>(this.CanDataOpen)).ApplyExecute<SupplierView>(new Action<SupplierView>(this.DataOpen))), nameof (CmdDataOpen));

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      SupplierListPageVM supplierListPageVm = this;
      if (!supplierListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (supplierListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (supplierListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = supplierListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      if (supplierListPageVm.ParamBackup.SupplierType.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeNoMemo + "]");
      }
      if (supplierListPageVm.ParamBackup.SupplierKind.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeNoMemo + "]");
      }
      if (supplierListPageVm.ParamBackup.StdPreTax.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeNoMemo + "]");
      }
      if (supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeNoMemo + "]");
      }
      string keyword = supplierListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + supplierListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + supplierListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (supplierListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (supplierListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Portrait;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (supplierListPageVm.MenuInfo).Title,
        Top1Left = string.Empty,
        Top1Right = string.Empty,
        Top2Left = stringBuilder1.ToString(),
        Top2Right = string.Empty,
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (supplierListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (supplierListPageVm.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (supplierListPageVm.MenuInfo).Code;
      int count = supplierListPageVm.Datas.Count;
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
        __nonvirtual (supplierListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
      SupplierListPageVM supplierListPageVm = this;
      if (!supplierListPageVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      bool? use = supplierListPageVm.ParamBackup.Use;
      bool flag = true;
      if (use.GetValueOrDefault() == flag & use.HasValue)
      {
        stringBuilder1.Append("[사용]");
        stringBuilder2.Append("[사용]");
      }
      if (supplierListPageVm.ParamBackup.SupplierType.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierType.comm_TypeNoMemo + "]");
      }
      if (supplierListPageVm.ParamBackup.SupplierKind.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierKind.comm_TypeNoMemo + "]");
      }
      if (supplierListPageVm.ParamBackup.StdPreTax.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.StdPreTax.comm_TypeNoMemo + "]");
      }
      if (supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeNo > 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeNoMemo + "]");
        stringBuilder2.Append("[" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeMemo + ":" + supplierListPageVm.ParamBackup.SupplierMulti.comm_TypeNoMemo + "]");
      }
      string keyword = supplierListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + supplierListPageVm.ParamBackup.Keyword + "]");
        stringBuilder2.Append("[키워드:" + supplierListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (supplierListPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (supplierListPageVm.Exporter), __nonvirtual (supplierListPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (supplierListPageVm.MenuInfo).Code, applyRowCnt: supplierListPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (supplierListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<SupplierListPageVM.InitParam>
    {
      private bool? use = new bool?(true);
      private int _Supplier_TypeNo;
      private int _Supplier_KindNo;
      private int _StdPreTaxNo;
      private int _Supplier_MultiNo;

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

      public int Supplier_TypeNo
      {
        get => this._Supplier_TypeNo;
        set
        {
          this._Supplier_TypeNo = value;
          this.NotifyOfPropertyChange(nameof (Supplier_TypeNo));
        }
      }

      public int Supplier_KindNo
      {
        get => this._Supplier_KindNo;
        set
        {
          this._Supplier_KindNo = value;
          this.NotifyOfPropertyChange(nameof (Supplier_KindNo));
        }
      }

      public int StdPreTaxNo
      {
        get => this._StdPreTaxNo;
        set
        {
          this._StdPreTaxNo = value;
          this.NotifyOfPropertyChange(nameof (StdPreTaxNo));
        }
      }

      public int Supplier_MultiNo
      {
        get => this._Supplier_MultiNo;
        set
        {
          this._Supplier_MultiNo = value;
          this.NotifyOfPropertyChange(nameof (Supplier_MultiNo));
        }
      }
    }

    public class SearchParam : ParamBase<SupplierListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string keyword;
      private CommonCodeView _SupplierType;
      private CommonCodeView _supplierKind;
      private CommonCodeView _stdPreTax;
      private CommonCodeView _supplierMulti;

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

      public CommonCodeView SupplierType
      {
        get => this._SupplierType;
        set
        {
          this._SupplierType = value;
          this.NotifyOfPropertyChange(nameof (SupplierType));
        }
      }

      public CommonCodeView SupplierKind
      {
        get => this._supplierKind;
        set
        {
          this._supplierKind = value;
          this.NotifyOfPropertyChange(nameof (SupplierKind));
        }
      }

      public CommonCodeView StdPreTax
      {
        get => this._stdPreTax;
        set
        {
          this._stdPreTax = value;
          this.NotifyOfPropertyChange(nameof (StdPreTax));
        }
      }

      public CommonCodeView SupplierMulti
      {
        get => this._supplierMulti;
        set
        {
          this._supplierMulti = value;
          this.NotifyOfPropertyChange(nameof (SupplierMulti));
        }
      }
    }
  }
}
