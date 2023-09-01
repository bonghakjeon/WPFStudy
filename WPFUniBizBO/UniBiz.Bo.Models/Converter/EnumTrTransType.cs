// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrTransType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrTransType
  {
    [Description("-거래유형-")] NONE,
    [Description("정상")] NORMAL,
    [Description("배송")] DELIVERY,
    [Description("보류")] HOLD,
    [Description("거래중지")] CANCEL,
    [Description("포인트사후적립")] POINTAFTER,
    [Description("현금영수증사후적립")] CASHRCTAFTER,
    [Description("준비금")] RES_MONEY,
    [Description("중간입금")] MID_MONEY,
    [Description("마감입금")] CLO_MONEY,
    [Description("포인트사후교환")] POINT_EXCHANGE,
    [Description("현금영수증사후교환")] CASHRCT_EXCHANGE,
    [Description("사후배달")] DELIVERYAFTER,
    [Description("전화주문거래")] ORDER_TEL,
    [Description("앱주문거래")] ORDER_APP,
    [Description("사후배달-자동")] DELIVERYAFTER_AUTO,
    [Description("매장결제배송")] DELIVERY_PAYMENT,
  }
}
