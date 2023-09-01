// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.PageDeptMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main
{
  public class PageDeptMPartVM : MPartBase<
  #nullable disable
  DeptView>
  {
    public DeptView _SearchData = new DeptView();
    private IList<CommonCodeView> _DptDepthList;
    private bool _IsAdmin;
    private bool? _IsSaveAuth = new bool?(true);
    private string _FooterRemark = string.Empty;

    public PageDeptMPartVM(IContainer container)
      : base(container)
    {
    }

    public DeptView SearchData
    {
      get => this._SearchData;
      set
      {
        this._SearchData = value;
        this.NotifyOfPropertyChange(nameof (SearchData));
        this.InitNewData();
      }
    }

    public void InitNewData()
    {
      if (this._SearchData == null)
        return;
      this.WorkDataT.CurrentT.dpt_lv2_ID = 0;
      this.WorkDataT.CurrentT.dpt_lv2_ViewCode = string.Empty;
      this.WorkDataT.CurrentT.dpt_lv2_Name = string.Empty;
      this.WorkDataT.CurrentT.dpt_Memo = string.Empty;
      this.WorkDataT.CurrentT.dpt_Depth = this._SearchData.dpt_Depth;
      if (this._SearchData.dpt_Depth == 1)
      {
        this.WorkDataT.CurrentT.dpt_Depth = 2;
        this.WorkDataT.CurrentT.dpt_lv1_ID = this._SearchData.dpt_lv1_ID;
        this.WorkDataT.CurrentT.dpt_lv1_ViewCode = this._SearchData.dpt_lv1_ViewCode;
        this.WorkDataT.CurrentT.dpt_lv1_Name = this._SearchData.dpt_lv1_Name;
        this.WorkDataT.CurrentT.dpt_ParentsID = this._SearchData.dpt_lv1_ID;
        this.WorkDataT.CurrentT.dpt_ParentsName = this._SearchData.dpt_lv1_Name;
      }
      else if (this._SearchData.dpt_Depth == 2)
      {
        this.WorkDataT.CurrentT.dpt_Depth = 3;
        this.WorkDataT.CurrentT.dpt_lv1_ID = this._SearchData.dpt_lv1_ID;
        this.WorkDataT.CurrentT.dpt_lv1_ViewCode = this._SearchData.dpt_lv1_ViewCode;
        this.WorkDataT.CurrentT.dpt_lv1_Name = this._SearchData.dpt_lv1_Name;
        this.WorkDataT.CurrentT.dpt_lv2_ID = this._SearchData.dpt_lv2_ID;
        this.WorkDataT.CurrentT.dpt_lv2_ViewCode = this._SearchData.dpt_lv2_ViewCode;
        this.WorkDataT.CurrentT.dpt_lv2_Name = this._SearchData.dpt_lv2_Name;
        this.WorkDataT.CurrentT.dpt_ParentsID = this._SearchData.dpt_lv2_ID;
        this.WorkDataT.CurrentT.dpt_ParentsName = this._SearchData.dpt_lv2_Name;
      }
      else
      {
        if (this._SearchData.dpt_Depth != 3)
          return;
        this.WorkDataT.CurrentT.dpt_Depth = 3;
        this.WorkDataT.CurrentT.dpt_lv1_ID = this._SearchData.dpt_lv1_ID;
        this.WorkDataT.CurrentT.dpt_lv1_ViewCode = this._SearchData.dpt_lv1_ViewCode;
        this.WorkDataT.CurrentT.dpt_lv1_Name = this._SearchData.dpt_lv1_Name;
        this.WorkDataT.CurrentT.dpt_lv2_ID = this._SearchData.dpt_lv2_ID;
        this.WorkDataT.CurrentT.dpt_lv2_ViewCode = this._SearchData.dpt_lv2_ViewCode;
        this.WorkDataT.CurrentT.dpt_lv2_Name = this._SearchData.dpt_lv2_Name;
        this.WorkDataT.CurrentT.dpt_ParentsID = this._SearchData.dpt_lv2_ID;
        this.WorkDataT.CurrentT.dpt_ParentsName = this._SearchData.dpt_lv2_Name;
      }
    }

    public IList<CommonCodeView> DptDepthList
    {
      get => this._DptDepthList;
      set
      {
        this._DptDepthList = value;
        this.NotifyOfPropertyChange(nameof (DptDepthList));
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

    public bool? IsSaveAuth
    {
      get => this._IsSaveAuth;
      set
      {
        this._IsSaveAuth = value;
        this.NotifyOfPropertyChange(nameof (IsSaveAuth));
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

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.DptDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.DeptDepth].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.IsSaveAuth = new bool?(this.App.User.User.Source.IsMasterCommonSave);
      if (this.WorkDataT != null && this.WorkDataT.CurrentT != null && this.WorkDataT.CurrentT.dpt_ID > 0)
        return;
      this.WorkDataT.CurrentT.dpt_ID = 0;
      this.WorkDataT.CurrentT.dpt_Depth = 1;
      this.WorkDataT.CurrentT.dpt_UseYn = "Y";
      this.WorkDataT.CurrentT.dpt_ViewCode = string.Empty;
      this.WorkDataT.CurrentT.dpt_Memo = string.Empty;
      this.WorkDataT.CurrentT.DB_STATUS = EnumDBStatus.NEW;
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageDeptMPartVM pageDeptMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageDeptMpartVm.\u003C\u003En__0(p_param);
      pageDeptMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public WpfCommand CmdDeptInsert => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanDeptInsert()),
        ExecuteAction = (Action<object>) (_ => this.OnDeptInsert())
      };
    }), nameof (CmdDeptInsert));

    public bool CanDeptInsert() => true;

    public void OnDeptInsert()
    {
    }

    public WpfCommand CmdDeptReset => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanDeptReset()),
        ExecuteAction = (Action<object>) (_ => this.OnDeptReset())
      };
    }), nameof (CmdDeptReset));

    public bool CanDeptReset() => true;

    public void OnDeptReset()
    {
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.DisplayName + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.WinClose();
    }

    protected async Task OnSavingDataAsync()
    {
      PageDeptMPartVM pageDeptMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageDeptMpartVm.Job).CreateJob("저장", (string) null))
        {
          if (!pageDeptMpartVm.DataCheck())
            throw new Exception("데이타 점검 오류");
          // ISSUE: explicit non-virtual call
          int dbStatus = (int) __nonvirtual (pageDeptMpartVm.WorkDataT).CurrentT.DB_STATUS;
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<DeptView> success = (await DeptRestServer.PostDept(pageDeptMpartVm.LogInPackInfo.sendType, pageDeptMpartVm.LogInPackInfo.siteID, __nonvirtual (pageDeptMpartVm.WorkDataT).CurrentT.dpt_ID, 0, __nonvirtual (pageDeptMpartVm.MenuInfo).Code, __nonvirtual (pageDeptMpartVm.WorkDataT).CurrentT).ExecuteToReturnAsync<UbRes<DeptView>>((UniBizHttpClient) __nonvirtual (pageDeptMpartVm.App).Api)).GetSuccess<UbRes<DeptView>>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageDeptMpartVm.WorkDataT).Set(success.response);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (pageDeptMpartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    public void OnSaveData()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "데이타 저장", this.DisplayName + " 데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.OnSavingDataAsync();
    }

    public bool CanSaveData() => true;

    public WpfCommand CmdSaveData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSaveData()),
        ExecuteAction = (Action<object>) (_ => this.OnSaveData())
      };
    }), nameof (CmdSaveData));

    public bool DataCheck()
    {
      try
      {
        if (this.WorkDataT.CurrentT.dpt_ViewCode == null || this.WorkDataT.CurrentT.dpt_ViewCode.Length == 0)
          throw new Exception("뷰코드가 입력되지 않았습니다.");
        if (this.WorkDataT.CurrentT.dpt_DeptName == null || this.WorkDataT.CurrentT.dpt_DeptName.Length == 0)
          throw new Exception("부서명이 입력되지 않았습니다.");
        return true;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public void OnClearDatas()
    {
      if (this.PartContainerT.IsCreateMode)
        this.WorkDataT.CurrentT.DB_STATUS = EnumDBStatus.NEW;
      this.WorkDataT.CurrentT.dpt_ID = 0;
      this.WorkDataT.CurrentT.dpt_ViewCode = string.Empty;
      this.WorkDataT.CurrentT.dpt_DeptName = string.Empty;
      this.WorkDataT.CurrentT.dpt_Memo = string.Empty;
      if (this.WorkDataT.CurrentT.dpt_Depth == 1)
      {
        this.WorkDataT.CurrentT.dpt_lv1_ID = 0;
        this.WorkDataT.CurrentT.dpt_lv2_ID = 0;
        this.WorkDataT.CurrentT.dpt_lv1_Name = string.Empty;
        this.WorkDataT.CurrentT.dpt_lv1_ViewCode = string.Empty;
      }
      else
      {
        if (this.WorkDataT.CurrentT.dpt_Depth != 2)
          return;
        this.WorkDataT.CurrentT.dpt_lv2_ID = 0;
        this.WorkDataT.CurrentT.dpt_lv2_Name = string.Empty;
        this.WorkDataT.CurrentT.dpt_lv2_ViewCode = string.Empty;
      }
    }

    public bool CanClearData() => true;

    public WpfCommand CmdClearData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanClearData()),
        ExecuteAction = (Action<object>) (_ => this.OnClearDatas())
      };
    }), nameof (CmdClearData));

    public void BtnSearchDept()
    {
      DeptView deptView = this.Container.Get<DeptCommonBoardVM>().Set(this.MenuInfo.Title + " 부서 조회").ShowDialog2Data();
      if (deptView == null)
        return;
      this.WorkDataT.CurrentT.dpt_ParentsID = deptView.dpt_ID;
      this.WorkDataT.CurrentT.dpt_ParentsName = deptView.dpt_DeptName;
    }
  }
}
