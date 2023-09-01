// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTableColumnStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTableColumnStatus
  {
    [Description("미설정")] None = 0,
    [Description("조인")] IsJoin = 1,
    [Description("속성")] IsAttribute = 2,
    [Description("KEY 여부")] IsKey = 4,
    [Description("필수입력 여부")] IsRequired = 8,
    [Description("헤더만 내려감")] IsNullData = 16, // 0x00000010
  }
}
