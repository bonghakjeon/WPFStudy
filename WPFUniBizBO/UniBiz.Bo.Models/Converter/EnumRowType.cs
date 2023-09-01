// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumRowType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumRowType
  {
    [Description("-상태-")] None,
    [Description("데이터")] Normal,
    [Description("부분계")] Summary,
    [Description("합계")] TotalSum,
  }
}
