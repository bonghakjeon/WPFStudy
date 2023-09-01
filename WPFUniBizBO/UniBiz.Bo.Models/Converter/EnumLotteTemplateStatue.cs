// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteTemplateStatue
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteTemplateStatue
  {
    [Description("-템플릿상태-")] None = 0,
    [Description("템플릿 승인(A)")] Approved = 65, // 0x00000041
    [Description("카카오 검수중(Q)")] InspectionKakao = 81, // 0x00000051
    [Description("롯데정보통신 검수중(R)")] InspectionLotte = 82, // 0x00000052
    [Description("템플릿 반려(S)")] Companion = 83, // 0x00000053
    [Description("신청완료(T)")] Receipt = 84, // 0x00000054
  }
}
