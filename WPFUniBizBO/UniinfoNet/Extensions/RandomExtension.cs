// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.RandomExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Threading;

namespace UniinfoNet.Extensions
{
  public static class RandomExtension
  {
    [ThreadStatic]
    private static Random threadSafeRandom;

    public static Random ThreadSafeRandom => RandomExtension.threadSafeRandom ?? (RandomExtension.threadSafeRandom = new Random(Environment.TickCount + Thread.GetCurrentProcessorId()));
  }
}
