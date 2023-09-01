// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Employee.PageAuthStoreMPartVM
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
using UniBizBO.Composition;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Employee
{
  public class PageAuthStoreMPartVM : MPartBase<
  #nullable disable
  EmployeeView>
  {
    private BindableCollection<EmpAuthorityStore> _AuthStoreDatas = new BindableCollection<EmpAuthorityStore>();
    private bool _IsAdmin;

    public IReadOnlyDictionary<string, TableColumnInfo> AuthStoreHeader => this.App.Sys?.TableColumns?.GetDictionary<EmpAuthorityStore>();

    public BindableCollection<EmpAuthorityStore> AuthStoreDatas
    {
      get => this._AuthStoreDatas;
      set
      {
        this._AuthStoreDatas = value;
        this.NotifyOfPropertyChange(nameof (AuthStoreDatas));
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

    public PageAuthStoreMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.IsAdmin = this.App.User.User.Source.IsAdmin || this.App.User.User.Source.IsEmployeePermitSave;
      this.AuthStoreDatas.Clear();
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.PartContainer.IsCreateMode)
        return;
      this.SearchAsync(this.WorkDataT.CurrentT.emp_Code);
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageAuthStoreMPartVM authStoreMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await authStoreMpartVm.\u003C\u003En__0(p_param);
      authStoreMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void SearchAsync(int p_emp_Code)
    {
      PageAuthStoreMPartVM authStoreMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (authStoreMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (authStoreMpartVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          IList<EmpAuthorityStore> data = (await EmployeeRestServer.GetEmpAuthorityStoreList(authStoreMpartVm.LogInPackInfo.sendType, authStoreMpartVm.LogInPackInfo.siteID, p_emp_Code, 0, __nonvirtual (authStoreMpartVm.MenuInfo).Code, config: 1).ExecuteToReturnAsync<UbRes<IList<EmpAuthorityStore>>>((UniBizHttpClient) __nonvirtual (authStoreMpartVm.App).Api)).GetData<IList<EmpAuthorityStore>>();
          authStoreMpartVm.AuthStoreDatas.Clear();
          authStoreMpartVm.AuthStoreDatas.AddRange((IEnumerable<EmpAuthorityStore>) data);
          if (data.Count > 0)
            authStoreMpartVm.OnAppWinMsgArgsRequested("GRID");
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (authStoreMpartVm.Container)).Set(__nonvirtual (authStoreMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void PostAsync(EmpAuthorityStore p_data)
    {
      PageAuthStoreMPartVM authStoreMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (authStoreMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (authStoreMpartVm.Job).CreateJob("추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.PostEmpAuthorityStore(authStoreMpartVm.LogInPackInfo.sendType, authStoreMpartVm.LogInPackInfo.siteID, p_data.ea_EmpCode, p_data.ea_AuthType, p_data.ea_AuthValue, 0, __nonvirtual (authStoreMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<EmpAuthorityStore>>((UniBizHttpClient) __nonvirtual (authStoreMpartVm.App).Api)).GetData<EmpAuthorityStore>();
          p_data.eas_status = p_data.ea_EmpCode;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (authStoreMpartVm.Container)).Set(__nonvirtual (authStoreMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void DeleteAsync(EmpAuthorityStore p_data)
    {
      PageAuthStoreMPartVM authStoreMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (authStoreMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (authStoreMpartVm.Job).CreateJob("삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.DeleteEmpAuthorityStore(authStoreMpartVm.LogInPackInfo.sendType, authStoreMpartVm.LogInPackInfo.siteID, p_data.ea_EmpCode, p_data.ea_AuthType, p_data.ea_AuthValue, 0, __nonvirtual (authStoreMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<EmpAuthorityStore>>((UniBizHttpClient) __nonvirtual (authStoreMpartVm.App).Api)).GetData<EmpAuthorityStore>();
          p_data.eas_status = 0;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (authStoreMpartVm.Container)).Set(__nonvirtual (authStoreMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand<EmpAuthorityStore> CmdStoreAuth => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpAuthorityStore>>((Func<WpfCommand<EmpAuthorityStore>>) (() =>
    {
      return new WpfCommand<EmpAuthorityStore>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<EmpAuthorityStore, bool>) (item => this.CanStoreAuth(item)),
        ExecuteAction = (Action<EmpAuthorityStore>) (item => this.StoreAuthAuth(item))
      };
    }), nameof (CmdStoreAuth));

    public bool CanStoreAuth(EmpAuthorityStore p_item) => this.PartContainer != null && this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null;

    public void StoreAuthAuth(EmpAuthorityStore p_item)
    {
      if (p_item.eas_status > 0)
        this.DeleteAsync(p_item);
      else
        this.PostAsync(p_item);
    }

    public bool CanDataOpen(EmpAuthorityStore item) => this.PartContainer != null && this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && item != null;

    public void DataOpen(EmpAuthorityStore item)
    {
      if (!this.CanDataOpen(item))
        return;
      if (item.eas_UseYn)
        this.DeleteAsync(item);
      else
        this.PostAsync(item);
    }

    public WpfCommand<EmpAuthorityStore> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpAuthorityStore>>((Func<WpfCommand<EmpAuthorityStore>>) (() => new WpfCommand<EmpAuthorityStore>().AutoRefreshOn<WpfCommand<EmpAuthorityStore>>().ApplyCanExecute<EmpAuthorityStore>(new Func<EmpAuthorityStore, bool>(this.CanDataOpen)).ApplyExecute<EmpAuthorityStore>(new Action<EmpAuthorityStore>(this.DataOpen))), nameof (CmdDataOpen));

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }
  }
}
