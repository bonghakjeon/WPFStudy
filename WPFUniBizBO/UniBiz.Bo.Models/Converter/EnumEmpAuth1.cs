// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEmpAuth1
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEmpAuth1
  {
    [Description("-사용권한1-")] NONE = 0,
    [Description("개발사")] ADMIN_SYSTEM = 1,
    [Description("유통사")] ADMIN_AGENT = 2,
    [Description("전산 관리자")] ADMIN_ADMIN = 4,
    [Description("보조 관리자")] ADMIN_ADMIN_SUB = 8,
    [Description("출력")] OUTPUT_PRINT = 16, // 0x00000010
    [Description("엑셀")] OUTPUT_EXCEL = 32, // 0x00000020
    [Description("SMS")] OUTPUT_SMS = 64, // 0x00000040
    [Description("이메일")] OUTPUT_EMAIL = 128, // 0x00000080
    [Description("상품등록(가격변경)")] GOODS_SAVE = 256, // 0x00000100
    [Description("상품등록(가격변경제외)")] GOODS_SAVE_PRICE_EXCEPT = 512, // 0x00000200
    [Description("지점 등록")] STORE_INSERT = 1024, // 0x00000400
    [Description("지점 변경")] STORE_UPDATE = 2048, // 0x00000800
    [Description("사원 등록 변경")] EMPLOYEE_SAVE = 4096, // 0x00001000
    [Description("사원 권한 변경")] EMPLOYEE_PERMIT_SAVE = 8192, // 0x00002000
    [Description("마스터공통")] MASTER_COMMON_SAVE = 16384, // 0x00004000
    [Description("업체등록")] SUPPLIER_SAVE = 32768, // 0x00008000
    [Description("매출목표")] SALES_GOAL_SAVE = 65536, // 0x00010000
    [Description("회원유형등록")] MEMBER_TYPE_SAVE = 131072, // 0x00020000
    [Description("회원산정기준등록")] MEMBER_STD_SAVE = 262144, // 0x00040000
    [Description("회원계산서발행")] MEMBER_TAX_PUBLISH = 524288, // 0x00080000
    [Description("예약 21")] PERMIT_SAMPLE_21 = 1048576, // 0x00100000
    [Description("결제 전표 등록")] PAYMENT_INPUT = 2097152, // 0x00200000
    [Description("결제 전표 확정")] PAYMENT_CONFIRM = 4194304, // 0x00400000
    [Description("결제 전표 삭제")] PAYMENT_DELETE = 8388608, // 0x00800000
    [Description("결제 마감")] PAYMENT_CLOSED = 16777216, // 0x01000000
    [Description("장부(수불) 마감")] INVT_CLOSED = 33554432, // 0x02000000
    [Description("캠페인 등록")] CAMPAIGN_SAVE = 67108864, // 0x04000000
    [Description("프로모션 등록")] PROMOTION_SAVE = 134217728, // 0x08000000
    [Description("쿠폰 등록")] COUPON_SAVE = 268435456, // 0x10000000
    [Description("메뉴 등록")] PROG_MENU_SAVE = 301989888, // 0x12000000
    [Description("예약 30")] PERMIT_SAMPLE_30 = 536870912, // 0x20000000
    [Description("예약 31")] PERMIT_SAMPLE_31 = 1073741824, // 0x40000000
  }
}
