// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteResultCodeType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteResultCodeType
  {
    [Description("결과코드")] None = 0,
    [Description("요청 성공")] Success = 200, // 0x000000C8
    [Description("데이터 없음")] DataNULL = 204, // 0x000000CC
    [Description("권한 없음")] PermissionNULL = 403, // 0x00000193
    [Description("파라미터 오류")] ParameterError = 405, // 0x00000195
    [Description("지원하지 않는 미디어 타입")] NotSupportMediaType = 415, // 0x0000019F
    [Description("이미지 오류(용량, 사이즈, 파일형식)")] ImageError = 600, // 0x00000258
    [Description("인증 에러")] CertificationError = 701, // 0x000002BD
    [Description("토큰 유효 기간 만료")] TokenExpirationOfValidity = 702, // 0x000002BE
    [Description("REST API 사용 권한 없음")] RestApiPermissionError = 703, // 0x000002BF
    [Description("알 수 없는 토큰 정보")] TokenError = 704, // 0x000002C0
  }
}
