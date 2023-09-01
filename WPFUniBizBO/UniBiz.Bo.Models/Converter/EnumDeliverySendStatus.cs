// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDeliverySendStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDeliverySendStatus
  {
    [Description("-배송전송상태-")] NONE,
    [Description("POS")] POS,
    [Description("점.API 요청중")] MiddleReq,
    [Description("Neo.API 요청중")] NeoReq,
    [Description("LInk")] Link,
    [Description("Neo.API 응답")] NeoRes,
    [Description("점.API 응답")] MiddleRes,
  }
}
