// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSupRebateStdDate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSupRebateStdDate
  {
    [Description("-성과장려 기준일자-")] NONE,
    [Description("년")] YEAR,
    [Description("반년")] YEAR_HALF,
    [Description("분기")] QUARTER,
    [Description("월")] MONTH,
    [Description("대금결제조건")] PAY_CONTION,
  }
}
