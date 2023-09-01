// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.WebSocket.TestWebSoketWsBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBizBO.Composition;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.WebSocket
{
  public class TestWebSoketWsBoardVM : 
    CommonBoardBase<
    #nullable disable
    UniApiWsJobEvtString>,
    IHandle<UniApiWsJobEvtString>,
    IHandle
  {
    private string _Title = "웹소켓 테스트 보드";
    private string _TitleDesc = string.Empty;

    public string JobId { get; set; }

    public JobProgressState JobState { get; set; }

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

    public TestWebSoketWsBoardVM(IContainer container)
      : base(container)
    {
    }

    public TestWebSoketWsBoardVM Set(string pTitle = null, string pTitleDesc = null)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      return this;
    }

    public IList<UniApiWsJobEvtString> ShowDialog2Datas()
    {
      this.IsMultiSelectMode = true;
      this.WindowManager.ShowDialog((object) this);
      return (IList<UniApiWsJobEvtString>) this.Datas;
    }

    public void Handle(UniApiWsJobEvtString pMessage)
    {
      if (!string.Equals(this.JobId, pMessage.JobId))
        return;
      if (this.JobState == null)
        this.JobState = this.Job.CreateJob((string) null, (string) null).Cancelable((Action) (() => this.WorkStopAsync()));
      switch (pMessage.JobType)
      {
        case EnumJobEvtMessageType.Start:
          this.JobState.Title = JsonSerializer.Deserialize<JobEvtStart>(pMessage.Item).Title;
          this.JobState.IsIndeterminate = true;
          break;
        case EnumJobEvtMessageType.Progressing:
          JobEvtProgressing jobEvtProgressing = JsonSerializer.Deserialize<JobEvtProgressing>(pMessage.Item);
          this.JobState.Title = jobEvtProgressing.Title;
          this.JobState.Msg = jobEvtProgressing.Msg;
          this.JobState.Value = new double?(jobEvtProgressing.ProgressValue);
          break;
        case EnumJobEvtMessageType.Stopped:
          JobEvtStopped stop = JsonSerializer.Deserialize<JobEvtStopped>(pMessage.Item);
          this.App.ApiWebSocket.ApiWebSocketDisconnectAsync();
          ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() =>
          {
            int num = (int) this.Container.Get<CommonMsgVM>().SetDefault(MsgBoxLevel.Error, "작업 중지", stop.Msg, MsgBoxButton.Confirm).ShowDialog();
            if (this.JobState != null)
              this.JobState.Dispose();
            this.JobState = (JobProgressState) null;
          }));
          break;
        case EnumJobEvtMessageType.Completed:
          JsonSerializer.Deserialize<JobEvtCompleted>(pMessage.Item);
          if (this.JobState != null)
            this.JobState.Dispose();
          this.JobState = (JobProgressState) null;
          this.App.ApiWebSocket.ApiWebSocketDisconnectAsync();
          break;
        case EnumJobEvtMessageType.Message:
          this.Datas.Add(pMessage);
          this.SelectedData = this.Datas.LastOrDefault<UniApiWsJobEvtString>();
          this.JobState.Msg = JsonSerializer.Deserialize<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>(pMessage.Item).Msg;
          break;
        case EnumJobEvtMessageType.ErrMessage:
          this.Datas.Add(pMessage);
          break;
      }
    }

    public WpfCommand CmdWorkStart
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.CanExecuteFunc = (Func<object, bool>) (_ => this.CanWorkStart());
        wpfCommand.ExecuteAction = (Action<object>) (async _ => await this.WorkStartAsync());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdWorkStart));
      }
    }

    public bool CanWorkStart() => this.JobState == null;

    public async Task WorkStartAsync()
    {
      TestWebSoketWsBoardVM webSoketWsBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (webSoketWsBoardVm.Job).CreateJob((string) null, (string) null))
        {
          webSoketWsBoardVm.Datas.Clear();
          if (string.IsNullOrEmpty(webSoketWsBoardVm.JobId))
            webSoketWsBoardVm.JobId = Guid.NewGuid().ToString();
          // ISSUE: explicit non-virtual call
          await __nonvirtual (webSoketWsBoardVm.App).ApiWebSocket.ApiWebSocketReConnectAsync(webSoketWsBoardVm.JobId);
          await Task.Delay(500);
          // ISSUE: explicit non-virtual call
          (await EmployeeRestServer.PostWebSocketTest(webSoketWsBoardVm.LogInPackInfo.sendType, webSoketWsBoardVm.JobId, webSoketWsBoardVm.LogInPackInfo.siteID, 0, 0).ExecuteToReturnAsync<UbRes<JobEvtEodReWork>>((UniBizHttpClient) __nonvirtual (webSoketWsBoardVm.App).Api)).GetSuccess<UbRes<JobEvtEodReWork>>().GetSuccess<UbRes<JobEvtEodReWork>>();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public async Task WorkStopAsync()
    {
      TestWebSoketWsBoardVM webSoketWsBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        (await EmployeeRestServer.DeleteWebSocketTest(webSoketWsBoardVm.LogInPackInfo.sendType, webSoketWsBoardVm.LogInPackInfo.siteID, 0, 0, webSoketWsBoardVm.JobId).ExecuteToReturnAsync<UbRes<bool>>((UniBizHttpClient) __nonvirtual (webSoketWsBoardVm.App).Api)).GetSuccess<UbRes<bool>>().GetSuccess<UbRes<bool>>();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }
  }
}
