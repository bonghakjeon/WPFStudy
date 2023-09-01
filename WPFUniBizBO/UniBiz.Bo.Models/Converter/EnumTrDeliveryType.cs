// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrDeliveryType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrDeliveryType
  {
    [Description("-배송유형-")] NONE,
    [Description("등록")] REGI,
    [Description("등록완료")] REGI_FIN,
    [Description("배달완료")] DELI_FIN,
    [Description("보류완료")] HOLD_FIN,
    [Description("선결제배달")] DELI_TRAN,
  }
}
