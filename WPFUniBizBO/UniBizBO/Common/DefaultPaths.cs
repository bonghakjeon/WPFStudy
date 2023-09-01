// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.DefaultPaths
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.IO;

namespace UniBizBO.Common
{
  public static class DefaultPaths
  {
    public static string CommonDataFolderPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Uniinfo", "UniBizBO");

    public static string DbFolderPath { get; } = Path.Combine(DefaultPaths.CommonDataFolderPath, "Database");

    public static string TempFolderPath { get; } = Path.Combine(DefaultPaths.CommonDataFolderPath, "Temp");

    public static string LabelTemplateTempFolderPath { get; } = Path.Combine(DefaultPaths.CommonDataFolderPath, "LabelTemplate");
  }
}
