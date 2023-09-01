// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniBase.Supplier
{
  public static class SupplierConverter
  {
    public const string su_Supplier = "코드";
    public const string su_SiteID = "싸이트";
    public const string su_HeadSupplier = "대표코드";
    public const string su_HeadName = "대표명";
    public const string su_SupplierViewCode = "식별코드";
    public const string su_SupplierName = "업체명";
    public const string su_SupplierType = "형태";
    public const string su_SupplierTypeDesc = "형태 설명";
    public const string su_SupplierKind = "타입";
    public const string su_SupplierKindDesc = "타입 설명";
    public const string su_UseYn = "상태";
    public const string su_PreTaxDiv = "기준단가";
    public const string su_PreTaxDesc = "기준단가 설명";
    public const string su_MultiSuplierDiv = "타사상품";
    public const string su_MultiSuplierDesc = "타사상품 설명";
    public const string su_DeductionDayDiv = "자동공제";
    public const string su_DeductionDayDesc = "자동공제 설명";
    public const string su_NewStatementYn = "신규전표사용상태";
    public const string su_Tel = "전화";
    public const string su_Fax = "FAX";
    public const string su_BizNo = "사업자번호";
    public const string su_BizName = "사업자명";
    public const string su_BizCeo = "대표자";
    public const string su_BizType = "업태";
    public const string su_BizCategory = "업종";
    public const string su_RegidentNo = "주민번호";
    public const string su_Addr1 = "주소";
    public const string su_Addr2 = "주소 상세";
    public const string su_ZipCode = "우편번호";
    public const string su_ContactNm1 = "담당자";
    public const string su_ContactMemo1 = "담당자 연락처";
    public const string su_ContactEmail1 = "담당자 이메일";
    public const string su_ContactNm2 = "담당자2";
    public const string su_ContactMemo2 = "담당자2 연락처";
    public const string su_ContactEmail2 = "담당자2 이메일";
    public const string su_BankCode = "은행";
    public const string su_AccountNo = "계좌번호";
    public const string su_AccountName = "예금주명";
    public const string su_Memo1 = "메모";
    public const string su_Memo2 = "메모 상세";
    public const string su_LeadTime = "리드타입";
    public const string su_Deposit = "보증금";
    public const string su_ErpCode = "ERP 코드";
    public const string su_EmailStatement = "전표용 이메일";
    public const string su_EmailTax = "계산서용 이메일";
    public const string su_head_Name = "대표코드 명";
    public const string su_head_ViewCode = "대표코드 식별코드";
    public const string su_AssignUser = "담당사원";
    public const string su_AssignUser_Name = "담당사원명";
    public const string sui_ID = "업체 이미지";
    public const string sui_SiteID = "싸이트";
    public const string sui_Supplier = "코드";
    public const string sui_Kind = "이미지 종류";
    public const string sui_KindDesc = "이미지 종류 설명";
    public const string sui_ImgType = "파일 타입";
    public const string sui_ImgFileName = "파일명";
    public const string sui_ThumbSize = "썸네일 사이즈";
    public const string sui_ThumbData = "썸네일";
    public const string sui_OriginSize = "원본 사이즈";
    public const string sui_OriginData = "원본";
    public const string suh_ID = "업체 결제 이력 KEY";
    public const string suh_SiteID = "싸이트";
    public const string suh_Supplier = "코드";
    public const string suh_StoreCode = "지점코드";
    public const string suh_StartDate = "시작일자";
    public const string suh_EndDate = "종료일자";
    public const string suh_PayMethod = "결제수단";
    public const string suh_PayMethodDesc = "결제수단 설명";
    public const string suh_PayCondition = "결제조건";
    public const string suad_SupplierHistory = "업체 결제 이력 KEY";
    public const string suad_Seq = "공제항목";
    public const string suad_SiteID = "싸이트";
    public const string suad_SeqDesc = "공제항목 설명";
    public const string suad_CalcType = "계산방법";
    public const string suad_CalcTypeDesc = "계산방법 설명";
    public const string suad_StdPriceType = "기준단가";
    public const string suad_StdPriceTypeDesc = "기준단가 설명";
    public const string suad_StdValue = "기준금액";
    public const string suad_Value = "공제값";
    public const string suad_AddProperty = "속성타입";
    public const string rch_StoreCode = "지점코드";
    public const string rch_Supplier = "코드";
    public const string rch_SiteID = "싸이트";
    public const string rch_ContractDate = "입점일(계약일)";
    public const string rch_CalcPeriodType = "생성주기";
    public const string rch_CalcPeriodTypeDesc = "생성주기 설명";
    public const string rch_StdAmtType = "기준금액유형";
    public const string rch_StdAmtTypeDesc = "기준금액유형 설명";
    public const string rch_UseYn = "사용상태";
    public const string rch_AddProperty = "속성타입";
    public const string rcd_StoreCode = "지점코드";
    public const string rcd_Supplier = "코드";
    public const string rcd_Seq = "순번";
    public const string rcd_SiteID = "싸이트";
    public const string rcd_StdAmtFrom = "기준금액 (이상)";
    public const string rcd_StdAmtTo = "기준금액 (미만)";
    public const string rcd_RebateRate = "적용장려금율 ";
    public const string rcd_AddProperty = "속성타입";
    public const string aoc_ID = "자동발주ID";
    public const string aoc_SiteID = "싸이트";
    public const string aoc_Supplier = "코드";
    public const string aoc_StoreCode = "지점코드";
    public const string aoc_CategoryCodeTop = "대분류코드";
    public const string aoc_DayofWeek = "요일";
    public const string aoc_LeadTime = "리드타임";
    public const string aoc_OrderCycle = "발주 주기일";
    public const string aoc_StatementSeqType = "전표 채번타입";
    public const string aoc_AddProperty = "속성타입";
  }
}
