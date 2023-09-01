// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType.RegTypePageVM
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
using UniBiz.Bo.Models.UniMembers.Info.MemberType;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Http.UniBiz;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType
{
  public class RegTypePageVM : RegTypePageBase<
  #nullable disable
  MemberTypeView>, ISystemPage
  {
    public RegTypePageVM(IContainer container)
      : base(container)
    {
    }

    protected override void InitControl()
    {
      this.Param.IsDate = false;
      base.InitControl();
    }

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
      RegTypePageVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          string sendType = sender.LogInPackInfo.sendType;
          long siteId = sender.LogInPackInfo.siteID;
          string useYn = sender.Param.UseYn;
          string keyword = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (sender.MenuInfo).Code;
          string mt_UseYn = useYn;
          string KeyWord = keyword;
          // ISSUE: explicit non-virtual call
          UbRes<IList<MemberTypeView>> success = (await MemberInfoRestServer.GetMemberTypeList(sendType, siteId, code, 0, mt_UseYn: mt_UseYn, KeyWord: KeyWord).ExecuteToReturnAsync<UbRes<IList<MemberTypeView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<MemberTypeView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<MemberTypeView>) success.response);
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

    public override async void DataOpen(MemberTypeView item)
    {
      int num = (int) new CommonMsgVM(this.Container).Set("Test", "기능 개발 중...").ShowDialog();
    }
  }
}
