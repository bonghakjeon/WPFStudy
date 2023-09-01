// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales.SupplierPageBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Supplier;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales
{
  [HiddenVm]
  public class SupplierPageBase<T> : PageBase<
  #nullable disable
  T>, IPrintElementDocumentVM, IExportUniDataGridVM
  {
    private SupplierPageBase<T>.InitParam _InitControlParam = new SupplierPageBase<T>.InitParam();
    private SupplierPageBase<T>.SearchParam param = new SupplierPageBase<T>.SearchParam();
    protected SupplierPageBase<T>.SumParam _sumData = new SupplierPageBase<T>.SumParam();
    private string _FooterRemark = string.Empty;

    [ManagedStatus]
    public SupplierPageBase<T>.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public SupplierPageBase<T>.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public SupplierPageBase<T>.SearchParam ParamBackup { get; set; }

    public SupplierPageBase<T>.SumParam SumData
    {
      get => this._sumData;
      set
      {
        this._sumData = value;
        this.NotifyOfPropertyChange(nameof (SumData));
      }
    }

    public string FooterRemark
    {
      get => this._FooterRemark;
      set
      {
        this._FooterRemark = value;
        this.NotifyOfPropertyChange(nameof (FooterRemark));
      }
    }

    public IUniDataGridViewer GridViewer { get; set; }

    public SupplierPageBase(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      SupplierPageBase<T> supplierPageBase = this;
      // ISSUE: reference to a compiler-generated method
      supplierPageBase.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await supplierPageBase.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Print))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (supplierPageBase.PrintDocumentAsync());
      }
      if (funcType.Equals((object) DefaultPageFunc.ExportExcel))
      {
        // ISSUE: explicit non-virtual call
        await __nonvirtual (supplierPageBase.ExportExcelAsync());
      }
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      supplierPageBase.OnClose();
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType)
    {
      if (funcType.Equals((object) DefaultPageFunc.Print))
        return this.CanPrintDocument();
      return !funcType.Equals((object) DefaultPageFunc.ExportExcel) || this.CanExportExcel();
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
      if (this.App.User.User.Source.IsPermitPrint)
        defaultPageFuncList.Add(DefaultPageFunc.Print);
      if (this.App.User.User.Source.IsPermitExcel)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl()
    {
      this.Param.StoreCodeIn = this.App.User.User.Source.emp_BaseStore.ToString();
      this.Param.StoreNameIn = this.App.User.User.Source.si_StoreName;
      if (this.InitControlParam.CategoryDepth == null)
        this.InitControlParam.CategoryDepth = this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth][1];
      this.Param.CategoryDepth = this.InitControlParam.CategoryDepth;
      this.Param.IsStoreTotal = this.InitControlParam.IsStoreTotal;
      this.Param.IsTax = this.InitControlParam.IsTax;
      this.Param.IsTaxFree = this.InitControlParam.IsTaxFree;
      this.Param.IsSaleDirect = this.InitControlParam.IsSaleDirect;
      this.Param.IsSaleSpe = this.InitControlParam.IsSaleSpe;
      this.Param.IsSaleLea = this.InitControlParam.IsSaleLea;
      this.Param.IsStockUnitAmount = this.InitControlParam.IsStockUnitAmount;
      this.Param.IsStockUnitQty = this.InitControlParam.IsStockUnitQty;
      this.Param.IsStockUnitWeight = this.InitControlParam.IsStockUnitWeight;
      this.Param.ExpandsCount = this.InitControlParam.ExpandsCount;
      this.InitCategoryViews();
    }

    protected virtual void InitCategoryViews()
    {
      if (this.DataView.CategoryViews.Count != 0)
        return;
      this.CreateCategoryViews();
    }

    protected virtual void CreateCategoryViews()
    {
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S1_Qty",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S1_Amount",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_SaleRate",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S1_ProfitAmt",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S1_Customer",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S1_DcAmount",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S1_PayAmount",
        IsDisplay = false
      });
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<SupplierPageBase<T>.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.CategoryDepth = this.Param.CategoryDepth;
      this.InitControlParam.IsStoreTotal = this.Param.IsStoreTotal;
      this.InitControlParam.IsTax = this.Param.IsTax;
      this.InitControlParam.IsTaxFree = this.Param.IsTaxFree;
      this.InitControlParam.IsSaleDirect = this.Param.IsSaleDirect;
      this.InitControlParam.IsSaleSpe = this.Param.IsSaleSpe;
      this.InitControlParam.IsSaleLea = this.Param.IsSaleLea;
      this.InitControlParam.IsStockUnitAmount = this.Param.IsStockUnitAmount;
      this.InitControlParam.IsStockUnitQty = this.Param.IsStockUnitQty;
      this.InitControlParam.IsStockUnitWeight = this.Param.IsStockUnitWeight;
      this.InitControlParam.ExpandsCount = this.Param.ExpandsCount;
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      SupplierPageBase<T> supplierPageBase = this;
      // ISSUE: reference to a compiler-generated method
      await supplierPageBase.\u003C\u003En__1(p_param);
      supplierPageBase.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public virtual async Task SearchAsync() => await Task.Yield();

    public virtual void SetFooterData(IList<T> p_list)
    {
      this._sumData.Sum = new SaleByDayDateSupplier();
      this.SumData.sbd_ProfitRule = 0.0;
      this.SumData.sbd_SlipCustomerPrice = 0.0;
      this.SumData.sbd_CategoryCustomerPrice = 0.0;
      this.SumData.sbd_GoodsCustomerPrice = 0.0;
      foreach (T p in (IEnumerable<T>) p_list)
      {
        if (p is SaleByDayDateSupplier pSource)
          this.SumData.Sum.CalcAddSum((SaleByDayDateStore) pSource);
      }
      foreach (T p in (IEnumerable<T>) p_list)
      {
        if (p is SaleByDayDateSupplier byDayDateSupplier)
        {
          byDayDateSupplier.sbd_SaleQtyRule = CalcHelper.ToCompositionRate(byDayDateSupplier.sbd_SaleQty, this.SumData.Sum.sbd_SaleQty);
          byDayDateSupplier.sbd_SaleAmtRule = CalcHelper.ToCompositionRate(byDayDateSupplier.sbd_SaleAmt, this.SumData.Sum.sbd_SaleAmt);
        }
      }
      this.SumData.sbd_ProfitRule = this.SumData.Sum.sbd_ProfitRule;
      this.SumData.sbd_SlipCustomerPrice = this.SumData.Sum.sbd_SlipCustomerPrice;
      this.SumData.sbd_CategoryCustomerPrice = this.SumData.Sum.sbd_CategoryCustomerPrice;
      this.SumData.sbd_GoodsCustomerPrice = this.SumData.Sum.sbd_GoodsCustomerPrice;
    }

    public virtual void SetSubColumns(IList<T> p_list)
    {
    }

    public override async Task OnReceiveParamAsync(
      IPage sender,
      ParamBase param,
      IDictionary<string, object> arg = null)
    {
      SupplierPageBase<T> supplierPageBase = this;
      // ISSUE: reference to a compiler-generated method
      await supplierPageBase.\u003C\u003En__2(sender, param, arg);
      foreach (UniDataCategoryView categoryView in (Collection<UniDataCategoryView>) (sender as IUbVM).DataView.CategoryViews)
      {
        UniDataCategoryView item = categoryView;
        // ISSUE: explicit non-virtual call
        IEnumerable<UniDataCategoryView> source = __nonvirtual (supplierPageBase.DataView).CategoryViews.Where<UniDataCategoryView>((Func<UniDataCategoryView, bool>) (x => x.Key == item.Key));
        UniDataCategoryView dataCategoryView = source != null ? source.FirstOrDefault<UniDataCategoryView>() : (UniDataCategoryView) null;
        if (dataCategoryView != null)
        {
          dataCategoryView.IsDisplay = item.IsDisplay;
        }
        else
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (supplierPageBase.DataView).CategoryViews.Add(new UniDataCategoryView()
          {
            Key = item.Key,
            IsDisplay = item.IsDisplay
          });
        }
      }
      supplierPageBase.Param = ParamBase<SupplierPageBase<T>.SearchParam>.Create(param, arg);
      supplierPageBase.Param.Keyword = (string) null;
      await supplierPageBase.SearchAsync();
    }

    public WpfCommand<T> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<T>>((Func<WpfCommand<T>>) (() => new WpfCommand<T>().AutoRefreshOn<WpfCommand<T>>().ApplyCanExecute<T>(new Func<T, bool>(this.CanDataOpen)).ApplyExecute<T>(new Action<T>(this.DataOpen))), nameof (CmdDataOpen));

    public virtual bool CanDataOpen(T item) => (object) item != null;

    public virtual async void DataOpen(T item)
    {
      SupplierPageBase<T> sender = this;
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      // ISSUE: explicit non-virtual call
      await __nonvirtual (sender.SendParamAfterPageAsync((IPage) sender, (ParamBase) sender.Param, (IDictionary<string, object>) dictionary));
    }

    public WpfCommand<(object, object)> CmdColumnDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<(object, object)>>((Func<WpfCommand<(object, object)>>) (() => new WpfCommand<(object, object)>().ApplyExecute<(object, object)>(new Action<(object, object)>(this.NextTabColume))), nameof (CmdColumnDataOpen));

    public virtual async void NextTabColume((object, object) x) => await Task.Yield();

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      SupplierPageBase<T> supplierPageBase = this;
      if (!supplierPageBase.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str = __nonvirtual (supplierPageBase.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (supplierPageBase.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      StringBuilder stringBuilder6 = new StringBuilder();
      if (supplierPageBase.ParamBackup.StoreCodeIn.Length > 0)
      {
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.StoreNameIn + "]");
        stringBuilder3.Append("[" + supplierPageBase.ParamBackup.StoreNameIn + "]");
      }
      stringBuilder2.Append("[" + new DateTime?(supplierPageBase.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(supplierPageBase.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
      stringBuilder4.Append("조회:" + new DateTime?(supplierPageBase.ParamBackup.DtStart).GetDateToStr("yyyy-MM-dd") + "~" + new DateTime?(supplierPageBase.ParamBackup.DtEnd).GetDateToStr("yyyy-MM-dd"));
      stringBuilder4.Append("\n");
      bool flag1 = false;
      if (supplierPageBase.ParamBackup.SupplierCodeIn.Length > 0)
      {
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.SupplierNameIn + "]");
        if (flag1)
          stringBuilder4.Append("/");
        else
          flag1 = true;
        stringBuilder4.Append("[업체:" + supplierPageBase.ParamBackup.SupplierNameIn + "]");
      }
      string keyword = supplierPageBase.ParamBackup.Keyword;
      if ((keyword != null ? (keyword.Length > 0 ? 1 : 0) : 0) != 0)
      {
        stringBuilder2.Append("[키워드:" + supplierPageBase.ParamBackup.Keyword + "]");
        stringBuilder5.Append("[키워드:" + supplierPageBase.ParamBackup.Keyword + "]");
      }
      if (supplierPageBase.ParamBackup.Dpt_Name.Length > 0)
      {
        stringBuilder2.Append("[부서:" + supplierPageBase.ParamBackup.Dpt_Name + "]");
        if (flag1)
          stringBuilder4.Append("/");
        else
          flag1 = true;
        stringBuilder4.Append("[부서:" + supplierPageBase.ParamBackup.Dpt_Name + "]");
      }
      if (supplierPageBase.ParamBackup.CategoryNameIn.Length > 0)
      {
        stringBuilder2.Append("[분류:" + supplierPageBase.ParamBackup.CategoryNameIn + "]");
        if (flag1)
          stringBuilder4.Append("/");
        else
          flag1 = true;
        stringBuilder4.Append("[분류:" + supplierPageBase.ParamBackup.Dpt_Name + "]");
      }
      if (supplierPageBase.ParamBackup.BookmarkGoodsID > 0)
      {
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.BookmarkGoodsName + "]");
        if (flag1)
          stringBuilder4.Append("\n");
        stringBuilder4.Append("[관심상품:" + supplierPageBase.ParamBackup.BookmarkGoodsName + "]");
      }
      if (!supplierPageBase.ParamBackup.IsTaxFree || !supplierPageBase.ParamBackup.IsTax)
      {
        bool flag2 = false;
        stringBuilder2.Append("[");
        stringBuilder6.Append("[");
        if (supplierPageBase.ParamBackup.IsTaxFree)
        {
          if (flag2)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          else
            flag2 = true;
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsTax)
        {
          if (flag2)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
        }
        stringBuilder2.Append("]");
        stringBuilder6.Append("]");
      }
      if (!supplierPageBase.ParamBackup.IsStockUnitAmount || !supplierPageBase.ParamBackup.IsStockUnitQty || !supplierPageBase.ParamBackup.IsStockUnitWeight)
      {
        bool flag3 = false;
        stringBuilder2.Append("[");
        stringBuilder6.Append("[");
        if (supplierPageBase.ParamBackup.IsStockUnitAmount)
        {
          if (flag3)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          else
            flag3 = true;
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsStockUnitQty)
        {
          if (flag3)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          else
            flag3 = true;
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsStockUnitWeight)
        {
          if (flag3)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
        }
        stringBuilder2.Append("]");
        stringBuilder6.Append("]");
      }
      if (!supplierPageBase.ParamBackup.IsSaleDirect || !supplierPageBase.ParamBackup.IsSaleSpe || !supplierPageBase.ParamBackup.IsSaleLea)
      {
        bool flag4 = false;
        stringBuilder2.Append("[");
        stringBuilder6.Append("[");
        if (supplierPageBase.ParamBackup.IsSaleDirect)
        {
          if (flag4)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          else
            flag4 = true;
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsSaleSpe)
        {
          if (flag4)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          else
            flag4 = true;
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsSaleLea)
        {
          if (flag4)
          {
            stringBuilder2.Append("/");
            stringBuilder6.Append(",");
          }
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
          // ISSUE: explicit non-virtual call
          stringBuilder6.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
        }
        stringBuilder2.Append("]");
        stringBuilder6.Append("]");
      }
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (supplierPageBase.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (supplierPageBase.Duplicator));
      creater.Orientation = PageOrientation.Landscape;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      creater.Arg = new TemplateFixedDocumentCreaterArg()
      {
        Title = __nonvirtual (supplierPageBase.MenuInfo).Title,
        Top1Left = stringBuilder3.ToString(),
        Top1Right = stringBuilder5.ToString(),
        Top2Left = stringBuilder4.ToString(),
        Top2Right = stringBuilder6.ToString(),
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (supplierPageBase.App).User.User.Source.emp_Name, (object) __nonvirtual (supplierPageBase.App).User.User.Source.emp_Code, (object) str),
        BottomRight = "UniBizSM : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (supplierPageBase.MenuInfo).Code;
      int count = supplierPageBase.Datas.Count;
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
        __nonvirtual (supplierPageBase.WindowManager)?.ShowDialog((object) viewModel);
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
      SupplierPageBase<T> supplierPageBase = this;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (supplierPageBase.ParamBackup.StoreCodeIn.Length > 0)
      {
        stringBuilder1.Append("[" + supplierPageBase.ParamBackup.StoreNameIn + "]");
        if (stringBuilder2.Length > 0)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.StoreNameIn + "]");
      }
      stringBuilder1.Append("[" + new DateTime?(supplierPageBase.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(supplierPageBase.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
      if (stringBuilder2.Length > 0)
        stringBuilder2.Append("/");
      stringBuilder2.Append("[" + new DateTime?(supplierPageBase.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(supplierPageBase.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
      if (!string.IsNullOrEmpty(supplierPageBase.ParamBackup.SupplierCodeIn))
      {
        stringBuilder1.Append("[" + supplierPageBase.ParamBackup.SupplierNameIn + "]");
        if (stringBuilder2.Length > 0)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.SupplierNameIn + "]");
      }
      if (!string.IsNullOrEmpty(supplierPageBase.ParamBackup.Keyword))
      {
        stringBuilder1.Append("[키워드:" + supplierPageBase.ParamBackup.Keyword + "]");
        if (stringBuilder2.Length > 0)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[키워드:" + supplierPageBase.ParamBackup.Keyword + "]");
      }
      if (!string.IsNullOrEmpty(supplierPageBase.ParamBackup.Dpt_Name))
      {
        stringBuilder1.Append("[부서:" + supplierPageBase.ParamBackup.Dpt_Name + "]");
        if (stringBuilder2.Length > 0)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.Dpt_Name + "]");
      }
      if (!string.IsNullOrEmpty(supplierPageBase.ParamBackup.CategoryNameIn))
      {
        stringBuilder1.Append("[분류:" + supplierPageBase.ParamBackup.CategoryNameIn + "]");
        if (stringBuilder2.Length > 0)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.CategoryNameIn + "]");
      }
      if (supplierPageBase.ParamBackup.BookmarkGoodsID > 0)
      {
        stringBuilder1.Append("[" + supplierPageBase.ParamBackup.BookmarkGoodsName + "]");
        if (stringBuilder2.Length > 0)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[" + supplierPageBase.ParamBackup.BookmarkGoodsName + "]");
      }
      if (!supplierPageBase.ParamBackup.IsTaxFree || !supplierPageBase.ParamBackup.IsTax)
      {
        stringBuilder1.Append("[");
        bool flag = false;
        if (supplierPageBase.ParamBackup.IsTaxFree)
        {
          if (flag)
            stringBuilder1.Append("/");
          else
            flag = true;
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][2]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsTax)
        {
          if (flag)
            stringBuilder1.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.TaxDiv][1]?.comm_TypeNoMemo);
        }
        stringBuilder1.Append("]");
      }
      if (!supplierPageBase.ParamBackup.IsStockUnitAmount || !supplierPageBase.ParamBackup.IsStockUnitQty || !supplierPageBase.ParamBackup.IsStockUnitWeight)
      {
        stringBuilder1.Append("[");
        bool flag = false;
        if (supplierPageBase.ParamBackup.IsStockUnitAmount)
        {
          if (flag)
            stringBuilder1.Append("/");
          else
            flag = true;
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][1]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsStockUnitQty)
        {
          if (flag)
            stringBuilder1.Append("/");
          else
            flag = true;
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][2]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsStockUnitWeight)
        {
          if (flag)
            stringBuilder1.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.StockUnit][3]?.comm_TypeNoMemo);
        }
        stringBuilder1.Append("]");
      }
      if (!supplierPageBase.ParamBackup.IsSaleDirect || !supplierPageBase.ParamBackup.IsSaleSpe || !supplierPageBase.ParamBackup.IsSaleLea)
      {
        stringBuilder1.Append("[");
        bool flag = false;
        if (supplierPageBase.ParamBackup.IsSaleDirect)
        {
          if (flag)
            stringBuilder1.Append("/");
          else
            flag = true;
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][1]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsSaleSpe)
        {
          if (flag)
            stringBuilder1.Append("/");
          else
            flag = true;
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][2]?.comm_TypeNoMemo);
        }
        if (supplierPageBase.ParamBackup.IsSaleLea)
        {
          if (flag)
            stringBuilder1.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder1.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
          if (stringBuilder2.Length > 0)
            stringBuilder2.Append("/");
          // ISSUE: explicit non-virtual call
          stringBuilder2.Append(__nonvirtual (supplierPageBase.App).Sys.CommonCodes[CommonCodeTypes.SupplierType][3]?.comm_TypeNoMemo);
        }
        stringBuilder1.Append("]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (supplierPageBase.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (supplierPageBase.Exporter), __nonvirtual (supplierPageBase.MenuInfo).Title, stringBuilder2.ToString(), __nonvirtual (supplierPageBase.MenuInfo).Code, applyRowCnt: supplierPageBase.Datas.Count, memo: stringBuilder1.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (supplierPageBase.WindowManager)?.ShowDialog((object) viewModel);
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

    public class InitParam : ParamBase<SupplierPageBase<T>.InitParam>
    {
      private bool _IsStoreTotal;
      private CommonCodeView _CategoryDepth;
      private bool _IsTax = true;
      private bool _IsTaxFree = true;
      private bool _IsSaleDirect = true;
      private bool _IsSaleSpe;
      private bool _IsSaleLea;
      private bool _IsStockUnitAmount = true;
      private bool _IsStockUnitQty = true;
      private bool _IsStockUnitWeight = true;
      private int _ExpandsCount = 2;

      public bool IsStoreTotal
      {
        get => this._IsStoreTotal;
        set
        {
          this._IsStoreTotal = value;
          this.NotifyOfPropertyChange(nameof (IsStoreTotal));
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

    public class SearchParam : ParamBase<SupplierPageBase<T>.SearchParam>
    {
      private string keyword = string.Empty;
      private string _StoreCodeIn = string.Empty;
      private string _StoreNameIn = string.Empty;
      private bool _IsStoreTotal;
      private DateTime _DtStart = DateTime.Now;
      private DateTime _DtEnd = DateTime.Now;
      private string _SupplierCodeIn = string.Empty;
      private string _SupplierNameIn = string.Empty;
      private int _Dpt_ID;
      private string _Dpt_Name = string.Empty;
      private int _Dpt_Depth;
      private string _CategoryNameIn = string.Empty;
      private string _CategoryCodeInLv1 = string.Empty;
      private string _CategoryCodeInLv2 = string.Empty;
      private string _CategoryCodeInLv3 = string.Empty;
      private CommonCodeView _CategoryDepth;
      private int _IsBookmarkGoodsID;
      private string _BookmarkGoodsName = string.Empty;
      private bool _IsTax = true;
      private bool _IsTaxFree = true;
      private bool _IsSaleDirect = true;
      private bool _IsSaleSpe;
      private bool _IsSaleLea;
      private bool _IsStockUnitAmount = true;
      private bool _IsStockUnitQty = true;
      private bool _IsStockUnitWeight = true;
      private int _ExpandsCount = 2;

      public string Keyword
      {
        get => this.keyword;
        set
        {
          this.keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public string StoreCodeIn
      {
        get => this._StoreCodeIn;
        set
        {
          this._StoreCodeIn = value;
          this.NotifyOfPropertyChange(nameof (StoreCodeIn));
        }
      }

      public string StoreNameIn
      {
        get => this._StoreNameIn;
        set
        {
          this._StoreNameIn = value;
          this.NotifyOfPropertyChange(nameof (StoreNameIn));
        }
      }

      public bool IsStoreTotal
      {
        get => this._IsStoreTotal;
        set
        {
          this._IsStoreTotal = value;
          this.NotifyOfPropertyChange(nameof (IsStoreTotal));
        }
      }

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

      public string SupplierCodeIn
      {
        get => this._SupplierCodeIn;
        set
        {
          this._SupplierCodeIn = value;
          this.NotifyOfPropertyChange(nameof (SupplierCodeIn));
        }
      }

      public string SupplierNameIn
      {
        get => this._SupplierNameIn;
        set
        {
          this._SupplierNameIn = value;
          this.NotifyOfPropertyChange(nameof (SupplierNameIn));
        }
      }

      public int Dpt_ID
      {
        get => this._Dpt_ID;
        set
        {
          this._Dpt_ID = value;
          this.NotifyOfPropertyChange(nameof (Dpt_ID));
        }
      }

      public string Dpt_Name
      {
        get => this._Dpt_Name;
        set
        {
          this._Dpt_Name = value;
          this.NotifyOfPropertyChange(nameof (Dpt_Name));
        }
      }

      public int Dpt_Depth
      {
        get => this._Dpt_Depth;
        set
        {
          this._Dpt_Depth = value;
          this.NotifyOfPropertyChange(nameof (Dpt_Depth));
        }
      }

      public string CategoryNameIn
      {
        get => this._CategoryNameIn;
        set
        {
          this._CategoryNameIn = value;
          this.NotifyOfPropertyChange(nameof (CategoryNameIn));
        }
      }

      public string CategoryCodeInLv1
      {
        get => this._CategoryCodeInLv1;
        set
        {
          this._CategoryCodeInLv1 = value;
          this.NotifyOfPropertyChange(nameof (CategoryCodeInLv1));
        }
      }

      public string CategoryCodeInLv2
      {
        get => this._CategoryCodeInLv2;
        set
        {
          this._CategoryCodeInLv2 = value;
          this.NotifyOfPropertyChange(nameof (CategoryCodeInLv2));
        }
      }

      public string CategoryCodeInLv3
      {
        get => this._CategoryCodeInLv3;
        set
        {
          this._CategoryCodeInLv3 = value;
          this.NotifyOfPropertyChange(nameof (CategoryCodeInLv3));
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

      public int BookmarkGoodsID
      {
        get => this._IsBookmarkGoodsID;
        set
        {
          this._IsBookmarkGoodsID = value;
          this.NotifyOfPropertyChange(nameof (BookmarkGoodsID));
        }
      }

      public string BookmarkGoodsName
      {
        get => this._BookmarkGoodsName;
        set
        {
          this._BookmarkGoodsName = value;
          this.NotifyOfPropertyChange(nameof (BookmarkGoodsName));
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

    public class SumParam : ParamBase<SupplierPageBase<T>.SumParam>
    {
      private SaleByDayDateSupplier _sum = new SaleByDayDateSupplier();
      private double _sbd_ProfitRule;
      private double _sbd_SlipCustomerPrice;
      private double _sbd_CategoryCustomerPrice;
      private double _sbd_GoodsCustomerPrice;

      public SaleByDayDateSupplier Sum
      {
        get => this._sum;
        set
        {
          this._sum = value;
          this.NotifyOfPropertyChange(nameof (Sum));
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
