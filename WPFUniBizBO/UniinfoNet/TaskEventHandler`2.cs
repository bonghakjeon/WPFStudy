// Decompiled with JetBrains decompiler
// Type: UniinfoNet.TaskEventHandler`2
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Threading.Tasks;

namespace UniinfoNet
{
  public delegate Task TaskEventHandler<TSender, TEventArg>(TSender sender, TEventArg e) where TSender : class;
}
