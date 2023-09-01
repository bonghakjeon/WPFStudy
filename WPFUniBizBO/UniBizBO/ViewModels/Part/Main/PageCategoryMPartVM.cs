// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.PageCategoryMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main
{
  public class PageCategoryMPartVM : MPartBase<
  #nullable disable
  CategoryView>
  {
    public CategoryView _SearchData = new CategoryView();
    public DeptView _SearchDataDept = new DeptView();
    private IList<CommonCodeView> _CtgDepthList;
    private bool _isAdmin;
    private bool? _IsSaveAuth = new bool?(true);
    private Hashtable _SearchDeptContion = new Hashtable();
    private Hashtable _SearchCtgContion = new Hashtable();

    public PageCategoryMPartVM(IContainer container)
      : base(container)
    {
    }

    public CategoryView SearchData
    {
      get => this._SearchData;
      set
      {
        this._SearchData = value;
        this.NotifyOfPropertyChange(nameof (SearchData));
        this.MakeNewData();
      }
    }

    public DeptView SearchDataDept
    {
      get => this._SearchDataDept;
      set
      {
        this._SearchDataDept = value;
        this.NotifyOfPropertyChange(nameof (SearchDataDept));
        this.MakeNewDataDept();
      }
    }

    public void MakeNewData()
    {
      if (this._SearchData == null)
        return;
      this.WorkDataT.CurrentT.ctg_lv2_ID = 0;
      this.WorkDataT.CurrentT.ctg_lv2_ViewCode = string.Empty;
      this.WorkDataT.CurrentT.ctg_lv2_Name = string.Empty;
      this.WorkDataT.CurrentT.ctg_Memo = string.Empty;
      if (this._SearchData.ctg_Depth == 1)
      {
        this.WorkDataT.CurrentT.ctg_Depth = 2;
        this.WorkDataT.CurrentT.ctg_lv1_ID = this._SearchData.ctg_lv1_ID;
        this.WorkDataT.CurrentT.ctg_lv1_ViewCode = this._SearchData.ctg_lv1_ViewCode;
        this.WorkDataT.CurrentT.ctg_lv1_Name = this._SearchData.ctg_lv1_Name;
        this.WorkDataT.CurrentT.ctg_ParentsID = this._SearchData.ctg_lv1_ID;
        this.WorkDataT.CurrentT.ctg_ParentsName = this._SearchData.ctg_lv1_Name;
      }
      else if (this._SearchData.ctg_Depth == 2)
      {
        this.WorkDataT.CurrentT.ctg_Depth = 3;
        this.WorkDataT.CurrentT.ctg_lv1_ID = this._SearchData.ctg_lv1_ID;
        this.WorkDataT.CurrentT.ctg_lv1_ViewCode = this._SearchData.ctg_lv1_ViewCode;
        this.WorkDataT.CurrentT.ctg_lv1_Name = this._SearchData.ctg_lv1_Name;
        this.WorkDataT.CurrentT.ctg_lv2_ID = this._SearchData.ctg_lv2_ID;
        this.WorkDataT.CurrentT.ctg_lv2_ViewCode = this._SearchData.ctg_lv2_ViewCode;
        this.WorkDataT.CurrentT.ctg_lv2_Name = this._SearchData.ctg_lv2_Name;
        this.WorkDataT.CurrentT.ctg_ParentsID = this._SearchData.ctg_lv2_ID;
        this.WorkDataT.CurrentT.ctg_ParentsName = this._SearchData.ctg_lv2_Name;
      }
      else if (this._SearchData.ctg_Depth == 3)
      {
        this.WorkDataT.CurrentT.ctg_Depth = 3;
        this.WorkDataT.CurrentT.ctg_lv1_ID = this._SearchData.ctg_lv1_ID;
        this.WorkDataT.CurrentT.ctg_lv1_ViewCode = this._SearchData.ctg_lv1_ViewCode;
        this.WorkDataT.CurrentT.ctg_lv1_Name = this._SearchData.ctg_lv1_Name;
        this.WorkDataT.CurrentT.ctg_lv2_ID = this._SearchData.ctg_lv2_ID;
        this.WorkDataT.CurrentT.ctg_lv2_ViewCode = this._SearchData.ctg_lv2_ViewCode;
        this.WorkDataT.CurrentT.ctg_lv2_Name = this._SearchData.ctg_lv2_Name;
        this.WorkDataT.CurrentT.ctg_ParentsID = this._SearchData.ctg_lv2_ID;
        this.WorkDataT.CurrentT.ctg_ParentsName = this._SearchData.ctg_lv2_Name;
      }
      this.WorkDataT.CurrentT.DeptInfo.dpt_ID = this._SearchData.DeptInfo.dpt_ID;
      this.WorkDataT.CurrentT.DeptInfo.dpt_DeptName = this._SearchData.DeptInfo.dpt_DeptName;
    }

    public void MakeNewDataDept()
    {
      if (this._SearchDataDept == null)
        return;
      try
      {
        this.WorkDataT.CurrentT.DeptInfo.dpt_ID = this._SearchDataDept.dpt_Depth == 3 ? this._SearchDataDept.dpt_ID : throw new Exception("PC 부서선택 오류 !");
        this.WorkDataT.CurrentT.DeptInfo.dpt_DeptName = this._SearchDataDept.dpt_DeptName;
        this.WorkDataT.CurrentT.ctg_ParentsID = this._SearchDataDept.dpt_ID;
        this.WorkDataT.CurrentT.ctg_ParentsName = this._SearchDataDept.dpt_DeptName;
        this.WorkDataT.CurrentT.DeptInfo = this._SearchDataDept;
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        int num = (int) this.Container.Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    public IList<CommonCodeView> CtgDepthList
    {
      get => this._CtgDepthList;
      set
      {
        this._CtgDepthList = value;
        this.NotifyOfPropertyChange(nameof (CtgDepthList));
      }
    }

    public bool IsAdmin
    {
      get => this._isAdmin;
      set
      {
        this._isAdmin = value;
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

    public Hashtable SearchDeptContion
    {
      get => this._SearchDeptContion;
      set
      {
        this._SearchDeptContion = value;
        this.NotifyOfPropertyChange(nameof (SearchDeptContion));
      }
    }

    public Hashtable SearchCtgContion
    {
      get => this._SearchCtgContion;
      set
      {
        this._SearchCtgContion = value;
        this.NotifyOfPropertyChange(nameof (SearchCtgContion));
      }
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.CtgDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.IsSaveAuth = new bool?(this.App.User.User.Source.IsMasterCommonSave);
      this.SearchDeptContion.Add((object) "DptDepth", (object) this.App.Sys.CommonCodes[CommonCodeTypes.DeptDepth][3]);
      this.SearchDeptContion.Add((object) "TabIndex", (object) 0);
      this.SearchDeptContion.Add((object) "IsDepthSelect", (object) false);
      if (this.WorkDataT != null && this.WorkDataT.CurrentT != null && this.WorkDataT.CurrentT.ctg_ID > 0)
        return;
      this.WorkDataT.CurrentT.ctg_ID = 0;
      this.WorkDataT.CurrentT.ctg_Depth = 1;
      this.WorkDataT.CurrentT.ctg_UseYn = "Y";
      this.WorkDataT.CurrentT.ctg_ViewCode = string.Empty;
      this.WorkDataT.CurrentT.ctg_Memo = string.Empty;
      this.WorkDataT.CurrentT.DB_STATUS = EnumDBStatus.NEW;
      DeptView deptView = new DeptView();
      deptView.dpt_DeptName = string.Empty;
      deptView.dpt_ViewCode = string.Empty;
      deptView.dpt_lv1_ViewCode = string.Empty;
      deptView.dpt_lv1_Name = string.Empty;
      deptView.dpt_lv2_ViewCode = string.Empty;
      deptView.dpt_lv2_Name = string.Empty;
      deptView.dpt_Memo = string.Empty;
      this.WorkDataT.CurrentT.DeptInfo = deptView;
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageCategoryMPartVM pageCategoryMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageCategoryMpartVm.\u003C\u003En__0(p_param);
      pageCategoryMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.DisplayName + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.WinClose();
    }

    public void OnSaveData()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "데이타 저장", this.DisplayName + " 데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.SaveWorkDataAsync();
    }

    protected async Task OnSavingDataAsync()
    {
      PageCategoryMPartVM pageCategoryMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageCategoryMpartVm.Job).CreateJob("저장", (string) null))
        {
          if (!pageCategoryMpartVm.DataCheck())
            throw new Exception("데이타 점검 오류");
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<CategoryView> success = (await CategoryRestServer.PostCategory(pageCategoryMpartVm.LogInPackInfo.sendType, pageCategoryMpartVm.LogInPackInfo.siteID, __nonvirtual (pageCategoryMpartVm.WorkDataT).CurrentT.ctg_ID, 0, __nonvirtual (pageCategoryMpartVm.MenuInfo).Code, __nonvirtual (pageCategoryMpartVm.WorkDataT).CurrentT).ExecuteToReturnAsync<UbRes<CategoryView>>((UniBizHttpClient) __nonvirtual (pageCategoryMpartVm.App).Api)).GetSuccess<UbRes<CategoryView>>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageCategoryMpartVm.WorkDataT).Set(success.response);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (pageCategoryMpartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    public void OnSaveDatas()
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
        ExecuteAction = (Action<object>) (_ => this.OnSaveDatas())
      };
    }), nameof (CmdSaveData));

    public bool DataCheck()
    {
      try
      {
        if (this.WorkDataT.CurrentT.DeptInfo == null || this.WorkDataT.CurrentT.DeptInfo.dpt_ID == 0)
          throw new Exception("상위 부서가 입력되지 않았습니다.");
        if (this.WorkDataT.CurrentT.ctg_ViewCode == null || this.WorkDataT.CurrentT.ctg_ViewCode.Length == 0)
          throw new Exception("뷰코드가 입력되지 않았습니다.");
        if (this.WorkDataT.CurrentT.ctg_CategoryName == null || this.WorkDataT.CurrentT.ctg_CategoryName.Length == 0)
          throw new Exception("분류명이 입력되지 않았습니다.");
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
      this.WorkDataT.CurrentT.ctg_ID = 0;
      this.WorkDataT.CurrentT.ctg_ViewCode = string.Empty;
      this.WorkDataT.CurrentT.ctg_CategoryName = string.Empty;
      this.WorkDataT.CurrentT.ctg_Memo = string.Empty;
      if (this.WorkDataT.CurrentT.ctg_Depth == 1)
      {
        this.WorkDataT.CurrentT.ctg_lv1_ID = 0;
        this.WorkDataT.CurrentT.ctg_lv2_ID = 0;
        this.WorkDataT.CurrentT.ctg_lv1_Name = string.Empty;
        this.WorkDataT.CurrentT.ctg_lv1_ViewCode = string.Empty;
      }
      else
      {
        if (this.WorkDataT.CurrentT.ctg_Depth != 2)
          return;
        this.WorkDataT.CurrentT.ctg_lv2_ID = 0;
        this.WorkDataT.CurrentT.ctg_lv2_Name = string.Empty;
        this.WorkDataT.CurrentT.ctg_lv2_ViewCode = string.Empty;
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
  }
}
