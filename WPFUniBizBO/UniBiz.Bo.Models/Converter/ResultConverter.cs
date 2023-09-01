// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.ResultConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.Converter
{
  public class ResultConverter
  {
    private const string IDS_RESULT_ERROR = "에러";
    private const string IDS_RESULT_SUCCESS = "성공";
    private const string IDS_RESULT_EMPTY = "미처리";
    private const string IDS_RESULT_EXISTS = "중복";
    private const string IDS_RESULT_REQUEST = "요청";

    public static string GetResultDesc(EnumResult p_value)
    {
      switch (p_value)
      {
        case EnumResult.Error:
          return "에러";
        case EnumResult.Success:
          return "성공";
        case EnumResult.Empty:
          return "미처리";
        case EnumResult.Exists:
          return "중복";
        case EnumResult.Request:
          return "요청";
        default:
          return string.Empty;
      }
    }

    public static bool IsResultExists(int pValue) => 3 == pValue;
  }
}
