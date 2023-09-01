// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Employee.PageAuthSupplierMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.EmpAuthority;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Composition;
using UniBizBO.Services.Board;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Employee
{
  public class PageAuthSupplierMPartVM : MPartBase<
  #nullable disable
  EmployeeView>
  {
    private BindableCollection<EmpAuthoritySupplier> _AuthSupplierDatas = new BindableCollection<EmpAuthoritySupplier>();
    private bool _IsAdmin;

    public IReadOnlyDictionary<string, TableColumnInfo> AuthSupplierHeader => this.App.Sys?.TableColumns?.GetDictionary<EmpAuthoritySupplier>();

    public BindableCollection<EmpAuthoritySupplier> AuthSupplierDatas
    {
      get => this._AuthSupplierDatas;
      set
      {
        this._AuthSupplierDatas = value;
        this.NotifyOfPropertyChange(nameof (AuthSupplierDatas));
      }
    }

    public bool IsAdmin
    {
      get => this._IsAdmin;
      set
      {
        this._IsAdmin = value;
        this.NotifyOfPropertyChange(nameof (IsAdmin));
      }
    }

    public PageAuthSupplierMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.AuthSupplierDatas.Clear();
      this.IsAdmin = this.App.User.User.Source.IsAdmin || this.App.User.User.Source.IsEmployeePermitSave;
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.PartContainer.IsCreateMode)
        return;
      this.SearchAsync(this.WorkDataT.CurrentT.emp_Code);
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageAuthSupplierMPartVM authSupplierMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await authSupplierMpartVm.\u003C\u003En__0(p_param);
      authSupplierMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void SearchAsync(int p_emp_Code)
    {
      PageAuthSupplierMPartVM authSupplierMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (authSupplierMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (authSupplierMpartVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          IList<EmpAuthoritySupplier> data = (await EmployeeRestServer.GetEmpAuthoritySupplierList(authSupplierMpartVm.LogInPackInfo.sendType, authSupplierMpartVm.LogInPackInfo.siteID, p_emp_Code, 0, __nonvirtual (authSupplierMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<IList<EmpAuthoritySupplier>>>((UniBizHttpClient) __nonvirtual (authSupplierMpartVm.App).Api)).GetData<IList<EmpAuthoritySupplier>>();
          authSupplierMpartVm.AuthSupplierDatas.Clear();
          authSupplierMpartVm.AuthSupplierDatas.AddRange((IEnumerable<EmpAuthoritySupplier>) data);
          if (data.Count > 0)
            authSupplierMpartVm.OnAppWinMsgArgsRequested("GRID");
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (authSupplierMpartVm.Container)).Set(__nonvirtual (authSupplierMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void PostAsync(EmpAuthoritySupplier p_data, bool pListAdd)
    {
      PageAuthSupplierMPartVM authSupplierMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (authSupplierMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (authSupplierMpartVm.Job).CreateJob("추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<EmpAuthoritySupplier> returnAsync = await EmployeeRestServer.PostEmpAuthoritySupplier(authSupplierMpartVm.LogInPackInfo.sendType, authSupplierMpartVm.LogInPackInfo.siteID, p_data.ea_EmpCode, p_data.ea_AuthValue, 0, __nonvirtual (authSupplierMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<EmpAuthoritySupplier>>((UniBizHttpClient) __nonvirtual (authSupplierMpartVm.App).Api);
          if (!returnAsync.isSuccess)
            throw new Exception(returnAsync.message);
          p_data.eas_status = p_data.ea_EmpCode;
          if (pListAdd)
            authSupplierMpartVm.AuthSupplierDatas.Add(p_data);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (authSupplierMpartVm.Container)).Set(__nonvirtual (authSupplierMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void DeleteAsync(EmpAuthoritySupplier p_data)
    {
      PageAuthSupplierMPartVM authSupplierMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (authSupplierMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (authSupplierMpartVm.Job).CreateJob("삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.DeleteEmpAuthoritySupplier(authSupplierMpartVm.LogInPackInfo.sendType, authSupplierMpartVm.LogInPackInfo.siteID, p_data.ea_EmpCode, p_data.ea_AuthValue, 0, __nonvirtual (authSupplierMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<EmpAuthoritySupplier>>((UniBizHttpClient) __nonvirtual (authSupplierMpartVm.App).Api)).GetData<EmpAuthoritySupplier>();
          p_data.eas_status = 0;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (authSupplierMpartVm.Container)).Set(__nonvirtual (authSupplierMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand CmdSearchSupplierList => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchSupplierList()),
        ExecuteAction = (Action<object>) (_ => this.SearchSupplierList())
      };
    }), nameof (CmdSearchSupplierList));

    public bool CanSearchSupplierList() => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin;

    public void SearchSupplierList()
    {
      if (!this.CanSearchSupplierList())
        return;
      if (this.PartContainer.IsCreateMode)
      {
        int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title + " 오류", "신규 등록 저장후 조회 가능 합니다.").ShowDialog();
      }
      SupplierCommonBoardVM viewModel = this.Container.Get<SupplierCommonBoardVM>();
      viewModel.IsMultiSelectMode = false;
      viewModel.Confirmed += new EventHandler<CommonBoardBase<SupplierView>>(this.SupplierListConfirmed);
      this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
    }

    private void SupplierListConfirmed(object sender, CommonBoardBase<SupplierView> e)
    {
      if (e.SelectedData.su_Supplier == 0)
        return;
      EmpAuthoritySupplier p_data = new EmpAuthoritySupplier();
      p_data.row_number = this.AuthSupplierDatas.Count + 1;
      p_data.ea_AuthType = 22;
      p_data.ea_EmpCode = this.WorkDataT.CurrentT.emp_Code;
      p_data.ea_AuthValue = e.SelectedData.su_Supplier.ToString();
      p_data.ea_SiteID = e.SelectedData.su_SiteID;
      p_data.eas_status = this.WorkDataT.CurrentT.emp_Code;
      p_data.su_Supplier = e.SelectedData.su_Supplier;
      p_data.su_SupplierName = e.SelectedData.su_SupplierName;
      p_data.su_SupplierViewCode = e.SelectedData.su_SupplierViewCode;
      p_data.su_SupplierType = e.SelectedData.su_SupplierType;
      p_data.su_UseYn = e.SelectedData.su_UseYn;
      p_data.su_BizNo = e.SelectedData.su_BizNo;
      p_data.su_BizCeo = e.SelectedData.su_BizCeo;
      this.PostAsync(p_data, true);
    }

    public WpfCommand<EmpAuthoritySupplier> CmdSupplierAuth => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpAuthoritySupplier>>((Func<WpfCommand<EmpAuthoritySupplier>>) (() =>
    {
      return new WpfCommand<EmpAuthoritySupplier>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<EmpAuthoritySupplier, bool>) (item => this.CanSupplierAuth(item)),
        ExecuteAction = (Action<EmpAuthoritySupplier>) (item => this.SupplierAuthAuth(item))
      };
    }), nameof (CmdSupplierAuth));

    public bool CanSupplierAuth(EmpAuthoritySupplier p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null;

    public void SupplierAuthAuth(EmpAuthoritySupplier p_item)
    {
      if (p_item.eas_status > 0)
        this.DeleteAsync(p_item);
      else
        this.PostAsync(p_item, false);
    }

    public bool CanDataOpen(EmpAuthoritySupplier item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && item != null;

    public void DataOpen(EmpAuthoritySupplier item)
    {
      if (!this.CanDataOpen(item))
        return;
      if (item.eas_status > 0)
        this.DeleteAsync(item);
      else
        this.PostAsync(item, false);
    }

    public WpfCommand<EmpAuthoritySupplier> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpAuthoritySupplier>>((Func<WpfCommand<EmpAuthoritySupplier>>) (() => new WpfCommand<EmpAuthoritySupplier>().AutoRefreshOn<WpfCommand<EmpAuthoritySupplier>>().ApplyCanExecute<EmpAuthoritySupplier>(new Func<EmpAuthoritySupplier, bool>(this.CanDataOpen)).ApplyExecute<EmpAuthoritySupplier>(new Action<EmpAuthoritySupplier>(this.DataOpen))), nameof (CmdDataOpen));

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }
  }
}
