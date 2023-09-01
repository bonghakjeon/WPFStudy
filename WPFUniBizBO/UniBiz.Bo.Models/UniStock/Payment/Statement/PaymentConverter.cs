// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public static class PaymentConverter
  {
    public const int payc_anytime = 9999;
    public const string pay_Code = "결제코드";
    public const string pay_SiteID = "싸이트";
    public const string pay_Date = "결제일";
    public const string pay_StoreCode = "지점코드";
    public const string pay_Supplier = "코드";
    public const string pay_SupplierType = "형태";
    public const string pay_Type = "타입";
    public const string pay_StartDate = "시작일자";
    public const string pay_EndDate = "종료일자";
    public const string pay_PayMethod = "결제수단";
    public const string pay_PayMethodDesc = "결제수단 설명";
    public const string pay_Round = "회";
    public const string pay_RoundDesc = "회 설명";
    public const string pay_Turn = "차";
    public const string pay_TurnDesc = "차 설명";
    public const string pay_ConfirmStatus = "결제확정";
    public const string pay_ConfirmStatusDesc = "결제확정 설명";
    public const string pay_StatementStatus = "전표확정";
    public const string pay_StatementStatusDesc = "전표확정 설명";
    public const string pay_TypeCustom1 = "타입1";
    public const string pay_TypeCustom1Desc = "타입1 설명";
    public const string pay_TypeCustom2 = "타입2";
    public const string pay_TypeCustom2Desc = "타입2 설명";
    public const string pay_BaseAmount = "기초금액";
    public const string pay_BuyAmount = "매입금액";
    public const string pay_BuyTax = "매입과세계";
    public const string pay_BuyVat = "매입부가세계";
    public const string pay_BuyFree = "매입면세계";
    public const string pay_BuyReturnAmount = "반품금액";
    public const string pay_BuyReturnTax = "반품과세계";
    public const string pay_BuyReturnVat = "반품부가세계";
    public const string pay_BuyReturnFree = "반품면세계";
    public const string pay_Deposit = "저장품";
    public const string pay_SaleAmount = "매출금액";
    public const string pay_SaleTax = "매출과세계";
    public const string pay_SaleVat = "매출부가세계";
    public const string pay_SaleFree = "매출면세계";
    public const string pay_DeductionAmount = "공제금액";
    public const string pay_PayAmount = "결제금액";
    public const string pay_AddAmount = "보정금액";
    public const string pay_EndAmount = "기말금액";
    public const int ORDER_BY_PAYMENT_STORE_SUPPLIER_DATE = 1;
    public const int ORDER_BY_PAYMENT_SUPPLIER_STORE_DATE = 2;
    public const int ORDER_BY_PAYMENT_STORE_DATE_SUPPLIER = 3;
    public const int ORDER_BY_PAYMENT_STORE_SUPPLIER_DATE1 = 4;
    public const int ORDER_BY_PAYMENT_SUPPLIER_STORE_DATE1 = 5;
    public const int ORDER_BY_PAYMENT_STORE_DATE1_SUPPLIER = 6;
    public const string pd_PaymentID = "결제코드";
    public const string pd_Seq = "순번";
    public const string pd_SiteID = "싸이트";
    public const string pd_StoreCode = "지점코드";
    public const string pd_ConfirmDate = "확정일자";
    public const string pd_ConfirmStatus = "확정타입";
    public const string pd_InOutDiv = "입출금";
    public const string pd_StatementType = "종목";
    public const string pd_ReasonType = "타입";
    public const string pd_WriteType = "작성";
    public const string pd_Amount = "금액";
    public const string pd_PayAmount = "결제금액";
    public const string pd_DeductAmount = "공제금액";
    public const string pd_Memo = "메모";
    public const string pd_TransmitStatus = "전송상태";
    public const string pd_TransmitDate = "전송일시";
    public const string buy_Amount = "매입금액";
    public const string return_Amount = "반품금액";
    public const string pdd_Type = "타입";
    public const string pdd_DeductReasonType = "공제";
    public const string pdd_PayAmount = "결제금액";
    public const string pdd_DeductAmount = "공제금액";
    public const string pdd_EndAmount = "기말금액";
    public const string T_PAYMENT_EXIST = "결제 전표 존재 유무";
    public const string T_PAYMENT_DATE_AFTER_CONFIRM = "대금 전표 이후 확정 전표 유무";
    public const string T_PAYMENT_DATE_AFTER_STATEMENT = "대금전표 일자 이후 전표 마감 유무";
    public const string T_PAYMENT_MONTH = "대금 기초 월";
    public const string T_MONTH_INIT_STATEMENT_BUY = "매입전표 월 초기값 설정";
    public const string T_MONTH_INIT_SALES_LEA_CHARGE_NOT_ZERO = "기초 임대 매출 수수료 초기값 설정";
    public const string T_MONTH_INIT_SALES_LEA_CHARGE_ZERO = "임대매출 수수료율 없을 때";
    public const string T_MONTH_INIT_PAYMENT_DETAIL = "기초 결제(결제+공제)";
    public const string T_STATEMENT_BUY = "해당 기간 매입";
    public const string T_SALES_LEA_CHARGE_NOT_ZERO = "임대매출 수수료율 있을때";
    public const string T_SALES_LEA_CHARGE_ZERO = "임대매출 수수료율 없을때";
    public const string T_STATEMENT_RETURN = "해당 기간 반품";
    public const string T_SALES = "해당 기간 매출";
    public const string T_PAYMENT_STATEMENT = "해당 기간 결제,공제";
  }
}
