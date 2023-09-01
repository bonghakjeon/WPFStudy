// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteKakaoButtonType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteKakaoButtonType
  {
    [Description("-버튼타입-")] NONE,
    [Description("웹 링크(WL)")] WL,
    [Description("앱 링크(AL)")] AL,
    [Description("배송조회(DS)")] DS,
    [Description("봇 키워드(BK)")] BK,
    [Description("메시지 전달(MD)")] MD,
    [Description("상담톡 전환(BC)")] BC,
    [Description("봇 전환(BT)")] BT,
    [Description("채널 추가(AC)")] AC,
  }
}
