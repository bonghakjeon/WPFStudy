// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.MemberInqConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;

namespace UniBiz.Bo.Models.UniMembers.Inq
{
  public static class MemberInqConverter
  {
    public const string MemberInqBasicCycleChgHisHeader = "회원기본조회(회원주기변경이력_헤더)";
    public const string mbrCnt = "회원수";
    public const string mbrCntRate = "구성비";
    public const string upChgMbrCnt = "Up회원수";
    public const string noChgMbrCnt = "유지회원수";
    public const string downChgMbrCnt = "Down회원수";
    public const string newMemberGradeName = "신회원등급명";
    public const string oldMemberGradeName = "구회원등급명";
    public const string mibpds_SaleDate = "영업일";
    public const string mibpds_SiteID = "싸이트";
    public const string mibpds_AddPoint = "적립포인트";
    public const string mibpds_AddMbrCnt = "적립회원수";
    public const string mibpds_AfAddPoint = "사후적립포인트";
    public const string mibpds_AfAddMbrCnt = "사후적립회원수";
    public const string mibpds_MlAddPoint = "수기적립포인트";
    public const string mibpds_MlAddMbrCnt = "수기적립회원수";
    public const string mibpds_UsePoint = "사용포인트";
    public const string mibpds_UseMbrCnt = "사용회원수";
    public const string mibpds_ExtinctPoint = "소멸포인트";
    public const string mibpds_ExtinctMbrCnt = "소멸회원수";
    public const string mibpds_MlUsePoint = "수기차감포인트";
    public const string mibpds_MlUseMbrCnt = "수기차감회원수";
    public const string mibpds_AddPointSum = "적립포인트소계";
    public const string mibpds_UsePointSum = "사용포인트소계";
    public const string mibpds_PointSum = "당일포인트합계";
    public const string mibwb_Code = "조회코드";
    public const string mibwb_SiteID = "싸이트";
    public const string mibwb_CodeName = "코드명";
    public const string mibwb_SaleQty = "수량";
    public const string mibwb_SaleQtyRate = "수량구성비";
    public const string mibwb_SaleAmt = "금액";
    public const string mibwb_SaleAmtRate = "금액구성비";
    public const string mibwb_EikAmt = "이익액";
    public const string mibwb_EikAmtRate = "이익액구성비";
    public const string mibwb_BuyCnt = "구매횟수";
    public const string mibwb_BuyCntRate = "구매횟수구성비";
    public const string mibwb_BuyPrice = "구매단가";
    public const string mibwb_BuyPriceRate = "구매단가구성비";
    public const string mibwb_MbrSaleAmt = "회원금액";
    public const string mibwb_MbrSaleAmtRate = "회원금액구성비";
    public const string mibwb_MbrEikAmt = "회원이익액";
    public const string mibwb_MbrEikAmtRate = "회원이익액구성비";
    public const string mibwb_MbrBuyCnt = "회원구매횟수";
    public const string mibwb_MbrBuyCntRate = "회원구매횟수구성비";
    public const string mibwb_MbrBuyPrice = "회원구매단가";
    public const string mibwb_MbrBuyPriceRate = "회원구매단가구성비";
    public const string mibwb_MbrRate = "회원비중";

    public static EnumMemberInqSelectCodeGoods ToMemberInqSelectCodeGoods(int p_value)
    {
      foreach (EnumMemberInqSelectCodeGoods inqSelectCodeGoods in Enum.GetValues(typeof (EnumMemberInqSelectCodeGoods)))
      {
        if (inqSelectCodeGoods == (EnumMemberInqSelectCodeGoods) p_value)
          return inqSelectCodeGoods;
      }
      return EnumMemberInqSelectCodeGoods.NONE;
    }
  }
}
