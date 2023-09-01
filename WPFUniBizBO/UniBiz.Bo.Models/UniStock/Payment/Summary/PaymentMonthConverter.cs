// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Summary.PaymentMonthConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniStock.Payment.Summary
{
  public static class PaymentMonthConverter
  {
    public const string paym_YyyyMm = "결제월";
    public const string paym_StoreCode = "지점코드";
    public const string paym_Supplier = "코드";
    public const string paym_SiteID = "싸이트";
    public const string paym_BaseAmount = "기초금액";
    public const string paym_BuyTax = "매입과세계";
    public const string paym_BuyVat = "매입부가세계";
    public const string paym_BuyFree = "매입면세계";
    public const string paym_BuyAmount = "매입계";
    public const string paym_BuyReturnTax = "반품과세계";
    public const string paym_BuyReturnVat = "반품부가세계";
    public const string paym_BuyReturnFree = "반품면세계";
    public const string paym_BuyReturnAmount = "반품계";
    public const string paym_BuySumAmount = "매입반품합계";
    public const string paym_Deposit = "저장품계";
    public const string paym_SaleTax = "매출과세계";
    public const string paym_SaleVat = "매출부가세계";
    public const string paym_SaleFree = "매출면세계";
    public const string paym_DeductionAmount = "공제금액";
    public const string paym_PayAmount = "결제금액";
    public const string paym_AddAmount = "보정금액";
    public const string paym_EndAmount = "기말금액";
    public const string paym_befor = "전월";
    public const int ORDER_BY_PAYMENT_MONTH_YYMM_STORE_SUPPLIER = 1;
    public const int ORDER_BY_PAYMENT_MONTH_YYMM_SUPPLIER_STORE = 2;
  }
}
