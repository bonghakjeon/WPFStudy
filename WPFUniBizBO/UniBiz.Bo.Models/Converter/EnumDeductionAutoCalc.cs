// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDeductionAutoCalc
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDeductionAutoCalc
  {
    [Description("-자동 공제 계산-")] NONE,
    [Description("계산(율)")] RATE,
    [Description("고정금액")] AMOUNT,
  }
}
