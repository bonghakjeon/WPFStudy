// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMemberBuyCycleGroup
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMemberBuyCycleGroup
  {
    [Description("-회원구매주기-")] NONE = 0,
    [Description("1주이하")] CYCLE_1 = 1,
    [Description("2주이하")] CYCLE_2 = 2,
    [Description("3주이하")] CYCLE_3 = 3,
    [Description("4주이하")] CYCLE_4 = 4,
    [Description("8주이하")] CYCLE_8 = 8,
    [Description("8주초과")] CYCLE_10 = 10, // 0x0000000A
  }
}
