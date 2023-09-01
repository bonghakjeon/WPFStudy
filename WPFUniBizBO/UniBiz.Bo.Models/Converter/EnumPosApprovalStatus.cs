// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPosApprovalStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPosApprovalStatus
  {
    [Description("-승인처리상태-")] NONE,
    [Description("요청")] REQ,
    [Description("요청응답")] REQ_RES,
    [Description("처리요청")] PROC_REQ,
    [Description("처리완료")] PROC_RES,
    [Description("망취소")] PROC_CANCEL,
  }
}
