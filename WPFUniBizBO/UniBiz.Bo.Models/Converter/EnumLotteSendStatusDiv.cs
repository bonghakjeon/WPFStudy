// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteSendStatusDiv
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteSendStatusDiv
  {
    [Description("-전송상태-")] None,
    [Description("발송결과코드")] Req,
    [Description("발송중(대기중)")] Waiting,
    [Description("수신 완료")] Complete,
    [Description("발송요청실패")] Failure,
    [Description("발송예약")] Reservation,
  }
}
