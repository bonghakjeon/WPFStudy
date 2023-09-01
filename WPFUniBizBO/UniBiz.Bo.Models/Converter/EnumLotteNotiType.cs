// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLotteNotiType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLotteNotiType
  {
    [Description("타입")] None,
    [Description("SMS")] SMS,
    [Description("LMS")] LMS,
    [Description("MMS")] MMS,
    [Description("알림톡")] Notice,
    [Description("알림톡/문자")] NoticeFailToMessage,
    [Description("친구톡")] FriendNotice,
    [Description("친구톡/문자")] FriendNoticeFailToMessage,
    [Description("친구톡(이미지)")] FriendNoticeImage,
    [Description("친구톡 이미지 업로드")] FriendSendImage,
    [Description("상태조회")] PackLotteSendMessageStateReq,
    [Description("상태리스트조회")] PackLotteSendMessageStateListReq,
    [Description("월사용 집계 결산")] PackCreditSummary,
    [Description("템플릿 목록 조회")] LotteNoticeTemplateSimple,
    [Description("템플릿 조회")] LotteNoticeTemplate,
    [Description("템플릿 카테고리 조회")] LotteNoticeTemplateCategory,
    [Description("템플릿 이미지")] LotteNoticeTemplateImage,
  }
}
