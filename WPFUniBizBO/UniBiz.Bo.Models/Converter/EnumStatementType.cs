// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumStatementType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumStatementType
  {
    [Description("-전표타입-")] None = 0,
    [Description("매입")] Buy = 1,
    [Description("매출")] Sale = 2,
    [Description("점내대출입")] InnerMove = 3,
    [Description("점간대출입")] OuterMove = 4,
    [Description("재고조정")] Adjust = 5,
    [Description("폐기")] Disuse = 6,
    [Description("재고이동")] StockMove = 7,
    [Description("결제")] Payment = 21, // 0x00000015
  }
}
