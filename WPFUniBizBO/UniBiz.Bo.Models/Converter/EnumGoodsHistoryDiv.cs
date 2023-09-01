// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumGoodsHistoryDiv
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumGoodsHistoryDiv
  {
    [Description("-상품 이력 조건-")] NONE,
    [Description("이력변경")] HISTORY_START,
    [Description("행사시작")] EVENT_START,
    [Description("행사대상")] EVENT_ING,
    [Description("멤버가1시작")] MEMBER1_START,
    [Description("멤버가1대상")] MEMBER1_ING,
    [Description("멤버가2시작")] MEMBER2_START,
    [Description("멤버가2대상")] MEMBER2_ING,
    [Description("멤버가3시작")] MEMBER3_START,
    [Description("멤버가3대상")] MEMBER3_ING,
  }
}
