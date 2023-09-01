// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.IEnumerableExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace UniinfoNet.Extensions
{
  public static class IEnumerableExtension
  {
    public static IEnumerable<T> OrderByShuffle<T>(this IEnumerable<T> obj)
    {
      Random r = RandomExtension.ThreadSafeRandom;
      return (IEnumerable<T>) obj.OrderBy<T, int>((Func<T, int>) (it => r.Next()));
    }
  }
}
