// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEventType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEventType
  {
    [Description("-이벤트유형-")] NONE = 0,
    [Description("영수증메세지인쇄")] PRINT = 1,
    [Description("추가포인트제공")] ADDPOINT = 2,
    [Description("할인쿠폰제공")] COUPON = 3,
    [Description("상품권제공")] GIFTCARD = 4,
    [Description("포인트대체상품권")] POINTGIFT = 5,
    [Description("에누리")] ENURY = 6,
    [Description("벌크이벤트")] BULK = 7,
    [Description("영수증번호")] ETC_TRANSNO = 91, // 0x0000005B
    [Description("영수증금액")] ETC_AMOUNT = 92, // 0x0000005C
    [Description("회원등급")] ETC_GRADE = 93, // 0x0000005D
  }
}
