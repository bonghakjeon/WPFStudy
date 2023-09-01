// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.DebugExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace UniinfoNet.Extensions
{
  public static class DebugExtension
  {
    public static string ToStackLog<T>(
      this T obj,
      int stackSkip = 0,
      int stackDepth = 4,
      [CallerFilePath] string filePath = "",
      [CallerLineNumber] int line = 0,
      [CallerMemberName] string name = "")
    {
      StackTrace stackTrace = new StackTrace();
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = stackSkip + 1; index < stackDepth + stackSkip + 1; ++index)
      {
        StackFrame frame = stackTrace.GetFrame(index);
        stringBuilder.Append("<" + frame.GetMethod().Name + ">");
      }
      stringBuilder.Append(": [").Append(obj.GetType().Name).Append("] ");
      return stringBuilder.ToString();
    }

    public static string ToJson<T>(this T obj, int maxJsonDepth = 1) => JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions()
    {
      WriteIndented = false,
      IgnoreNullValues = false,
      MaxDepth = maxJsonDepth
    });

    public static string ToDebugInfo<T>(
      this T obj,
      int maxJsonDepth = 1,
      int stackSkip = 0,
      int stackDepth = 4,
      [CallerFilePath] string filePath = "",
      [CallerLineNumber] int line = 0,
      [CallerMemberName] string name = "")
    {
      return obj.ToStackLog<T>(1, filePath: "D:\\Source\\UniinfoNet\\UniinfoNet\\Extensions\\DebugExtension.cs", line: 26, name: nameof (ToDebugInfo)) + "\n" + obj.ToJson<T>();
    }
  }
}
