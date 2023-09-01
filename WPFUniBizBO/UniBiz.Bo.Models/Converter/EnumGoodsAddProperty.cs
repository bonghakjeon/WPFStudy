// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumGoodsAddProperty
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumGoodsAddProperty
  {
    [Description("-상품특성-")] NONE = 0,
    [Description("할인/에누리 불가")] NOT_DC = 1,
    [Description("행사 제외 품목")] NOT_EVENT = 2,
    [Description("전체DC불가")] NOT_DC_All = 3,
    [Description("쿠폰제외")] NOT_COUPON = 4,
    [Description("온라인품번")] ON_PUMBUN = 8,
    [Description("상품권")] GIFT_CARD = 16, // 0x00000010
    [Description("상품권승인")] TAG_GIFT_CATD = 19, // 0x00000013
    [Description("상품권2")] GIFT_CARD2 = 32, // 0x00000020
    [Description("상품권2승인")] TAG_GIFT_CATD2 = 35, // 0x00000023
    [Description("온라인마스크")] ON_LINE_MASK = 48, // 0x00000030
    [Description("예약7")] reservation_7 = 64, // 0x00000040
    [Description("예약8")] reservation_8 = 128, // 0x00000080
    [Description("맥주")] BEER = 256, // 0x00000100
    [Description("위스키")] WHISKEY = 512, // 0x00000200
    [Description("소주")] SOJU = 1024, // 0x00000400
    [Description("기타주류")] ETC = 2048, // 0x00000800
    [Description("주류마스크")] LIQUOR_MASK = 3840, // 0x00000F00
    [Description("예약13")] reservation_13 = 4096, // 0x00001000
    [Description("예약14")] reservation_14 = 8192, // 0x00002000
    [Description("담배")] TOBACCO = 16384, // 0x00004000
    [Description("예약16")] reservation_16 = 32768, // 0x00008000
    [Description("19마스크")] ADULT_MASK = 65280, // 0x0000FF00
    [Description("배송출력상품")] DELIVERY_GOODS = 65536, // 0x00010000
    [Description("배송출력비상품")] DELIVERY_NONE_GOODS = 131072, // 0x00020000
    [Description("예약17")] reservation_17 = 262144, // 0x00040000
    [Description("예약18")] reservation_18 = 524288, // 0x00080000
    [Description("공병")] DEPOSIT_BOTTLE = 1048576, // 0x00100000
    [Description("박스")] DEPOSIT_BOX = 2097152, // 0x00200000
    [Description("봉투")] DEPOSIT_BAG = 4194304, // 0x00400000
    [Description("배송비")] DEPOSIT_DELI = 8388608, // 0x00800000
    [Description("전체마스크")] ALL_MASK = 268435455, // 0x0FFFFFFF
  }
}
