// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumResult
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumResult
  {
    [Description("에러")] Error,
    [Description("성공")] Success,
    [Description("미처리")] Empty,
    [Description("중복")] Exists,
    [Description("요청")] Request,
    [Description("세션정보없음")] SessionIsNull,
    [Description("재로그인 필요")] ReLogin,
    [Description("데이터 싱크 에러")] DataSync,
  }
}
