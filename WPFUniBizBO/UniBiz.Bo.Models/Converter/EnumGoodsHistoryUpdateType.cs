// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumGoodsHistoryUpdateType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumGoodsHistoryUpdateType
  {
    [Description("-타입-")] None,
    [Description("전체")] All,
    [Description("정상가")] Price,
    [Description("행사가")] EventPrice,
    [Description("회원가")] MemberPrice,
    [Description("코드")] Code,
  }
}
