// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Utils.CastToUtil`1
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Linq.Expressions;

namespace UniinfoNet.Utils
{
  public static class CastToUtil<T>
  {
    public static T From<S>(S s) => CastToUtil<T>.Cache<S>.caster(s);

    private static class Cache<S>
    {
      public static readonly Func<S, T> caster = CastToUtil<T>.Cache<S>.Get();

      private static Func<S, T> Get() => ((Expression<Func<S, T>>) (s => {checked {(T) s;}})).Compile();
    }
  }
}
