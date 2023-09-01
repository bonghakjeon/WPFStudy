// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPromotionDiv
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPromotionDiv
  {
    [Description("-프로모션종류-")] None,
    [Description("금액")] Amount,
    [Description("율")] Percent,
    [Description("균일가")] UniformPrice,
    [Description("이벤트영수증")] EventReceipt,
  }
}
