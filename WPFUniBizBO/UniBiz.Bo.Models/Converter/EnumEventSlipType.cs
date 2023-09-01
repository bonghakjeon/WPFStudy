// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEventSlipType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEventSlipType
  {
    [Description("-영수증이벤트타입-")] NONE = 0,
    [Description("이벤트")] EVENT = 1,
    [Description("추첨권")] LOTTERY = 2,
    [Description("상품권")] GIFTCARD = 3,
    [Description("교환권")] EXCHANGE = 4,
    [Description("쿠폰")] COUPON = 5,
    [Description("공지사항")] POS_NOTICE = 6,
    [Description("고객모니터공지")] POS_CUSTOMER_NOTICE = 7,
    [Description("상단로고")] TOPLOGO = 90, // 0x0000005A
    [Description("하단로고")] BOTTOMLOGO = 91, // 0x0000005B
    [Description("배달로고")] DELIVERYLOGO = 92, // 0x0000005C
  }
}
