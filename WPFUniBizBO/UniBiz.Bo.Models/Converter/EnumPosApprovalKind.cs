// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPosApprovalKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPosApprovalKind
  {
    [Description("-승인구분-")] NONE,
    [Description("쿠폰")] COUPON_AUTH,
    [Description("자사상품권")] GIFTCARD_AUTH,
    [Description("포인트사용")] POINTUSE_AUTH,
    [Description("사내소비")] INNER_USE,
    [Description("신용카드")] CARD_AUTH,
    [Description("현금영수증")] CASHRCT_AUTH,
    [Description("수표조회")] CHECK_INQUERY,
  }
}
