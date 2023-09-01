// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEodInfoStatus
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEodInfoStatus
  {
    [Description("-STATUS-")] NONE,
    [Description("Category")] Category,
    [Description("Employee")] Employee,
    [Description("Goods")] Goods,
    [Description("MemberGoods")] MemberGoods,
    [Description("PosInfo")] PosInfo,
    [Description("StoreInfo")] StoreInfo,
    [Description("Supplier")] Supplier,
    [Description("EventSlipHeader")] EventSlipHeader,
    [Description("EventSlipDetail")] EventSlipDetail,
    [Description("ShortCutGroup")] ShortCutGroup,
    [Description("ShortCutList")] ShortCutList,
    [Description("VanComp")] VanComp,
    [Description("CardComp")] CardComp,
    [Description("VanLinkComp")] VanLinkComp,
    [Description("MemberType")] MemberType,
    [Description("MemberTypeHistory")] MemberTypeHistory,
    [Description("MemberGroup")] MemberGroup,
    [Description("MemberGrade")] MemberGrade,
    [Description("Member")] Member,
    [Description("MemberCard")] MemberCard,
    [Description("GiftCard")] GiftCard,
    [Description("EventInfo")] EventInfo,
    [Description("EventHistory")] EventHistory,
    [Description("EventTargetDetail")] EventTargetDetail,
    [Description("NeoSiteOption")] NeoSiteOption,
    [Description("CommonCode")] CommonCode,
    [Description("ShortCutList")] ShortCutListGoods,
    [Description("DeliveryList")] DeliveryList,
    [Description("MultiVanHeader")] MultiVanHeader,
    [Description("MultiVanDetail")] MultiVanDetail,
    [Description("이기종 데이터 가지고 오기")] LINK_SERVER_RECV,
    [Description("수불")] SUBUL,
    [Description("특정매입작업")] FEE_INVOICE,
    [Description("대금")] PAYMENT,
    [Description("회원 주기 마감")] MEMBER_CYCLE,
    [Description("회원 등급 마감")] MEMBER_GRADE,
    [Description("회원 포인트 소멸 마감")] MEMBER_POINT_EXTINCTION,
    [Description("회원구매주기마감")] MEMBER_BUY_CYCLE,
    [Description("이기종 데이터 보내기")] LINK_SERVER_SEND,
    [Description("DB BACKUP")] DB_BACKUP,
    [Description("자동 발주")] AUTO_ORDER,
    [Description("외상매출마감")] CREDIT_PAYMENT,
  }
}
