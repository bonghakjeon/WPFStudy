// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumActionType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumActionType
  {
    [Description("사용자로그")] NONE = 0,
    [Description("등록")] NEW = 1,
    [Description("수정")] UPDATE = 2,
    [Description("삭제")] DELETE = 3,
    [Description("조회")] SEARCH = 4,
    [Description("로그인")] LOG_IN = 8,
    [Description("로그아웃")] LOG_OUT = 9,
    [Description("엑셀")] EXCEL = 10, // 0x0000000A
    [Description("출력")] PRINT = 11, // 0x0000000B
    [Description("PDF")] PDF = 12, // 0x0000000C
    [Description("이메일")] EMAIL = 13, // 0x0000000D
  }
}
