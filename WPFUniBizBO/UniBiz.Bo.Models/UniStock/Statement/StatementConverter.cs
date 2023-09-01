// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public static class StatementConverter
  {
    public const string OrderInfo = "주문정보";
    public const string StatementInfo = "전표정보";
    public const string PriceInfo = "단가정보";
    public const string QtyInfo = "수량정보";
    public const string AmountInfo = "금액정보";
    public const string EtcInfo = "기타정보";
    public const string sh_StatementNo = "전표 코드";
    public const string sh_SiteID = "싸이트";
    public const string sh_StoreCode = "지점코드";
    public const string sh_OrderDate = "발주일";
    public const string sh_StrOrderDate = "발주일자";
    public const string sh_OrderStatus = "발주상태";
    public const string sh_ConfirmDate = "확정일";
    public const string sh_ConfirmMonth = "확정월";
    public const string sh_ConfirmDateOfWeek = "요일";
    public const string sh_StrConfirmDate = "확정일자";
    public const string sh_ConfirmStatus = "확정상태";
    public const string sh_Supplier = "코드";
    public const string sh_SupplierType = "형태";
    public const string sh_InOutDiv = "입출고 타입";
    public const string sh_StatementType = "전표 타입";
    public const string sh_ReasonCode = "사유 코드";
    public const string sh_CostTaxAmt = "과세계";
    public const string sh_CostTaxFreeAmt = "면세계";
    public const string sh_CostVatAmt = "부가세계";
    public const string sh_CostSumAmt = "공급가계";
    public const string sh_Deposit = "보증금";
    public const string sh_PriceTaxAmt = "매가 과세계";
    public const string sh_PriceTaxFreeAmt = "매가 면세계";
    public const string sh_PriceVatAmt = "매가 부가세계";
    public const string sh_PriceSumAmt = "매가합계계";
    public const string sh_ProfitAmt = "세제외이익";
    public const string sh_DeviceType = "장치타입";
    public const string sh_DeviceDesc = "장치타입 설명";
    public const string sh_OuterConnAuth = "장치 코드";
    public const string sh_AdditionalOpt = "추가옵션";
    public const string sh_Memo = "메모";
    public const string sh_DeliveryNumber = "송장번호";
    public const string sh_TransmitStatus = "전송상태";
    public const string sh_TransmitStatusDesc = "전송상태 설명";
    public const string sh_TransmitDate = "전송일";
    public const string sh_StrTransmitDate = "전송일시";
    public const string sh_MobieStatementNo = "장치 전표 번호";
    public const string sh_AssignUser = "담당사원";
    public const string IsOrder = "발주전표";
    public const string row_DataType = "ROW 타입";
    public const string before_OrderStatus = "이전 발주상태";
    public const string before_ConfirmStatus = "이전 확정상태";
    public const string before_ConfirmDate = "이전 확정일";
    public const string m_IsOuterMovePermitChecked = "상대 지점 체크 여부";
    public const string m_store_info = "지점 정보";
    public const string m_supplier = "협력업체 정보";
    public const string si_StoreName = "지점명";
    public const string si_StoreViewCode = "관리코드";
    public const string si_LocationUseYn = "로케이션 사용유무";
    public const string locationUseYnDesc = "로케이션 사용유무 설명";
    public const string su_HeadSupplier = "대표코드";
    public const string su_SupplierViewCode = "식별코드";
    public const string su_SupplierName = "업체명";
    public const string su_HeadName = "대표코드 명";
    public const string details = "상세 리스트";
    public const string sd_StatementNo = "전표 코드";
    public const string sd_Seq = "순서";
    public const string sd_SiteID = "싸이트";
    public const string sd_GoodsCode = "상품코드";
    public const string sd_BoxCode = "등록코드";
    public const string sd_BarCode = "스캔코드";
    public const string sd_CategoryCode = "소부류코드";
    public const string sd_TaxDiv = "과면세";
    public const string taxDivDesc = "과면세 설명";
    public const string taxUrl = "과면세 이미지 URL";
    public const string sd_SalesUnit = "판매단위";
    public const string salesUnitDesc = "판매단위 설명";
    public const string sd_StockUnit = "재고단위";
    public const string stockUnitDesc = "재고단위 설명";
    public const string sd_PackUnit = "묶음단위";
    public const string sd_LinkRowNCount = "연결행건수";
    public const string sd_CostGoods = "원단가(마스타)";
    public const string sd_PriceGoods = "매단가(마스타)";
    public const string sd_OrderQty = "발주량";
    public const string sd_BoxQty = "등록량";
    public const string sd_BuyQty = "수량";
    public const string sd_CheckQty = "검수량";
    public const string sd_CostInput = "원단가";
    public const string sd_CostInputVat = "원단가VAT";
    public const string sd_CostInputPrice = "공급가";
    public const string sd_CostTaxAmt = "과세금액";
    public const string sd_CostTaxFreeAmt = "면세금액";
    public const string sd_CostVatAmt = "부가세금액";
    public const string sd_CostTaxVatSumAmt = "과세계";
    public const string sd_CostSumAmt = "공급가금액";
    public const string sd_Deposit = "보증금";
    public const string sd_TotalAmount = "합계금액";
    public const string sd_PriceTaxAmt = "매가 과세금액";
    public const string sd_PriceTaxFreeAmt = "매가 면세금액";
    public const string sd_PriceVatAmt = "매가 부가세금액";
    public const string sd_PriceSumAmt = "매가 합계금액";
    public const string sd_ProfitAmt = "세제외이익액";
    public const string sd_SaleMargin = "이익율";
    public const string sd_EventYn = "이벤트 사용상태";
    public const string eventYnDesc = "이벤트 설명";
    public const string isEventYn = "이벤트 사용유무";
    public const string sd_Native = "원산지";
    public const string nativeDesc = "원산지 설명";
    public const string sd_HistoryID = "이력 ID";
    public const string sd_Memo = "메모";
    public const string sd_MobieSeq = "모바일 전표 순번";
    public const int ORDER_BY_HEADER_SUPPLIER_STORE_CONFIRMDATE_NO = 1;
    public const int ORDER_BY_HEADER_SUPPLIER_STORE_CONFIRMDATE1_NO = 2;
    public const string mio_OuterStatementNo = "출고 전표번호";
    public const string mio_InnerStatementNo = "입고 전표번호";
    public const string mio_SiteID = "싸이트";
  }
}
