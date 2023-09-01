// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Systems.Security.OuterConnAuth.OuterConnAuthListPageVM
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
using System.Windows.Controls;
using System.Windows.Threading;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.OuterConnAuth;
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
namespace UniBizBO.ViewModels.Page.UniSales.Systems.Security.OuterConnAuth
{
  public class OuterConnAuthListPageVM : 
    PageBase<
    #nullable disable
    OuterConnAuthView>,
    ISystemPage,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private OuterConnAuthListPageVM.InitParam _InitControlParam = new OuterConnAuthListPageVM.InitParam();
    private OuterConnAuthListPageVM.SearchParam _Param = new OuterConnAuthListPageVM.SearchParam();
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public OuterConnAuthListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public OuterConnAuthListPageVM.SearchParam Param
    {
      get => this._Param;
      set
      {
        this._Param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public OuterConnAuthListPageVM.SearchParam ParamBackup { get; set; } = new OuterConnAuthListPageVM.SearchParam();

    public BindableCollection<OuterConnAuthLevel> DepthDatas { get; } = new BindableCollection<OuterConnAuthLevel>();

    public IUniDataGridViewer GridViewer { get; set; }

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public OuterConnAuthListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      OuterConnAuthListPageVM connAuthListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      connAuthListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await connAuthListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await connAuthListPageVm.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await connAuthListPageVm.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (connAuthListPageVm.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
        connAuthListPageVm.IsOpenExcelPopup = true;
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      connAuthListPageVm.CloseItem();
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
      this.Param.DevicePermit = this.App.Sys.CommonCodes[CommonCodeTypes.DevicePermit][this.InitControlParam.DevicePermitNo];
      this.Param.AppType = this.App.Sys.CommonCodes[CommonCodeTypes.AppType][this.InitControlParam.AppTypeNo];
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<OuterConnAuthListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.DevicePermitNo = this.Param.DevicePermit.comm_TypeNo;
      this.InitControlParam.AppTypeNo = this.Param.AppType.comm_TypeNo;
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      OuterConnAuthListPageVM connAuthListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await connAuthListPageVm.\u003C\u003En__1(p_param);
      connAuthListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
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
      OuterConnAuthListPageVM connAuthListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (connAuthListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (connAuthListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (connAuthListPageVm.Container)).Set(__nonvirtual (connAuthListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadExcelFile() => this.App.User.User.Source.IsAdmin;

    public async Task UploadExcelFileAsync()
    {
      OuterConnAuthListPageVM connAuthListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (connAuthListPageVm.Container)).Set("Test", "기능 개발 중...").ShowDialog();
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (connAuthListPageVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (connAuthListPageVm.Container)).Set(__nonvirtual (connAuthListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task SearchAsync()
    {
      OuterConnAuthListPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          int commTypeNo1 = sender.Param.DevicePermit.comm_TypeNo;
          int commTypeNo2 = sender.Param.AppType.comm_TypeNo;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          int oca_ProgKind = commTypeNo2;
          int oca_Status = commTypeNo1;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<OuterConnAuthView>> success = (await OuterConnAuthRestServer.GetOuterConnAuthList(sendType, siteId, code, 0, oca_ProgKind: oca_ProgKind, oca_Status: oca_Status, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<OuterConnAuthView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<OuterConnAuthView>>>();
          IList<OuterConnAuthView> response = success.response;
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<OuterConnAuthView>) response);
          List<OuterConnAuthLevel> outerConnAuthLevelList = new List<OuterConnAuthLevel>();
          foreach (OuterConnAuthView outerConnAuthView in (IEnumerable<OuterConnAuthView>) response)
          {
            bool flag = false;
            foreach (OuterConnAuthLevel outerConnAuthLevel in outerConnAuthLevelList)
            {
              if (outerConnAuthLevel.oca_TreeDepth == outerConnAuthView.oca_ProgKind)
              {
                outerConnAuthLevel.Items.Add(outerConnAuthView);
                flag = true;
                break;
              }
            }
            if (!flag)
            {
              OuterConnAuthLevel outerConnAuthLevel1 = new OuterConnAuthLevel();
              outerConnAuthLevel1.oca_TreeDepth = outerConnAuthView.oca_ProgKind;
              OuterConnAuthLevel outerConnAuthLevel2 = outerConnAuthLevel1;
              EnumAppType appType = Enum2StrConverter.ToAppType(outerConnAuthView.oca_ProgKind);
              string str1 = appType.ToString();
              outerConnAuthLevel2.oca_TreeName = str1;
              OuterConnAuthLevel outerConnAuthLevel3 = outerConnAuthLevel1;
              appType = Enum2StrConverter.ToAppType(outerConnAuthView.oca_ProgKind);
              string str2 = appType.ToString();
              outerConnAuthLevel3.oca_DeviceName = str2;
              outerConnAuthLevel1.Items.Add(outerConnAuthView);
              outerConnAuthLevelList.Add(outerConnAuthLevel1);
            }
          }
          sender.DepthDatas.Clear();
          sender.DepthDatas.AddRange((IEnumerable<OuterConnAuthLevel>) outerConnAuthLevelList.ToArray());
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

    public bool CanDataOpen(OuterConnAuthView item) => item != null && item.oca_ID > 0;

    public void DataOpen(OuterConnAuthView item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }

    public WpfCommand<OuterConnAuthView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<OuterConnAuthView>>((Func<WpfCommand<OuterConnAuthView>>) (() => new WpfCommand<OuterConnAuthView>().AutoRefreshOn<WpfCommand<OuterConnAuthView>>().ApplyCanExecute<OuterConnAuthView>(new Func<OuterConnAuthView, bool>(this.CanDataOpen)).ApplyExecute<OuterConnAuthView>(new Action<OuterConnAuthView>(this.DataOpen))), nameof (CmdDataOpen));

    public void BtnClick(object p_object)
    {
      if (!(p_object is ContentPresenter contentPresenter) || !(contentPresenter.DataContext is OuterConnAuthLevel dataContext) || dataContext.oca_TreeDepth != 2)
        return;
      this.DataOpen((OuterConnAuthView) dataContext);
    }

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      OuterConnAuthListPageVM connAuthListPageVm = this;
      if (!connAuthListPageVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (connAuthListPageVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (connAuthListPageVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      bool flag = false;
      if (connAuthListPageVm.ParamBackup.AppType.comm_TypeNo > 0)
      {
        stringBuilder5.Append("[" + connAuthListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
        if (flag)
          stringBuilder4.Append("/");
        else
          flag = true;
        stringBuilder4.Append("[" + connAuthListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
      }
      if (connAuthListPageVm.ParamBackup.DevicePermit.comm_TypeNo > 0)
      {
        stringBuilder5.Append("[" + connAuthListPageVm.ParamBackup.DevicePermit.comm_TypeNoMemo + "]");
        if (flag)
          stringBuilder4.Append("/");
        stringBuilder4.Append("[" + connAuthListPageVm.ParamBackup.DevicePermit.comm_TypeNoMemo + "]");
      }
      string keyword = connAuthListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder5.Append("[키워드:" + connAuthListPageVm.ParamBackup.Keyword + "]");
        stringBuilder3.Append("[키워드:" + connAuthListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (connAuthListPageVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (connAuthListPageVm.Duplicator));
      creater.Orientation = PageOrientation.Landscape;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (connAuthListPageVm.MenuInfo).Title,
        Top1Left = stringBuilder1.ToString(),
        Top1Right = stringBuilder3.ToString(),
        Top2Left = stringBuilder2.ToString(),
        Top2Right = stringBuilder4.ToString(),
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (connAuthListPageVm.App).User.User.Source.emp_Name, (object) __nonvirtual (connAuthListPageVm.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizSM : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (connAuthListPageVm.MenuInfo).Code;
      int count = connAuthListPageVm.Datas.Count;
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
        __nonvirtual (connAuthListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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
      OuterConnAuthListPageVM connAuthListPageVm = this;
      if (!connAuthListPageVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (connAuthListPageVm.ParamBackup.AppType.comm_TypeNo > 0)
      {
        stringBuilder2.Append("[" + connAuthListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + connAuthListPageVm.ParamBackup.AppType.comm_TypeNoMemo + "]");
      }
      if (connAuthListPageVm.ParamBackup.DevicePermit.comm_TypeNo > 0)
      {
        stringBuilder2.Append("[" + connAuthListPageVm.ParamBackup.DevicePermit.comm_TypeNoMemo + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + connAuthListPageVm.ParamBackup.DevicePermit.comm_TypeNoMemo + "]");
      }
      string keyword = connAuthListPageVm.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder2.Append("[키워드:" + connAuthListPageVm.ParamBackup.Keyword + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[키워드:" + connAuthListPageVm.ParamBackup.Keyword + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (connAuthListPageVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (connAuthListPageVm.Exporter), __nonvirtual (connAuthListPageVm.MenuInfo).Title, stringBuilder1.ToString(), __nonvirtual (connAuthListPageVm.MenuInfo).Code, applyRowCnt: connAuthListPageVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (connAuthListPageVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<OuterConnAuthListPageVM.InitParam>
    {
      private int _DevicePermitNo;
      private int _AppTypeNo;

      public int DevicePermitNo
      {
        get => this._DevicePermitNo;
        set
        {
          this._DevicePermitNo = value;
          this.NotifyOfPropertyChange(nameof (DevicePermitNo));
        }
      }

      public int AppTypeNo
      {
        get => this._AppTypeNo;
        set
        {
          this._AppTypeNo = value;
          this.NotifyOfPropertyChange(nameof (AppTypeNo));
        }
      }
    }

    public class SearchParam : ParamBase<OuterConnAuthListPageVM.SearchParam>
    {
      private string keyword;
      private CommonCodeView _DevicePermit;
      private CommonCodeView _AppType;

      public string Keyword
      {
        get => this.keyword;
        set
        {
          this.keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public CommonCodeView DevicePermit
      {
        get => this._DevicePermit;
        set
        {
          this._DevicePermit = value;
          this.NotifyOfPropertyChange(nameof (DevicePermit));
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
