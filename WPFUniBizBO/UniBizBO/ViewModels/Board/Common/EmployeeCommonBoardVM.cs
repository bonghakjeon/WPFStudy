// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.EmployeeCommonBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers.Code.Employee;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class EmployeeCommonBoardVM : CommonBoardBase<
  #nullable disable
  EmployeeView>
  {
    private string _Title = "사원조회";
    private string _TitleDesc = string.Empty;
    private EmployeeCommonBoardVM.InitParam _InitControlParam = new EmployeeCommonBoardVM.InitParam();
    private EmployeeCommonBoardVM.SearchParam param = new EmployeeCommonBoardVM.SearchParam();

    public EmployeeCommonBoardVM(IContainer container)
      : base(container)
    {
      this.Param.Use = new bool?(true);
    }

    public EmployeeCommonBoardVM Set(string pTitle = null, string pTitleDesc = null)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      return this;
    }

    public EmployeeView ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (EmployeeView) null : this.SelectedData;
    }

    public IList<EmployeeView> ShowDialog2Datas()
    {
      this.IsMultiSelectMode = true;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (IList<EmployeeView>) null : (IList<EmployeeView>) this.SelectedDatas;
    }

    public string Title
    {
      get => this._Title;
      set
      {
        this._Title = value;
        this.NotifyOfPropertyChange(nameof (Title));
      }
    }

    public string TitleDesc
    {
      get => this._TitleDesc;
      set
      {
        this._TitleDesc = value;
        this.NotifyOfPropertyChange(nameof (TitleDesc));
      }
    }

    [ManagedStatus]
    public EmployeeCommonBoardVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public EmployeeCommonBoardVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public override void OnQueryDefaultFunc(DefaultBoardFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (funcType.Equals((object) DefaultBoardFunc.Search))
        this.SearchAsync();
      if (!funcType.Equals((object) DefaultBoardFunc.Create))
        return;
      this.CreateCodeAsync();
    }

    public override bool OnQueryCanDefaultFunc(DefaultBoardFunc funcType)
    {
      bool flag = base.OnQueryCanDefaultFunc(funcType);
      if (funcType.Equals((object) DefaultBoardFunc.Create))
        flag = this.CanCreateCode();
      return flag;
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      List<DefaultBoardFunc> defaultBoardFuncList = new List<DefaultBoardFunc>()
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
      if (this.App.User.User.Source.IsMasterCommonSave)
        defaultBoardFuncList.Add(DefaultBoardFunc.Create);
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) defaultBoardFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl()
    {
      if (!this.InitControlParam.Use.HasValue)
        this.InitControlParam.Use = new bool?(true);
      this.Param.Use = this.InitControlParam.Use;
    }

    public void SetParamBackup() => this.InitControlParam.Use = this.Param.Use;

    public void OnWinClose() => this.RequestClose(new bool?());

    public bool CanCreateCode() => this.App.User.User.Source.IsEmployeeSave;

    public async Task CreateCodeAsync()
    {
      EmployeeCommonBoardVM employeeCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!employeeCommonBoardVm.CanCreateCode() || __nonvirtual (employeeCommonBoardVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 6)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageEmployeePartConVM viewModel = __nonvirtual (employeeCommonBoardVm.Container).Get<PageEmployeePartConVM>();
        if (viewModel == null)
          return;
        viewModel.WorkDataKeys = (object[]) null;
        // ISSUE: explicit non-virtual call
        __nonvirtual (employeeCommonBoardVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public async Task SearchAsync(JobProgressState pj = null)
    {
      EmployeeCommonBoardVM employeeCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (pj ?? __nonvirtual (employeeCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          string sendType = employeeCommonBoardVm.LogInPackInfo.sendType;
          long siteId = employeeCommonBoardVm.LogInPackInfo.siteID;
          string useYn = employeeCommonBoardVm.Param.UseYn;
          string storeCodeIn = employeeCommonBoardVm.Param.StoreCodeIn;
          string emp_UseYn = useYn;
          string keyword = employeeCommonBoardVm.Param.Keyword;
          // ISSUE: explicit non-virtual call
          IList<EmployeeView> data = (await EmployeeRestServer.GetEmployeeList(sendType, siteId, 0, 0, emp_BaseStoreIn: storeCodeIn, emp_UseYn: emp_UseYn, KeyWord: keyword).ExecuteToReturnAsync<UbRes<IList<EmployeeView>>>((UniBizHttpClient) __nonvirtual (employeeCommonBoardVm.App).Api)).GetData<IList<EmployeeView>>();
          employeeCommonBoardVm.Datas.Clear();
          employeeCommonBoardVm.Datas.AddRange((IEnumerable<EmployeeView>) data);
          if (data.Count > 0)
            employeeCommonBoardVm.OnAppWinMsgArgsRequested("GRID");
          employeeCommonBoardVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (employeeCommonBoardVm.Container)).SetException(ex).ShowDialog();
      }
    }

    public bool CanDataDbClick(EmployeeView item) => item != null;

    public void DataDbClick(EmployeeView item)
    {
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<EmployeeView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmployeeView>>((Func<WpfCommand<EmployeeView>>) (() => new WpfCommand<EmployeeView>().AutoRefreshOn<WpfCommand<EmployeeView>>().ApplyCanExecute<EmployeeView>(new Func<EmployeeView, bool>(this.CanDataDbClick)).ApplyExecute<EmployeeView>(new Action<EmployeeView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      EmployeeCommonBoardVM employeeCommonBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await employeeCommonBoardVm.\u003C\u003En__0(p_param);
      employeeCommonBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public class InitParam : ParamBase<EmployeeCommonBoardVM.InitParam>
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

    public class SearchParam : ParamBase<EmployeeCommonBoardVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string keyword = string.Empty;
      private string _StoreCodeIn;
      private string _StoreNameIn;

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
