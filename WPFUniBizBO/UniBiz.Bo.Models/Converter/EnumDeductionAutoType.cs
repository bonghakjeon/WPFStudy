// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDeductionAutoType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDeductionAutoType
  {
    [Description("-결제 자동공제 리스트-")] NONE,
    [Description("장려금(미만)")] REBATE_DOWN,
    [Description("장려금(이상)")] REBATE_UP,
    [Description("장려금(성과)")] REBATE_PERFORMANCE,
    [Description("수수료")] FEE,
    [Description("임대료")] RENT_AMOUNT,
    [Description("카드수수료")] CARD,
    [Description("상품권수수료")] GIFT_CARD,
    [Description("포인트수수료")] POINT,
  }
}
