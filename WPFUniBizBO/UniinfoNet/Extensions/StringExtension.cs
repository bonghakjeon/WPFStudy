// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.StringExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniinfoNet.Extensions
{
  public static class StringExtension
  {
    public static bool ContainsAny(this string obj, params string[] array) => ((IEnumerable<string>) array).Any<string>((Func<string, bool>) (it => obj.Contains(it)));

    public static bool ContainsAll(this string obj, params string[] array) => ((IEnumerable<string>) array).All<string>((Func<string, bool>) (it => obj.Contains(it)));

    public static string FixLeft(this string obj, int length)
    {
      int length1 = obj.Length < length ? obj.Length : length;
      return obj.Substring(0, length1).PadRight(length);
    }

    public static string FixRight(this string obj, int length)
    {
      int length1 = obj.Length < length ? obj.Length : length;
      return obj.Substring(obj.Length - length1, length1).PadLeft(length);
    }

    public static string MaxLeft(this string obj, int size) => obj.Length > size ? obj.Substring(0, size) : obj;

    public static string MaxRight(this string obj, int size) => obj.Length > size ? obj.Substring(obj.Length - size, size) : obj;

    public static string CamelCase(this string obj) => obj.Length == 0 || string.IsNullOrWhiteSpace(obj) ? obj : char.ToLower(obj[0]).ToString() + obj.Substring(1, obj.Length - 1);

    public static string ToStringWithSeparator(this IEnumerable objs, string separator = ",")
    {
      if (objs == null)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      foreach (object obj in objs)
      {
        stringBuilder.Append(obj?.ToString() ?? string.Empty);
        stringBuilder.Append(separator);
      }
      if (stringBuilder.Length >= separator.Length)
        stringBuilder.Length -= separator.Length;
      return stringBuilder.ToString();
    }
  }
}
