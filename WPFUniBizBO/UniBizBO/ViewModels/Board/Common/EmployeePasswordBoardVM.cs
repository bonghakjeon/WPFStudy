// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.EmployeePasswordBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizBO.Services.Board;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class EmployeePasswordBoardVM : CommonBoardBase<
  #nullable disable
  EmployeePassword>
  {
    private EnumEmployeePasswordType _PasswordType;
    private string _BeforePassword = string.Empty;
    private string _NewPassword = string.Empty;
    private int _EmpCode;
    private string _Title = "패스워드 변경";
    private string _TitleDesc = string.Empty;

    public EnumEmployeePasswordType PasswordType
    {
      get => this._PasswordType;
      set
      {
        this._PasswordType = value;
        this.NotifyOfPropertyChange(nameof (PasswordType));
      }
    }

    public string BeforePassword
    {
      get => this._BeforePassword;
      set
      {
        this._BeforePassword = value;
        this.NotifyOfPropertyChange(nameof (BeforePassword));
      }
    }

    public string NewPassword
    {
      get => this._NewPassword;
      set
      {
        this._NewPassword = value;
        this.NotifyOfPropertyChange(nameof (NewPassword));
      }
    }

    public int EmpCode
    {
      get => this._EmpCode;
      set
      {
        this._EmpCode = value;
        this.NotifyOfPropertyChange(nameof (EmpCode));
      }
    }

    public EmployeePasswordBoardVM(IContainer container)
      : base(container)
    {
    }

    public EmployeePasswordBoardVM Set(
      string pTitle = null,
      string pTitleDesc = null,
      EnumEmployeePasswordType pPasswordType = EnumEmployeePasswordType.NONE)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      if (pPasswordType != EnumEmployeePasswordType.NONE)
        this.PasswordType = pPasswordType;
      return this;
    }

    public EmployeePassword ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (EmployeePassword) null : this.SelectedData;
    }

    public IList<EmployeePassword> ShowDialog2Datas()
    {
      this.IsMultiSelectMode = true;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (IList<EmployeePassword>) null : (IList<EmployeePassword>) this.SelectedDatas;
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
    }

    public void SetParamBackup()
    {
    }

    public WpfCommand<string> CmdPasswordChange => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<string>>((Func<WpfCommand<string>>) (() => new WpfCommand<string>().AutoRefreshOn<WpfCommand<string>>().ApplyExecute<string>(new Func<string, Task>(this.ChangePasswordAsync))), nameof (CmdPasswordChange));

    public async Task ChangePasswordAsync(string p_type)
    {
      EmployeePasswordBoardVM employeePasswordBoardVm = this;
      JobProgressState j;
      if (employeePasswordBoardVm.NewPassword.Length == 0)
      {
        j = (JobProgressState) null;
      }
      else
      {
        // ISSUE: explicit non-virtual call
        j = __nonvirtual (employeePasswordBoardVm.Job).CreateJob("패스워드 변경", (string) null);
        try
        {
          // ISSUE: explicit non-virtual call
          int num = (await EmployeeRestServer.PutEmployeePassword(employeePasswordBoardVm.LogInPackInfo.sendType, employeePasswordBoardVm.LogInPackInfo.siteID, employeePasswordBoardVm.EmpCode, 0, 0, new EmployeePassword()
          {
            ChangedType = (int) employeePasswordBoardVm.PasswordType,
            emp_Code = employeePasswordBoardVm.EmpCode,
            emp_SiteID = employeePasswordBoardVm.LogInPackInfo.siteID,
            OldPass = employeePasswordBoardVm.BeforePassword,
            NewPass = employeePasswordBoardVm.NewPassword
          }).ExecuteToReturnAsync<UbRes<bool>>((UniBizHttpClient) __nonvirtual (employeePasswordBoardVm.App).Api)).GetSuccess<UbRes<bool>>().response ? 1 : 0;
          j = (JobProgressState) null;
        }
        finally
        {
          j?.Dispose();
        }
      }
    }

    public void OnWinClose() => this.RequestClose(new bool?());
  }
}
