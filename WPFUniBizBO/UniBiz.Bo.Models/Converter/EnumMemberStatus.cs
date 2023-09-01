// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMemberStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMemberStatus
  {
    [Description("-회원 상태-")] NONE,
    [Description("정상")] NORMAL,
    [Description("중지")] STOP,
    [Description("탈퇴")] SECESSION,
  }
}
