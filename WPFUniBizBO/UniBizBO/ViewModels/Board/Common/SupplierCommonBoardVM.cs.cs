// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.SupplierCommonBoardVM
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
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers.Code.Supplier;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class SupplierCommonBoardVM : CommonBoardBase<
  #nullable disable
  SupplierView>
  {
    private string _Title = "업체조회";
    private string _TitleDesc = string.Empty;
    private SupplierCommonBoardVM.InitParam _InitControlParam = new SupplierCommonBoardVM.InitParam();
    private Hashtable _searchContion;
    private SupplierCommonBoardVM.SearchParam _Param = new SupplierCommonBoardVM.SearchParam();
    private string _FooterRemark = string.Empty;

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
    public SupplierCommonBoardVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public Hashtable SearchContion
    {
      get => this._searchContion;
      set
      {
        this._searchContion = value;
        this.NotifyOfPropertyChange(nameof (SearchContion));
      }
    }

    public SupplierCommonBoardVM.SearchParam Param
    {
      get => this._Param;
      set
      {
        this._Param = value;
        this.NotifyOfPropertyChange(nameof (Param));
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

    public SupplierCommonBoardVM(IContainer container)
      : base(container)
    {
    }

    public SupplierCommonBoardVM Set(
      string pTitle = null,
      string pTitleDesc = null,
      EnumSupplierType pSupplierType = EnumSupplierType.None,
      EnumSupplierKind pSupKind = EnumSupplierKind.None)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      if (pSupplierType != EnumSupplierType.None)
      {
        this.InitControlParam.SupplierType = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierType][(int) pSupplierType];
        this.Param.IsInitSupType = true;
      }
      else
        this.InitControlParam.SupplierType = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierType][0];
      if (pSupKind != EnumSupplierKind.None)
      {
        this.InitControlParam.SupplierKind = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierKind][(int) pSupKind];
        this.Param.IsInitSupplierKind = true;
      }
      else
        this.InitControlParam.SupplierKind = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierKind][0];
      return this;
    }

    public SupplierView ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (SupplierView) null : this.SelectedData;
    }

    public IList<SupplierView> ShowDialog2Datas()
    {
      this.IsMultiSelectMode = true;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (IList<SupplierView>) null : (IList<SupplierView>) this.SelectedDatas;
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
      this.InitControl();
      base.OnInitialActivate();
      List<DefaultBoardFunc> defaultBoardFuncList = new List<DefaultBoardFunc>()
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
      if (this.App.User.User.Source.IsSupplierSave)
        defaultBoardFuncList.Add(DefaultBoardFunc.Create);
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) defaultBoardFuncList.ToArray();
    }

    public void InitControl()
    {
      if (this.InitControlParam.SupplierType == null)
        this.InitControlParam.SupplierType = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierType][0];
      if (this.InitControlParam.SupplierKind == null)
        this.InitControlParam.SupplierKind = this.App.Sys.CommonCodes[CommonCodeTypes.SupplierKind][0];
      this.Param.Use = new bool?(this.InitControlParam.Use);
      this.Param.SupplierType = this.InitControlParam.SupplierType;
      this.Param.SupplierKind = this.InitControlParam.SupplierKind;
    }

    public void SetParamBackup()
    {
      if (!this.Param.IsInitSupType)
        this.InitControlParam.SupplierType = this.Param.SupplierType;
      if (this.Param.IsInitSupplierKind)
        return;
      this.InitControlParam.SupplierKind = this.Param.SupplierKind;
    }

    public void OnWinClose() => this.RequestClose(new bool?());

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      SupplierCommonBoardVM supplierCommonBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await supplierCommonBoardVm.\u003C\u003En__0(p_param);
      supplierCommonBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public bool CanCreateCode() => this.App.User.User.Source.IsSupplierSave;

    public async Task CreateCodeAsync()
    {
      SupplierCommonBoardVM supplierCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!supplierCommonBoardVm.CanCreateCode() || __nonvirtual (supplierCommonBoardVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 22)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageSupplierPartConVM viewModel = __nonvirtual (supplierCommonBoardVm.Container).Get<PageSupplierPartConVM>();
        // ISSUE: explicit non-virtual call
        __nonvirtual (supplierCommonBoardVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public async Task SearchAsync(JobProgressState pj = null)
    {
      SupplierCommonBoardVM supplierCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (pj ?? __nonvirtual (supplierCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          supplierCommonBoardVm.FooterRemark = string.Empty;
          // ISSUE: explicit non-virtual call
          IList<SupplierView> data = (await SupplierRestServer.GetSupplierList(supplierCommonBoardVm.LogInPackInfo.sendType, supplierCommonBoardVm.LogInPackInfo.siteID, 0, 0, su_SupplierType: supplierCommonBoardVm.Param.SupplierType.comm_TypeNo, su_SupplierKind: supplierCommonBoardVm.Param.SupplierKind.comm_TypeNo, su_UseYn: supplierCommonBoardVm.Param.UseYn, KeyWord: supplierCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<SupplierView>>>((UniBizHttpClient) __nonvirtual (supplierCommonBoardVm.App).Api)).GetData<IList<SupplierView>>();
          supplierCommonBoardVm.Datas.Clear();
          supplierCommonBoardVm.Datas.AddRange((IEnumerable<SupplierView>) data);
          if (data.Count > 0)
            supplierCommonBoardVm.FooterRemark = "[" + data.Count.ToString("n0") + "] 건 조회";
          supplierCommonBoardVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierCommonBoardVm.Container)).SetException(ex).ShowDialog();
      }
    }

    public bool CanDataDbClick(SupplierView item) => item != null;

    public void DataDbClick(SupplierView item)
    {
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<SupplierView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<SupplierView>>((Func<WpfCommand<SupplierView>>) (() => new WpfCommand<SupplierView>().AutoRefreshOn<WpfCommand<SupplierView>>().ApplyCanExecute<SupplierView>(new Func<SupplierView, bool>(this.CanDataDbClick)).ApplyExecute<SupplierView>(new Action<SupplierView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public class InitParam : ParamBase<SupplierCommonBoardVM.InitParam>
    {
      private bool use = true;
      private CommonCodeView _SupplierType;
      private CommonCodeView _supplierKind;

      public bool Use
      {
        get => this.use;
        set
        {
          this.use = value;
          this.NotifyOfPropertyChange(nameof (Use));
        }
      }

      public CommonCodeView SupplierType
      {
        get => this._SupplierType;
        set
        {
          this._SupplierType = value;
          this.NotifyOfPropertyChange(nameof (SupplierType));
        }
      }

      public CommonCodeView SupplierKind
      {
        get => this._supplierKind;
        set
        {
          this._supplierKind = value;
          this.NotifyOfPropertyChange(nameof (SupplierKind));
        }
      }
    }

    public class SearchParam : ParamBase<SupplierCommonBoardVM.SearchParam>
    {
      private string keyword = string.Empty;
      private CommonCodeView _SupplierType;
      private bool _IsInitSupType;
      private CommonCodeView _supplierKind;
      private bool _IsInitSupplierKind;
      private bool? use = new bool?(true);

      public string Keyword
      {
        get => this.keyword;
        set
        {
          this.keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public CommonCodeView SupplierType
      {
        get => this._SupplierType;
        set
        {
          this._SupplierType = value;
          this.NotifyOfPropertyChange(nameof (SupplierType));
        }
      }

      public bool IsInitSupType
      {
        get => this._IsInitSupType;
        set
        {
          this._IsInitSupType = value;
          this.NotifyOfPropertyChange(nameof (IsInitSupType));
        }
      }

      public CommonCodeView SupplierKind
      {
        get => this._supplierKind;
        set
        {
          this._supplierKind = value;
          this.NotifyOfPropertyChange(nameof (SupplierKind));
        }
      }

      public bool IsInitSupplierKind
      {
        get => this._IsInitSupplierKind;
        set
        {
          this._IsInitSupplierKind = value;
          this.NotifyOfPropertyChange(nameof (IsInitSupplierKind));
        }
      }

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
  }
}
