// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.IDictionaryExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UniinfoNet.Extensions
{
  public static class IDictionaryExtension
  {
    public static R GetValueOrInsert<T, R>(
      this IDictionary<string, T> obj,
      Func<R> factory,
      [CallerMemberName] string key = "")
      where R : T
    {
      T valueOrInsert1;
      if (obj.TryGetValue(key, out valueOrInsert1))
        return (R) (object) valueOrInsert1;
      if (factory == null)
        return default (R);
      T valueOrInsert2 = (T) factory();
      obj[key] = valueOrInsert2;
      return (R) (object) valueOrInsert2;
    }

    public static R GetValueOrInsert<T, R>(this IDictionary<string, T> obj, R item, [CallerMemberName] string key = "") where R : T
    {
      T valueOrInsert1;
      if (obj.TryGetValue(key, out valueOrInsert1))
        return (R) (object) valueOrInsert1;
      T valueOrInsert2 = (T) item;
      obj[key] = valueOrInsert2;
      return (R) (object) valueOrInsert2;
    }
  }
}
