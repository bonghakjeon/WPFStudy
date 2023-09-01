// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType.RegTypeHistoryPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniMembers.Info;
using UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Http.UniBiz;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType
{
  public class RegTypeHistoryPageVM : RegTypePageBase<
  #nullable disable
  MemberTypeHistoryView>, ISystemPage
  {
    public RegTypeHistoryPageVM(IContainer container)
      : base(container)
    {
    }

    protected override void InitControl() => base.InitControl();

    protected override void OnClose() => base.OnClose();

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public override async Task SearchAsync()
    {
      RegTypeHistoryPageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          long num = sender.Param.IsDate ? sender.Param.DtDate.ToLong() : 0L;
          string useYn = sender.Param.UseYn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          long dt_date = num;
          string mt_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<MemberTypeHistoryView>> success = (await MemberInfoRestServer.GetMemberTypeHistoryList(sendType, siteId, code, 0, dt_date: dt_date, mt_UseYn: mt_UseYn, OrderByType: 1, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<MemberTypeHistoryView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<MemberTypeHistoryView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<MemberTypeHistoryView>) success.response);
          if (sender.Datas.Count >= 0)
          {
            sender.DisplaySearchCount = success.response.Count;
            // ISSUE: explicit non-virtual call
            IEventAggregator eventAggregator = __nonvirtual (sender.EventAggregator);
            OpenedPageMsg message = new OpenedPageMsg((IUbVM) sender);
            message.Page = (IPage) sender;
            message.DisplaySearchCount = sender.DisplaySearchCount;
            // ISSUE: explicit non-virtual call
            message.DisplayTitle = __nonvirtual (sender.MenuInfo).Name;
            string[] strArray = Array.Empty<string>();
            eventAggregator.PublishOnUIThread((object) message, strArray);
          }
          sender.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (sender.MenuInfo).Title + " 오류=" + ex.Message);
      }
    }

    public override async void DataOpen(MemberTypeHistoryView item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }
  }
}
