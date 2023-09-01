// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Brand;
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Maker;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Part.Sub.Category
{
  public class GoodsCountByCategoryPartVM : 
    SPartBase<
    #nullable disable
    GoodsCountByCategory>,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private GoodsCountByCategoryPartVM.SearchParam param = new GoodsCountByCategoryPartVM.SearchParam();
    private int _StoreCode;
    private string _StoreName;
    private string _NameRemark = string.Empty;
    private IList<CommonCodeView> _CategoryDepthList;

    public GoodsCountByCategoryPartVM(IContainer container)
      : base(container)
    {
    }

    public GoodsCountByCategoryPartVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public GoodsCountByCategoryPartVM.SearchParam ParamBackup { get; set; }

    public IUniDataGridViewer GridViewer { get; set; }

    public int StoreCode
    {
      get => this._StoreCode;
      set
      {
        int num = this._StoreCode == 0 ? 1 : 0;
        this._StoreCode = value;
        this.NotifyOfPropertyChange(nameof (StoreCode));
        if (num != 0)
          return;
        this.SearchAsync();
      }
    }

    public string StoreName
    {
      get => this._StoreName;
      set
      {
        this._StoreName = value;
        this.NotifyOfPropertyChange(nameof (StoreName));
      }
    }

    public string NameRemark
    {
      get => this._NameRemark;
      set
      {
        this._NameRemark = value;
        this.NotifyOfPropertyChange(nameof (NameRemark));
      }
    }

    public IList<CommonCodeView> CategoryDepthList
    {
      get => this._CategoryDepthList;
      set
      {
        this._CategoryDepthList = value;
        this.NotifyOfPropertyChange(nameof (CategoryDepthList));
      }
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      if (this.PartContainer.IsCreateMode)
        return;
      this.DefaultFuncs = (IEnumerable<DefaultPartFunc>) new List<DefaultPartFunc>()
      {
        DefaultPartFunc.Search
      }.ToArray();
      this.InitControl();
      this.SetParamInit();
    }

    protected void InitControl()
    {
      this.Param.DtDate = DateTime.Now;
      this.CategoryDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth].ToArray<CommonCodeView>();
      this.Param.CategoryDepth = this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth][1];
      this.StoreCode = this.App.User.User.Source.emp_BaseStore;
      this.StoreName = this.App.User.User.Source.si_StoreName;
    }

    public override async void OnQueryDefaultFunc(DefaultPartFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (funcType.Equals((object) DefaultPartFunc.Search))
        await this.SearchAsync();
      if (funcType.Equals((object) DefaultPartFunc.Print))
        await this.PrintDocumentAsync();
      if (!funcType.Equals((object) DefaultPartFunc.ExportExcel))
        return;
      await this.ExportExcelAsync();
    }

    public override bool OnQueryCanDefaultFunc(DefaultPartFunc funcType)
    {
      if (funcType.Equals((object) DefaultPartFunc.Print))
        return this.CanPrintDocument();
      return funcType.Equals((object) DefaultPartFunc.ExportExcel) ? this.CanExportExcel() : base.OnQueryCanDefaultFunc(funcType);
    }

    public void SetParamBackup() => this.ParamBackup = ParamBase<GoodsCountByCategoryPartVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);

    private void SetParamInit()
    {
      switch (this.PartContainer.TableCode)
      {
        case TableCodeType.Maker:
          if (!(this.WorkData.Current is MakerView current1))
            break;
          this.Param.mk_MakerCode = new int?(current1.mk_MakerCode);
          this.NameRemark = string.Format("{0}({1})", (object) current1.mk_MakerName, (object) current1.mk_MakerCode);
          break;
        case TableCodeType.Supplier:
          if (!(this.WorkData.Current is SupplierView current2))
            break;
          this.Param.su_Supplier = new int?(current2.su_Supplier);
          this.NameRemark = current2.su_SupplierName + "(" + current2.su_SupplierViewCode + ")";
          break;
        case TableCodeType.Brand:
          if (!(this.WorkData.Current is BrandView current3))
            break;
          this.Param.br_BrandCode = new int?(current3.br_BrandCode);
          this.NameRemark = string.Format("{0}({1})", (object) current3.br_BrandName, (object) current3.br_BrandCode);
          break;
        case TableCodeType.Category:
          if (!(this.WorkData.Current is CategoryView current4))
            break;
          switch (current4.ctg_Depth)
          {
            case 1:
              this.Param.ctg_lv1_ID = new int?(current4.ctg_lv1_ID);
              break;
            case 2:
              this.Param.ctg_lv2_ID = new int?(current4.ctg_lv2_ID);
              break;
            case 3:
              this.Param.ctg_ID = new int?(current4.ctg_ID);
              break;
          }
          this.NameRemark = current4.ctg_CategoryName + "(" + current4.ctg_ViewCode + ")";
          break;
      }
    }

    public async Task SearchAsync()
    {
      GoodsCountByCategoryPartVM byCategoryPartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (byCategoryPartVm.PartContainer).IsCreateMode)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (byCategoryPartVm.Job).CreateJob("검색", (string) null))
        {
          byCategoryPartVm.Datas.Clear();
          byCategoryPartVm.SetParamInit();
          byCategoryPartVm.Param.StoreCode = byCategoryPartVm.StoreCode;
          byCategoryPartVm.Param.StoreName = byCategoryPartVm.StoreName;
          string sendType = byCategoryPartVm.LogInPackInfo.sendType;
          long siteId = byCategoryPartVm.LogInPackInfo.siteID;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (byCategoryPartVm.MenuInfo).Code;
          long dt_date = byCategoryPartVm.Param.DtDate.ToLong();
          int storeCode = byCategoryPartVm.StoreCode;
          int? nullable = byCategoryPartVm.Param.su_Supplier;
          int su_Supplier = nullable.Value;
          nullable = byCategoryPartVm.Param.ctg_lv1_ID;
          int ctg_lv1_ID = nullable.Value;
          nullable = byCategoryPartVm.Param.ctg_lv2_ID;
          int ctg_lv2_ID = nullable.Value;
          nullable = byCategoryPartVm.Param.ctg_ID;
          int ctg_ID = nullable.Value;
          int commTypeNo = byCategoryPartVm.Param.CategoryDepth.comm_TypeNo;
          nullable = byCategoryPartVm.Param.mk_MakerCode;
          int mk_MakerCode = nullable.Value;
          nullable = byCategoryPartVm.Param.br_BrandCode;
          int br_BrandCode = nullable.Value;
          // ISSUE: explicit non-virtual call
          UbRes<IList<GoodsCountByCategory>> success = (await CategoryRestServer.GetGoodsCountByCategoryList(sendType, siteId, 0, code, dt_date, storeCode, su_Supplier, ctg_lv1_ID, ctg_lv2_ID, ctg_ID, commTypeNo, mk_MakerCode, br_BrandCode).ExecuteToReturnAsync<UbRes<IList<GoodsCountByCategory>>>((UniBizHttpClient) __nonvirtual (byCategoryPartVm.App).Api)).GetSuccess<UbRes<IList<GoodsCountByCategory>>>();
          byCategoryPartVm.Datas.AddRange((IEnumerable<GoodsCountByCategory>) success.response);
          byCategoryPartVm.SetParamBackup();
          List<string> source = new List<string>();
          switch (byCategoryPartVm.Param.CategoryDepth.comm_TypeNo)
          {
            case 1:
              source.Add("ctg_lv2_Name");
              source.Add("ctg_CategoryName");
              break;
            case 2:
              source.Add("ctg_CategoryName");
              break;
          }
          // ISSUE: explicit non-virtual call
          foreach (UniDataColumnView columnView in (Collection<UniDataColumnView>) __nonvirtual (byCategoryPartVm.DataView).ColumnViews)
          {
            UniDataColumnView item = columnView;
            if (item.Key.Equals("ctg_lv2_Name") || item.Key.Equals("ctg_CategoryName"))
              item.IsDisplay = source.Count<string>((Func<string, bool>) (col => col.Equals(item.Key))) < 1;
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (byCategoryPartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      GoodsCountByCategoryPartVM byCategoryPartVm = this;
      // ISSUE: reference to a compiler-generated method
      await byCategoryPartVm.\u003C\u003En__1(p_param);
      byCategoryPartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      GoodsCountByCategoryPartVM byCategoryPartVm = this;
      if (!byCategoryPartVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str1 = __nonvirtual (byCategoryPartVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (byCategoryPartVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      if (byCategoryPartVm.ParamBackup.StoreName.Length > 0)
      {
        stringBuilder5.Append("[" + byCategoryPartVm.ParamBackup.StoreName + "]");
        stringBuilder1.Append("[" + byCategoryPartVm.ParamBackup.StoreName + "]");
      }
      stringBuilder5.Append("[" + new DateTime?(byCategoryPartVm.ParamBackup.DtDate).GetDateToStr("yyyy-MM-dd") + "]");
      stringBuilder2.Append("[" + new DateTime?(byCategoryPartVm.ParamBackup.DtDate).GetDateToStr("yyyy-MM-dd") + "]");
      stringBuilder2.Append("\n");
      bool flag = false;
      if (byCategoryPartVm.Param.CategoryDepth.comm_TypeNo > 0)
      {
        stringBuilder5.Append("[단계:" + byCategoryPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
        if (flag)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[단계:" + byCategoryPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str2 = __nonvirtual (byCategoryPartVm.PartContainer).ContentsDisplay + " - " + __nonvirtual (byCategoryPartVm.MenuInfo).Title;
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (byCategoryPartVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (byCategoryPartVm.Duplicator));
      creater.Orientation = PageOrientation.Landscape;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = str2,
        Top1Left = stringBuilder1.ToString(),
        Top1Right = stringBuilder3.ToString(),
        Top2Left = stringBuilder2.ToString(),
        Top2Right = stringBuilder4.ToString(),
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (byCategoryPartVm.App).User.User.Source.emp_Name, (object) __nonvirtual (byCategoryPartVm.App).User.User.Source.emp_Code, (object) str1),
        BottomRight = "UniBizSM : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (byCategoryPartVm.MenuInfo).Code;
      int count = byCategoryPartVm.Datas.Count;
      string memo1 = stringBuilder5.ToString();
      string empty = string.Empty;
      int pPropInfoCode = code;
      int pApplyRowCnt = count;
      UniDataGridPrintSysBoardVM viewModel = gridPrintSysBoardVm.Set(creater, memo1, empty, pPropInfoCode: pPropInfoCode, pApplyRowCnt: pApplyRowCnt);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (byCategoryPartVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public WpfCommand CmdExportExcel => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        CanDisplayFunc = (Func<object, bool>) (_ => this.CanExportExcel()),
        ExecuteAction = (Action<object>) (_ => await this.ExportExcelAsync())
      };
    }), nameof (CmdExportExcel));

    public bool CanExportExcel() => this.App.User.User.Source.IsPermitExcel && this.Exporter != null && this.Datas.Count > 0;

    public async Task ExportExcelAsync()
    {
      GoodsCountByCategoryPartVM byCategoryPartVm = this;
      if (!byCategoryPartVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (byCategoryPartVm.ParamBackup.StoreName.Length > 0)
      {
        stringBuilder2.Append("[" + byCategoryPartVm.ParamBackup.StoreName + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + byCategoryPartVm.ParamBackup.StoreName + "]");
      }
      stringBuilder2.Append("[" + new DateTime?(byCategoryPartVm.ParamBackup.DtDate).GetDateToStr("yyyy-MM-dd") + "]");
      if (stringBuilder1.Length > 0)
        stringBuilder1.Append("/");
      stringBuilder1.Append("[" + new DateTime?(byCategoryPartVm.ParamBackup.DtDate).GetDateToStr("yyyy-MM-dd") + "]");
      if (byCategoryPartVm.Param.CategoryDepth.comm_TypeNo > 0)
      {
        stringBuilder2.Append("[단계:" + byCategoryPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[단계:" + byCategoryPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string title = __nonvirtual (byCategoryPartVm.PartContainer).ContentsDisplay + " - " + __nonvirtual (byCategoryPartVm.MenuInfo).Title;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (byCategoryPartVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (byCategoryPartVm.Exporter), title, stringBuilder1.ToString(), propInfoCode: __nonvirtual (byCategoryPartVm.MenuInfo).Code, applyRowCnt: byCategoryPartVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (byCategoryPartVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class SearchParam : ParamBase<GoodsCountByCategoryPartVM.SearchParam>
    {
      private DateTime _DtDate;
      private CommonCodeView _CategoryDepth;
      private int? _su_Supplier = new int?(0);
      private int? _ctg_lv1_ID = new int?(0);
      private int? _ctg_lv2_ID = new int?(0);
      private int? _ctg_ID = new int?(0);
      private int? _mk_MakerCode = new int?(0);
      private int? _br_BrandCode = new int?(0);
      private int _StoreCode;
      private string _StoreName;

      public DateTime DtDate
      {
        get => this._DtDate;
        set
        {
          this._DtDate = value;
          this.NotifyOfPropertyChange(nameof (DtDate));
        }
      }

      public CommonCodeView CategoryDepth
      {
        get => this._CategoryDepth;
        set
        {
          this._CategoryDepth = value;
          this.NotifyOfPropertyChange(nameof (CategoryDepth));
        }
      }

      public int? su_Supplier
      {
        get => this._su_Supplier;
        set
        {
          this._su_Supplier = value;
          this.NotifyOfPropertyChange(nameof (su_Supplier));
        }
      }

      public int? ctg_lv1_ID
      {
        get => this._ctg_lv1_ID;
        set
        {
          this._ctg_lv1_ID = value;
          this.NotifyOfPropertyChange(nameof (ctg_lv1_ID));
        }
      }

      public int? ctg_lv2_ID
      {
        get => this._ctg_lv2_ID;
        set
        {
          this._ctg_lv2_ID = value;
          this.NotifyOfPropertyChange(nameof (ctg_lv2_ID));
        }
      }

      public int? ctg_ID
      {
        get => this._ctg_ID;
        set
        {
          this._ctg_ID = value;
          this.NotifyOfPropertyChange(nameof (ctg_ID));
        }
      }

      public int? mk_MakerCode
      {
        get => this._mk_MakerCode;
        set
        {
          this._mk_MakerCode = value;
          this.NotifyOfPropertyChange(nameof (mk_MakerCode));
        }
      }

      public int? br_BrandCode
      {
        get => this._br_BrandCode;
        set
        {
          this._br_BrandCode = value;
          this.NotifyOfPropertyChange(nameof (br_BrandCode));
        }
      }

      public int StoreCode
      {
        get => this._StoreCode;
        set
        {
          this._StoreCode = value;
          this.NotifyOfPropertyChange(nameof (StoreCode));
        }
      }

      public string StoreName
      {
        get => this._StoreName;
        set
        {
          this._StoreName = value;
          this.NotifyOfPropertyChange(nameof (StoreName));
        }
      }
    }
  }
}
