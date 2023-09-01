// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Employee.PageAuthMPartVM
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth;
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
  public class PageAuthMPartVM : MPartBase<
  #nullable disable
  EmployeeView>
  {
    private BindableCollection<EmpWorkAuth1> _Auth1Datas = new BindableCollection<EmpWorkAuth1>();
    private BindableCollection<EmpWorkAuth2> _Auth2Datas = new BindableCollection<EmpWorkAuth2>();
    private BindableCollection<EmpWorkAuth3> _Auth3Datas = new BindableCollection<EmpWorkAuth3>();
    private bool _IsAdmin;

    public IReadOnlyDictionary<string, TableColumnInfo> Auth1Header => this.App.Sys?.TableColumns?.GetDictionary<EmpWorkAuth1>();

    public IReadOnlyDictionary<string, TableColumnInfo> Auth2Header => this.App.Sys?.TableColumns?.GetDictionary<EmpWorkAuth2>();

    public IReadOnlyDictionary<string, TableColumnInfo> Auth3Header => this.App.Sys?.TableColumns?.GetDictionary<EmpWorkAuth2>();

    public BindableCollection<EmpWorkAuth1> Auth1Datas
    {
      get => this._Auth1Datas;
      set
      {
        this._Auth1Datas = value;
        this.NotifyOfPropertyChange(nameof (Auth1Datas));
      }
    }

    public BindableCollection<EmpWorkAuth2> Auth2Datas
    {
      get => this._Auth2Datas;
      set
      {
        this._Auth2Datas = value;
        this.NotifyOfPropertyChange(nameof (Auth2Datas));
      }
    }

    public BindableCollection<EmpWorkAuth3> Auth3Datas
    {
      get => this._Auth3Datas;
      set
      {
        this._Auth3Datas = value;
        this.NotifyOfPropertyChange(nameof (Auth3Datas));
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

    public PageAuthMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.Auth1Datas.Clear();
      this.Auth2Datas.Clear();
      this.Auth3Datas.Clear();
      this.IsAdmin = this.App.User.User.Source.IsAdmin || this.App.User.User.Source.IsEmployeePermitSave;
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.PartContainer.IsCreateMode)
        return;
      this.SearchAsync(this.WorkDataT.CurrentT.emp_Code);
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageAuthMpartVm.\u003C\u003En__0(p_param);
      pageAuthMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void SearchAsync(int p_emp_Code)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          IList<EmpWorkAuth1> data1 = (await EmployeeRestServer.GetEmpWorkAuth1List(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_emp_Code, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<IList<EmpWorkAuth1>>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<IList<EmpWorkAuth1>>();
          pageAuthMpartVm.Auth1Datas.Clear();
          pageAuthMpartVm.Auth1Datas.AddRange((IEnumerable<EmpWorkAuth1>) data1);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          IList<EmpWorkAuth2> data2 = (await EmployeeRestServer.GetEmpWorkAuth2List(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_emp_Code, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<IList<EmpWorkAuth2>>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<IList<EmpWorkAuth2>>();
          pageAuthMpartVm.Auth2Datas.Clear();
          pageAuthMpartVm.Auth2Datas.AddRange((IEnumerable<EmpWorkAuth2>) data2);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          IList<EmpWorkAuth3> data3 = (await EmployeeRestServer.GetEmpWorkAuth3List(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_emp_Code, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<IList<EmpWorkAuth3>>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<IList<EmpWorkAuth3>>();
          pageAuthMpartVm.Auth3Datas.Clear();
          pageAuthMpartVm.Auth3Datas.AddRange((IEnumerable<EmpWorkAuth3>) data3);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void Auth1PostAsync(EmpWorkAuth1 p_data)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.PostEmpWorkAuth1(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_data.emp_Code, p_data.emp_TypeNo, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<EmpWorkAuth1>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<EmpWorkAuth1>();
          p_data.emp_ProgAuth |= p_data.emp_TypeNo;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void Auth2PostAsync(EmpWorkAuth2 p_data)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.PostEmpWorkAuth2(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_data.emp_Code, p_data.emp_TypeNo, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<EmpWorkAuth2>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<EmpWorkAuth2>();
          p_data.emp_ProgAuth |= p_data.emp_TypeNo;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void Auth3PostAsync(EmpWorkAuth3 p_data)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.PostEmpWorkAuth3(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_data.emp_Code, p_data.emp_TypeNo, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<EmpWorkAuth3>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<EmpWorkAuth3>();
          p_data.emp_ProgAuth |= p_data.emp_TypeNo;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void Auth1DeleteAsync(EmpWorkAuth1 p_data)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.DeleteEmpWorkAuth1(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_data.emp_Code, p_data.emp_TypeNo, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<EmpWorkAuth1>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<EmpWorkAuth1>();
          p_data.emp_ProgAuth &= ~p_data.emp_TypeNo;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void Auth2DeleteAsync(EmpWorkAuth2 p_data)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.DeleteEmpWorkAuth2(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_data.emp_Code, p_data.emp_TypeNo, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<EmpWorkAuth2>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<EmpWorkAuth2>();
          p_data.emp_ProgAuth &= ~p_data.emp_TypeNo;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void Auth3DeleteAsync(EmpWorkAuth3 p_data)
    {
      PageAuthMPartVM pageAuthMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (pageAuthMpartVm.PartContainer).IsCreateMode)
          throw new Exception("신규 등록 저장후 조회 가능 합니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageAuthMpartVm.Job).CreateJob("삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.DeleteEmpWorkAuth3(pageAuthMpartVm.LogInPackInfo.sendType, pageAuthMpartVm.LogInPackInfo.siteID, p_data.emp_Code, p_data.emp_TypeNo, 0, __nonvirtual (pageAuthMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<EmpWorkAuth3>>((UniBizHttpClient) __nonvirtual (pageAuthMpartVm.App).Api)).GetData<EmpWorkAuth3>();
          p_data.emp_ProgAuth &= ~p_data.emp_TypeNo;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageAuthMpartVm.Container)).Set(__nonvirtual (pageAuthMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand<EmpWorkAuth1> CmdEmployeeAuth1 => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpWorkAuth1>>((Func<WpfCommand<EmpWorkAuth1>>) (() =>
    {
      return new WpfCommand<EmpWorkAuth1>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<EmpWorkAuth1, bool>) (item => this.CanEmployeeAuth1(item)),
        ExecuteAction = (Action<EmpWorkAuth1>) (item => this.EmployeeAuth1(item))
      };
    }), nameof (CmdEmployeeAuth1));

    public bool CanEmployeeAuth1(EmpWorkAuth1 p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null && !p_item.emp_IsTypeNoFixed;

    public void EmployeeAuth1(EmpWorkAuth1 p_item)
    {
      if (p_item.emp_IsTypeNo)
        this.Auth1DeleteAsync(p_item);
      else
        this.Auth1PostAsync(p_item);
    }

    public WpfCommand<EmpWorkAuth2> CmdEmployeeAuth2 => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpWorkAuth2>>((Func<WpfCommand<EmpWorkAuth2>>) (() =>
    {
      return new WpfCommand<EmpWorkAuth2>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<EmpWorkAuth2, bool>) (item => this.CanEmployeeAuth2(item)),
        ExecuteAction = (Action<EmpWorkAuth2>) (item => this.EmployeeAuth2(item))
      };
    }), nameof (CmdEmployeeAuth2));

    public bool CanEmployeeAuth2(EmpWorkAuth2 p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null && !p_item.emp_IsTypeNoFixed;

    public void EmployeeAuth2(EmpWorkAuth2 p_item)
    {
      if (p_item.emp_IsTypeNo)
        this.Auth2DeleteAsync(p_item);
      else
        this.Auth2PostAsync(p_item);
    }

    public WpfCommand<EmpWorkAuth3> CmdEmployeeAuth3 => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpWorkAuth3>>((Func<WpfCommand<EmpWorkAuth3>>) (() =>
    {
      return new WpfCommand<EmpWorkAuth3>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<EmpWorkAuth3, bool>) (item => this.CanEmployeeAuth3(item)),
        ExecuteAction = (Action<EmpWorkAuth3>) (item => this.EmployeeAuth3(item))
      };
    }), nameof (CmdEmployeeAuth3));

    public bool CanEmployeeAuth3(EmpWorkAuth3 p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null && !p_item.emp_IsTypeNoFixed;

    public void EmployeeAuth3(EmpWorkAuth3 p_item)
    {
      if (p_item.emp_IsTypeNo)
        this.Auth3DeleteAsync(p_item);
      else
        this.Auth3PostAsync(p_item);
    }

    public bool CanDataOpen1(EmpWorkAuth1 p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null && !p_item.emp_IsTypeNoFixed;

    public void DataOpen1(EmpWorkAuth1 item)
    {
      if (!this.CanDataOpen1(item))
        return;
      if (item.emp_IsTypeNoFixed)
      {
        int num = (int) new CommonMsgVM(this.Container).Set("고정 권한", "고정 권한 변경 불가.").ShowDialog();
      }
      else if (item.emp_IsTypeNo)
        this.Auth1DeleteAsync(item);
      else
        this.Auth1PostAsync(item);
    }

    public WpfCommand<EmpWorkAuth1> CmdDataOpen1 => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpWorkAuth1>>((Func<WpfCommand<EmpWorkAuth1>>) (() => new WpfCommand<EmpWorkAuth1>().AutoRefreshOn<WpfCommand<EmpWorkAuth1>>().ApplyCanExecute<EmpWorkAuth1>(new Func<EmpWorkAuth1, bool>(this.CanDataOpen1)).ApplyExecute<EmpWorkAuth1>(new Action<EmpWorkAuth1>(this.DataOpen1))), nameof (CmdDataOpen1));

    public bool CanDataOpen2(EmpWorkAuth2 p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null && !p_item.emp_IsTypeNoFixed;

    public void DataOpen2(EmpWorkAuth2 item)
    {
      if (!this.CanDataOpen2(item))
        return;
      if (item.emp_IsTypeNo)
        this.Auth2DeleteAsync(item);
      else
        this.Auth2PostAsync(item);
    }

    public WpfCommand<EmpWorkAuth2> CmdDataOpen2 => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpWorkAuth2>>((Func<WpfCommand<EmpWorkAuth2>>) (() => new WpfCommand<EmpWorkAuth2>().AutoRefreshOn<WpfCommand<EmpWorkAuth2>>().ApplyCanExecute<EmpWorkAuth2>(new Func<EmpWorkAuth2, bool>(this.CanDataOpen2)).ApplyExecute<EmpWorkAuth2>(new Action<EmpWorkAuth2>(this.DataOpen2))), nameof (CmdDataOpen2));

    public bool CanDataOpen3(EmpWorkAuth3 p_item) => this.PartContainer != null && !this.PartContainer.IsCreateMode && this.IsAdmin && p_item != null && !p_item.emp_IsTypeNoFixed;

    public void DataOpen3(EmpWorkAuth3 item)
    {
      if (!this.CanDataOpen3(item))
        return;
      if (item.emp_IsTypeNo)
        this.Auth3DeleteAsync(item);
      else
        this.Auth3PostAsync(item);
    }

    public WpfCommand<EmpWorkAuth3> CmdDataOpen3 => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<EmpWorkAuth3>>((Func<WpfCommand<EmpWorkAuth3>>) (() => new WpfCommand<EmpWorkAuth3>().AutoRefreshOn<WpfCommand<EmpWorkAuth3>>().ApplyCanExecute<EmpWorkAuth3>(new Func<EmpWorkAuth3, bool>(this.CanDataOpen3)).ApplyExecute<EmpWorkAuth3>(new Action<EmpWorkAuth3>(this.DataOpen3))), nameof (CmdDataOpen3));

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }
  }
}
