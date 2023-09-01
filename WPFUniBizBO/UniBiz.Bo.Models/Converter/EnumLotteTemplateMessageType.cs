// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteTemplateMessageType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteTemplateMessageType
  {
    [Description("-템플릿 메시지 유형-")] None,
    [Description("기본형")] BA,
    [Description("부가 정보형")] EX,
    [Description("광고 추가형")] AD,
    [Description("복합형")] MI,
  }
}
