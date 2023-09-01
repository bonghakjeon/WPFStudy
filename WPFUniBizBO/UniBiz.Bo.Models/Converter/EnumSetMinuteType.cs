// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSetMinuteType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSetMinuteType
  {
    [Description("00분")] Minute00 = 0,
    [Description("05분")] Minute05 = 5,
    [Description("10분")] Minute10 = 10, // 0x0000000A
    [Description("15분")] Minute15 = 15, // 0x0000000F
    [Description("20분")] Minute20 = 20, // 0x00000014
    [Description("25분")] Minute25 = 25, // 0x00000019
    [Description("30분")] Minute30 = 30, // 0x0000001E
    [Description("35분")] Minute35 = 35, // 0x00000023
    [Description("40분")] Minute40 = 40, // 0x00000028
    [Description("45분")] Minute45 = 45, // 0x0000002D
    [Description("50분")] Minute50 = 50, // 0x00000032
    [Description("55분")] Minute55 = 55, // 0x00000037
  }
}
