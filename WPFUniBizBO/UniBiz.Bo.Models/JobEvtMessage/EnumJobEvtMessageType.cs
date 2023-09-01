// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.EnumJobEvtMessageType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public enum EnumJobEvtMessageType
  {
    [Description("JobMessage")] None,
    [Description("작업 시작")] Start,
    [Description("작업중..")] Progressing,
    [Description("작업중 중단")] Stopped,
    [Description("정상 완료")] Completed,
    [Description("작업중 메세지")] Message,
    [Description("작업중 에러 메세지")] ErrMessage,
    [Description("상품 이력 등록 변경")] GoodsHistoryRegister,
    [Description("사용자 (재)일마감")] EodReWork,
    [Description("사용자 수불 장부 마감")] ProfitWork,
    [Description("사용자 재고조사 결산")] InventoryWork,
    [Description("사용자 대금 장부 마감")] PaymentMonthWork,
    [Description("작업 정보")] JobEvtInfo,
    [Description("데이터 변경 로그")] DataModLog,
    [Description("전표 등록")] StatementHeader,
    [Description("재고조사 전표 등록")] InventoryHeader,
  }
}
