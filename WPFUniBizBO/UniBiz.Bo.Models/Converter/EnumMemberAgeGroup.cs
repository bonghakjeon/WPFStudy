// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMemberAgeGroup
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMemberAgeGroup
  {
    [Description("-회원연령대-")] NONE = 0,
    [Description("10대")] AGE_10 = 1,
    [Description("20대")] AGE_20 = 2,
    [Description("30대")] AGE_30 = 3,
    [Description("40대")] AGE_40 = 4,
    [Description("50대")] AGE_50 = 5,
    [Description("60대 이상")] AGE_60 = 6,
    [Description("나이오류")] AGE_ERR = 10, // 0x0000000A
  }
}
