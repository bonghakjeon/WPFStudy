// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.Member.MemberCreate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.Interface;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Info.Member
{
  public class MemberCreate : TMember, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MemberCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MemberCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.Member) + " mbr_MemberNo BIGINT NOT NULL,mbr_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_MemberName", (object) 100) + ",mbr_MemberType INT NOT NULL DEFAULT(1),mbr_MemberCycle INT NOT NULL DEFAULT(1),mbr_MemberGrade INT NOT NULL DEFAULT(1)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_GroupCode", (object) 10) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "mbr_Status", (object) 1) + ",mbr_TotalPoint INT NOT NULL DEFAULT(0),mbr_UsePoint INT NOT NULL DEFAULT(0),mbr_CurrentPoint INT NOT NULL DEFAULT(0),mbr_UsablePoint INT NOT NULL DEFAULT(0),mbr_ExtinctionPoint INT NOT NULL DEFAULT(0),mbr_PreSystemPoint INT NOT NULL DEFAULT(0),mbr_PointExtinctionAgree INT NOT NULL DEFAULT(0),mbr_PointExtinctionStartDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_PointUsePassword", (object) 200) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "mbr_CashReceiptDiv", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_CashReceiptAuthNo", (object) 200) + ",mbr_CreditLimitAmt MONEY NOT NULL DEFAULT(0.0),mbr_CreditAmt MONEY NOT NULL DEFAULT(0.0),mbr_RegStore INT NOT NULL DEFAULT(0),mbr_LastVisitStore INT NOT NULL DEFAULT(0),mbr_LastVisitDate DATETIME NULL" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "mbr_SmsSendAgree", (object) 1) + ",mbr_SmsFailCnt INT NOT NULL DEFAULT(0),mbr_LastSmsSendDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_ZipCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_Addr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_Addr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_TelNo", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_MobileNo", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_MobileNoEnc", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_Email", (object) 100) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "mbr_Gender", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "mbr_BirthType", (object) 1) + ",mbr_Birthday DATETIME NULL,mbr_Anniversary DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryZipCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryAddr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryAddr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryRecvName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryMobileNoEnc1", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryMobileNoEnc2", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryMemo", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_PosMsg", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_DeliveryMsg", (object) 100) + ",mbr_ExpireDate DATETIME NULL,mbr_Supplier INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_BizNo", (object) 15) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_BizName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_BizCeo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_BizType", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_BizCategory", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_TaxBillYn", (object) 1) + ",mbr_LastTaxBillDate DATETIME NULL,mbr_TaxBillCycle INT NOT NULL DEFAULT(0),mbr_BankCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_AccountNo", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_AccountName", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mbr_MemberEngName", (object) 50) + ",mbr_BuyCycle INT NOT NULL DEFAULT(999),mbr_InDate DATETIME NULL,mbr_InUser INT NOT NULL DEFAULT(0),mbr_ModDate DATETIME NULL,mbr_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mbr_MemberNo) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.Member) + " mbr_MemberNo BIGINT NOT NULL,mbr_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_MemberName", (object) 100) + ",mbr_MemberType INT NOT NULL DEFAULT 1,mbr_MemberCycle INT NOT NULL DEFAULT 1,mbr_MemberGrade INT NOT NULL DEFAULT 1" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_GroupCode", (object) 10) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "mbr_Status", (object) 1) + ",mbr_TotalPoint INT NOT NULL DEFAULT 0,mbr_UsePoint INT NOT NULL DEFAULT 0,mbr_CurrentPoint INT NOT NULL DEFAULT 0,mbr_UsablePoint INT NOT NULL DEFAULT 0,mbr_ExtinctionPoint INT NOT NULL DEFAULT 0,mbr_PreSystemPoint INT NOT NULL DEFAULT 0,mbr_PointExtinctionAgree INT NOT NULL DEFAULT 0,mbr_PointExtinctionStartDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_PointUsePassword", (object) 200) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "mbr_CashReceiptDiv", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_CashReceiptAuthNo", (object) 200) + ",mbr_CreditLimitAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,mbr_CreditAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,mbr_RegStore INT NOT NULL DEFAULT 0,mbr_LastVisitStore INT NOT NULL DEFAULT 0,mbr_LastVisitDate DATETIME NULL" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "mbr_SmsSendAgree", (object) 1) + ",mbr_SmsFailCnt INT NOT NULL DEFAULT 0,mbr_LastSmsSendDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_ZipCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_Addr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_Addr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_TelNo", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_MobileNo", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_MobileNoEnc", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_Email", (object) 100) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "mbr_Gender", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "mbr_BirthType", (object) 1) + ",mbr_Birthday DATETIME NULL,mbr_Anniversary DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryZipCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryAddr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryAddr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryRecvName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryMobileNoEnc1", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryMobileNoEnc2", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryMemo", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_PosMsg", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_DeliveryMsg", (object) 100) + ",mbr_ExpireDate DATETIME NULL,mbr_Supplier INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_BizNo", (object) 15) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_BizName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_BizCeo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_BizType", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_BizCategory", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_TaxBillYn", (object) 1) + ",mbr_LastTaxBillDate DATETIME NULL,mbr_TaxBillCycle INT NOT NULL DEFAULT 0,mbr_BankCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_AccountNo", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_AccountName", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mbr_MemberEngName", (object) 50) + ",mbr_BuyCycle INT NOT NULL DEFAULT 999,mbr_InDate DATETIME NULL,mbr_InUser INT NOT NULL DEFAULT 0,mbr_ModDate DATETIME NULL,mbr_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mbr_MemberNo) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MemberCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_MEMBERS, (object) this.TableCode)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool CreateTableComment(string p_db_category)
    {
      if (DbQueryHelper.DbTypeNotNull() != EnumDB.MSSQL)
        return true;
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string str = "EXEC " + UbModelBase.UNI_MEMBERS + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Member.ToDescription(), (object) TableCodeType.Member));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원코드", (object) TableCodeType.Member, (object) "mbr_MemberNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Member, (object) "mbr_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원유형", (object) TableCodeType.Member, (object) "mbr_MemberType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원명", (object) TableCodeType.Member, (object) "mbr_MemberName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "영문명", (object) TableCodeType.Member, (object) "mbr_MemberEngName"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "회원주기", (object) 186, (object) TableCodeType.Member, (object) "mbr_MemberCycle"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원등급", (object) TableCodeType.Member, (object) "mbr_MemberGrade"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원그룹", (object) TableCodeType.Member, (object) "mbr_GroupCode"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "상태", (object) 181, (object) TableCodeType.Member, (object) "mbr_Status"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "누적포인트", (object) TableCodeType.Member, (object) "mbr_TotalPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용포인트", (object) TableCodeType.Member, (object) "mbr_UsePoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "현재포인트", (object) TableCodeType.Member, (object) "mbr_CurrentPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "가용포인트", (object) TableCodeType.Member, (object) "mbr_UsablePoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "소멸포인트", (object) TableCodeType.Member, (object) "mbr_ExtinctionPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이전시스템포인트", (object) TableCodeType.Member, (object) "mbr_PreSystemPoint"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "포인트소멸동의", (object) 182, (object) TableCodeType.Member, (object) "mbr_PointExtinctionAgree"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "포인트소멸시작일", (object) TableCodeType.Member, (object) "mbr_PointExtinctionStartDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "포인트사용 비밀번호", (object) TableCodeType.Member, (object) "mbr_PointUsePassword"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "현금영수증구분", (object) 183, (object) TableCodeType.Member, (object) "mbr_CashReceiptDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "현금영수증인증번호", (object) TableCodeType.Member, (object) "mbr_CashReceiptAuthNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "외상한도", (object) TableCodeType.Member, (object) "mbr_CreditLimitAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "외상합계", (object) TableCodeType.Member, (object) "mbr_CreditAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "등록지점코드", (object) TableCodeType.Member, (object) "mbr_RegStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최종방문지점코드", (object) TableCodeType.Member, (object) "mbr_LastVisitStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최종방문일", (object) TableCodeType.Member, (object) "mbr_LastVisitDate"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "SMS 허용", (object) 184, (object) TableCodeType.Member, (object) "mbr_SmsSendAgree"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "SMS 실패수", (object) TableCodeType.Member, (object) "mbr_SmsFailCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최근SMS전송일", (object) TableCodeType.Member, (object) "mbr_LastSmsSendDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "우편번호", (object) TableCodeType.Member, (object) "mbr_ZipCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주소", (object) TableCodeType.Member, (object) "mbr_Addr1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주소 상세", (object) TableCodeType.Member, (object) "mbr_Addr2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "전화", (object) TableCodeType.Member, (object) "mbr_TelNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "모바일", (object) TableCodeType.Member, (object) "mbr_MobileNo"));
        stringBuilder.Append(string.Format("{0}{1} 암호화', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "모바일", (object) TableCodeType.Member, (object) "mbr_MobileNoEnc"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이메일", (object) TableCodeType.Member, (object) "mbr_Email"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "성별", (object) 100, (object) TableCodeType.Member, (object) "mbr_Gender"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "양/음력", (object) 101, (object) TableCodeType.Member, (object) "mbr_BirthType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "생년월일", (object) TableCodeType.Member, (object) "mbr_Birthday"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "기념일", (object) TableCodeType.Member, (object) "mbr_Anniversary"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배송지우편번호", (object) TableCodeType.Member, (object) "mbr_DeliveryZipCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배송지주소", (object) TableCodeType.Member, (object) "mbr_DeliveryAddr1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배송지상세", (object) TableCodeType.Member, (object) "mbr_DeliveryAddr2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "수취인명", (object) TableCodeType.Member, (object) "mbr_DeliveryRecvName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "모바일", (object) TableCodeType.Member, (object) "mbr_DeliveryMobileNoEnc1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "모바일", (object) TableCodeType.Member, (object) "mbr_DeliveryMobileNoEnc2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배송메모", (object) TableCodeType.Member, (object) "mbr_DeliveryMemo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "포스안내메세지", (object) TableCodeType.Member, (object) "mbr_PosMsg"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배달영수증메세지", (object) TableCodeType.Member, (object) "mbr_DeliveryMsg"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "유료회원만료일", (object) TableCodeType.Member, (object) "mbr_ExpireDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "외상거래처", (object) TableCodeType.Member, (object) "mbr_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사업자번호", (object) TableCodeType.Member, (object) "mbr_BizNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사업자명", (object) TableCodeType.Member, (object) "mbr_BizName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "대표자", (object) TableCodeType.Member, (object) "mbr_BizCeo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업태", (object) TableCodeType.Member, (object) "mbr_BizType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업종", (object) TableCodeType.Member, (object) "mbr_BizCategory"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "계산서발행여부", (object) TableCodeType.Member, (object) "mbr_TaxBillYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최근계산서발행일", (object) TableCodeType.Member, (object) "mbr_LastTaxBillDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "계산서발행주기", (object) TableCodeType.Member, (object) "mbr_TaxBillCycle"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "은행", (object) TableCodeType.Member, (object) "mbr_BankCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "계좌번호", (object) TableCodeType.Member, (object) "mbr_AccountNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "예금주명", (object) TableCodeType.Member, (object) "mbr_AccountName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "구매주기", (object) TableCodeType.Member, (object) "mbr_BuyCycle"));
        if (this.OleDB.Execute(stringBuilder.ToString()))
          return true;
        this.message = " " + this.TableCode.ToDescription() + " 주석 Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.DebugColor(this.message);
        return false;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return false;
    }

    public bool InitTable() => this.InitTable(1L);

    public bool InitTable(long pSiteID)
    {
      if (pSiteID == 0L)
        pSiteID = 1L;
      MemberView memberView = this.OleDB.Create<MemberView>();
      if (pSiteID == 1L)
      {
        memberView.mbr_SiteID = pSiteID;
        memberView.mbr_MemberName = "미등록";
        this.OleDB.Execute(memberView.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("mbr_MemberNo"))
          this.mbr_MemberNo = p_rs.GetFieldLong("mbr_MemberNo");
        if (p_rs.IsFieldName("mbr_SiteID"))
          this.mbr_SiteID = p_rs.GetFieldLong("mbr_SiteID");
        if (p_rs.IsFieldName("mbr_MemberType"))
          this.mbr_MemberType = p_rs.GetFieldInt("mbr_MemberType");
        if (p_rs.IsFieldName("mbr_MemberName"))
          this.mbr_MemberName = p_rs.GetFieldString("mbr_MemberName");
        if (p_rs.IsFieldName("mbr_MemberEngName"))
          this.mbr_MemberEngName = p_rs.GetFieldString("mbr_MemberEngName");
        if (p_rs.IsFieldName("mbr_MemberCycle"))
          this.mbr_MemberCycle = p_rs.GetFieldInt("mbr_MemberCycle");
        if (p_rs.IsFieldName("mbr_GroupCode"))
          this.mbr_GroupCode = p_rs.GetFieldString("mbr_GroupCode");
        if (p_rs.IsFieldName("mbr_Status"))
          this.mbr_Status = p_rs.GetFieldInt("mbr_Status");
        if (p_rs.IsFieldName("mbr_TotalPoint"))
          this.mbr_TotalPoint = p_rs.GetFieldInt("mbr_TotalPoint");
        if (p_rs.IsFieldName("mbr_UsePoint"))
          this.mbr_UsePoint = p_rs.GetFieldInt("mbr_UsePoint");
        if (p_rs.IsFieldName("mbr_CurrentPoint"))
          this.mbr_CurrentPoint = p_rs.GetFieldInt("mbr_CurrentPoint");
        if (p_rs.IsFieldName("mbr_UsablePoint"))
          this.mbr_UsablePoint = p_rs.GetFieldInt("mbr_UsablePoint");
        if (p_rs.IsFieldName("mbr_ExtinctionPoint"))
          this.mbr_ExtinctionPoint = p_rs.GetFieldInt("mbr_ExtinctionPoint");
        if (p_rs.IsFieldName("mbr_PreSystemPoint"))
          this.mbr_PreSystemPoint = p_rs.GetFieldInt("mbr_PreSystemPoint");
        if (p_rs.IsFieldName("mbr_PointExtinctionAgree"))
          this.mbr_PointExtinctionAgree = p_rs.GetFieldInt("mbr_PointExtinctionAgree");
        if (p_rs.IsFieldName("mbr_PointExtinctionStartDate"))
          this.mbr_PointExtinctionStartDate = p_rs.GetFieldDateTime("mbr_PointExtinctionStartDate");
        if (p_rs.IsFieldName("mbr_PointUsePassword"))
          this.mbr_PointUsePassword = p_rs.GetFieldString("mbr_PointUsePassword");
        if (p_rs.IsFieldName("mbr_CashReceiptDiv"))
          this.mbr_CashReceiptDiv = p_rs.GetFieldInt("mbr_CashReceiptDiv");
        if (p_rs.IsFieldName("mbr_CashReceiptAuthNo"))
          this.mbr_CashReceiptAuthNo = p_rs.GetFieldString("mbr_CashReceiptAuthNo");
        if (p_rs.IsFieldName("mbr_CreditLimitAmt"))
          this.mbr_CreditLimitAmt = p_rs.GetFieldDouble("mbr_CreditLimitAmt");
        if (p_rs.IsFieldName("mbr_CreditAmt"))
          this.mbr_CreditAmt = p_rs.GetFieldDouble("mbr_CreditAmt");
        if (p_rs.IsFieldName("mbr_RegStore"))
          this.mbr_RegStore = p_rs.GetFieldInt("mbr_RegStore");
        if (p_rs.IsFieldName("mbr_LastVisitStore"))
          this.mbr_LastVisitStore = p_rs.GetFieldInt("mbr_LastVisitStore");
        if (p_rs.IsFieldName("mbr_LastVisitDate"))
          this.mbr_LastVisitDate = p_rs.GetFieldDateTime("mbr_LastVisitDate");
        if (p_rs.IsFieldName("mbr_SmsSendAgree"))
          this.mbr_SmsSendAgree = p_rs.GetFieldInt("mbr_SmsSendAgree");
        if (p_rs.IsFieldName("mbr_SmsFailCnt"))
          this.mbr_SmsFailCnt = p_rs.GetFieldInt("mbr_SmsFailCnt");
        if (p_rs.IsFieldName("mbr_LastSmsSendDate"))
          this.mbr_LastSmsSendDate = p_rs.GetFieldDateTime("mbr_LastSmsSendDate");
        if (p_rs.IsFieldName("mbr_ZipCode"))
          this.mbr_ZipCode = p_rs.GetFieldString("mbr_ZipCode");
        if (p_rs.IsFieldName("mbr_Addr1"))
          this.mbr_Addr1 = p_rs.GetFieldString("mbr_Addr1");
        if (p_rs.IsFieldName("mbr_Addr2"))
          this.mbr_Addr2 = p_rs.GetFieldString("mbr_Addr2");
        if (p_rs.IsFieldName("mbr_TelNo"))
          this.mbr_TelNo = p_rs.GetFieldString("mbr_TelNo");
        if (p_rs.IsFieldName("mbr_MobileNo"))
          this.mbr_MobileNo = p_rs.GetFieldString("mbr_MobileNo");
        if (p_rs.IsFieldName("mbr_MobileNoEnc"))
          this.mbr_MobileNoEnc = p_rs.GetFieldString("mbr_MobileNoEnc");
        if (p_rs.IsFieldName("mbr_Email"))
          this.mbr_Email = p_rs.GetFieldString("mbr_Email");
        if (p_rs.IsFieldName("mbr_Gender"))
          this.mbr_Gender = p_rs.GetFieldInt("mbr_Gender");
        if (p_rs.IsFieldName("mbr_BirthType"))
          this.mbr_BirthType = p_rs.GetFieldInt("mbr_BirthType");
        if (p_rs.IsFieldName("mbr_Birthday"))
          this.mbr_Birthday = p_rs.GetFieldDateTime("mbr_Birthday");
        if (p_rs.IsFieldName("mbr_Anniversary"))
          this.mbr_Anniversary = p_rs.GetFieldDateTime("mbr_Anniversary");
        if (p_rs.IsFieldName("mbr_DeliveryZipCode"))
          this.mbr_DeliveryZipCode = p_rs.GetFieldString("mbr_DeliveryZipCode");
        if (p_rs.IsFieldName("mbr_DeliveryAddr1"))
          this.mbr_DeliveryAddr1 = p_rs.GetFieldString("mbr_DeliveryAddr1");
        if (p_rs.IsFieldName("mbr_DeliveryAddr2"))
          this.mbr_DeliveryAddr2 = p_rs.GetFieldString("mbr_DeliveryAddr2");
        if (p_rs.IsFieldName("mbr_DeliveryRecvName"))
          this.mbr_DeliveryRecvName = p_rs.GetFieldString("mbr_DeliveryRecvName");
        if (p_rs.IsFieldName("mbr_DeliveryMobileNoEnc1"))
          this.mbr_DeliveryMobileNoEnc1 = p_rs.GetFieldString("mbr_DeliveryMobileNoEnc1");
        if (p_rs.IsFieldName("mbr_DeliveryMobileNoEnc2"))
          this.mbr_DeliveryMobileNoEnc2 = p_rs.GetFieldString("mbr_DeliveryMobileNoEnc2");
        if (p_rs.IsFieldName("mbr_DeliveryMemo"))
          this.mbr_DeliveryMemo = p_rs.GetFieldString("mbr_DeliveryMemo");
        if (p_rs.IsFieldName("mbr_PosMsg"))
          this.mbr_PosMsg = p_rs.GetFieldString("mbr_PosMsg");
        if (p_rs.IsFieldName("mbr_DeliveryMsg"))
          this.mbr_DeliveryMsg = p_rs.GetFieldString("mbr_DeliveryMsg");
        if (p_rs.IsFieldName("mbr_ExpireDate"))
          this.mbr_ExpireDate = p_rs.GetFieldDateTime("mbr_ExpireDate");
        if (p_rs.IsFieldName("mbr_Supplier"))
          this.mbr_Supplier = p_rs.GetFieldInt("mbr_Supplier");
        if (p_rs.IsFieldName("mbr_BizNo"))
          this.mbr_BizNo = p_rs.GetFieldString("mbr_BizNo");
        if (p_rs.IsFieldName("mbr_BizName"))
          this.mbr_BizName = p_rs.GetFieldString("mbr_BizName");
        if (p_rs.IsFieldName("mbr_BizCeo"))
          this.mbr_BizCeo = p_rs.GetFieldString("mbr_BizCeo");
        if (p_rs.IsFieldName("mbr_BizType"))
          this.mbr_BizType = p_rs.GetFieldString("mbr_BizType");
        if (p_rs.IsFieldName("mbr_BizCategory"))
          this.mbr_BizCategory = p_rs.GetFieldString("mbr_BizCategory");
        if (p_rs.IsFieldName("mbr_TaxBillYn"))
          this.mbr_TaxBillYn = p_rs.GetFieldString("mbr_TaxBillYn");
        if (p_rs.IsFieldName("mbr_LastTaxBillDate"))
          this.mbr_LastTaxBillDate = p_rs.GetFieldDateTime("mbr_LastTaxBillDate");
        if (p_rs.IsFieldName("mbr_TaxBillCycle"))
          this.mbr_TaxBillCycle = p_rs.GetFieldInt("mbr_TaxBillCycle");
        if (p_rs.IsFieldName("mbr_BankCode"))
          this.mbr_BankCode = p_rs.GetFieldInt("mbr_BankCode");
        if (p_rs.IsFieldName("mbr_AccountNo"))
          this.mbr_AccountNo = p_rs.GetFieldString("mbr_AccountNo");
        if (p_rs.IsFieldName("mbr_AccountName"))
          this.mbr_AccountName = p_rs.GetFieldString("mbr_AccountName");
        if (p_rs.IsFieldName("mbr_BuyCycle"))
          this.mbr_BuyCycle = p_rs.GetFieldInt("mbr_BuyCycle");
        if (p_rs.IsFieldName("mbr_InDate"))
          this.mbr_InDate = p_rs.GetFieldDateTime("mbr_InDate");
        if (p_rs.IsFieldName("mbr_InUser"))
          this.mbr_InUser = p_rs.GetFieldInt("mbr_InUser");
        if (p_rs.IsFieldName("mbr_ModDate"))
          this.mbr_ModDate = p_rs.GetFieldDateTime("mbr_ModDate");
        if (p_rs.IsFieldName("mbr_ModUser"))
          this.mbr_ModUser = p_rs.GetFieldInt("mbr_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public bool ReCreateTable()
    {
      try
      {
        IList<MemberCreate> memberCreateList = this.OleDB.Create<MemberCreate>().SelectAllListE<MemberCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (memberCreateList == null)
        {
          this.message = " " + this.TableCode.ToDescription() + " SELECT AND Serialize 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.DropTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Drop 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Create 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTableComment(string.Empty))
        {
          this.message = " " + this.TableCode.ToDescription() + " Create Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        int count = memberCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (memberCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Member.ToDescription(), (object) TableCodeType.Member) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MemberCreate memberCreate in (IEnumerable<MemberCreate>) memberCreateList)
        {
          stringBuilder.Append(memberCreate.InsertQuery());
          if (stringBuilder.Length > 4000)
          {
            if (!this.OleDB.Execute(stringBuilder.ToString()))
            {
              this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
              throw new Exception();
            }
            stringBuilder.Clear();
          }
          ++num1;
          num2 = num1 * 100 / count;
          if (num3 != num2)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num2));
            num3 = num2;
          }
        }
        if (stringBuilder.Length > 0)
        {
          if (!this.OleDB.Execute(stringBuilder.ToString()))
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          stringBuilder.Clear();
        }
        TMember tmember = this.OleDB.Create<TMember>();
        tmember.mbr_SiteID = 1L;
        tmember.mbr_MemberName = "미등록";
        tmember.UpdateExInsert();
        if (memberCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Member.ToDescription(), (object) TableCodeType.Member) + "\n--------------------------------------------------------------------------------------------------");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.DebugColor(this.message);
        return false;
      }
      return true;
    }
  }
}
