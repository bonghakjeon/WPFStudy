// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMemberCycle
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMemberCycle
  {
    [Description("-회원주기-")] NONE,
    [Description("가망")] REG,
    [Description("신규")] NEW,
    [Description("안정")] STABILITY,
    [Description("안정2")] STABILITY_BEST,
    [Description("휴면")] SLEEP,
  }
}
