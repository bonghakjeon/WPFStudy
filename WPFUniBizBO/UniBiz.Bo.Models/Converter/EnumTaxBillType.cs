// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTaxBillType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTaxBillType
  {
    [Description("-회원 계산서발행 타입-")] NONE,
    [Description("직영과세")] DIR_TAX,
    [Description("직영면세")] DIR_FREE,
    [Description("임대과세")] LEA_TAX,
    [Description("임대면세")] LEA_FREE,
  }
}
