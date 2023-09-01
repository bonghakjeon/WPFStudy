// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMemberTaxBillCycle
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMemberTaxBillCycle
  {
    [Description("-회원 계산서발행 주기-")] NONE,
    [Description("수기")] MANUAL,
    [Description("월별")] MONTH,
    [Description("분기별")] QUARTER,
  }
}
