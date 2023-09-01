// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMemberCalcCycleDiv
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMemberCalcCycleDiv
  {
    [Description("-산정주기구분-")] NONE,
    [Description("회원주기")] MemberCycle,
    [Description("회원등급")] MemberGrade,
    [Description("소멸")] Extinction,
    [Description("회원구매주기")] MemberBuyCycle,
  }
}
