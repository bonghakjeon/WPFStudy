// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.UniApiWsManager
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBizBO.Settings;
using UniBizUtil.Util;
using UniinfoNet.Extensions;


#nullable enable
namespace UniBizBO.Composition
{
  public class UniApiWsManager
  {
    [Inject]
    public 
    #nullable disable
    LogInPack LogInPackInfo { get; set; }

    [Inject]
    public UbHttpClient Api { get; set; }

    [Inject]
    public IEventAggregator EventAggregator { get; set; }

    private static string ClassName => MethodBase.GetCurrentMethod().ReflectedType.Name;

    private static string GetAsyncMethodName([CallerMemberName] string name = null) => name;

    public async Task ApiWebSocketConnectAsync(string p_JobID)
    {
      if (this.Api == null)
        return;
      if (AppSetting.Default.Login.ServerPath.Length == 0)
        return;
      try
      {
        if (string.IsNullOrEmpty(p_JobID))
          p_JobID = this.LogInPackInfo.sendType;
        await this.Api.ConnectWebSocketAsync(AppSetting.Default.Login.ServerPath + (AppSetting.Default.Login.ServerPath.ToRight(1).Equals("/") ? string.Empty : "/") + string.Format("ws/{0}/{1}/{2}", (object) this.LogInPackInfo.siteID, (object) p_JobID, (object) Convert.ToInt32(this.LogInPackInfo.appID)));
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n " + UniApiWsManager.ClassName + "." + UniApiWsManager.GetAsyncMethodName(nameof (ApiWebSocketConnectAsync)) + " \n - " + ex.Message);
        throw;
      }
    }

    public async Task ApiWebSocketReConnectAsync(string p_JobID)
    {
      try
      {
        Log.Logger.Information("웹소켓 재연결 시작");
        if (this.Api.BaseWebSocket != null && this.Api.BaseWebSocket.State == WebSocketState.Open)
          await this.ApiWebSocketDisconnectAsync();
        if (!string.IsNullOrEmpty(p_JobID))
        {
          await this.Api.ConnectWebSocketAsync(AppSetting.Default.Login.ServerPath + (AppSetting.Default.Login.ServerPath.ToRight(1).Equals("/") ? string.Empty : "/") + string.Format("ws/{0}/{1}/{2}", (object) this.LogInPackInfo.siteID, (object) p_JobID, (object) Convert.ToInt32(this.LogInPackInfo.appID)));
          Log.Logger.Information("웹소켓 재연결 성공");
        }
        Log.Logger.Information("웹소켓 재연결 종료");
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("웹소켓 재연결 실패\n " + UniApiWsManager.ClassName + "." + UniApiWsManager.GetAsyncMethodName(nameof (ApiWebSocketReConnectAsync)) + " \n - " + ex.Message);
      }
    }

    public async Task ApiWebSocketDisconnectAsync()
    {
      try
      {
        Log.Logger.Information("웹소켓 해제 시작");
        if (this.Api == null || this.Api.BaseWebSocket != null && this.Api.BaseWebSocket.State == WebSocketState.Closed)
          return;
        await this.Api.BaseWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the ConnectionManager", CancellationToken.None);
        Log.Logger.Information("웹소켓 해제 종료");
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n " + UniApiWsManager.ClassName + "." + UniApiWsManager.GetAsyncMethodName(nameof (ApiWebSocketDisconnectAsync)) + " \n - " + ex.Message);
      }
    }

    public async Task RecvMessageAsync(string pMessage)
    {
      UniApiWsManager pSender = this;
      object obj = (object) null;
      int num = 0;
      try
      {
        try
        {
          if (pMessage.Length != 0)
          {
            if (pMessage.Contains("resource"))
            {
              JobEvtBase jobEvtBase = JsonSerializer.Deserialize<JobEvtBase>(pMessage);
              if (jobEvtBase != null)
              {
                switch (jobEvtBase.JobType)
                {
                  case EnumJobEvtMessageType.Start:
                  case EnumJobEvtMessageType.Progressing:
                  case EnumJobEvtMessageType.Stopped:
                  case EnumJobEvtMessageType.Completed:
                  case EnumJobEvtMessageType.Message:
                  case EnumJobEvtMessageType.ErrMessage:
                    pSender.EventAggregator.PublishOnUIThread((object) new UniApiWsJobEvtString((object) pSender, jobEvtBase.JobId, jobEvtBase.JobType, pMessage));
                    goto label_10;
                  default:
                    Log.Logger.Debug("\nWEB SOKET RECV DEFAULT NO WORK\n" + jobEvtBase.ToJson<JobEvtBase>() + "\n");
                    goto label_10;
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          Log.Logger.ErrorColor("\nWEB SOKET RECV ERROR\n" + UniApiWsManager.GetAsyncMethodName(nameof (RecvMessageAsync)) + "\nERROR = " + ex.Message);
          throw;
        }
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
label_10:
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return;
      obj = (object) null;
    }

    public async Task AppStoppingAsync()
    {
      Log.Logger.Information("App 종료 작업 시작");
      await this.ApiWebSocketDisconnectAsync();
      Log.Logger.Information("App 종료 작업 종료");
    }
  }
}
