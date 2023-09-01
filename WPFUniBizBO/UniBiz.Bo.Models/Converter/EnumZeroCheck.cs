// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumZeroCheck
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumZeroCheck
  {
    [Description("-0체크-")] None,
    [Description("금액")] Amount,
    [Description("수량")] Qty,
    [Description("전체")] ALL,
  }
}
