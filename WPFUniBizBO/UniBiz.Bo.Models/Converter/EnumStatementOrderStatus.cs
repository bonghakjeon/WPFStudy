// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumStatementOrderStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumStatementOrderStatus
  {
    [Description("-발주상태-")] None,
    [Description("발주확정")] Confirm,
    [Description("미확정")] NotConfirm,
    [Description("전표이동")] Statement,
    [Description("전표마감")] Dead,
    [Description("삭제")] Delete,
  }
}
