// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Employee.EmployeeListPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers.Code.Employee;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Employee
{
  public class EmployeeListPageVM : PageBase<
  #nullable disable
  EmployeeView>, ISystemPage
  {
    private EmployeeListPageVM.InitParam _InitControlParam = new EmployeeListPageVM.InitParam();
    private EmployeeListPageVM.SearchParam param = new EmployeeListPageVM.SearchParam();
    private string _FooterRemark = string.Empty;
    private bool _IsOpenExcelPopup;

    [ManagedStatus]
    public EmployeeListPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public EmployeeListPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public EmployeeListPageVM.SearchParam ParamBackup { get; set; } = new EmployeeListPageVM.SearchParam();

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

    public bool IsOpenExcelPopup
    {
      get => this._IsOpenExcelPopup;
      set => this.SetAndNotify<bool>(ref this._IsOpenExcelPopup, value, nameof (IsOpenExcelPopup));
    }

    public EmployeeListPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      EmployeeListPageVM employeeListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      employeeListPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await employeeListPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await employeeListPageVm.CreateAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await employeeListPageVm.SearchAsync();
      if (!funcType.Equals((object) DefaultPageFunc.ExportExcel))
        return;
      employeeListPageVm.IsOpenExcelPopup = true;
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType)
    {
      if (funcType.Equals((object) DefaultPageFunc.Create))
        this.CanCreateCode();
      return true;
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
      if (this.App.User.User.Source.IsEmployeeSave)
        defaultPageFuncList.Add(DefaultPageFunc.Create);
      if (this.App.User.User.Source.IsPermitPrint)
        defaultPageFuncList.Add(DefaultPageFunc.Print);
      if (this.App.User.User.Source.IsPermitExcel)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      else if (this.App.User.User.Source.IsEmployeeSave)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl()
    {
      if (!this.InitControlParam.Use.HasValue)
        this.InitControlParam.Use = new bool?(true);
      this.Param.Use = this.InitControlParam.Use;
      this.InitCategoryViews();
    }

    protected virtual void InitCategoryViews()
    {
      if (this.DataView.CategoryViews.Count != 0)
        return;
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "Image",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "E1_TelInfo",
        IsDisplay = true
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "E1_Email",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "E1_AddrInfo",
        IsDisplay = false
      });
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<EmployeeListPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam() => this.InitControlParam.Use = this.Param.Use;

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      EmployeeListPageVM employeeListPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await employeeListPageVm.\u003C\u003En__1(p_param);
      employeeListPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsEmployeeSave;

    public async Task CreateAsync()
    {
      EmployeeListPageVM employeeListPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!employeeListPageVm.CanCreateCode() || __nonvirtual (employeeListPageVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 6)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageEmployeePartConVM viewModel = __nonvirtual (employeeListPageVm.Container).Get<PageEmployeePartConVM>();
        // ISSUE: explicit non-virtual call
        __nonvirtual (employeeListPageVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (employeeListPageVm.Container)).Set(__nonvirtual (employeeListPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task SearchAsync()
    {
      EmployeeListPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          string useYn = sender.Param.UseYn;
          string storeCodeIn = sender.Param.StoreCodeIn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          string emp_BaseStoreIn = storeCodeIn;
          string emp_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<EmployeeView>> success = (await EmployeeRestServer.GetEmployeeList(sendType, siteId, code, 0, emp_BaseStoreIn: emp_BaseStoreIn, emp_UseYn: emp_UseYn, is_thumb_image: true, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<EmployeeView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<EmployeeView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<EmployeeView>) success.response);
          if (sender.Datas.Count > 0)
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

    public bool CanDataOpen(EmployeeView item) => item != null;

    public void DataOpen(EmployeeView item)
    {
      if (item == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == item.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageEmployeePartConVM viewModel = this.Container.Get<PageEmployeePartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageEmployeePartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public WpfCommand<EmployeeView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmployeeView>>((Func<WpfCommand<EmployeeView>>) (() => new WpfCommand<EmployeeView>().AutoRefreshOn<WpfCommand<EmployeeView>>().ApplyCanExecute<EmployeeView>(new Func<EmployeeView, bool>(this.CanDataOpen)).ApplyExecute<EmployeeView>(new Action<EmployeeView>(this.DataOpen))), nameof (CmdDataOpen));

    public class InitParam : ParamBase<EmployeeListPageVM.InitParam>
    {
      private bool? use = new bool?(true);

      public bool? Use
      {
        get => this.use;
        set
        {
          this.use = value;
          this.NotifyOfPropertyChange(nameof (Use));
        }
      }
    }

    public class SearchParam : ParamBase<EmployeeListPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string keyword;
      private string _StoreCodeIn = string.Empty;
      private string _StoreNameIn = string.Empty;

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
    }
  }
}
