// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.IListExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;

namespace UniinfoNet.Extensions
{
  public static class IListExtension
  {
    public static void Shuffle<T>(this IList<T> obj)
    {
      Random threadSafeRandom = RandomExtension.ThreadSafeRandom;
      int count = obj.Count;
      while (count > 1)
      {
        --count;
        int index = threadSafeRandom.Next(count + 1);
        T obj1 = obj[index];
        obj[index] = obj[count];
        obj[count] = obj1;
      }
    }
  }
}
