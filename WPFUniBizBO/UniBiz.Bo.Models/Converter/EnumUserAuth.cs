// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumUserAuth
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumUserAuth
  {
    [Description("사용자권한")] None,
    [Description("시스템관리자")] Admin,
    [Description("유통관리자")] Distributor,
    [Description("사이트관리자")] Site,
    [Description("지점관리자")] Store,
    [Description("사용자")] User,
  }
}
