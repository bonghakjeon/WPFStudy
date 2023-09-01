// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Sub.Sales
{
  public class DaySalesVerticalPartVM : 
    SPartBase<
    #nullable disable
    SaleByDayVerticalByCategoryBot>,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private DaySalesVerticalPartVM.SearchParam param = new DaySalesVerticalPartVM.SearchParam();
    protected DaySalesVerticalPartVM.SumParam _sumData = new DaySalesVerticalPartVM.SumParam();
    private List<ColumnDescription> subColumns;
    private int _StoreCode;
    private string _StoreName;
    private string _NameRemark = string.Empty;
    private IList<CommonCodeView> _CategoryDepthList;

    public DaySalesVerticalPartVM(IContainer container)
      : base(container)
    {
    }

    public DaySalesVerticalPartVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public DaySalesVerticalPartVM.SearchParam ParamBackup { get; set; }

    public IUniDataGridViewer GridViewer { get; set; }

    public DaySalesVerticalPartVM.SumParam SumData
    {
      get => this._sumData;
      set
      {
        this._sumData = value;
        this.NotifyOfPropertyChange(nameof (SumData));
      }
    }

    public List<ColumnDescription> SubColumns
    {
      get => this.subColumns;
      set
      {
        this.subColumns = value;
        this.NotifyOfPropertyChange(nameof (SubColumns));
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

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      DaySalesVerticalPartVM salesVerticalPartVm = this;
      if (!salesVerticalPartVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str1 = __nonvirtual (salesVerticalPartVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (salesVerticalPartVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      if (salesVerticalPartVm.ParamBackup.StoreName.Length > 0)
      {
        stringBuilder5.Append("[" + salesVerticalPartVm.ParamBackup.StoreName + "]");
        stringBuilder1.Append("[" + salesVerticalPartVm.ParamBackup.StoreName + "]");
      }
      stringBuilder5.Append("[" + new DateTime?(salesVerticalPartVm.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(salesVerticalPartVm.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
      stringBuilder2.Append("[" + new DateTime?(salesVerticalPartVm.ParamBackup.DtStart).GetDateToStr("yyyy-MM-dd") + "~" + new DateTime?(salesVerticalPartVm.ParamBackup.DtEnd).GetDateToStr("yyyy-MM-dd") + "]");
      stringBuilder2.Append("\n");
      bool flag1 = false;
      if (salesVerticalPartVm.Param.CategoryDepth.comm_TypeNo > 0)
      {
        stringBuilder5.Append("[단계:" + salesVerticalPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
        if (flag1)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[단계:" + salesVerticalPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
      }
      bool flag2 = false;
      if (salesVerticalPartVm.ParamBackup.IsTax)
      {
        if (flag2)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        else
          flag2 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsTaxFree)
      {
        if (flag2)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
      }
      bool flag3 = false;
      if (salesVerticalPartVm.ParamBackup.IsSaleDirect)
      {
        if (flag3)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        else
          flag3 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsSaleSpe)
      {
        if (flag3)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        else
          flag3 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsSaleLea)
      {
        if (flag3)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
      }
      bool flag4 = false;
      if (salesVerticalPartVm.ParamBackup.IsStockUnitAmount)
      {
        if (flag4)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        else
          flag4 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsStockUnitQty)
      {
        if (flag4)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        else
          flag4 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsStockUnitWeight)
      {
        if (flag4)
        {
          stringBuilder5.Append("/");
          stringBuilder4.Append(",");
        }
        // ISSUE: explicit non-virtual call
        stringBuilder5.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
        // ISSUE: explicit non-virtual call
        stringBuilder4.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str2 = __nonvirtual (salesVerticalPartVm.PartContainer).ContentsDisplay + " - " + __nonvirtual (salesVerticalPartVm.MenuInfo).Title;
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (salesVerticalPartVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (salesVerticalPartVm.Duplicator));
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
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (salesVerticalPartVm.App).User.User.Source.emp_Name, (object) __nonvirtual (salesVerticalPartVm.App).User.User.Source.emp_Code, (object) str1),
        BottomRight = "UniBizSM : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (salesVerticalPartVm.MenuInfo).Code;
      int count = salesVerticalPartVm.Datas.Count;
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
        __nonvirtual (salesVerticalPartVm.WindowManager)?.ShowDialog((object) viewModel);
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
      DaySalesVerticalPartVM salesVerticalPartVm = this;
      if (!salesVerticalPartVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (salesVerticalPartVm.ParamBackup.StoreName.Length > 0)
      {
        stringBuilder2.Append("[" + salesVerticalPartVm.ParamBackup.StoreName + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + salesVerticalPartVm.ParamBackup.StoreName + "]");
      }
      stringBuilder2.Append("[" + new DateTime?(salesVerticalPartVm.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(salesVerticalPartVm.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
      if (stringBuilder1.Length > 0)
        stringBuilder1.Append("/");
      stringBuilder1.Append("[" + new DateTime?(salesVerticalPartVm.ParamBackup.DtStart).GetDateToStr("yyyy-MM-dd") + "~" + new DateTime?(salesVerticalPartVm.ParamBackup.DtEnd).GetDateToStr("yyyy-MM-dd") + "]");
      if (salesVerticalPartVm.Param.CategoryDepth.comm_TypeNo > 0)
      {
        stringBuilder2.Append("[단계:" + salesVerticalPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[단계:" + salesVerticalPartVm.Param.CategoryDepth.comm_TypeNoMemo + "]");
      }
      bool flag1 = false;
      if (salesVerticalPartVm.ParamBackup.IsTax)
      {
        if (flag1)
          stringBuilder2.Append("/");
        else
          flag1 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsTaxFree)
      {
        if (flag1)
          stringBuilder2.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
      }
      bool flag2 = false;
      if (salesVerticalPartVm.ParamBackup.IsSaleDirect)
      {
        if (flag2)
          stringBuilder2.Append("/");
        else
          flag2 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsSaleSpe)
      {
        if (flag2)
          stringBuilder2.Append("/");
        else
          flag2 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsSaleLea)
      {
        if (flag2)
          stringBuilder2.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
      }
      bool flag3 = false;
      if (salesVerticalPartVm.ParamBackup.IsStockUnitAmount)
      {
        if (flag3)
          stringBuilder2.Append("/");
        else
          flag3 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsStockUnitQty)
      {
        if (flag3)
          stringBuilder2.Append("/");
        else
          flag3 = true;
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
      }
      if (salesVerticalPartVm.ParamBackup.IsStockUnitWeight)
      {
        if (flag3)
          stringBuilder2.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder2.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        // ISSUE: explicit non-virtual call
        stringBuilder1.Append(__nonvirtual (salesVerticalPartVm.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string title = __nonvirtual (salesVerticalPartVm.PartContainer).ContentsDisplay + " - " + __nonvirtual (salesVerticalPartVm.MenuInfo).Title;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (salesVerticalPartVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (salesVerticalPartVm.Exporter), title, stringBuilder1.ToString(), propInfoCode: __nonvirtual (salesVerticalPartVm.MenuInfo).Code, applyRowCnt: salesVerticalPartVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (salesVerticalPartVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class SearchParam : ParamBase<DaySalesVerticalPartVM.SearchParam>
    {
      private DateTime _DtStart;
      private DateTime _DtEnd;
      private CommonCodeView _CategoryDepth;
      private bool _IsTax = true;
      private bool _IsTaxFree = true;
      private bool _IsSaleDirect = true;
      private bool _IsSaleSpe;
      private bool _IsSaleLea = true;
      private bool _IsStockUnitAmount = true;
      private bool _IsStockUnitQty = true;
      private bool _IsStockUnitWeight = true;
      private int _StoreCode;
      private string _StoreName;
      private int? _su_Supplier = new int?(0);
      private int? _ctg_lv1_ID = new int?(0);
      private int? _ctg_lv2_ID = new int?(0);
      private int? _ctg_ID = new int?(0);
      private int? _mk_MakerCode = new int?(0);
      private int? _br_BrandCode = new int?(0);
      private int? _gd_GoodsCode = new int?(0);
      private int _ExpandsCount = 2;

      public DateTime DtStart
      {
        get => this._DtStart;
        set
        {
          this._DtStart = value;
          this.NotifyOfPropertyChange(nameof (DtStart));
        }
      }

      public DateTime DtEnd
      {
        get => this._DtEnd;
        set
        {
          this._DtEnd = value;
          this.NotifyOfPropertyChange(nameof (DtEnd));
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

      public bool IsTax
      {
        get => this._IsTax;
        set
        {
          this._IsTax = value;
          this.NotifyOfPropertyChange(nameof (IsTax));
        }
      }

      public bool IsTaxFree
      {
        get => this._IsTaxFree;
        set
        {
          this._IsTaxFree = value;
          this.NotifyOfPropertyChange(nameof (IsTaxFree));
        }
      }

      public bool IsSaleDirect
      {
        get => this._IsSaleDirect;
        set
        {
          this._IsSaleDirect = value;
          this.NotifyOfPropertyChange(nameof (IsSaleDirect));
        }
      }

      public bool IsSaleSpe
      {
        get => this._IsSaleSpe;
        set
        {
          this._IsSaleSpe = value;
          this.NotifyOfPropertyChange(nameof (IsSaleSpe));
        }
      }

      public bool IsSaleLea
      {
        get => this._IsSaleLea;
        set
        {
          this._IsSaleLea = value;
          this.NotifyOfPropertyChange(nameof (IsSaleLea));
        }
      }

      public bool IsStockUnitAmount
      {
        get => this._IsStockUnitAmount;
        set
        {
          this._IsStockUnitAmount = value;
          this.NotifyOfPropertyChange(nameof (IsStockUnitAmount));
        }
      }

      public bool IsStockUnitQty
      {
        get => this._IsStockUnitQty;
        set
        {
          this._IsStockUnitQty = value;
          this.NotifyOfPropertyChange(nameof (IsStockUnitQty));
        }
      }

      public bool IsStockUnitWeight
      {
        get => this._IsStockUnitWeight;
        set
        {
          this._IsStockUnitWeight = value;
          this.NotifyOfPropertyChange(nameof (IsStockUnitWeight));
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

      public int? gd_GoodsCode
      {
        get => this._gd_GoodsCode;
        set
        {
          this._gd_GoodsCode = value;
          this.NotifyOfPropertyChange(nameof (gd_GoodsCode));
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

    public class SumParam : ParamBase<DaySalesVerticalPartVM.SumParam>
    {
      private double _sbd_GoalRate;
      private double _sbd_ProfitRule;
      private double _sbd_SlipCustomerPrice;
      private double _sbd_CategoryCustomerPrice;
      private double _sbd_GoodsCustomerPrice;

      public double sbd_GoalRate
      {
        get => this._sbd_GoalRate;
        set
        {
          this._sbd_GoalRate = value;
          this.NotifyOfPropertyChange(nameof (sbd_GoalRate));
        }
      }

      public double sbd_ProfitRule
      {
        get => this._sbd_ProfitRule;
        set
        {
          this._sbd_ProfitRule = value;
          this.NotifyOfPropertyChange(nameof (sbd_ProfitRule));
        }
      }

      public double sbd_SlipCustomerPrice
      {
        get => this._sbd_SlipCustomerPrice;
        set
        {
          this._sbd_SlipCustomerPrice = value;
          this.NotifyOfPropertyChange(nameof (sbd_SlipCustomerPrice));
        }
      }

      public double sbd_CategoryCustomerPrice
      {
        get => this._sbd_CategoryCustomerPrice;
        set
        {
          this._sbd_CategoryCustomerPrice = value;
          this.NotifyOfPropertyChange(nameof (sbd_CategoryCustomerPrice));
        }
      }

      public double sbd_GoodsCustomerPrice
      {
        get => this._sbd_GoodsCustomerPrice;
        set
        {
          this._sbd_GoodsCustomerPrice = value;
          this.NotifyOfPropertyChange(nameof (sbd_GoodsCustomerPrice));
        }
      }
    }
  }
}
