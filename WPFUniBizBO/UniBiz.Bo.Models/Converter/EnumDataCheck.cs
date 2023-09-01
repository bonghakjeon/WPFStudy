// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDataCheck
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDataCheck
  {
    [Description("에러")] Unknown,
    [Description("성공")] Success,
    [Description("데이터 0값")] CodeZero,
    [Description("빈 데이터 정보")] Empty,
    [Description("일자 유효성 검사 실패")] DateDeadLind,
    [Description("데이터 널 값")] NULL,
    [Description("데이터 중복")] Exists,
    [Description("유효성 검사 실패")] Valid,
  }
}
