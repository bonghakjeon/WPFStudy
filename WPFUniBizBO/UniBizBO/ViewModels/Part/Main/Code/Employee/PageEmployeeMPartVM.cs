// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Employee.PageEmployeeMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.Win32;
using Models.Addr.MoisGoKr;
using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.EmpImage;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Services.Board;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Employee
{
  public class PageEmployeeMPartVM : MPartBase<
  #nullable disable
  EmployeeView>
  {
    private IList<CommonCodeView> _MenuGroupList;
    private IList<CommonCodeView> _PositionList;
    private IList<CommonCodeView> _GenderList;
    private bool _IsAdmin;
    private bool _IsAdminOrMine;
    private bool _IsCreateMode;

    public IList<CommonCodeView> MenuGroupList
    {
      get => this._MenuGroupList;
      set
      {
        this._MenuGroupList = value;
        this.NotifyOfPropertyChange(nameof (MenuGroupList));
      }
    }

    public IList<CommonCodeView> PositionList
    {
      get => this._PositionList;
      set
      {
        this._PositionList = value;
        this.NotifyOfPropertyChange(nameof (PositionList));
      }
    }

    public IList<CommonCodeView> GenderList
    {
      get => this._GenderList;
      set
      {
        this._GenderList = value;
        this.NotifyOfPropertyChange(nameof (GenderList));
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

    public bool IsAdminOrMine
    {
      get => this._IsAdminOrMine;
      set
      {
        this._IsAdminOrMine = value;
        this.NotifyOfPropertyChange(nameof (IsAdminOrMine));
      }
    }

    public bool IsCreateMode
    {
      get => this._IsCreateMode;
      set
      {
        this._IsCreateMode = value;
        this.NotifyOfPropertyChange(nameof (IsCreateMode));
        this.NotifyOfPropertyChange("IsModifyMode");
      }
    }

    public bool IsModifyMode => !this.IsCreateMode;

    public PageEmployeeMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.MenuGroupList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.UserMenuGroup].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>();
      this.PositionList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.EmpPosition].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>();
      this.GenderList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.Gender].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>();
      this.IsAdmin = this.App.User.User.Source.IsEmployeeSave;
      this.IsAdminOrMine = this.IsAdmin;
      if (this.WorkDataT.OriginT.emp_Code == 0)
        this.IsCreateMode = true;
      if (this.WorkDataT == null)
        return;
      this.IsAdminOrMine = this.App.User.User.Source.IsEmployeeSave || this.WorkDataT.OriginT.emp_Code == this.App.User.User.Source.emp_Code;
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageEmployeeMPartVM pageEmployeeMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageEmployeeMpartVm.\u003C\u003En__0(p_param);
      pageEmployeeMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }

    public WpfCommand CmdSaveData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSaveData()),
        ExecuteAction = (Action<object>) (_ => this.SaveData())
      };
    }), nameof (CmdSaveData));

    public bool CanSaveData() => this.IsAdminOrMine;

    public void SaveData()
    {
      if (!this.CanSaveData())
        return;
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "데이타 저장", this.MenuInfo.Title + " 데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.SaveWorkDataAsync();
    }

    public bool CanSearchZip() => true;

    public void OnSearchZip()
    {
      AddrInfoBoardVM viewModel = this.Container.Get<AddrInfoBoardVM>();
      viewModel.IsMultiSelectMode = false;
      viewModel.Confirmed += new EventHandler<CommonBoardBase<AddrInfoView>>(this.VmAddrInfoConfirmed);
      this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
    }

    private void VmAddrInfoConfirmed(object sender, CommonBoardBase<AddrInfoView> e)
    {
      if (e.SelectedData.ZipNo.Length == 0)
        return;
      this.WorkDataT.CurrentT.emp_Zipcode = e.SelectedData.ZipNo;
      this.WorkDataT.CurrentT.emp_Addr1 = e.SelectedData.RoadAddr;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("emp_Addr2")), (DispatcherPriority) 4);
    }

    public WpfCommand CmdSearchZip => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchZip()),
        ExecuteAction = (Action<object>) (_ => this.OnSearchZip())
      };
    }), nameof (CmdSearchZip));

    public void BtnImageUpload()
    {
      int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title, "업로드").ShowDialog();
    }

    public void BtnImageDownload() => this.DownloadProfileImageAsync();

    public bool CanDownloadProfileImage() => this.WorkDataT?.CurrentT?.emp_Code.GetValueOrDefault() != 0 || this.WorkDataT?.CurrentT?.ei_UseYnImage.Equals("Y").GetValueOrDefault();

    public async Task DownloadProfileImageAsync()
    {
      PageEmployeeMPartVM pageEmployeeMpartVm = this;
      try
      {
        SaveFileDialog fd;
        // ISSUE: explicit non-virtual call
        using (JobProgressState j = __nonvirtual (pageEmployeeMpartVm.Job).CreateJob("프로필 이미지 다운로드", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UniBizHttpDownloadInfo downloadInfoAsync = await EmployeeRestServer.GetEmpImageFile(pageEmployeeMpartVm.LogInPackInfo.sendType, pageEmployeeMpartVm.LogInPackInfo.siteID, __nonvirtual (pageEmployeeMpartVm.WorkDataT).CurrentT.emp_Code, 0, __nonvirtual (pageEmployeeMpartVm.MenuInfo).Code).ExecuteToDownloadInfoAsync((UniBizHttpClient) __nonvirtual (pageEmployeeMpartVm.App).Api, (IProgress<double>) new Progress<double>((Action<double>) (p => j.Value = new double?(p))), j.Token);
          if (downloadInfoAsync == (UniBizHttpDownloadInfo) null || downloadInfoAsync.Data == null || downloadInfoAsync.Data.Length == 0)
            throw new Exception("데이타 없음");
          fd = new SaveFileDialog();
          fd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
          fd.FileName = downloadInfoAsync.Disposition.FileName;
          fd.CheckPathExists = true;
          if (fd.ShowDialog().GetValueOrDefault())
          {
            // ISSUE: explicit non-virtual call
            using (JobProgressState j2 = __nonvirtual (pageEmployeeMpartVm.Job).CreateJob("파일 생성", (string) null))
            {
              await File.WriteAllBytesAsync(fd.FileName, downloadInfoAsync.Data, j.Token);
              j2.Dispose();
              Process.Start("explorer.exe", "/select," + fd.FileName);
            }
          }
        }
        fd = (SaveFileDialog) null;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (pageEmployeeMpartVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageEmployeeMpartVm.Container)).Set(__nonvirtual (pageEmployeeMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanUploadProfileImage() => true;

    public async Task UploadProfileImageAsync()
    {
      PageEmployeeMPartVM pageEmployeeMpartVm = this;
      try
      {
        FileStream fs;
        UniBizHttpRequest<UbRes<EmpImageView>> req;
        // ISSUE: explicit non-virtual call
        using (JobProgressState j = __nonvirtual (pageEmployeeMpartVm.Job).CreateJob("프로필 이미지 업로드", (string) null))
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.Filter = "Image File|*.png;*.jpg;*.jpeg;*.bmp";
          bool? nullable = openFileDialog.ShowDialog();
          bool flag = true;
          if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue) || !File.Exists(openFileDialog.FileName))
            return;
          fs = File.OpenRead(openFileDialog.FileName);
          try
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            req = EmployeeRestServer.PostEmpImageFile(pageEmployeeMpartVm.LogInPackInfo.sendType, pageEmployeeMpartVm.LogInPackInfo.siteID, __nonvirtual (pageEmployeeMpartVm.WorkDataT).CurrentT.emp_Code, 0, __nonvirtual (pageEmployeeMpartVm.MenuInfo).Code, openFileDialog.SafeFileName, (Stream) fs);
            try
            {
              // ISSUE: explicit non-virtual call
              UbRes<EmpImageView> returnAsync = await req.ExecuteToReturnAsync<UbRes<EmpImageView>>((UniBizHttpClient) __nonvirtual (pageEmployeeMpartVm.App).Api, (IProgress<double>) new Progress<double>((Action<double>) (p => j.Value = new double?(p))), j.Token);
              returnAsync.GetSuccess<UbRes<EmpImageView>>();
              if (returnAsync.response.ei_ThumbData != null)
              {
                // ISSUE: explicit non-virtual call
                __nonvirtual (pageEmployeeMpartVm.WorkDataT).CurrentT.ei_ThumbData = returnAsync.response.ei_ThumbData;
                // ISSUE: explicit non-virtual call
                __nonvirtual (pageEmployeeMpartVm.WorkDataT).CurrentT.Changed("ei_ThumbData");
                // ISSUE: explicit non-virtual call
                __nonvirtual (pageEmployeeMpartVm.WorkDataT).CurrentT.Changed("Base64Data");
              }
            }
            finally
            {
              req?.Dispose();
            }
          }
          finally
          {
            fs?.Dispose();
          }
        }
        fs = (FileStream) null;
        req = (UniBizHttpRequest<UbRes<EmpImageView>>) null;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (pageEmployeeMpartVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageEmployeeMpartVm.Container)).Set(__nonvirtual (pageEmployeeMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand CmdDownloadProfileImage => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanDownloadProfileImage()),
        ExecuteAction = (Action<object>) (_ => await this.DownloadProfileImageAsync())
      };
    }), nameof (CmdDownloadProfileImage));

    public WpfCommand CmdUploadProfileImage => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        ExecuteAction = (Action<object>) (_ => await this.UploadProfileImageAsync())
      };
    }), nameof (CmdUploadProfileImage));

    public WpfCommand CmdSearchStore => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchStore()),
        ExecuteAction = (Action<object>) (_ => this.SearchStore())
      };
    }), nameof (CmdSearchStore));

    public bool CanSearchStore() => this.WorkDataT != null && this.WorkDataT.CurrentT != null;

    public void SearchStore()
    {
      try
      {
        if (!this.CanSearchStore())
          return;
        StoreInfoView storeInfoView = this.Container.Get<StoreCommonBoardVM>().Action<StoreCommonBoardVM>((Action<StoreCommonBoardVM>) (it => it.LoadManagedStatus())).Set("(" + this.WorkDataT.CurrentT.emp_Name + ")님 시작 지점 등록").ShowDialog2Data();
        if (storeInfoView == null || storeInfoView.si_StoreCode == 0)
          return;
        this.WorkDataT.CurrentT.emp_BaseStore = storeInfoView.si_StoreCode;
        this.WorkDataT.CurrentT.si_StoreName = storeInfoView.si_StoreName;
      }
      catch (Exception ex)
      {
        Log.Error("시작 지점 등록 오류=" + ex.Message);
        int num = (int) new CommonMsgVM(this.Container).Set("시작 지점 등록 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand<string> CmdPasswordChange => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<string>>((Func<WpfCommand<string>>) (() => new WpfCommand<string>().AutoRefreshOn<WpfCommand<string>>().ApplyExecute<string>(new Action<string>(this.ChangePassword))), nameof (CmdPasswordChange));

    public void ChangePassword(string p_type)
    {
      EnumEmployeePasswordType source = EnumEmployeePasswordType.NONE;
      try
      {
        switch (p_type.ToString())
        {
          case "emp_ProgPwd":
            source = EnumEmployeePasswordType.emp_ProgPwd;
            break;
          case "emp_PosPwd":
            source = EnumEmployeePasswordType.emp_PosPwd;
            break;
          case "emp_EmailPwd":
            source = EnumEmployeePasswordType.emp_EmailPwd;
            break;
        }
        EmployeePasswordBoardVM viewModel = this.Container.Get<EmployeePasswordBoardVM>();
        viewModel.PasswordType = source;
        viewModel.EmpCode = this.WorkDataT.CurrentT.emp_Code;
        viewModel.IsMultiSelectMode = false;
        viewModel.Title = "(" + this.WorkDataT.CurrentT.emp_Name + ")님 " + source.ToDescription() + " 변경";
        this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
      }
      catch (Exception ex)
      {
        Log.Error(source.ToDescription() + " 변경 오류=" + ex.Message);
        int num = (int) new CommonMsgVM(this.Container).Set(source.ToDescription() + " 변경 오류", ex.Message).ShowDialog();
      }
    }
  }
}
