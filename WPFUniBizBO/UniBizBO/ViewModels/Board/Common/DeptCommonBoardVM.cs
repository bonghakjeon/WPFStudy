// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.DeptCommonBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class DeptCommonBoardVM : CommonBoardBase<
  #nullable disable
  DeptView>
  {
    private DeptCommonBoardVM.InitParam _InitControlParam = new DeptCommonBoardVM.InitParam();
    private Hashtable _searchContion;
    private DeptCommonBoardVM.SearchParam param = new DeptCommonBoardVM.SearchParam();
    private IList<CommonCodeView> _DptDepthList;
    private DeptView _selectedLv1Datas;
    private int _TabIndex;
    private int _TabIndex_2 = -1;
    private string _Title = "부서조회";
    private string _TitleDesc = string.Empty;

    [ManagedStatus]
    public DeptCommonBoardVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public DeptCommonBoardVM(IContainer container)
      : base(container)
    {
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) new DefaultBoardFunc[3]
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
      this.Param.IsDepthSelect = new bool?(true);
      this.IsDept = true;
      this.Param.Use = new bool?(true);
      this.Param.DtDate = DateTime.Now;
      this.DptDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.DeptDepth].ToArray<CommonCodeView>();
      this.Param.DptDepth = this.App.Sys.CommonCodes[CommonCodeTypes.DeptDepth][0];
    }

    public DeptCommonBoardVM Set(string pTitle = null, string pTitleDesc = null)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      return this;
    }

    public DeptView ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (DeptView) null : this.SelectedData;
    }

    public void InitControl()
    {
      if (this.SearchContion == null || this.SearchContion.Count == 0)
        return;
      Log.Error("------------------------------------------------------------------------------------------------------");
      foreach (DictionaryEntry dictionaryEntry in this.SearchContion)
      {
        if (dictionaryEntry.Key is string key)
        {
          switch (key)
          {
            case "DptDepth":
              this.Param.DptDepth = (CommonCodeView) dictionaryEntry.Value;
              break;
            case "dt_date":
              this.Param.DtDate = (DateTime) dictionaryEntry.Value;
              break;
            case "TabIndex":
              this.TabIndex_2 = (int) dictionaryEntry.Value;
              break;
            case "IsDepthSelect":
              this.Param.IsDepthSelect = new bool?((bool) dictionaryEntry.Value);
              break;
          }
        }
        Log.Error(string.Format("key = {0} , name = {1} .", dictionaryEntry.Key, dictionaryEntry.Value));
      }
      Log.Error("------------------------------------------------------------------------------------------------------");
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

    public DeptCommonBoardVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
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

    public bool IsDept { get; set; }

    public BindableCollection<DeptView> Lv1Datas { get; } = new BindableCollection<DeptView>();

    public DeptView SelectedLv1Datas
    {
      get => this._selectedLv1Datas;
      set => this.SetAndNotify<DeptView>(ref this._selectedLv1Datas, value, nameof (SelectedLv1Datas));
    }

    public int TabIndex
    {
      get => this._TabIndex;
      set
      {
        this._TabIndex = value;
        this.NotifyOfPropertyChange(nameof (TabIndex));
      }
    }

    public int TabIndex_2
    {
      get => this._TabIndex_2;
      set
      {
        this._TabIndex_2 = value;
        this.NotifyOfPropertyChange(nameof (TabIndex_2));
      }
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

    public bool CanCreateCode() => this.App.User.User.Source.IsMasterCommonSave;

    public async Task CreateCodeAsync()
    {
      DeptCommonBoardVM deptCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!deptCommonBoardVm.CanCreateCode() || __nonvirtual (deptCommonBoardVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 31)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageDeptPartConVM viewModel = __nonvirtual (deptCommonBoardVm.Container).Get<PageDeptPartConVM>();
        // ISSUE: explicit non-virtual call
        __nonvirtual (deptCommonBoardVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public async Task SearchAsync(JobProgressState pj = null)
    {
      DeptCommonBoardVM deptCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (pj ?? __nonvirtual (deptCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          IList<DeptView> data1 = (await DeptRestServer.GetDeptList(deptCommonBoardVm.LogInPackInfo.sendType, deptCommonBoardVm.LogInPackInfo.siteID, 0, 0, dpt_UseYn: deptCommonBoardVm.Param.UseYn, dpt_Depth: deptCommonBoardVm.Param.DptDepth.comm_TypeNo, KeyWord: deptCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<DeptView>>>((UniBizHttpClient) __nonvirtual (deptCommonBoardVm.App).Api)).GetData<IList<DeptView>>();
          deptCommonBoardVm.Datas.Clear();
          deptCommonBoardVm.Datas.AddRange((IEnumerable<DeptView>) data1);
          deptCommonBoardVm.SetParamBackup();
          // ISSUE: explicit non-virtual call
          DeptLevel data2 = (await DeptRestServer.GetDeptDepth(deptCommonBoardVm.LogInPackInfo.sendType, deptCommonBoardVm.LogInPackInfo.siteID, 0, 0, deptCommonBoardVm.Param.UseYn, deptCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<DeptLevel>>((UniBizHttpClient) __nonvirtual (deptCommonBoardVm.App).Api)).GetData<DeptLevel>();
          deptCommonBoardVm.Lv1Datas.Clear();
          deptCommonBoardVm.Lv1Datas.AddRange((IEnumerable<DeptView>) data2.Items);
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (deptCommonBoardVm.Container)).SetException(ex).ShowDialog();
      }
    }

    public void OnWinClose() => this.RequestClose(new bool?());

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
      this.InitControl2();
    }

    protected void InitControl2()
    {
      if (!this.InitControlParam.Use.HasValue)
        this.InitControlParam.Use = new bool?(true);
      this.Param.Use = this.InitControlParam.Use;
      this.TabIndex = this.InitControlParam.TabIndex;
      if (this.TabIndex_2 < 0)
        return;
      this.TabIndex = this.TabIndex_2;
    }

    public void SetParamBackup() => this.InitControlParam.Use = this.Param.Use;

    public override void OnConfirm()
    {
      if (!this.Param.IsDepthSelect.Value && this.SelectedData != null && this.SelectedData.dpt_Depth != this.Param.DptDepth.comm_TypeNo)
      {
        int num = (int) new CommonMsgVM(this.Container).Set("", string.Format("{0}단계를 선택하세요", (object) this.Param.DptDepth.comm_TypeNo)).ShowDialog();
      }
      else
      {
        this.InitControlParam.TabIndex = this.TabIndex;
        base.OnConfirm();
      }
    }

    public bool CanDataDbClick(DeptView item) => item != null;

    public void DataDbClick(DeptView item)
    {
      this.IsDept = true;
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<DeptView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public void LvDataDbClick(DeptView item)
    {
      this.IsDept = false;
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<DeptView> CmdLvDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.LvDataDbClick))), nameof (CmdLvDataDbClick));

    public void Lv2DataDbClick(DeptView item)
    {
      this.IsDept = false;
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<DeptView> CmdLv2DataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<DeptView>>((Func<WpfCommand<DeptView>>) (() => new WpfCommand<DeptView>().AutoRefreshOn<WpfCommand<DeptView>>().ApplyCanExecute<DeptView>(new Func<DeptView, bool>(this.CanDataDbClick)).ApplyExecute<DeptView>(new Action<DeptView>(this.Lv2DataDbClick))), nameof (CmdLv2DataDbClick));

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      DeptCommonBoardVM deptCommonBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await deptCommonBoardVm.\u003C\u003En__0(p_param);
      deptCommonBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public class InitParam : ParamBase<DeptCommonBoardVM.InitParam>
    {
      private bool? use;
      private int _TabIndex;

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

      public int TabIndex
      {
        get => this._TabIndex;
        set
        {
          this._TabIndex = value;
          this.NotifyOfPropertyChange(nameof (TabIndex));
        }
      }
    }

    public class SearchParam : ParamBase<DeptCommonBoardVM.SearchParam>
    {
      private DateTime _DtDate;
      private bool? use;
      private string keyword = string.Empty;
      private CommonCodeView _DptDepth;
      private bool? _IsDepthSelect;

      public DateTime DtDate
      {
        get => this._DtDate;
        set
        {
          this._DtDate = value;
          this.NotifyOfPropertyChange(nameof (DtDate));
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

      public string Keyword
      {
        get => this.keyword;
        set
        {
          this.keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public CommonCodeView DptDepth
      {
        get => this._DptDepth;
        set
        {
          this._DptDepth = value;
          this.NotifyOfPropertyChange(nameof (DptDepth));
        }
      }

      public bool? IsDepthSelect
      {
        get => this._IsDepthSelect;
        set
        {
          this._IsDepthSelect = value;
          this.NotifyOfPropertyChange(nameof (IsDepthSelect));
        }
      }
    }
  }
}
