// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.CategoryCommonBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.CommonCode;
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
  public class CategoryCommonBoardVM : CommonBoardBase<
  #nullable disable
  CategoryView>
  {
    private CategoryCommonBoardVM.InitParam _InitControlParam = new CategoryCommonBoardVM.InitParam();
    private Hashtable _searchContion;
    private CategoryCommonBoardVM.SearchParam param = new CategoryCommonBoardVM.SearchParam();
    private IList<CommonCodeView> _CtgDepthList;
    private CategoryView _selectedLv1Datas;
    private int _TabIndex;
    private int _TabIndex_2 = -1;
    private string _Title = "분류조회";
    private string _TitleDesc = string.Empty;

    [ManagedStatus]
    public CategoryCommonBoardVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public CategoryView ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (CategoryView) null : this.SelectedData;
    }

    public IList<CategoryView> ShowDialog2Datas()
    {
      this.IsMultiSelectMode = true;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (IList<CategoryView>) null : (IList<CategoryView>) this.SelectedDatas;
    }

    public CategoryCommonBoardVM(IContainer container)
      : base(container)
    {
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) new DefaultBoardFunc[3]
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
      this.IsCategory = true;
      this.Param.IsDepthSelect = new bool?(true);
      this.Param.Use = new bool?(true);
      this.Param.DtDate = DateTime.Now;
      this.CtgDepthList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth].ToArray<CommonCodeView>();
      this.Param.CtgDepth = this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth][0];
    }

    public CategoryCommonBoardVM Set(
      string pTitle = null,
      string pTitleDesc = null,
      int pDepth = 0,
      int pTabIndex = -1,
      bool pIsDepthSelect = true)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      if (pDepth > 0)
        this.Param.CtgDepth = this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth][pDepth];
      this.TabIndex_2 = pTabIndex;
      this.Param.IsDepthSelect = new bool?(pIsDepthSelect);
      return this;
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
            case "CtgDepth":
              this.Param.CtgDepth = (CommonCodeView) dictionaryEntry.Value;
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

    public CategoryCommonBoardVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
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

    public bool IsCategory { get; set; }

    public BindableCollection<CategoryView> Lv1Datas { get; } = new BindableCollection<CategoryView>();

    public CategoryView SelectedLv1Datas
    {
      get => this._selectedLv1Datas;
      set => this.SetAndNotify<CategoryView>(ref this._selectedLv1Datas, value, nameof (SelectedLv1Datas));
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
      CategoryCommonBoardVM categoryCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!categoryCommonBoardVm.CanCreateCode() || __nonvirtual (categoryCommonBoardVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 34)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageCategoryPartConVM viewModel = __nonvirtual (categoryCommonBoardVm.Container).Get<PageCategoryPartConVM>();
        // ISSUE: explicit non-virtual call
        __nonvirtual (categoryCommonBoardVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public async Task SearchAsync(JobProgressState pj = null)
    {
      CategoryCommonBoardVM categoryCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (pj ?? __nonvirtual (categoryCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          IList<CategoryView> data1 = (await CategoryRestServer.GetCategoryList(categoryCommonBoardVm.LogInPackInfo.sendType, categoryCommonBoardVm.LogInPackInfo.siteID, 0, 0, ctg_UseYn: categoryCommonBoardVm.Param.UseYn, ctg_Depth: categoryCommonBoardVm.Param.CtgDepth.comm_TypeNo, KeyWord: categoryCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<CategoryView>>>((UniBizHttpClient) __nonvirtual (categoryCommonBoardVm.App).Api)).GetData<IList<CategoryView>>();
          categoryCommonBoardVm.Datas.Clear();
          categoryCommonBoardVm.Datas.AddRange((IEnumerable<CategoryView>) data1);
          categoryCommonBoardVm.SetParamBackup();
          // ISSUE: explicit non-virtual call
          CategoryLevel data2 = (await CategoryRestServer.GetCategoryDepth(categoryCommonBoardVm.LogInPackInfo.sendType, categoryCommonBoardVm.LogInPackInfo.siteID, 0, 0, categoryCommonBoardVm.Param.UseYn, categoryCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<CategoryLevel>>((UniBizHttpClient) __nonvirtual (categoryCommonBoardVm.App).Api)).GetData<CategoryLevel>();
          categoryCommonBoardVm.Lv1Datas.Clear();
          categoryCommonBoardVm.Lv1Datas.AddRange((IEnumerable<CategoryView>) data2.Items);
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (categoryCommonBoardVm.Container)).SetException(ex).ShowDialog();
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
      if (this.TabIndex_2 >= 0)
        this.TabIndex = this.TabIndex_2;
      this.Param.IsTreeChildrenBind = this.InitControlParam.IsTreeChildrenBind;
    }

    public void SetParamBackup()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.IsTreeChildrenBind = this.Param.IsTreeChildrenBind;
    }

    public override void OnConfirm()
    {
      if (!this.Param.IsDepthSelect.Value && this.SelectedData != null && this.SelectedData.ctg_Depth != this.Param.CtgDepth.comm_TypeNo)
      {
        int num = (int) new CommonMsgVM(this.Container).Set("", string.Format("{0}단계를 선택하세요", (object) this.Param.CtgDepth.comm_TypeNo)).ShowDialog();
      }
      else
      {
        this.InitControlParam.TabIndex = this.TabIndex;
        this.InitControlParam.IsTreeChildrenBind = this.Param.IsTreeChildrenBind;
        base.OnConfirm();
      }
    }

    public bool CanDataDbClick(CategoryView item) => item != null;

    public void DataDbClick(CategoryView item)
    {
      this.IsCategory = true;
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<CategoryView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<CategoryView>>((Func<WpfCommand<CategoryView>>) (() => new WpfCommand<CategoryView>().AutoRefreshOn<WpfCommand<CategoryView>>().ApplyCanExecute<CategoryView>(new Func<CategoryView, bool>(this.CanDataDbClick)).ApplyExecute<CategoryView>(new Action<CategoryView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public void LvDataDbClick(CategoryView item)
    {
      this.IsCategory = false;
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<CategoryView> CmdLvDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<CategoryView>>((Func<WpfCommand<CategoryView>>) (() => new WpfCommand<CategoryView>().AutoRefreshOn<WpfCommand<CategoryView>>().ApplyCanExecute<CategoryView>(new Func<CategoryView, bool>(this.CanDataDbClick)).ApplyExecute<CategoryView>(new Action<CategoryView>(this.LvDataDbClick))), nameof (CmdLvDataDbClick));

    public void Lv2DataDbClick(CategoryView item)
    {
      this.IsCategory = false;
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<CategoryView> CmdLv2DataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<CategoryView>>((Func<WpfCommand<CategoryView>>) (() => new WpfCommand<CategoryView>().AutoRefreshOn<WpfCommand<CategoryView>>().ApplyCanExecute<CategoryView>(new Func<CategoryView, bool>(this.CanDataDbClick)).ApplyExecute<CategoryView>(new Action<CategoryView>(this.Lv2DataDbClick))), nameof (CmdLv2DataDbClick));

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      CategoryCommonBoardVM categoryCommonBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await categoryCommonBoardVm.\u003C\u003En__0(p_param);
      categoryCommonBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public void BtnTreeClose() => this.RequestClose(new bool?());

    public void BtnTreeSelect()
    {
      if (!this.IsMultiSelectMode)
        return;
      List<CategoryView> items = new List<CategoryView>();
      foreach (CategoryView lv1Data in (Collection<CategoryView>) this.Lv1Datas)
      {
        if (lv1Data.RowCheckStatus.IsChecked)
          items.Add(lv1Data);
        foreach (CategoryView categoryView1 in (IEnumerable<CategoryView>) lv1Data.Lt_Detail)
        {
          if (categoryView1.RowCheckStatus.IsChecked)
            items.Add(categoryView1);
          foreach (CategoryView categoryView2 in (IEnumerable<CategoryView>) categoryView1.Lt_Detail)
          {
            if (categoryView2.RowCheckStatus.IsChecked)
              items.Add(categoryView2);
          }
        }
      }
      if (items.Count == 0)
      {
        int num = (int) new CommonMsgVM(this.Container).Set(this.Title + " 선택 필수.", "체크박스 선택 후 사용 가능.").ShowDialog();
      }
      else
      {
        this.SelectedDatas.Clear();
        this.SelectedDatas.AddRange((IEnumerable<CategoryView>) items);
        this.SelectedData = this.SelectedDatas.FirstOrDefault<CategoryView>();
        this.OnConfirm();
      }
    }

    public void TreeCheckedBoxClick(object p_depth)
    {
      if (!(p_depth is ContentPresenter contentPresenter) || !(contentPresenter.DataContext is CategoryView dataContext) || !this.Param.IsTreeChildrenBind || dataContext.Lt_Detail == null || dataContext.Lt_Detail.Count <= 0)
        return;
      foreach (CategoryView categoryView in (IEnumerable<CategoryView>) dataContext.Lt_Detail)
      {
        categoryView.RowCheckStatus.IsChecked = dataContext.RowCheckStatus.IsChecked;
        if (categoryView.Lt_Detail != null && categoryView.Lt_Detail.Count > 0)
        {
          foreach (UbModelBase ubModelBase in (IEnumerable<CategoryView>) categoryView.Lt_Detail)
            ubModelBase.RowCheckStatus.IsChecked = dataContext.RowCheckStatus.IsChecked;
        }
      }
    }

    public void BtnTreeCategoryClick(object p_data)
    {
      if (!(p_data is ContentPresenter contentPresenter) || !(contentPresenter.DataContext is CategoryView dataContext))
        return;
      this.SelectedDatas.Clear();
      this.SelectedDatas.AddRange((IEnumerable<CategoryView>) new List<CategoryView>()
      {
        dataContext
      });
      this.SelectedData = this.SelectedDatas.FirstOrDefault<CategoryView>();
      this.OnConfirm();
    }

    public class InitParam : ParamBase<CategoryCommonBoardVM.InitParam>
    {
      private bool? use;
      private int _TabIndex;
      private bool _IsTreeChildrenBind = true;

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

      public bool IsTreeChildrenBind
      {
        get => this._IsTreeChildrenBind;
        set
        {
          this._IsTreeChildrenBind = value;
          this.NotifyOfPropertyChange(nameof (IsTreeChildrenBind));
        }
      }
    }

    public class SearchParam : ParamBase<CategoryCommonBoardVM.SearchParam>
    {
      private DateTime _DtDate;
      private bool? use;
      private string keyword = string.Empty;
      private CommonCodeView _CtgDepth;
      private bool? _IsDepthSelect;
      private bool _IsTreeChildrenBind = true;

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

      public CommonCodeView CtgDepth
      {
        get => this._CtgDepth;
        set
        {
          this._CtgDepth = value;
          this.NotifyOfPropertyChange(nameof (CtgDepth));
          this.NotifyOfPropertyChange("IsSelectedTop");
          this.NotifyOfPropertyChange("IsSelectedMid");
          this.NotifyOfPropertyChange("IsSelectedBot");
        }
      }

      public bool IsSelectedTop => this.CtgDepth == null || this.CtgDepth.comm_TypeNo == 0 || this.CtgDepth.comm_TypeNo == 1;

      public bool IsSelectedMid => this.CtgDepth == null || this.CtgDepth.comm_TypeNo == 0 || this.CtgDepth.comm_TypeNo == 2;

      public bool IsSelectedBot => this.CtgDepth == null || this.CtgDepth.comm_TypeNo == 0 || this.CtgDepth.comm_TypeNo == 3;

      public bool? IsDepthSelect
      {
        get => this._IsDepthSelect;
        set
        {
          this._IsDepthSelect = value;
          this.NotifyOfPropertyChange(nameof (IsDepthSelect));
        }
      }

      public bool IsTreeChildrenBind
      {
        get => this._IsTreeChildrenBind;
        set
        {
          this._IsTreeChildrenBind = value;
          this.NotifyOfPropertyChange(nameof (IsTreeChildrenBind));
        }
      }
    }
  }
}
