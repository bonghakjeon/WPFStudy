// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteNoticeTemplateType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteNoticeTemplateType
  {
    [Description("-템플릿타입-")] None,
    [Description("배송시작")] DeliveryStart,
    [Description("배송완료")] DeliveryEnd,
    [Description("주문완료")] WebOrderEnd,
    [Description("인증코드 요청")] CitationNumber,
    [Description("임시 비밀번호 발급 안내")] TemporaryPassword,
  }
}
