// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEmpActionKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEmpActionKind
  {
    [Description("-사용자작업-")] NONE = 0,
    [Description("신규")] NEW = 1,
    [Description("변경")] UPDATE = 2,
    [Description("삭제")] DELETE = 3,
    [Description("조회")] SEARCH = 4,
    [Description("LogIn")] LOG_IN = 8,
    [Description("LogOut")] LOG_OUT = 8,
    [Description("엑셀 내보내기")] EXCEL = 10, // 0x0000000A
    [Description("인쇄물 출력")] PRINT = 11, // 0x0000000B
    [Description("PDF 내보내기")] PDF = 12, // 0x0000000C
    [Description("이메일 보내기")] EMAIL = 13, // 0x0000000D
  }
}
