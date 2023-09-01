// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumGiftCardSaleKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumGiftCardSaleKind
  {
    [Description("-상품권 판매구분-")] None,
    [Description("미지정")] UNASGN,
    [Description("수기")] MANUAL,
    [Description("POS")] POS,
    [Description("포인트차감")] PNTDDT,
    [Description("사은품")] GIFT,
  }
}
