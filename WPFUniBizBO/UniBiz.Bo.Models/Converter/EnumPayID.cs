// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPayID
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPayID
  {
    [Description("-결제 금종-")] NONE = 0,
    [Description("현금")] CASH = 1,
    [Description("카드")] CARD = 2,
    [Description("자사상품권")] INNER_GIFT = 3,
    [Description("타사상품권")] OUTER_GIFT = 4,
    [Description("포인트사용")] POINT = 5,
    [Description("외상")] CREDIT = 6,
    [Description("사용매출")] INNER_USE = 7,
    [Description("특판매출")] TUKPAN = 8,
    [Description("통판매출")] TONGPAN = 9,
    [Description("웹포인트사용")] WEBPOINT = 10, // 0x0000000A
    [Description("캐쉬백")] CASHBAG = 11, // 0x0000000B
    [Description("CMS")] CMS = 12, // 0x0000000C
    [Description("장바구니할인")] BASKET = 13, // 0x0000000D
    [Description("일반카드")] CATAPPR = 14, // 0x0000000E
    [Description("제휴상품권")] COALITION_GIFT = 15, // 0x0000000F
    [Description("제로페이")] ZEROPAY = 16, // 0x00000010
    [Description("카카오페이")] KAKAOPAY = 17, // 0x00000011
    [Description("네이버페이")] NAVERPAY = 18, // 0x00000012
    [Description("위챗페이")] WECHATPAY = 19, // 0x00000013
    [Description("알리페이")] ALIPAY = 20, // 0x00000014
    [Description("기타")] ETC = 90, // 0x0000005A
  }
}
