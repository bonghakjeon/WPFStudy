// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSlipTextType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSlipTextType
  {
    [Description("-인쇄유형-")] NONE,
    [Description("텍스트")] TEXT,
    [Description("단선")] LINE,
    [Description("이중선")] DOUBLE_LINE,
    [Description("EAN")] EAN,
    [Description("ITF")] ITF,
    [Description("CODE39")] CODE39,
    [Description("이미지")] IMAGE,
    [Description("커팅")] CUTTING,
  }
}
