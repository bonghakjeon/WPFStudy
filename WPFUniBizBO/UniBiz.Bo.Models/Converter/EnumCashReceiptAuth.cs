// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumCashReceiptAuth
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumCashReceiptAuth
  {
    [Description("-현금영수증 인증-")] NONE,
    [Description("미발행")] UNPUBLISHED,
    [Description("선승인")] PREAPP,
    [Description("자동인증(국세청)")] AUTO,
    [Description("번호입력인증")] INPUT,
  }
}
