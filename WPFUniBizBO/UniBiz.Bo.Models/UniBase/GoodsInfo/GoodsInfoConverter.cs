// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsInfoConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniBase.GoodsInfo
{
  public static class GoodsInfoConverter
  {
    public const string gd_GoodsCode = "상품코드";
    public const string gd_SiteID = "싸이트";
    public const string gd_GoodsName = "상품명";
    public const string gd_BarCode = "상품바코드";
    public const string gd_GoodsSize = "규격";
    public const string gd_TaxDiv = "과면세";
    public const string gd_TaxUrl = "과면세 이미지 URL";
    public const string gd_MakerCode = "제조사코드";
    public const string gd_BrandCode = "브랜드코드";
    public const string gd_BoxGoodsCode = "박스코드";
    public const string gd_BoxPackQty = "박스입수";
    public const string gd_Deposit = "보증금";
    public const string gd_SalesUnit = "판매단위";
    public const string gd_MinOrderUnit = "최소발주량";
    public const string gd_StockUnit = "재고단위";
    public const string gd_StockConvQty = "재고환산수량";
    public const string gd_PackUnit = "묶음단위";
    public const string gd_PackUnitUrl = "묶음단위 이미지 URL";
    public const string gd_AbcValue = "ABC분석";
    public const string gd_StorageDiv = "보관방법";
    public const string gd_EachDeliveryYn = "개별배송여부";
    public const string gd_VolumeTotal = "총용량";
    public const string gd_VolumeUnit = "단위용량";
    public const string gd_VolumeUnitText = "기준단위";
    public const string gd_AddedProperty = "추가상품속성";
    public const string gd_Memo = "메모";
    public const string gd_ErpCode = "ERP 연결코드";
    public const string gd_ExCode = "확장 연결코드";
    public const string gd_UseYn = "사용상태";
    public const string gd_VolumePrice = "단위가격";
    public const string gd_BoxStockQty = "박스환산량";
    public const string ea_GoodsCode = "기준상품";
    public const string ea_StockConvQty = "기준상품입수량";
    public const string ea_GoodsName = "기준상품명";
    public const string ea_BarCode = "기준상품바코드";
    public const string ea_GoodsSize = "기준상품규격";
    public const string gdh_StoreCode = "지점코드";
    public const string gdh_GoodsCode = "상품코드";
    public const string gdh_StartDate = "시작일";
    public const string gdh_SiteID = "싸이트";
    public const string gdh_EndDate = "종료일";
    public const string gdh_GoodsCategory = "소분류";
    public const string gdh_Supplier = "업체";
    public const string gdh_ChargeRate = "수수료율";
    public const string gdh_BuyCost = "매입원가";
    public const string gdh_BuyVat = "매입VAT";
    public const string gdh_BuyTaxPrice = "매입가";
    public const string gdh_SalePrice = "판매가";
    public const string gdh_SaleMargin = "이익율";
    public const string gdh_EventCost = "행사원가";
    public const string gdh_EventVat = "행사VAT";
    public const string gdh_EventBuyTaxPrice = "행사가";
    public const string gdh_EventPrice = "행사판매가";
    public const string gdh_EventMargin = "행사이익율";
    public const string gdh_MemberPrice1 = "회원가";
    public const string gdh_Member1Margin = "회원이익율";
    public const string gdh_MemberPrice2 = "회원가2";
    public const string gdh_Member2Margin = "회원2이익율";
    public const string gdh_MemberPrice3 = "회원가3";
    public const string gdh_Member3Margin = "회원3이익율";
    public const string gdh_PointRate = "회원특별적립율";
    public const string gdh_InDate = "이력등록일";
    public const string gdh_ModDate = "이력변경일";
    public const string GoodsHistoryDiv = "상품이력조건";
    public const string gdob_GoodsCode = "지점코드";
    public const string gdob_BarCode = "구 바코드";
    public const string gdob_SiteID = "싸이트";
    public const string gdob_AddProperty = "속성타입";
    public const string gdp_GoodsCode = "세트 상품";
    public const string gdp_SubGoodsCode = "구성 상품";
    public const string gdp_SiteID = "싸이트";
    public const string gdp_StockConvQty = "구성 입수량";
    public const string gdsh_StoreCode = "지점코드";
    public const string gdsh_GoodsCode = "상품코드";
    public const string gdsh_SiteID = "싸이트";
    public const string gdsh_DeliveryDiv = "배송 구분";
    public const string gdsh_MinOrderUnit = "최소 발주량";
    public const string gdsh_MultiSuplierYn = "복수거래처 여부";
    public const string gdsh_OrderType = "발주유형";
    public const string gdsh_AutoOrderMonth = "자동발주가능년월";
    public const string gdsh_OrderWeekDay = "주문가능요일";
    public const string gdsh_AutoOrderMonths = "개월수";
    public const string gdsh_AutoOrderDays = "판매일수";
    public const string gdsh_AutoOrderType = "타입구분";
    public const string gdsh_AutoSafeQty = "안전재고량";
    public const string gdsh_AutoMinQty = "최소재고발주량";
    public const string gdsh_AutoMidQty = "중간재고발주량";
    public const string gdsh_AutoMaxQty = "최대재고발주량";
    public const string gdsh_StorageStockQty = "창고 적정 재고 유지량";
    public const string gdsh_OrderEndDate = "발주중지";
    public const string gdsh_SaleEndDate = "판매중지";
    public const string gdsh_AddProperty = "속성타입";
    public const int ORDER_BY_HISTORY_STORE_GOODS_START1 = 1;
    public const int ORDER_BY_HISTORY_STORE_GOODS_START = 2;
    public const int ORDER_BY_HISTORY_GOODS_STORE_START1 = 3;
    public const int ORDER_BY_HISTORY_GOODS_STORE_START = 4;
    public const string gi_GoodsCode = "상품코드";
    public const string gi_SiteID = "싸이트";
    public const string gi_ImgFileName = "파일명";
    public const string gi_ImgType = "이미지타입";
    public const string gi_ThumbSize = "썸네일 크기";
    public const string gi_ThumbData = "썸네일";
    public const string gi_Thumb2Size = "썸네일2 크기";
    public const string gi_Thumb2Data = "썸네일2";
    public const string gi_Thumb3Size = "썸네일3 크기";
    public const string gi_Thumb3Data = "썸네일3";
    public const string gi_Thumb4Size = "썸네일4 크기";
    public const string gi_Thumb4Data = "썸네일4";
    public const string gi_OriginSize = "이미지 크기";
    public const string gi_OriginData = "이미지";
    public const string StoreBarCode = "22";
    public const string ScaleBarCode = "20";
    public const string gdmg_GoodsCode = "상품코드";
    public const string gdmg_MemberStore = "포인트지점코드";
    public const string gdmg_MemberGrade = "회원등급";
    public const string gdmg_DcRate = "할인율";
  }
}
