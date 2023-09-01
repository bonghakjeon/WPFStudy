// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.EnumDBStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models
{
  public enum EnumDBStatus
  {
    [Description("")] NONE,
    [Description("신규")] NEW,
    [Description("수정")] UPDATE,
    [Description("삭제")] DELETE,
    [Description("저장완료")] SAVED,
  }
}
