// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumRowTimeStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumRowTimeStatus
  {
    [Description("-상태-")] None,
    [Description("매출금액")] Sale,
    [Description("매출누계")] Cumulative,
    [Description("매출구성비")] Rate,
    [Description("매출평균")] Avg,
    [Description("대비금액")] BeforeSale,
    [Description("대비누계")] BeforeCumulative,
    [Description("대비구성비")] BeforeRate,
    [Description("대비평균")] BeforeAvg,
  }
}
