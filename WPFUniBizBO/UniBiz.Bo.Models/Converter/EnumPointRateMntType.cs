// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPointRateMntType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPointRateMntType
  {
    [Description("-포인트적립률형태-")] NONE,
    [Description("등급별_금종별")] GRADE_TENDER,
    [Description("상품별포인트_합계_등급금종별")] GOODS_RATE_TOTAL,
    [Description("상품별적립률_낱개_등급금종별")] GOODS_RATE_ITEM,
  }
}
