// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.PageBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniBizBO.Composition;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Services.Page
{
  [HiddenVm]
  public abstract class PageBase : 
    UbScreen,
    IPage,
    IDefaultFuncAbleVM<
    #nullable disable
    DefaultPageFunc>,
    IAppWinMsgEventArgs,
    IHandle<MenuBookMarkChangeMsg>,
    IHandle
  {
    private PageMenuInfo menuInfo;
    private int _DisplaySearchCount;
    private bool _IsBookMark;

    public PageMenuInfo MenuInfo
    {
      get => this.menuInfo;
      set => this.SetAndNotify<PageMenuInfo>(ref this.menuInfo, value, nameof (MenuInfo));
    }

    public int DisplaySearchCount
    {
      get => this._DisplaySearchCount;
      set
      {
        this._DisplaySearchCount = value;
        this.NotifyOfPropertyChange(nameof (DisplaySearchCount));
        this.NotifyOfPropertyChange("DisplaySearchCountDesc");
      }
    }

    public string DisplaySearchCountDesc => "[" + this.DisplaySearchCount.ToString("#,##0") + "] 건 조회";

    public bool IsBookMark
    {
      get => this._IsBookMark;
      set
      {
        this._IsBookMark = value;
        this.NotifyOfPropertyChange(nameof (IsBookMark));
      }
    }

    public PageBase(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.DataHeaders = this.OnQueryDataHeaders();
      this.DisplayName = this.menuInfo.Name;
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      this.IsBookMark = this.App.User.MenuBookMarkList.Where<ProgMenuBookMarkView>((Func<ProgMenuBookMarkView, bool>) (x => x.pmbm_MenuCode.Equals(this.menuInfo.Code))).FirstOrDefault<ProgMenuBookMarkView>() != null;
    }

    public virtual IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => (IReadOnlyDictionary<string, TableColumnInfo>) null;

    public virtual bool OnQueryCanDefaultFunc(DefaultPageFunc funcType) => true;

    public virtual void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
    }

    public void SendParamBeforePage(IPage sender)
    {
      if (!(this.Parent is IParentPage parent))
        return;
      parent.SendParamBeforePage(sender);
    }

    public virtual void OnReceiveBeforePage(IPage sender) => this.OnAppWinMsgArgsRequested("GRID");

    public async Task SendParamAfterPageAsync(
      IPage sender,
      ParamBase param,
      IDictionary<string, object> arg = null)
    {
      if (!(this.Parent is IParentPage parent))
        return;
      await parent.SendParamAfterPageAsync(sender, param, arg);
    }

    public virtual async Task OnReceiveParamAsync(
      IPage sender,
      ParamBase param,
      IDictionary<string, object> arg = null)
    {
      await Task.Yield();
    }

    public WpfCommand<object> CmdDefaultFunc => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<object>>((Func<WpfCommand<object>>) (() => new WpfCommand<object>().AutoRefreshOn<WpfCommand<object>>().ApplyCanExecute<object>((Func<object, bool>) (it =>
    {
      DefaultPageFunc funcType = (DefaultPageFunc) null;
      if (it is string name2)
        funcType = new DefaultPageFunc(name2);
      if (it is DefaultPageFunc defaultPageFunc2)
        funcType = defaultPageFunc2;
      return this.OnQueryCanDefaultFunc(funcType);
    })).ApplyExecute<object>((Action<object>) (it =>
    {
      DefaultPageFunc funcType = (DefaultPageFunc) null;
      if (it is string name4)
        funcType = new DefaultPageFunc(name4);
      if (it is DefaultPageFunc defaultPageFunc4)
        funcType = defaultPageFunc4;
      this.OnQueryDefaultFunc(funcType);
    }))), nameof (CmdDefaultFunc));

    public virtual IEnumerable<DefaultPageFunc> DefaultFuncs { get; set; }

    public async Task RegBookMarkAsync()
    {
      PageBase pageBase = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: reference to a compiler-generated method
        ProgMenuBookMarkView bookMarkItem = __nonvirtual (pageBase.App).User.MenuBookMarkList.Where<ProgMenuBookMarkView>(new Func<ProgMenuBookMarkView, bool>(pageBase.\u003CRegBookMarkAsync\u003Eb__30_0)).FirstOrDefault<ProgMenuBookMarkView>();
        pageBase.IsBookMark = bookMarkItem != null;
        JobProgressState j;
        if (!pageBase.IsBookMark)
        {
          bookMarkItem = new ProgMenuBookMarkView();
          bookMarkItem.pmbm_ID = 0L;
          bookMarkItem.pmbm_SiteID = pageBase.LogInPackInfo.siteID;
          bookMarkItem.pmbm_EmpCode = pageBase.LogInPackInfo.employee.emp_Code;
          // ISSUE: explicit non-virtual call
          bookMarkItem.pmbm_Title = __nonvirtual (pageBase.MenuInfo).Title;
          // ISSUE: explicit non-virtual call
          bookMarkItem.pmbm_MenuCode = __nonvirtual (pageBase.MenuInfo).Code;
          bookMarkItem.pmbm_AppType = 26;
          bookMarkItem.pmbm_ViewType = 2;
          bookMarkItem.pmbm_Parent = 0L;
          // ISSUE: explicit non-virtual call
          bookMarkItem.pmbm_Order = __nonvirtual (pageBase.App).User.MenuBookMarkList.Count + 1;
          bookMarkItem.pmbm_Depth = 1;
          bookMarkItem.db_status = 1;
          // ISSUE: explicit non-virtual call
          j = __nonvirtual (pageBase.Job).CreateJob("즐겨찾기 등록", (string) null);
          try
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            UbRes<ProgMenuBookMarkView> success = (await ProgMenuInfoRestServer.PostProgMenuBookMark(pageBase.LogInPackInfo.sendType, pageBase.LogInPackInfo.siteID, bookMarkItem.pmbm_ID, __nonvirtual (pageBase.MenuInfo).Code, 0, bookMarkItem).ExecuteToReturnAsync<UbRes<ProgMenuBookMarkView>>((UniBizHttpClient) __nonvirtual (pageBase.App).Api)).GetSuccess<UbRes<ProgMenuBookMarkView>>();
            if (!success.isSuccess)
              throw new Exception(success.message);
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageBase.App).User.MenuBookMarkList.Add(success.response);
            pageBase.IsBookMark = true;
          }
          finally
          {
            j?.Dispose();
          }
          j = (JobProgressState) null;
        }
        else
        {
          // ISSUE: explicit non-virtual call
          j = __nonvirtual (pageBase.Job).CreateJob("즐겨찾기 삭제", (string) null);
          try
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            UbRes<ProgMenuBookMarkView> success = (await ProgMenuInfoRestServer.DeleteProgMenuBookMark(pageBase.LogInPackInfo.sendType, pageBase.LogInPackInfo.siteID, bookMarkItem.pmbm_ID, __nonvirtual (pageBase.MenuInfo).Code, 0).ExecuteToReturnAsync<UbRes<ProgMenuBookMarkView>>((UniBizHttpClient) __nonvirtual (pageBase.App).Api)).GetSuccess<UbRes<ProgMenuBookMarkView>>();
            if (!success.isSuccess)
              throw new Exception(success.message);
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageBase.App).User.MenuBookMarkList.Remove(bookMarkItem);
            pageBase.IsBookMark = false;
          }
          finally
          {
            j?.Dispose();
          }
          j = (JobProgressState) null;
        }
        bookMarkItem = (ProgMenuBookMarkView) null;
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageBase.Container)).Set("즐겨찾기 등록/삭제 오류", ex.Message).ShowDialog();
      }
    }

    public virtual async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param) => await Task.Yield();

    public event EventHandler<AppWinMsgEventArgs> AppWinMsgArgsRequested;

    public virtual void OnAppWinMsgArgsRequested(
      string propertyName,
      int propertyKeyNnumber = 0,
      int propertyMessage = 0,
      long propertyWParam = 0,
      long propertyLParam = 0)
    {
      EventHandler<AppWinMsgEventArgs> msgArgsRequested = this.AppWinMsgArgsRequested;
      if (msgArgsRequested == null)
        return;
      msgArgsRequested((object) this, new AppWinMsgEventArgs(propertyName, propertyKeyNnumber, propertyMessage, propertyWParam, propertyLParam));
    }

    public void RequestCloseFromContainer(bool? dialogResult = null)
    {
      if (this.Parent is IParentPage parent)
        parent.RequestCloseFromContainer(dialogResult);
      else
        this.RequestClose(dialogResult);
    }

    public void CloseItem() => this.EventAggregator.PublishOnUIThread((object) new CloseTabPageItemMsg((IUbVM) this));

    public WpfCommand CmdRequestCloseFromContainer => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        ExecuteAction = (Action<object>) (x => this.RequestCloseFromContainer(new bool?()))
      };
    }), nameof (CmdRequestCloseFromContainer));

    public void Handle(MenuBookMarkChangeMsg message)
    {
      if (!this.IsActive)
        return;
      this.IsBookMark = this.App.User.MenuBookMarkList.Where<ProgMenuBookMarkView>((Func<ProgMenuBookMarkView, bool>) (x => x.pmbm_MenuCode.Equals(this.menuInfo.Code))).FirstOrDefault<ProgMenuBookMarkView>() != null;
    }
  }
}
