// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTrApprovalKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTrApprovalKind
  {
    [Description("-승인구분-")] NONE,
    [Description("카드승인")] CARD_AUTH,
    [Description("카드취소")] CARD_CANCEL,
    [Description("현금승인")] CASHRCT_AUTH,
    [Description("현금취소")] CASHRCT_CANCEL,
    [Description("수표조회")] CHECK_INQUERY,
    [Description("상품권승인")] GIFTCARD_AUTH,
    [Description("상품권취소")] GIFTCARD_CANCEL,
    [Description("상품권조회")] GIFTCARD_INQUERY,
    [Description("쿠폰승인")] COUPON_AUTH,
    [Description("쿠폰취소")] COUPON_CANCEL,
    [Description("쿠폰조회")] COUPON_INQUERY,
    [Description("포인트적립")] POINTADD_AUTH,
    [Description("포인트적립취소")] POINTADD_CANCEL,
    [Description("포인트조회")] POINT_INQUERY,
    [Description("포인트사용")] POINTUSE_AUTH,
    [Description("포인트취소")] POINTUSE_CANCEL,
    [Description("포인트사후적립")] POINTADD_AFTER,
    [Description("외상매출")] CREDIT_AUTH,
    [Description("외상취소")] CREDIT_CANCEL,
    [Description("배송정보")] DELIVERY_INFO,
    [Description("사내소비")] SALES_INNER_USE,
    [Description("준비금")] RESERVE_MONEY,
    [Description("중간입금")] PART_MONEY,
    [Description("마감입금")] CLOSING_MONEY,
    [Description("특판")] TUKPAN,
    [Description("일반카드")] CATAPPR,
    [Description("웹포인트사용")] WEBPOINT,
    [Description("현금영수증사후적립")] CASHRCT_AFTER,
    [Description("일반보류")] NORMAL_HOLD,
    [Description("배달보류")] DELIVERY_HOLD,
    [Description("마감정산")] CLOSING_POS,
    [Description("포인트인증삭제")] POINTAUTH_CANCEL,
    [Description("제휴상품권승인")] COALITION_AUTH,
    [Description("제휴상품권취소")] COALITION_CANCEL,
    [Description("통판")] TONGPAN,
    [Description("사은품승인")] GFITS_AUTH,
    [Description("사은품취소")] GIFTS_CANCEL,
    [Description("간편결제승인")] EASYPAYS_AUTH,
    [Description("간편결제취소")] EASYPAYS_CANCEL,
    [Description("사후배송")] DELIVERY_AFTER,
    [Description("배송지정상품")] DELIVERY_APPOINTGOODS,
    [Description("개설")] OPEN,
    [Description("앱주문메모")] ORDER_APP_MEMO,
  }
}
