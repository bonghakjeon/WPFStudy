// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.EnumCampaignInfoLen
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo
{
  public enum EnumCampaignInfoLen
  {
    pm_EndTime = 4,
    pm_StartTime = 4,
    cp_LMSKey = 20, // 0x00000014
    cpd_CouponNo = 20, // 0x00000014
    cpd_MobileNo = 20, // 0x00000014
    cp_Title = 50, // 0x00000032
    ci_CampaignName = 100, // 0x00000064
    pm_PromotionName = 100, // 0x00000064
    cp_Url = 200, // 0x000000C8
    cp_Desc = 500, // 0x000001F4
    pm_PromotionDesc = 500, // 0x000001F4
  }
}
