// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDevicePermit
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDevicePermit
  {
    [Description("-장치 권한-")] NONE,
    [Description("허용")] ALLOW,
    [Description("서비스 중지")] BLOCK,
    [Description("요청")] REQUEST,
    [Description("만료일 연장 요청")] EXPIRE_EX,
  }
}
