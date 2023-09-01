// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignInfoConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo
{
  public static class CampaignInfoConverter
  {
    public const string ci_CampaignCode = "캠페인코드";
    public const string ci_SiteID = "싸이트";
    public const string ci_CampaignName = "캠페인명";
    public const string ci_StartDate = "시작일";
    public const string ci_EndDate = "종료일";
    public const string ci_CampaignType = "캠페인유형";
    public const string ci_CampaignMember = "캠페인회원대상여부";
    public const string ci_CampaignGoods = "캠페인상품대상여부";
    public const string cip_CampaignCode = "캠페인코드";
    public const string cip_PromotionCode = "프로모션코드";
    public const string cip_SiteID = "싸이트";
    public const string cim_CampaignCode = "캠페인코드";
    public const string cim_MemberNo = "회원코드";
    public const string cim_SiteID = "싸이트";
    public const string cig_CampaignCode = "캠페인코드";
    public const string cig_CodeType = "코드타입";
    public const string cig_GoodsCode = "대상코드";
    public const string cig_SiteID = "싸이트";
    public const string cis_CampaignCode = "캠페인코드";
    public const string cis_StoreCode = "지점코드";
    public const string cis_SiteID = "싸이트";
    public const string cp_GiftCardID = "상품권코드";
    public const string cp_CouponID = "쿠폰ID";
    public const string cp_SiteID = "싸이트";
    public const string cp_CouponType = "쿠폰구분";
    public const string cp_Apply = "회원인증시 적용";
    public const string cp_EmpCode = "담당자코드";
    public const string cp_Title = "타이틀";
    public const string cp_Url = "디자인 URL";
    public const string cp_Desc = "설명";
    public const string cp_LMSKey = "LMS전송키";
    public const string cp_IssueCnt = "발급건수";
    public const string cp_UsableCnt = "사용가능횟수";
    public const string cp_CampaignCode = "캠페인코드";
    public const string cp_PromotionID = "프로모션ID";
    public const string cp_Status = "상태";
    public const string cp_ApprovalDate = "승인일시";
    public const string cp_SendDate = "발송일시";
    public const string cpd_CouponNo = "쿠폰번호";
    public const string cpd_SiteID = "싸이트";
    public const string cpd_GiftCardID = "상품권코드";
    public const string cpd_CouponID = "쿠폰ID";
    public const string cpd_ApplyDiv = "적용구분";
    public const string cpd_MemberNo = "회원(회원유형)";
    public const string cpd_MobileNo = "휴대폰번호";
    public const string cpd_UseCnt = "사용횟수";
    public const string cpd_StopYn = "중지여부";
    public const string cpd_StopYes = "중지";
    public const string cpd_StopNo = "허용";
    public const string cpd_MemberName = "회원(회원유형)명";
    public const string pm_PromotionCode = "프로모션코드";
    public const string pm_SiteID = "싸이트";
    public const string pm_PromotionName = "프로모션명";
    public const string pm_PromotionDesc = "프로모션상세명";
    public const string pm_PromotionKind = "종류";
    public const string pm_PromotionType = "유형";
    public const string pm_PromotionDiv = "구분";
    public const string pm_TargetGroup = "적용대상";
    public const string pm_DcValue = "할인값";
    public const string pm_MixYn = "믹스조건";
    public const string pm_MixOperator = "연산자";
    public const string pm_MixQty = "믹스수량";
    public const string pm_ApplyDiv = "적용체크";
    public const string pm_ApplyPackQty = "적용묶음수량";
    public const string pm_ApplyMinQty = "적용최소수량";
    public const string pm_ApplyMaxQty = "적용최대수량";
    public const string pm_ApplyMinAmt = "적용최소금액";
    public const string pm_ApplyMaxAmt = "적용최대금액";
    public const string pm_ApplyAllYn = "모두적용";
    public const string pm_ApplyAllYes = "모두할인";
    public const string pm_ApplyAllNo = "1개만할인";
    public const string pm_EventReceiptID = "이벤트영수증ID";
    public const string pm_StartDate = "시작일자";
    public const string pm_StartTime = "시작시간";
    public const string pm_StartTimeInit = "0000";
    public const string pm_EndDate = "종료일자";
    public const string pm_EndTime = "종료시간";
    public const string pm_EndTimeInit = "2359";
    public const string pm_SunYn = "일";
    public const string pm_MonYn = "월";
    public const string pm_TueYn = "화";
    public const string pm_WedYn = "수";
    public const string pm_ThuYn = "목";
    public const string pm_FriYn = "금";
    public const string pm_SatYn = "토";
    public const string pm_DuplicationYn = "중복가능";
    public const string PromotionStoreInfo = "대상지점";
    public const string pms_PromotionCode = "프로모션코드";
    public const string pms_StoreCode = "지점코드";
    public const string pms_SiteID = "싸이트";
    public const string PromotionTargetInfo = "할인대상";
    public const string pmt_PromotionCode = "프로모션코드";
    public const string pmt_TargetCode = "할인대상코드";
    public const string pmt_SiteID = "싸이트";
    public const string pmt_LinkViewCode = "할인대상 코드";
    public const string pmt_LinkName = "할인대상 명";
    public const string pmt_LinkGoodsSize = "규격/설명";
    public const string PromotionMixInfo = "믹스조건";
    public const string pmm_PromotionCode = "프로모션코드";
    public const string pmm_ConditionCode = "믹스조건코드";
    public const string pmm_SiteID = "싸이트";
    public const string pmm_LinkViewCode = "믹스조건대상 코드";
    public const string pmm_LinkName = "믹스조건대상 명";
    public const string pmm_LinkGoodsSize = "규격/설명";
  }
}
