// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumCashReceiptType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumCashReceiptType
  {
    [Description("미사용")] NONE,
    [Description("자동으로창띄움")] AUTO_DISPLAY,
    [Description("수동으로창띄움")] MANUAL_DISPLAY,
  }
}
