// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPromotionType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPromotionType
  {
    [Description("-프로모션유형-")] None,
    [Description("영수금액할인")] ReceiptAmount,
    [Description("영수금액상품할인")] ReceiptAmountNGoods,
    [Description("개별상품할인")] Goods,
    [Description("번들할인")] Bundle,
    [Description("덤할인")] BonusNPlus,
    [Description("믹스앤매치")] MixNMatch,
    [Description("연관할인")] Relation,
    [Description("이벤트영수증")] EventReceipt,
    [Description("이벤트적립")] EventPoint,
  }
}
