// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.TableCodeType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models
{
  public enum TableCodeType
  {
    [Description("-테이블-")] Unknown = 0,
    [Description("SITE")] UniSite = 1,
    [Description("공통코드")] CommonCode = 2,
    [Description("지점")] StoreInfo = 3,
    [Description("지점 그룹")] StoreGroupHeader = 4,
    [Description("지점 그룹 상세")] StoreGroupDetail = 5,
    [Description("사원")] Employee = 6,
    [Description("사원 이미지")] EmpImage = 7,
    [Description("사원 코드(지점,분류,거래처) 권한")] EmpAuthority = 8,
    [Description("APP MENU")] ProgMenu = 9,
    [Description("APP MENU Auth")] ProgMenuAuth = 10, // 0x0000000A
    [Description("POPUP MENU")] ProgMenuProp = 11, // 0x0000000B
    [Description("POPUP MENU Auth")] ProgMenuPropAuth = 12, // 0x0000000C
    [Description("즐겨찿기")] ProgMenuBookMark = 13, // 0x0000000D
    [Description("장치(Device)")] OuterConnAuth = 14, // 0x0000000E
    [Description("제조사")] Maker = 16, // 0x00000010
    [Description("POS정보")] PosInfo = 17, // 0x00000011
    [Description("밴사")] VanComp = 18, // 0x00000012
    [Description("카드회사")] CardComp = 19, // 0x00000013
    [Description("밴연결카드회사")] VanLinkComp = 20, // 0x00000014
    [Description("결제 계획")] PayContion = 21, // 0x00000015
    [Description("업체")] Supplier = 22, // 0x00000016
    [Description("업체 이미지")] SupplierImage = 23, // 0x00000017
    [Description("업체 결제 조건 이력")] SupplierHistory = 24, // 0x00000018
    [Description("업체 자동공제 이력")] SupplierAutoDeduction = 25, // 0x00000019
    [Description("장려금 조건")] RebateConditionHeader = 26, // 0x0000001A
    [Description("장려금 조건 상세")] RebateConditionDetail = 27, // 0x0000001B
    [Description("자동발주 조건 설정")] AutoOrderConition = 28, // 0x0000001C
    [Description("부서")] Dept = 31, // 0x0000001F
    [Description("브랜드")] Brand = 33, // 0x00000021
    [Description("분류")] Category = 34, // 0x00000022
    [Description("상품")] Goods = 36, // 0x00000024
    [Description("상품 이력")] GoodsHistory = 37, // 0x00000025
    [Description("구바코드")] GoodsOldBarcode = 38, // 0x00000026
    [Description("상품 구성")] GoodsPack = 39, // 0x00000027
    [Description("점별 상품")] GoodsStoreInfo = 40, // 0x00000028
    [Description("상품 이미지")] GoodsImage = 41, // 0x00000029
    [Description("관심상품")] BookmarkGoodsGroup = 42, // 0x0000002A
    [Description("관심상품 상세")] BookmarkGoodsList = 43, // 0x0000002B
    [Description("상품권")] GiftCard = 44, // 0x0000002C
    [Description("상품권 사용 이력")] GiftCardHistory = 45, // 0x0000002D
    [Description("프로그램 옵션")] ProgOption = 46, // 0x0000002E
    [Description("일마감")] EodInfo = 47, // 0x0000002F
    [Description("일마감 DB BACKUP")] EodDbBackup = 48, // 0x00000030
    [Description("컬럼 스타일")] ColStyle = 49, // 0x00000031
    [Description("에러코드")] ErrorCode = 50, // 0x00000032
    [Description("로케이션")] Location = 51, // 0x00000033
    [Description("손익 결산 작업")] ProfitLossWorkCnt = 61, // 0x0000003D
    [Description("손익 결산 작업 이력")] ProfitLossWorkCntLog = 62, // 0x0000003E
    [Description("손익 결산")] ProfitLossSummary = 63, // 0x0000003F
    [Description("재고조사 전표")] InventoryHeader = 64, // 0x00000040
    [Description("재고조사 전표 상세")] InventoryDetail = 65, // 0x00000041
    [Description("재고조사 결산 작업")] InventoryWorkCnt = 66, // 0x00000042
    [Description("재고조사 결산 작업 이력")] InventoryWorkCntLog = 67, // 0x00000043
    [Description("재고조사 결산")] InventorySummary = 68, // 0x00000044
    [Description("전표")] StatementHeader = 69, // 0x00000045
    [Description("전표 상세")] StatementDetail = 70, // 0x00000046
    [Description("전표 연결")] MoveInOutLink = 71, // 0x00000047
    [Description("매입대금 월 결산")] PaymentMonth = 72, // 0x00000048
    [Description("매입대금 전표")] Payment = 73, // 0x00000049
    [Description("매입대금 전표상세")] PaymentDetail = 74, // 0x0000004A
    [Description("부서별 목표액")] GoalByDept = 75, // 0x0000004B
    [Description("분류별 목표액")] GoalByCategory = 76, // 0x0000004C
    [Description("일날씨")] WeatherByDay = 77, // 0x0000004D
    [Description("시간대날씨")] WeatherByTime = 78, // 0x0000004E
    [Description("일매출현황")] SalesByDay = 79, // 0x0000004F
    [Description("시간대매출현황")] SalesByTime = 80, // 0x00000050
    [Description("회원타입")] MemberType = 81, // 0x00000051
    [Description("회원타입 이력")] MemberTypeHistory = 82, // 0x00000052
    [Description("회원그룹")] MemberGroup = 83, // 0x00000053
    [Description("회원")] Member = 84, // 0x00000054
    [Description("회원카드")] MemberCard = 85, // 0x00000055
    [Description("회원등급")] MemberGrade = 86, // 0x00000056
    [Description("회원산정주기")] MemberCalcCycle = 87, // 0x00000057
    [Description("회원주기기준")] MemberCycleStd = 88, // 0x00000058
    [Description("회원 등급 산정 방식 정보")] MemberGradeCalcStd = 89, // 0x00000059
    [Description("회원포인트소멸예정")] MemberPointExtinction = 90, // 0x0000005A
    [Description("회원일별매출집계")] MemberDaySum = 91, // 0x0000005B
    [Description("회원상품별매출집계")] MemberGoodsSum = 92, // 0x0000005C
    [Description("포인트적립 이력")] MemberPointHistory = 93, // 0x0000005D
    [Description("사은품")] GiftItem = 94, // 0x0000005E
    [Description("사은품 지금내역")] GiftGiveHistory = 95, // 0x0000005F
    [Description("회원 지점 기간별 외상매출 결제 조건")] MemberCreditHistory = 96, // 0x00000060
    [Description("회원-업체-포인트지점 연결")] MemberLinkSupplier = 97, // 0x00000061
    [Description("회원주기 변경 이력")] MemberCycleChgHistory = 98, // 0x00000062
    [Description("회원등급 변경 이력")] MemberGradeChgHistory = 99, // 0x00000063
    [Description("사원 작업 로그")] EmpActionLog = 100, // 0x00000064
    [Description("사원 변경 로그")] DataModLog = 101, // 0x00000065
    [Description("캠페인")] Campaign = 102, // 0x00000066
    [Description("캠페인 연결 프로모션")] CampaignPromotion = 103, // 0x00000067
    [Description("캠페인 연결 회원")] CampaignMember = 104, // 0x00000068
    [Description("캠페인 연결 상품/분류")] CampaignGoods = 105, // 0x00000069
    [Description("캠페인 연결 지점")] CampaignStore = 106, // 0x0000006A
    [Description("프로모션")] Promotion = 107, // 0x0000006B
    [Description("프로모션 연결 지점")] PromotionStore = 108, // 0x0000006C
    [Description("프로모션 연결 대상")] PromotionTarget = 109, // 0x0000006D
    [Description("프로모션 믹스 정보")] PromotionMix = 110, // 0x0000006E
    [Description("쿠폰")] Coupon = 111, // 0x0000006F
    [Description("쿠폰상세")] CouponDetail = 112, // 0x00000070
    [Description("에러 파일 정보")] ErrFiles = 113, // 0x00000071
    [Description("라벨 템플릿")] LabelTemplates = 114, // 0x00000072
    [Description("라벨 템플릿 컬럼")] LabelTemplateCols = 115, // 0x00000073
    [Description("폼텍 템플릿")] FormtecTemplates = 116, // 0x00000074
  }
}
