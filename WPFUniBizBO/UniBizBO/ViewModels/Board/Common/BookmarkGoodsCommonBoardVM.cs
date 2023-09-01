// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.BookmarkGoodsCommonBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.BookmarkGoods;
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class BookmarkGoodsCommonBoardVM : CommonBoardBase<
  #nullable disable
  BookmarkGoodsGroupView>
  {
    private string _Title = "관심 상품 조회";
    private string _TitleDesc = string.Empty;
    private BookmarkGoodsCommonBoardVM.InitParam _InitControlParam = new BookmarkGoodsCommonBoardVM.InitParam();
    private BookmarkGoodsCommonBoardVM.SearchParam param = new BookmarkGoodsCommonBoardVM.SearchParam();

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
    public BookmarkGoodsCommonBoardVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public BookmarkGoodsCommonBoardVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public BookmarkGoodsCommonBoardVM(IContainer container)
      : base(container)
    {
    }

    public BookmarkGoodsCommonBoardVM Set(
      string pTitle = null,
      string pTitleDesc = null,
      DateTime? dt_date = null,
      int si_StoreCode = 0,
      string si_StoreName = "")
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      if (dt_date.HasValue)
        this.Param.DtDate = dt_date.Value;
      if (si_StoreCode > 0)
      {
        this.Param.StoreCode = si_StoreCode;
        this.Param.StoreName = si_StoreName;
      }
      return this;
    }

    public BookmarkGoodsGroupView ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (BookmarkGoodsGroupView) null : this.SelectedData;
    }

    public override void OnQueryDefaultFunc(DefaultBoardFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (!funcType.Equals((object) DefaultBoardFunc.Search))
        return;
      this.SearchAsync();
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) new DefaultBoardFunc[3]
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
      this.InitControl();
    }

    protected void InitControl()
    {
      if (!this.InitControlParam.Use.HasValue)
        this.InitControlParam.Use = new bool?(true);
      this.Param.Use = this.InitControlParam.Use;
      this.Param.Emp_Code = this.App.User.User.Source.emp_Code;
      this.Param.Emp_Name = this.App.User.User.Source.emp_Name;
      this.Param.App_EmpCode = this.App.User.User.Source.emp_Code;
      this.SearchAsync();
    }

    public void SetParamBackup() => this.InitControlParam.Use = this.Param.Use;

    public void OnWinClose() => this.RequestClose(new bool?());

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      BookmarkGoodsCommonBoardVM goodsCommonBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await goodsCommonBoardVm.\u003C\u003En__0(p_param);
      goodsCommonBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async Task SearchAsync(JobProgressState pj = null)
    {
      BookmarkGoodsCommonBoardVM goodsCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (pj ?? __nonvirtual (goodsCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          IList<BookmarkGoodsGroupView> data = (await BookmarkGoodsRestServer.GetBookmarkGoodsGroupList(goodsCommonBoardVm.LogInPackInfo.sendType, goodsCommonBoardVm.LogInPackInfo.siteID, 0, 0, bgg_UseYn: goodsCommonBoardVm.Param.UseYn, emp_code: goodsCommonBoardVm.Param.Emp_Code, order_by: 2, KeyWord: goodsCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<BookmarkGoodsGroupView>>>((UniBizHttpClient) __nonvirtual (goodsCommonBoardVm.App).Api)).GetData<IList<BookmarkGoodsGroupView>>();
          goodsCommonBoardVm.Datas.Clear();
          goodsCommonBoardVm.Datas.AddRange((IEnumerable<BookmarkGoodsGroupView>) data);
          int count = data.Count;
          goodsCommonBoardVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (goodsCommonBoardVm.Container)).SetException(ex).ShowDialog();
      }
    }

    public async void CopyAsync(BookmarkGoodsGroupView p_data)
    {
      BookmarkGoodsCommonBoardVM goodsCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (goodsCommonBoardVm.Job).CreateJob(goodsCommonBoardVm.Title + " - 복사", (string) null))
          ;
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (goodsCommonBoardVm.Container)).SetException(goodsCommonBoardVm.Title, ex).ShowDialog();
      }
    }

    public async void DeleteAsync(BookmarkGoodsGroupView p_data)
    {
      int num = (int) new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Warning, "삭제 확인", "그룹 [" + p_data.bgg_GroupName + "]\n삭제 하시겠습니까?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog();
    }

    public void OpenData(BookmarkGoodsGroupView p_data)
    {
    }

    public void OpenData()
    {
    }

    public bool CanDataDbClick(BookmarkGoodsGroupView item) => item != null;

    public void DataDbClick(BookmarkGoodsGroupView item)
    {
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<BookmarkGoodsGroupView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<BookmarkGoodsGroupView>>((Func<WpfCommand<BookmarkGoodsGroupView>>) (() => new WpfCommand<BookmarkGoodsGroupView>().AutoRefreshOn<WpfCommand<BookmarkGoodsGroupView>>().ApplyCanExecute<BookmarkGoodsGroupView>(new Func<BookmarkGoodsGroupView, bool>(this.CanDataDbClick)).ApplyExecute<BookmarkGoodsGroupView>(new Action<BookmarkGoodsGroupView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public bool CanAdd() => true;

    public void DataOpen() => this.OpenData();

    public WpfCommand CmdAdd => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanAdd()),
        ExecuteAction = (Action<object>) (_ => this.DataOpen())
      };
    }), nameof (CmdAdd));

    public void BtnSearchBookmarkGoodsList(object p_object)
    {
      if (!(p_object is ContentPresenter contentPresenter) || !(contentPresenter.DataContext is BookmarkGoodsGroupView dataContext))
        return;
      this.OpenData(dataContext);
    }

    public void BtnWorkBookmarkGoodsList(object p_object)
    {
      if (!(p_object is ContentPresenter contentPresenter) || !(contentPresenter.DataContext is BookmarkGoodsGroupView dataContext))
        return;
      if (dataContext.bgg_InUser == this.Param.App_EmpCode)
        this.DeleteAsync(dataContext);
      else
        this.CopyAsync(dataContext);
    }

    public class InitParam : ParamBase<BookmarkGoodsCommonBoardVM.InitParam>
    {
      private bool? use = new bool?(true);

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

    public class SearchParam : ParamBase<BookmarkGoodsCommonBoardVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private string keyword = string.Empty;
      private int _Emp_Code;
      private string _Emp_Name;
      private DateTime _DtDate = DateTime.Now;
      private int _StoreCode;
      private string _StoreName = string.Empty;
      private int _App_EmpCode;

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

      public int Emp_Code
      {
        get => this._Emp_Code;
        set
        {
          this._Emp_Code = value;
          this.NotifyOfPropertyChange(nameof (Emp_Code));
        }
      }

      public string Emp_Name
      {
        get => this._Emp_Name;
        set
        {
          this._Emp_Name = value;
          this.NotifyOfPropertyChange(nameof (Emp_Name));
        }
      }

      public DateTime DtDate
      {
        get => this._DtDate;
        set
        {
          this._DtDate = value;
          this.NotifyOfPropertyChange(nameof (DtDate));
        }
      }

      public int StoreCode
      {
        get => this._StoreCode;
        set
        {
          this._StoreCode = value;
          this.NotifyOfPropertyChange(nameof (StoreCode));
        }
      }

      public string StoreName
      {
        get => this._StoreName;
        set
        {
          this._StoreName = value;
          this.NotifyOfPropertyChange(nameof (StoreName));
        }
      }

      public int App_EmpCode
      {
        get => this._App_EmpCode;
        set
        {
          this._App_EmpCode = value;
          this.NotifyOfPropertyChange(nameof (App_EmpCode));
        }
      }
    }
  }
}
