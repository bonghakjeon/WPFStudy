// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDeliveryMovingStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDeliveryMovingStatus
  {
    [Description("-승인처리상태-")] NONE,
    [Description("등록")] DELI_ENTER,
    [Description("일감확정")] DELI_SELECT,
    [Description("배송시작")] DELI_START,
    [Description("배송완료")] DELI_END,
    [Description("마감")] DELI_CLOSING,
    [Description("원본마감")] ORIGIN_CLOSING,
  }
}
