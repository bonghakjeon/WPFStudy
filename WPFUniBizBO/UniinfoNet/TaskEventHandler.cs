// Decompiled with JetBrains decompiler
// Type: UniinfoNet.TaskEventHandlerExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


#nullable enable
namespace UniinfoNet
{
  public static class TaskEventHandlerExtension
  {
    public static 
    #nullable disable
    IEnumerable<T> GetHandlers<T>(this T handler) where T : Delegate => handler.GetInvocationList().Cast<T>();

    public static Task InvokeAllAsync<TSender>(
      this TaskEventHandler<TSender> handler,
      TSender sender)
      where TSender : class
    {
      return handler == null ? Task.CompletedTask : Task.WhenAll(handler.GetHandlers<TaskEventHandler<TSender>>().Select<TaskEventHandler<TSender>, Task>((Func<TaskEventHandler<TSender>, Task>) (handleAsync => handleAsync(sender))));
    }

    public static Task InvokeAllAsync<TSender, TEventArg>(
      this TaskEventHandler<TSender, TEventArg> handler,
      TSender sender,
      TEventArg arg)
      where TSender : class
    {
      return handler == null ? Task.CompletedTask : Task.WhenAll(handler.GetHandlers<TaskEventHandler<TSender, TEventArg>>().Select<TaskEventHandler<TSender, TEventArg>, Task>((Func<TaskEventHandler<TSender, TEventArg>, Task>) (handleAsync => handleAsync(sender, arg))));
    }

    public static async Task InvokeAsync<TSender>(
      this TaskEventHandler<TSender> handler,
      TSender sender)
      where TSender : class
    {
      if (handler == null)
        await Task.CompletedTask;
      foreach (TaskEventHandler<TSender> handler1 in handler.GetHandlers<TaskEventHandler<TSender>>())
        await handler1(sender);
    }

    public static async Task InvokeAsync<TSender, TEventArg>(
      this TaskEventHandler<TSender, TEventArg> handler,
      TSender sender,
      TEventArg arg)
      where TSender : class
    {
      if (handler == null)
        await Task.CompletedTask;
      foreach (TaskEventHandler<TSender, TEventArg> handler1 in handler.GetHandlers<TaskEventHandler<TSender, TEventArg>>())
        await handler1(sender, arg);
    }

    public static async Task InvokeAsync<TSender, TEventArg>(
      this TaskCancelEventHandler<TSender, TEventArg> handler,
      TSender sender,
      TEventArg arg)
      where TSender : class
      where TEventArg : CancelEventArgs
    {
      if (handler == null)
        await Task.CompletedTask;
      foreach (TaskCancelEventHandler<TSender, TEventArg> handler1 in handler.GetHandlers<TaskCancelEventHandler<TSender, TEventArg>>())
      {
        await handler1(sender, arg);
        if (((TEventArg) arg).Cancel)
          break;
      }
    }
  }
}
