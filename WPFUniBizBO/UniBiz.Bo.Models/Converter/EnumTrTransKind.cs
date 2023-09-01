// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrTransKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrTransKind
  {
    [Description("-거래종류-")] NONE,
    [Description("거래")] TRAN,
    [Description("X.사용매출")] INNERUSE,
    [Description("마감")] CLOSE,
    [Description("X.실사")] STOCK,
    [Description("X.연습 거래")] TRAIN_TRAN,
    [Description("X.연습 사용")] TRAIN_INNERUSE,
    [Description("X.연습 마감")] TRAIN_CLOSE,
    [Description("X.연습 실사")] TRAIN_STOCK,
    [Description("X.삭제")] DELETET,
    [Description("X.외상")] CREDIT,
    MAX,
    TRANDALL,
    TRANTRAINALL,
    PAYMENT,
    [Description("개설")] OPEN,
  }
}
