// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSalesUnit
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSalesUnit
  {
    [Description("-판매방식-")] NONE,
    [Description("낱개")] EA,
    [Description("박스")] BOX,
    [Description("중량")] WEIGHT,
    [Description("금액")] AMOUNT,
  }
}
