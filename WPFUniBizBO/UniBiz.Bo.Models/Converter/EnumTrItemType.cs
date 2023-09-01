// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrItemType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrItemType
  {
    [Description("-상태-")] NONE,
    [Description("상품")] GOODS,
    [Description("행사할인")] EVENT,
    [Description("분류,업체 행사")] CATEGORY,
    [Description("쿠폰할인")] COUPON,
    [Description("멤버쉽 할인1")] MEMPRICE,
    [Description("멤버쉽 할인2")] MEMPRICE2,
    [Description("멤버쉽 할인3")] MEMPRICE3,
    [Description("개인 특별단가")] PROMOTION,
    [Description("자사상품권 지급")] INNERGIFT,
    [Description("타사상품건 지급")] OUTERGIFT,
    [Description("메세지발행\n")] TICKET,
    [Description("할인태그부착")] DC_TAG,
    [Description("주류:맥주")] LIQUOR_BEER,
    [Description("주류:양주")] LIQUOR_WK,
    [Description("주류:소주")] LIQUOR_SOJU,
    [Description("주류:기타")] LIQUOR_ETC,
    [Description("상품권발매승인")] GIFTCARD_PUBLISH_AUTH,
    [Description("상품권발매취소")] GIFTCARD_PUBLISH_CANCEL,
    [Description("기프트카드 발매승인")] PREPAID_CARD_PUBLISH_AUTH,
    [Description("기프트카드 발매취소")] PREPAID_CARD_PUBLISH_CANCEL,
    [Description("MAX")] MAX,
  }
}
