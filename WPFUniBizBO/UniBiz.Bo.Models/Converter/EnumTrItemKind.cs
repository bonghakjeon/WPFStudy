// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrItemKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrItemKind
  {
    [Description("-상태-")] NONE,
    [Description("상품")] GOODS,
    [Description("회원")] MEMBER,
    [Description("현금")] CASH,
    [Description("현금영수증")] CASH_RECEIPT,
    [Description("카드")] CARD,
    [Description("자사상품권")] INNERGIFT,
    [Description("타사상품권")] OUTERGIFT,
    [Description("외상")] CREDIT,
    [Description("외상 온라인")] CREDIT_ONLINE,
    [Description("포인트사용")] PAYPOINT,
    [Description("영수증 인쇄")] RECEIPT_PRINT,
    [Description("할인(에누리)")] KEYDC,
    [Description("기타13")] PAYETC,
    [Description("기타14")] PAYETC1,
    [Description("기타15")] PAYETC2,
    [Description("기타16")] PAYETC3,
    [Description("기타17")] PAYETC4,
    [Description("기타18")] PAYETC5,
    [Description("수표")] CHECK,
    [Description("쿠폰")] COUPON,
    [Description("온라인 처리결과")] ONLINE_SERVICE,
    [Description("주문서")] ORDERSHEET,
    [Description("주류")] LIGUORS,
  }
}
