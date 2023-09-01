// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPaymentStatementDiv
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPaymentStatementDiv
  {
    [Description("-전표 결제 타입-")] NONE,
    [Description("결제")] PAYMENT,
    [Description("공제")] DEDUCTION,
  }
}
