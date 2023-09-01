// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.LogExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace UniinfoNet.Extensions
{
  public static class LogExtension
  {
    public static string ToLog<T>(this T obj)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (!EqualityComparer<T>.Default.Equals(obj, default (T)) || typeof (T).IsValueType)
        stringBuilder.Append(obj.GetType().Name);
      else
        stringBuilder.Append(obj?.GetType()?.Name);
      return stringBuilder.ToString();
    }

    public static string ToLog<T, P>(
      this T obj,
      P param,
      int depth = 2,
      [CallerFilePath] string filePath = "",
      [CallerLineNumber] int line = 0,
      [CallerMemberName] string name = "")
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(string.Format("{0}|{1,4:###0}|{2}|{3}:", (object) ((IEnumerable<string>) filePath.Split('\\')).LastOrDefault<string>(), (object) line, (object) name.FixLeft(15), (object) (obj?.GetType()?.Name ?? "Null").FixLeft(15)));
      if ((object) param != null)
        param.Action<P>((Action<P>) (it => sb.Append((object) it)));
      return sb.ToString();
    }

    public static string ToLog<T>(this T obj, int depth = 2, [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0, [CallerMemberName] string name = "") => obj.ToLog<T, string>((string) null, depth, filePath, line, name);

    public static string ToStackLog<T>(this T obj, int skip = 1, int depth = 3)
    {
      StackTrace stackTrace = new StackTrace();
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = skip; index < depth + skip; ++index)
      {
        StackFrame frame = stackTrace.GetFrame(index);
        stringBuilder.Append("- <" + frame.GetMethod().Name + "> ");
      }
      stringBuilder.Append(": [").Append(obj.GetType().Name).Append("] ");
      stringBuilder.Append(obj.ToLog<T>());
      return stringBuilder.ToString();
    }

    public static string ToCallerLog<T>(this T obj, [CallerMemberName] string name = "") => string.Format("{0}:{1}", (object) typeof (T), (object) name);
  }
}
