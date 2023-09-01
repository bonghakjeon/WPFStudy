// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.ColumnCategoryDictionary
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Collections.Generic;

namespace UniBizBO.Common
{
  public class ColumnCategoryDictionary : Dictionary<string, string>
  {
    public static ColumnCategoryDictionary Default { get; set; }

    static ColumnCategoryDictionary()
    {
      ColumnCategoryDictionary categoryDictionary = new ColumnCategoryDictionary();
      categoryDictionary["S1_GoalAmount"] = "목표";
      categoryDictionary["S1_Qty"] = "수량";
      categoryDictionary["S1_Amount"] = "금액";
      categoryDictionary["S1_SaleRate"] = "비율";
      categoryDictionary["S1_ProfitAmt"] = "이익액";
      categoryDictionary["S1_Customer"] = "객수";
      categoryDictionary["S1_CustomerPrice"] = "객단가";
      categoryDictionary["S1_DcAmount"] = "할인";
      categoryDictionary["S1_PayAmount"] = "금종";
      categoryDictionary["S2_StoreEx"] = "지점상세";
      categoryDictionary["S2_SaleRate"] = "구성비";
      categoryDictionary["S2_DeptViewCode"] = "부서코드";
      categoryDictionary["S2_DeptName"] = "부서명";
      categoryDictionary["S2_CategoryViewCode"] = "분류코드";
      categoryDictionary["S2_CategoryName"] = "분류명";
      categoryDictionary["S2_GoodsEx"] = "상품상세";
      categoryDictionary["S2_GoodsPrice"] = "상품가격";
      categoryDictionary["S2_SupplierEx"] = "업체상세";
      categoryDictionary["Image"] = "이미지";
      categoryDictionary["TypeInfo"] = "타입정보";
      categoryDictionary["BankInfo"] = "은행정보";
      categoryDictionary["Memo"] = "메모";
      categoryDictionary["E1_TelInfo"] = "연락처";
      categoryDictionary["E1_Email"] = "이메일";
      categoryDictionary["E1_AddrInfo"] = "주소";
      categoryDictionary["SU1_BizInfo"] = "사업자";
      categoryDictionary["SU1_TagInfo"] = "태그";
      categoryDictionary["SU1_HeadInfo"] = "대표";
      categoryDictionary["M1_Date"] = "일자";
      categoryDictionary["M1_Supplier"] = "업체";
      categoryDictionary["M1_ChargeRate"] = "수수료(이익율)";
      categoryDictionary["M1_PointRate"] = "추가적립율";
      categoryDictionary["M1_Category"] = "분류";
      categoryDictionary["M1_BuyCost"] = "원가";
      categoryDictionary["M1_BuyPrice"] = "매입가";
      categoryDictionary["M1_SalePrice"] = "판매가";
      categoryDictionary["M1_SaleMargin"] = "이익율";
      categoryDictionary["M1_Diff"] = "차액";
      categoryDictionary["M1_MemberPrice1"] = "회원가1";
      categoryDictionary["M1_MemberPrice2"] = "회원가2";
      categoryDictionary["M1_MemberPrice3"] = "회원가3";
      categoryDictionary["M1_PointRate"] = "적립율";
      categoryDictionary["M1_Maker"] = "제조사";
      categoryDictionary["M1_Brand"] = "브랜드";
      categoryDictionary["M2_StdPrice"] = "정상가";
      categoryDictionary["M2_EventPrice"] = "행사가";
      categoryDictionary["M3_MemberPrice"] = "회원가";
      categoryDictionary["M4_GoodsSize"] = "규격";
      categoryDictionary["M4_PriceSum"] = "합계";
      categoryDictionary["M4_VolumeInfo"] = "용량";
      categoryDictionary["M5_OrderEndDate"] = "발주중지";
      categoryDictionary["M5_SaleEndDate"] = "판매종료";
      categoryDictionary["M5_DeliveryDiv"] = "배송";
      categoryDictionary["M5_MultiSuplier"] = "복수업체";
      categoryDictionary["M5_MinOrderUnit"] = "최소발주";
      categoryDictionary["P1_Qty"] = "수량";
      categoryDictionary["P1_Amount"] = "세제외금액";
      categoryDictionary["P1_SumAmount"] = "금액";
      categoryDictionary["P1_Profit"] = "이익";
      categoryDictionary["P1_Etc"] = "기타";
      categoryDictionary["P1_AvgCost"] = "평균원가";
      categoryDictionary["P1_BarCode"] = "바코드";
      categoryDictionary["P1_GoodsInfo"] = "상품정보";
      categoryDictionary["P1_CostAmt"] = "원가금액";
      categoryDictionary["P1_PriceAmt"] = "매가금액";
      categoryDictionary["P1_Base"] = "기초";
      categoryDictionary["P1_Buy"] = "매입";
      categoryDictionary["P1_Return"] = "반품";
      categoryDictionary["P1_InnerMoveIn"] = "대입";
      categoryDictionary["P1_InnerMoveOut"] = "대출";
      categoryDictionary["P1_InnerMoveInOut"] = "대출입";
      categoryDictionary["P1_OuterMoveIn"] = "점입";
      categoryDictionary["P1_OuterMoveOut"] = "점출";
      categoryDictionary["P1_BuyAmount"] = "매출원가";
      categoryDictionary["P1_Sale"] = "매출";
      categoryDictionary["P1_Disuse"] = "폐기";
      categoryDictionary["P1_Adjust"] = "조정";
      categoryDictionary["P1_PriceUpDown"] = "인상하";
      categoryDictionary["P1_PriceUp"] = "인상";
      categoryDictionary["P1_PriceDown"] = "인하";
      categoryDictionary["P1_End"] = "기말";
      categoryDictionary["P1_Calc"] = "재고";
      categoryDictionary["P1_Logistics"] = "물류";
      categoryDictionary["P1_End2"] = "장부";
      categoryDictionary["P1_PreAdjust"] = "전조정";
      categoryDictionary["P1_Inventory"] = "실사";
      categoryDictionary["P1_Loss"] = "과부족";
      categoryDictionary["SMT1_OrderQty"] = "발주량";
      categoryDictionary["SMT1_Qty"] = "수량";
      categoryDictionary["SMT1_TaxFreeAmount"] = "면세";
      categoryDictionary["SMT1_TaxAmount"] = "과세";
      categoryDictionary["SMT1_Deposit"] = "보증금";
      categoryDictionary["SMT1_CostSumAmt"] = "합계";
      categoryDictionary["SMT1_Profit"] = "이익";
      categoryDictionary["SMT1_PriceAmount"] = "매가";
      categoryDictionary["SMT1_Sale"] = "매출";
      categoryDictionary["SMT1_Dept"] = "부서";
      categoryDictionary["SMT1_CategoryTop"] = "대";
      categoryDictionary["SMT1_CategoryMid"] = "중";
      categoryDictionary["SMT1_CategoryBot"] = "소";
      categoryDictionary["SMT1_BuyCost"] = "원가";
      categoryDictionary["SMT1_BuyCostPrice"] = "공급가";
      categoryDictionary["SMT1_DeviceInfo"] = "장치";
      categoryDictionary["SMT1_OrderDate"] = "발주일";
      categoryDictionary["INVSMT1_Qty"] = "재고수량";
      categoryDictionary["INVSMT1_CostSumAmt"] = "재고금액";
      categoryDictionary["Pay1_Store"] = "지점";
      categoryDictionary["Pay1_Supplier"] = "업체";
      categoryDictionary["Pay1_PayTypes"] = "지급";
      categoryDictionary["Pay1_Status"] = "상태";
      categoryDictionary["Pay1_StatusCustom"] = "상태확장";
      categoryDictionary["Pay1_DateFromTo"] = "조회기간";
      categoryDictionary["Pay1_BaseAmount"] = "기초";
      categoryDictionary["Pay1_BuyAmount"] = "매입";
      categoryDictionary["Pay1_BuyAmountEx"] = "매입상세";
      categoryDictionary["Pay1_BuyReturnAmount"] = "반품";
      categoryDictionary["Pay1_BuyReturnAmountEx"] = "반품상세";
      categoryDictionary["Pay1_BuyAmountSum"] = "매입합계";
      categoryDictionary["Pay1_BuyAmountSumEx"] = "매입합계상세";
      categoryDictionary["Pay1_Deposit"] = "보증금";
      categoryDictionary["Pay1_SaleAmount"] = "매출";
      categoryDictionary["Pay1_SaleAmountEx"] = "매출상세";
      categoryDictionary["Pay1_DeductionAmount"] = "공제";
      categoryDictionary["Pay1_PayAmount"] = "결제";
      categoryDictionary["Pay1_AddAmount"] = "보정";
      categoryDictionary["Pay1_EndAmount"] = "기말";
      categoryDictionary["Pay2_PayInfo"] = "결제정보";
      categoryDictionary["Pay2_StatementInfo"] = "전표정보";
      categoryDictionary["Pay2_PayAmountBefore"] = "결제할금액";
      categoryDictionary["Mbr1_Member"] = "회원";
      categoryDictionary["Mbr1_Card"] = "카드정보";
      categoryDictionary["Mbr1_Biz"] = "사업자정보";
      categoryDictionary["Mbr1_Tel"] = "전화정보";
      categoryDictionary["Mbr1_Sms"] = "SMS 정보";
      categoryDictionary["Mbr1_StoreDate"] = "지점,일자 정보";
      categoryDictionary["Mbr1_Msg"] = "공지";
      categoryDictionary["Mbr1_Addr"] = "주소 정보";
      categoryDictionary["Mbr1_Bank"] = "은행 정보";
      categoryDictionary["Mbr2_MbrCnt"] = "회원수";
      categoryDictionary["Mbr2_BuyCnt"] = "구매횟수";
      categoryDictionary["Mbr2_BuyAmt"] = "구매금액";
      categoryDictionary["Mbr2_BuyPrice"] = "구매단가";
      categoryDictionary["Mbr2_SaleQty"] = "매출수량";
      categoryDictionary["Mbr2_SaleAmt"] = "매출금액";
      categoryDictionary["Mbr2_EikAmt"] = "이익액";
      categoryDictionary["Mbr2_CompRate"] = "구성비";
      categoryDictionary["Mbr2_Code"] = "코드";
      // ISSUE: reference to a compiler-generated field
      ColumnCategoryDictionary.\u003CDefault\u003Ek__BackingField = categoryDictionary;
    }
  }
}
