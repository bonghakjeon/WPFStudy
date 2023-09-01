// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrItemDcType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrItemDcType
  {
    [Description("-DC-")] NONE,
    [Description("수기할인")] DC_KEYIN,
    [Description("프로모션 단품할인")] DC_PM_GOODS,
    [Description("프로모션 에누리")] DC_PM_ENURYSLIP,
    [Description("수기에누리")] DC_ENURYSLIP,
    [Description("끝전에누리")] DC_ENURYEND,
    [Description("행사할인")] DC_EVENT,
    [Description("멤버할인")] DC_MEMBER,
    [Description("가격변경")] DC_PRICE,
    [Description("쿠폰에누리")] DC_ENURYCOUPON,
  }
}
