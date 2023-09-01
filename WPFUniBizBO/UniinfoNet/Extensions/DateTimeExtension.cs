// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.DateTimeExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;

namespace UniinfoNet.Extensions
{
  public static class DateTimeExtension
  {
    public static DateTime BeginningOfMonth(this DateTime obj) => new DateTime(obj.Year, obj.Month, 1);

    public static DateTime BeginningOfYear(this DateTime obj) => new DateTime(obj.Year, 1, 1);

    public static DateTime BeginningOfDay(this DateTime obj) => new DateTime(obj.Year, obj.Month, obj.Day);
  }
}
