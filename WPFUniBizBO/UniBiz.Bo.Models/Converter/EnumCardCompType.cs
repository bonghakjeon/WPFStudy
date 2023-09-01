// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumCardCompType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumCardCompType
  {
    [Description("-매입유형-")] NONE,
    [Description("매입사")] ACQUIRER,
    [Description("발급사")] ISSUER,
    [Description("쿠폰상품권")] COUPONGIFT,
    [Description("포인트")] POINT,
    [Description("텍스프리")] TAXFREE,
    [Description("카카오")] KAKAO,
  }
}
