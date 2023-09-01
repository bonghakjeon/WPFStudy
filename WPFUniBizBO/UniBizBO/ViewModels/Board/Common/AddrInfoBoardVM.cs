// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.AddrInfoBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Models.Addr;
using Models.Addr.MoisGoKr;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class AddrInfoBoardVM : CommonBoardBase<
  #nullable disable
  AddrInfoView>
  {
    private AddrInfoBoardVM.SearchParam _Param = new AddrInfoBoardVM.SearchParam();
    private string _FooterRemark = string.Empty;

    public AddrInfoBoardVM.SearchParam Param
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

    public AddrInfoBoardVM(IContainer container)
      : base(container)
    {
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) new DefaultBoardFunc[3]
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
    }

    public override void OnQueryDefaultFunc(DefaultBoardFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (!funcType.Equals((object) DefaultBoardFunc.Search))
        return;
      this.SearchAsync();
    }

    public void OnWinClose() => this.RequestClose(new bool?());

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      AddrInfoBoardVM addrInfoBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await addrInfoBoardVm.\u003C\u003En__0(p_param);
      addrInfoBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void SearchAsync(int CurrentPage = 1)
    {
      AddrInfoBoardVM addrInfoBoardVm = this;
      try
      {
        if (addrInfoBoardVm.Param.Keyword.Length == 0)
          throw new Exception("[키워드]를 등록하여 주세요.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (addrInfoBoardVm.Job).CreateJob("조회", (string) null))
        {
          addrInfoBoardVm.Datas.Clear();
          addrInfoBoardVm.FooterRemark = string.Empty;
          UbRes<List<AddrInfoView>> listAsync = await AddrInfoView.GetListAsync(addrInfoBoardVm.Param.Keyword, CurrentPage);
          if (!listAsync.isSuccess)
            throw new Exception(listAsync.message);
          addrInfoBoardVm.Datas.AddRange((IEnumerable<AddrInfoView>) listAsync.response);
          addrInfoBoardVm.Param.TotalCount = (int) listAsync.code;
          addrInfoBoardVm.Param.CurrentPage = CurrentPage;
          if (addrInfoBoardVm.Datas.Count > 0)
          {
            addrInfoBoardVm.OnAppWinMsgArgsRequested("GRID");
            addrInfoBoardVm.FooterRemark = "[" + addrInfoBoardVm.Datas.Count.ToString("n0") + "] 건 조회";
          }
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (addrInfoBoardVm.Container)).SetException(ex).ShowDialog();
        await Task.Yield();
        // ISSUE: explicit non-virtual call
        // ISSUE: reference to a compiler-generated method
        ((DispatcherObject) __nonvirtual (addrInfoBoardVm.View)).Dispatcher.InvokeAsync(new Action(addrInfoBoardVm.\u003CSearchAsync\u003Eb__13_0), (DispatcherPriority) 4);
      }
    }

    public bool CanDataDbClick(AddrInfoView item) => item != null;

    public void DataDbClick(AddrInfoView item)
    {
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<AddrInfoView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<AddrInfoView>>((Func<WpfCommand<AddrInfoView>>) (() => new WpfCommand<AddrInfoView>().AutoRefreshOn<WpfCommand<AddrInfoView>>().ApplyCanExecute<AddrInfoView>(new Func<AddrInfoView, bool>(this.CanDataDbClick)).ApplyExecute<AddrInfoView>(new Action<AddrInfoView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public void BtnBringToFront()
    {
      if (1 == this.Param.CurrentPage)
        return;
      this.SearchAsync();
    }

    public void BtnBringForward()
    {
      if (1 == this.Param.CurrentPage)
        return;
      this.SearchAsync(this.Param.CurrentPage - 1);
    }

    public void BtnSendBackward()
    {
      if (this.Param.TotalCount == this.Param.CurrentPage)
        return;
      this.SearchAsync(this.Param.CurrentPage + 1);
    }

    public void BtnSendToBack()
    {
      if (this.Param.TotalCount == this.Param.CurrentPage)
        return;
      this.SearchAsync(this.Param.TotalCount);
    }

    public class SearchParam : ParamBase<AddrInfoBoardVM.SearchParam>
    {
      private string _Keyword = string.Empty;
      private int _TotalCount = 1;
      private int _CurrentPage = 1;

      public string Keyword
      {
        get => this._Keyword;
        set
        {
          this._Keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public int TotalCount
      {
        get => this._TotalCount;
        set
        {
          this._TotalCount = value;
          this.NotifyOfPropertyChange(nameof (TotalCount));
        }
      }

      public int CurrentPage
      {
        get => this._CurrentPage;
        set
        {
          this._CurrentPage = value;
          this.NotifyOfPropertyChange(nameof (CurrentPage));
        }
      }
    }
  }
}
