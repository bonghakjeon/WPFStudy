// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Sub.DataModLogPartVM
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
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Base;
using UniBizBO.ViewModels.Board.Sys;
using UniBizBO.ViewModels.Box;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Sub
{
  public class DataModLogPartVM : 
    SPartBase<
    #nullable disable
    DataModLogView>,
    IPrintElementDocumentVM,
    IExportUniDataGridVM
  {
    private DataModLogPartVM.SearchParam param = new DataModLogPartVM.SearchParam();

    public DataModLogPartVM(IContainer container)
      : base(container)
    {
    }

    public DataModLogPartVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public DataModLogPartVM.SearchParam ParamBackup { get; set; }

    public IUniDataGridViewer GridViewer { get; set; }

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
      this.Param.Emp_Code = this.App.User.User.Source.emp_Code;
      this.Param.Emp_Name = this.App.User.User.Source.emp_Name;
      this.Param.IsEmployee = this.App.User.User.Source.IsAdmin;
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

    public void SetParamBackup() => this.ParamBackup = ParamBase<DataModLogPartVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);

    private void SetParamInit()
    {
      switch (this.PartContainer.TableCode)
      {
        case TableCodeType.CommonCode:
          this.SetParamInit(false, false, 2, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]), Convert.ToInt64(this.PartContainer.WorkDataKeys[1]));
          break;
        case TableCodeType.StoreInfo:
          this.SetParamInit(false, false, 3, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.StoreGroupHeader:
          this.SetParamInit(false, false, 4, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.StoreGroupDetail:
          this.SetParamInit(false, false, 5, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Employee:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 6, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.ProgMenuProp:
          this.SetParamInit(false, false, 11, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.OuterConnAuth:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 14, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Maker:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 16, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.PayContion:
          this.SetParamInit(false, false, 21, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Supplier:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 22, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Dept:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 31, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Brand:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 33, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Category:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 34, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Goods:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(true, false, 36, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.ProgOption:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 46, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.PaymentMonth:
          this.SetParamInit(true, true, 72);
          break;
        case TableCodeType.MemberType:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 81, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.MemberGroup:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 83, p_dml_CodeStr: this.PartContainer.WorkDataKeys[0].ToString());
          break;
        case TableCodeType.MemberCalcCycle:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 87, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.MemberCycleStd:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 88);
          break;
        case TableCodeType.Campaign:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 102, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Promotion:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          this.SetParamInit(false, false, 107, Convert.ToInt32(this.PartContainer.WorkDataKeys[0]));
          break;
        case TableCodeType.Coupon:
          if (this.PartContainer.WorkDataKeys == null)
            break;
          long int32 = (long) Convert.ToInt32(this.PartContainer.WorkDataKeys[0]);
          this.SetParamInit(false, false, 111, Convert.ToInt32(this.PartContainer.WorkDataKeys[1]), int32);
          break;
      }
    }

    private void SetParamInit(
      bool p_is_store,
      bool p_is_stroe_search,
      int dml_TableSeq,
      int p_dml_CodeInt = 0,
      long p_dml_CodeLong = 0,
      string p_dml_CodeStr = "")
    {
      if (p_is_stroe_search)
      {
        this.Param.StoreCodeIn = this.App.User.User.Source.emp_BaseStore.ToString();
        this.Param.StoreNameIn = this.App.User.User.Source.si_StoreName;
      }
      this.Param.IsStore = new bool?(p_is_store);
      this.Param.TableSeq = dml_TableSeq;
      this.Param.CodeInt = p_dml_CodeInt;
      this.Param.CodeLong = p_dml_CodeLong;
      this.Param.CodeStr = p_dml_CodeStr;
    }

    public async Task SearchAsync()
    {
      DataModLogPartVM dataModLogPartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (dataModLogPartVm.PartContainer).IsCreateMode)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (dataModLogPartVm.Job).CreateJob("검색", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (dataModLogPartVm.PartContainer).TableCode != TableCodeType.PaymentMonth && __nonvirtual (dataModLogPartVm.PartContainer).TableCode != TableCodeType.MemberCycleStd && dataModLogPartVm.Param.CodeInt == 0 && dataModLogPartVm.Param.CodeLong == 0L && dataModLogPartVm.Param.CodeStr.Length == 0)
            throw new Exception("조건 부족.");
          dataModLogPartVm.Datas.Clear();
          dataModLogPartVm.SetParamInit();
          string sendType = dataModLogPartVm.LogInPackInfo.sendType;
          long siteId = dataModLogPartVm.LogInPackInfo.siteID;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (dataModLogPartVm.MenuInfo).Code;
          int codeInt = dataModLogPartVm.Param.CodeInt;
          long codeLong = dataModLogPartVm.Param.CodeLong;
          string codeStr = dataModLogPartVm.Param.CodeStr;
          int tableSeq = dataModLogPartVm.Param.TableSeq;
          long dml_SysDate_Begin = dataModLogPartVm.Param.DtStart.ToLong();
          long dml_SysDate_End = dataModLogPartVm.Param.DtEnd.ToLong();
          int dml_CodeInt = codeInt;
          long dml_CodeLong = codeLong;
          string dml_CodeStr = codeStr;
          int dml_TableSeq = tableSeq;
          string si_StoreCodeIn = dataModLogPartVm.Param.StoreCodeIn ?? string.Empty;
          int empCode = dataModLogPartVm.Param.Emp_Code;
          // ISSUE: explicit non-virtual call
          UbRes<IList<DataModLogView>> success = (await EmployeeRestServer.GetDataModLogList(sendType, siteId, 0, code, dml_SysDate_Begin: dml_SysDate_Begin, dml_SysDate_End: dml_SysDate_End, dml_CodeInt: dml_CodeInt, dml_CodeLong: dml_CodeLong, dml_CodeStr: dml_CodeStr, dml_TableSeq: dml_TableSeq, si_StoreCodeIn: si_StoreCodeIn, emp_Code: empCode).ExecuteToReturnAsync<UbRes<IList<DataModLogView>>>((UniBizHttpClient) __nonvirtual (dataModLogPartVm.App).Api)).GetSuccess<UbRes<IList<DataModLogView>>>();
          dataModLogPartVm.Datas.AddRange((IEnumerable<DataModLogView>) success.response);
          dataModLogPartVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (dataModLogPartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    public IElementDuplicator Duplicator { get; set; }

    public bool CanPrintDocument() => this.App.User.User.Source.IsPermitPrint && this.Datas.Count > 0;

    public async Task PrintDocumentAsync()
    {
      DataModLogPartVM dataModLogPartVm = this;
      if (!dataModLogPartVm.CanPrintDocument())
        return;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str1 = __nonvirtual (dataModLogPartVm.App).Sys.ProgOptions[0] != null ? "/" + __nonvirtual (dataModLogPartVm.App).Sys.ProgOptions[0].FirstOrDefault<ProgOptionView>().opt_Name : string.Empty;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      if (dataModLogPartVm.ParamBackup.StoreCodeIn.Length > 0)
      {
        stringBuilder5.Append("[" + dataModLogPartVm.ParamBackup.StoreNameIn + "]");
        stringBuilder1.Append("[" + dataModLogPartVm.ParamBackup.StoreNameIn + "]");
      }
      if (dataModLogPartVm.ParamBackup.IsDate)
      {
        stringBuilder5.Append("[기간 : " + new DateTime?(dataModLogPartVm.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(dataModLogPartVm.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
        stringBuilder2.Append("[기간 : " + new DateTime?(dataModLogPartVm.ParamBackup.DtStart).GetDateToStr("yyyy-MM-dd") + "~" + new DateTime?(dataModLogPartVm.ParamBackup.DtEnd).GetDateToStr("yyyy-MM-dd") + "]");
        stringBuilder2.Append("\n");
      }
      bool flag = false;
      if (dataModLogPartVm.ParamBackup.Emp_Code > 0)
      {
        stringBuilder5.Append("[" + dataModLogPartVm.ParamBackup.Emp_Name + "]");
        if (flag)
          stringBuilder2.Append("/");
        stringBuilder2.Append("[사원:" + dataModLogPartVm.ParamBackup.Emp_Name + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string str2 = __nonvirtual (dataModLogPartVm.PartContainer).ContentsDisplay + " - " + __nonvirtual (dataModLogPartVm.PartContainer).TableCode.ToDescription() + " 변경 로그";
      // ISSUE: explicit non-virtual call
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = __nonvirtual (dataModLogPartVm.Container).Get<UniDataGridPrintSysBoardVM>();
      // ISSUE: explicit non-virtual call
      TemplateFixedDocumentCreater creater = new TemplateFixedDocumentCreater(__nonvirtual (dataModLogPartVm.Duplicator));
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
        BottomLeft = string.Format("{0}({1}){2}", (object) __nonvirtual (dataModLogPartVm.App).User.User.Source.emp_Name, (object) __nonvirtual (dataModLogPartVm.App).User.User.Source.emp_Code, (object) str1),
        BottomRight = "UniBizBO : " + new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd HH:mm")
      };
      // ISSUE: explicit non-virtual call
      int code = __nonvirtual (dataModLogPartVm.MenuInfo).Code;
      int count = dataModLogPartVm.Datas.Count;
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
        __nonvirtual (dataModLogPartVm.WindowManager)?.ShowDialog((object) viewModel);
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
      DataModLogPartVM dataModLogPartVm = this;
      if (!dataModLogPartVm.CanExportExcel())
        return;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (dataModLogPartVm.ParamBackup.StoreCodeIn.Length > 0)
      {
        stringBuilder2.Append("[" + dataModLogPartVm.ParamBackup.StoreNameIn + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + dataModLogPartVm.ParamBackup.StoreNameIn + "]");
      }
      if (dataModLogPartVm.ParamBackup.IsDate)
      {
        stringBuilder2.Append("[" + new DateTime?(dataModLogPartVm.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(dataModLogPartVm.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + new DateTime?(dataModLogPartVm.ParamBackup.DtStart).GetDateToStr("yyMMdd") + "~" + new DateTime?(dataModLogPartVm.ParamBackup.DtEnd).GetDateToStr("yyMMdd") + "]");
      }
      if (dataModLogPartVm.ParamBackup.Emp_Code > 0)
      {
        stringBuilder2.Append("[" + dataModLogPartVm.ParamBackup.Emp_Name + "]");
        if (stringBuilder1.Length > 0)
          stringBuilder1.Append("/");
        stringBuilder1.Append("[" + dataModLogPartVm.ParamBackup.Emp_Name + "]");
      }
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      string title = __nonvirtual (dataModLogPartVm.PartContainer).ContentsDisplay + " - " + __nonvirtual (dataModLogPartVm.PartContainer).TableCode.ToDescription() + " 변경 로그";
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      DataGridExportSysBoardVM viewModel = __nonvirtual (dataModLogPartVm.Container).Get<DataGridExportSysBoardVM>().Set(__nonvirtual (dataModLogPartVm.Exporter), title, stringBuilder1.ToString(), propInfoCode: __nonvirtual (dataModLogPartVm.MenuInfo).Code, applyRowCnt: dataModLogPartVm.Datas.Count, memo: stringBuilder2.ToString(), memo2: string.Empty);
      object obj = (object) null;
      int num = 0;
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (dataModLogPartVm.WindowManager)?.ShowDialog((object) viewModel);
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

    public class SearchParam : ParamBase<DataModLogPartVM.SearchParam>
    {
      private int _ExpandsCount = 2;
      private string keyword;
      private bool _IsDate = true;
      private DateTime _DtStart = DateTime.Now.ToFirstDateOfMonth();
      private DateTime _DtEnd = DateTime.Now;
      private bool? _IsStore = new bool?(false);
      private string _StoreCodeIn = string.Empty;
      private string _StoreNameIn = string.Empty;
      private bool _IsEmployee;
      private int _Emp_Code;
      private string _Emp_Name = string.Empty;
      private int _CodeInt;
      private long _CodeLong;
      private string _CodeStr = string.Empty;
      private int _TableSeq;

      public int ExpandsCount
      {
        get => this._ExpandsCount;
        set
        {
          this._ExpandsCount = value;
          this.NotifyOfPropertyChange(nameof (ExpandsCount));
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

      public bool IsDate
      {
        get => this._IsDate;
        set
        {
          this._IsDate = value;
          this.NotifyOfPropertyChange(nameof (IsDate));
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

      public bool? IsStore
      {
        get => this._IsStore;
        set
        {
          this._IsStore = value;
          this.NotifyOfPropertyChange(nameof (IsStore));
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

      public bool IsEmployee
      {
        get => this._IsEmployee;
        set
        {
          this._IsEmployee = value;
          this.NotifyOfPropertyChange(nameof (IsEmployee));
        }
      }

      public int Emp_Code
      {
        get => this._Emp_Code;
        set
        {
          this._Emp_Code = value;
          this.NotifyOfPropertyChange(nameof (Emp_Code));
        }
      }

      public string Emp_Name
      {
        get => this._Emp_Name;
        set
        {
          this._Emp_Name = value;
          this.NotifyOfPropertyChange(nameof (Emp_Name));
        }
      }

      public int CodeInt
      {
        get => this._CodeInt;
        set
        {
          this._CodeInt = value;
          this.NotifyOfPropertyChange(nameof (CodeInt));
        }
      }

      public long CodeLong
      {
        get => this._CodeLong;
        set
        {
          this._CodeLong = value;
          this.NotifyOfPropertyChange(nameof (CodeLong));
        }
      }

      public string CodeStr
      {
        get => this._CodeStr;
        set
        {
          this._CodeStr = value;
          this.NotifyOfPropertyChange(nameof (CodeStr));
        }
      }

      public int TableSeq
      {
        get => this._TableSeq;
        set
        {
          this._TableSeq = value;
          this.NotifyOfPropertyChange(nameof (TableSeq));
        }
      }
    }
  }
}
