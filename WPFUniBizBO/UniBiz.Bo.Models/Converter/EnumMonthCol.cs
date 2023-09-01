// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMonthCol
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMonthCol
  {
    [Description("미설정")] NONE = 0,
    [Description("01월")] MONTH_01 = 1,
    [Description("02월")] MONTH_02 = 2,
    [Description("03월")] MONTH_03 = 4,
    [Description("04월")] MONTH_04 = 8,
    [Description("05월")] MONTH_05 = 16, // 0x00000010
    [Description("06월")] MONTH_06 = 32, // 0x00000020
    [Description("07월")] MONTH_07 = 64, // 0x00000040
    [Description("08월")] MONTH_08 = 128, // 0x00000080
    [Description("09월")] MONTH_09 = 256, // 0x00000100
    [Description("10월")] MONTH_10 = 512, // 0x00000200
    [Description("11월")] MONTH_11 = 1024, // 0x00000400
    [Description("12월")] MONTH_12 = 2048, // 0x00000800
    [Description("전월")] MONTH_ALL = 4095, // 0x00000FFF
  }
}
