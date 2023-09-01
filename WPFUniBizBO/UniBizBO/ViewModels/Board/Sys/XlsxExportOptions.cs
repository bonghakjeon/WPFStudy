// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Sys.XlsxExportOptions
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;

namespace UniBizBO.ViewModels.Board.Sys
{
  [Flags]
  public enum XlsxExportOptions
  {
    None = 0,
    Text = 1,
    Color = 2,
    Image = 4,
  }
}
