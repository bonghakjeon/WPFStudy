// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSlipTextFormat
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSlipTextFormat
  {
    [Description("-인쇄형식-")] NONE = 0,
    [Description("굵게")] Bold = 1,
    [Description("가로")] Horizontal = 2,
    [Description("세로")] Vertical = 4,
    [Description("역상")] Reverse = 8,
    [Description("밑줄")] UnderLine = 16, // 0x00000010
    [Description("강조")] Emphasize = 32, // 0x00000020
    [Description("윗줄")] OverLine = 64, // 0x00000040
  }
}
