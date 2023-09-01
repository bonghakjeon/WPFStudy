// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmployeeConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using UniBiz.Bo.Models.Converter;

namespace UniBiz.Bo.Models.UniBase.Employee
{
  public class EmployeeConverter
  {
    public const int DML_MAX_QUERY_SIZE = 4000;
    public const int DML_MAX_QUERY_SIZE_LARGE = 8000;
    public const string emp_Code = "사원코드";
    public const string emp_SiteID = "싸이트";
    public const string emp_Name = "사원명";
    public const string emp_BaseStore = "시작지점";
    public const string emp_Dept = "부서";
    public const string emp_Position = "직위";
    public const string emp_ID = "ID ";
    public const string emp_ProgPwd = "패스워드";
    public const string emp_PosID = "포스 ID";
    public const string emp_PosPwd = "포스 패스워드";
    public const string emp_UseYn = "사용상태";
    public const string emp_Tel = "전화";
    public const string emp_Mobile = "모바일";
    public const string emp_EnterDate = "입사일";
    public const string emp_StrEnterDate = "입사일자";
    public const string emp_RegidentNo = "주민번호";
    public const string emp_Email = "이메일";
    public const string emp_EmailPwd = "이메일패스워드";
    public const string emp_Zipcode = "우편번호";
    public const string emp_Addr1 = "주소";
    public const string emp_Addr2 = "주소 상세";
    public const string emp_Gender = "성별";
    public const string emp_BirthType = "양/음력";
    public const string emp_Birthday = "생년월일";
    public const string emp_StrBirthday = "생년일자";
    public const string emp_Anniversary = "기념일";
    public const string emp_StrAnniversary = "기념일자";
    public const string emp_MenuGroupID = "화면권한ID";
    public const string emp_ProgAuth1 = "작업 권한1";
    public const string emp_ProgAuth2 = "작업 권한2";
    public const string emp_ProgAuth3 = "작업 권한3";
    public const string emp_LoginLimitDate = "로그인 만료일";
    public const string emp_StrLoginLimitDate = "로그인 만료일자";
    public const string emp_PwdLimitDate = "패스워드 만료일";
    public const string emp_StrPwdLimitDate = "패스워드 만료일자";
    public const string emp_LoginDeny = "접속거절";
    public const string emp_ResignationStatus = "퇴사여부";
    public const string emp_ResignationDate = "퇴사일자";
    public const string emp_Job = "직책";
    public const string emp_ExtensionNumber = "내선번호";
    public const string ei_EmpCode = "사원코드";
    public const string ei_SiteID = "싸이트";
    public const string ei_ImgFileName = "파일명";
    public const string ei_ImgType = "이미지타입";
    public const string ei_ThumbSize = "사원 썸네일 크기";
    public const string ei_ThumbData = "사원 썸네일";
    public const string ei_OriginSize = "사원 이미지 크기";
    public const string ei_OriginData = "사원 이미지";
    public const string eal_ID = "ID (Key)";
    public const string eal_SiteID = "싸이트";
    public const string eal_SysDate = "사용일시";
    public const string eal_StoreCode = "지점코드";
    public const string eal_EmpCode = "사용자코드";
    public const string eal_MenuCode = "메뉴코드";
    public const string eal_SubProgID = "Sub화면 ID";
    public const string eal_ApplyRowCnt = "데이터수";
    public const string eal_ActionKind = "작업유형";
    public const string eal_ActionType = "동작유형";
    public const string eal_LocalIP = "내부 IP";
    public const string eal_PublicIP = "접속 IP";
    public const string eal_DeviceName = "디바이스명";
    public const string eal_Memo = "메모";
    public const string eal_Memo2 = "메모2";
    public const string eal_ProgKind = "프로그램 종류";
    public const string eal_ProgKindDesc = "프로그램 종류설명";
    public const string eal_Title = "타이틀";
    public const string dml_ID = "ID (Key)";
    public const string dml_SiteID = "싸이트";
    public const string dml_SysDate = "변경일시";
    public const string dml_StoreCode = "지점코드";
    public const string dml_EmpCode = "사용자코드";
    public const string dml_CodeInt = "키값";
    public const string dml_CodeLong = "키값2";
    public const string dml_CodeStr = "키값3";
    public const string dml_ActionKind = "변경유형";
    public const string dml_ActionType = "동작유형";
    public const string dml_TableSeq = "변경테이블";
    public const string dml_ModColumn = "변경컬럼";
    public const string dml_ModColumnDesc = "변경컬럼설명";
    public const string dml_BeforeValue = "변경전Data";
    public const string dml_AfterValue = "변경후Data";
    public const string dml_DeviceKey = "디바이스ID코드";
    public const string dml_DeviceName = "디바이스명";
    public const string ea_AuthType = "타입(지점,분류,거래처)";
    public const string ea_EmpCode = "사원코드";
    public const string ea_AuthValue = "허용코드";
    public const string ea_SiteID = "싸이트";
    public const string ea_InputYn = "입력여부";
    public const string ea_InputYnDesc = "입력여부 설명";
    public const string ea_PrintYn = "출력여부";
    public const string ea_PrintYnDesc = "출력여부 설명";
    public const string emp_ProgAuth = "작업 권한";
    public const string emp_TypeNo = "작업 권한 타입";

    public static bool IsSystem(int p_auth1) => (1 & p_auth1) > 0;

    public static bool IsAgent(int p_auth1) => (2 & p_auth1) > 0;

    public static bool IsManager(int p_auth1) => (4 & p_auth1) > 0 || (8 & p_auth1) > 0;

    public static bool IsAdmin(int p_auth1) => EmployeeConverter.IsSystem(p_auth1) || EmployeeConverter.IsAgent(p_auth1) || EmployeeConverter.IsManager(p_auth1);

    public static bool IsPermitPrint(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (16 & p_auth1) > 0;

    public static bool IsPermitExcel(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (32 & p_auth1) > 0;

    public static bool IsPermitSMS(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (64 & p_auth1) > 0;

    public static bool IsPermitEmail(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (128 & p_auth1) > 0;

    public static bool IsGoodsSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (256 & p_auth1) > 0;

    public static bool IsGoodsSavePriceExcept(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (512 & p_auth1) > 0;

    public static bool IsStoreInsert(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (1024 & p_auth1) > 0;

    public static bool IsStoreUpdate(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (2048 & p_auth1) > 0;

    public static bool IsEmployeeSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (4096 & p_auth1) > 0;

    public static bool IsEmployeePermitSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (8192 & p_auth1) > 0;

    public static bool IsMasterCommonSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (16384 & p_auth1) > 0;

    public static bool IsSupplierSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (32768 & p_auth1) > 0;

    public static bool IsSalesGoalSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (65536 & p_auth1) > 0;

    public static bool IsMemberTypeSave(int emp_permit1) => EmployeeConverter.IsAdmin(emp_permit1) || (131072 & emp_permit1) > 0;

    public static bool IsMemberStdSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (262144 & p_auth1) > 0;

    public static bool IsMemberTaxPublish(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (524288 & p_auth1) > 0;

    public static bool IsPaymentInput(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (2097152 & p_auth1) > 0;

    public static bool IsPaymentConfirm(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (4194304 & p_auth1) > 0;

    public static bool IsPaymentDelete(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (8388608 & p_auth1) > 0;

    public static bool IsPaymentClosed(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (16777216 & p_auth1) > 0;

    public static bool IsInvtClosed(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (33554432 & p_auth1) > 0;

    public static bool IsCampaignSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (67108864 & p_auth1) > 0;

    public static bool IsPromotionSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (134217728 & p_auth1) > 0;

    public static bool IsCouponSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (268435456 & p_auth1) > 0;

    public static bool IsProgMenuSave(int p_auth1) => EmployeeConverter.IsAdmin(p_auth1) || (301989888 & p_auth1) > 0;

    public static bool IsOrderInput(int p_auth2) => (1 & p_auth2) > 0;

    public static bool IsOrderConfirm(int p_auth2) => (2 & p_auth2) > 0;

    public static bool IsOrderDelete(int p_auth2) => (4 & p_auth2) > 0;

    public static bool IsOrderMove(int p_auth2) => (8 & p_auth2) > 0;

    public static bool IsBuyInput(int p_auth2) => (16 & p_auth2) > 0;

    public static bool IsBuyConfirm(int p_auth2) => (32 & p_auth2) > 0;

    public static bool IsBuyDelete(int p_auth2) => (64 & p_auth2) > 0;

    public static bool IsOuterMoveInput(int p_auth2) => (256 & p_auth2) > 0;

    public static bool IsOuterMoveConfirm(int p_auth2) => (512 & p_auth2) > 0;

    public static bool IsOuterMoveDelete(int p_auth2) => (1024 & p_auth2) > 0;

    public static bool IsInnerMoveInput(int p_auth2) => (4096 & p_auth2) > 0;

    public static bool IsInnerMoveConfirm(int p_auth2) => (8192 & p_auth2) > 0;

    public static bool IsInnerMoveDelete(int p_auth2) => (16384 & p_auth2) > 0;

    public static bool IsAdjustInput(int p_auth2) => (65536 & p_auth2) > 0;

    public static bool IsAdjustConfirm(int p_auth2) => (131072 & p_auth2) > 0;

    public static bool IsAdjustDelete(int p_auth2) => (262144 & p_auth2) > 0;

    public static bool IsDisuseInput(int p_auth2) => (1048576 & p_auth2) > 0;

    public static bool IsDisuseConfirm(int p_auth2) => (2097152 & p_auth2) > 0;

    public static bool IsDisuseDelete(int p_auth2) => (4194304 & p_auth2) > 0;

    public static bool IsStockInventoryInput(int p_auth2) => (16777216 & p_auth2) > 0;

    public static bool IsStockInventoryConfirm(int p_auth2) => (33554432 & p_auth2) > 0;

    public static bool IsStockInventoryDelete(int p_auth2) => (67108864 & p_auth2) > 0;

    public static bool IsAutoOrderSet(int p_auth2) => (134217728 & p_auth2) > 0;

    public static EnumEmpAuth1Fixed ToEmpAuth1Fixed(int p_value)
    {
      foreach (EnumEmpAuth1Fixed empAuth1Fixed in Enum.GetValues(typeof (EnumEmpAuth1Fixed)))
      {
        if (empAuth1Fixed == (EnumEmpAuth1Fixed) p_value)
          return empAuth1Fixed;
      }
      return EnumEmpAuth1Fixed.NONE;
    }

    public static bool IsAuth1Fixed(int p_comm_TypeNo) => EmployeeConverter.ToEmpAuth1Fixed(p_comm_TypeNo) != 0;

    public static EnumEmpAuth2Fixed ToEmpAuth2Fixed(int p_value)
    {
      foreach (EnumEmpAuth2Fixed empAuth2Fixed in Enum.GetValues(typeof (EnumEmpAuth2Fixed)))
      {
        if (empAuth2Fixed == (EnumEmpAuth2Fixed) p_value)
          return empAuth2Fixed;
      }
      return EnumEmpAuth2Fixed.NONE;
    }

    public static bool IsAuth2Fixed(int p_comm_TypeNo) => EmployeeConverter.ToEmpAuth2Fixed(p_comm_TypeNo) != 0;

    public static EnumEmpAuth3Fixed ToEmpAuth3Fixed(int p_value)
    {
      foreach (EnumEmpAuth3Fixed empAuth3Fixed in Enum.GetValues(typeof (EnumEmpAuth3Fixed)))
      {
        if (empAuth3Fixed == (EnumEmpAuth3Fixed) p_value)
          return empAuth3Fixed;
      }
      return EnumEmpAuth3Fixed.NONE;
    }

    public static bool IsAuth3Fixed(int p_comm_TypeNo) => EmployeeConverter.ToEmpAuth3Fixed(p_comm_TypeNo) != 0;

    public static bool IsEtcTypeFixed(int p_comm_Type) => Enum2StrConverter.ToCommonCodeFixed(p_comm_Type) != 0;
  }
}
