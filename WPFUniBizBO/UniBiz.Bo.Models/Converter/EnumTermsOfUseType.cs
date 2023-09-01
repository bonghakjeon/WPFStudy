// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumTermsOfUseType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumTermsOfUseType
  {
    [Description("-약관/개인정보-")] None,
    [Description("쇼핑몰 이용약관")] Shopping_Mall_Terms_and_Conditions,
    [Description("개인정보 처리방침")] privacy_policy,
    [Description("개인정보수집 및 이용동의(회원가입)")] Consent_to_collection_and_use_of_personal_information_member,
    [Description("개인정보수집 및 이용동의(비회원)")] Consent_to_collection_and_use_of_personal_information_,
    [Description("개인정보수집 및 이용동의(문의)")] Consent_to_collection_and_use_of_personal_information_inquiries,
    [Description("개인정보 제3자 제공(회원가입)")] Provision_of_personal_information_to_third_parties,
    [Description("개인정보 처리위탁(회원가입)")] Consignment_of_personal_information_processing,
    [Description("추가 동의 항목(회원가입)")] Additional_consent_items,
    [Description("배송문구")] Delivery_Text,
    [Description("이용안내")] Information_Use,
  }
}
