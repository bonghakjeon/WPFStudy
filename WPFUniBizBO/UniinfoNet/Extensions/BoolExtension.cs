// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.BoolExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;

namespace UniinfoNet.Extensions
{
  public static class BoolExtension
  {
    public static bool BoolAction(this bool obj, bool condition, Action action)
    {
      if (obj == condition)
        action();
      return obj;
    }

    public static bool? BoolAction(this bool? obj, bool? condition, Action action)
    {
      bool? nullable1 = obj;
      bool? nullable2 = condition;
      if (nullable1.GetValueOrDefault() == nullable2.GetValueOrDefault() & nullable1.HasValue == nullable2.HasValue)
        action();
      return obj;
    }

    public static R BoolFunc<R>(this bool obj, bool condition, Func<R> func) => obj == condition ? func() : default (R);

    public static R BoolFunc<R>(this bool? obj, bool? condition, Func<R> func)
    {
      bool? nullable1 = obj;
      bool? nullable2 = condition;
      return nullable1.GetValueOrDefault() == nullable2.GetValueOrDefault() & nullable1.HasValue == nullable2.HasValue ? func() : default (R);
    }
  }
}
