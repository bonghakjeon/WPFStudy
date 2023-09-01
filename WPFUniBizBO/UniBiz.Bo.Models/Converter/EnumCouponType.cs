// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumCouponType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumCouponType
  {
    [Description("-쿠폰구분-")] None,
    [Description("지류")] Paper,
    [Description("전자쿠폰")] Electronic,
  }
}
