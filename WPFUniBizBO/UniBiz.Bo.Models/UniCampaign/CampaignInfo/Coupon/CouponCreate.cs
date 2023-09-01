// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon.CouponCreate
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon
{
  public class CouponCreate : TCoupon, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = CouponCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = CouponCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_CAMPANIGN, (object) TableCodeType.Coupon) + " cp_GiftCardID BIGINT NOT NULL,cp_CouponID BIGINT NOT NULL,cp_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "cp_CouponType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "cp_Apply", (object) 0) + ",cp_EmpCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cp_Title", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cp_Url", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cp_Desc", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cp_LMSKey", (object) 20) + ",cp_IssueCnt INT NOT NULL DEFAULT(0),cp_UsableCnt INT NOT NULL DEFAULT(0),cp_CampaignCode BIGINT NOT NULL DEFAULT(0),cp_PromotionID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "cp_Status", (object) 0) + ",cp_ApprovalDate DATETIME NULL,cp_SendDate DATETIME NULL,cp_InDate DATETIME NULL,cp_InUser INT NOT NULL DEFAULT(0),cp_ModDate DATETIME NULL,cp_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(cp_GiftCardID,cp_CouponID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_CAMPANIGN, (object) TableCodeType.Coupon) + " cp_GiftCardID BIGINT NOT NULL,cp_CouponID BIGINT NOT NULL,cp_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "cp_CouponType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "cp_Apply", (object) 0) + ",cp_EmpCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cp_Title", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cp_Url", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cp_Desc", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cp_LMSKey", (object) 20) + ",cp_IssueCnt INT NOT NULL DEFAULT 0,cp_UsableCnt INT NOT NULL DEFAULT 0,cp_CampaignCode BIGINT NOT NULL DEFAULT 0,cp_PromotionID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "cp_Status", (object) 0) + ",cp_ApprovalDate DATETIME NULL,cp_SendDate DATETIME NULL,cp_InDate DATETIME NULL,cp_InUser INT NOT NULL DEFAULT 0,cp_ModDate DATETIME NULL,cp_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(cp_GiftCardID,cp_CouponID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(CouponCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_CAMPANIGN, (object) this.TableCode)))
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
        string str = "EXEC " + UbModelBase.UNI_CAMPANIGN + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Coupon.ToDescription(), (object) TableCodeType.Coupon));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품권코드", (object) TableCodeType.Coupon, (object) "cp_GiftCardID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "쿠폰ID", (object) TableCodeType.Coupon, (object) "cp_CouponID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Coupon, (object) "cp_SiteID"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "쿠폰구분", (object) 227, (object) TableCodeType.Coupon, (object) "cp_CouponType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "회원인증시 적용", (object) 228, (object) TableCodeType.Coupon, (object) "cp_Apply"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자코드", (object) TableCodeType.Coupon, (object) "cp_EmpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "타이틀", (object) TableCodeType.Coupon, (object) "cp_Title"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "디자인 URL", (object) TableCodeType.Coupon, (object) "cp_Url"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "설명", (object) TableCodeType.Coupon, (object) "cp_Desc"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "LMS전송키", (object) TableCodeType.Coupon, (object) "cp_LMSKey"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발급건수", (object) TableCodeType.Coupon, (object) "cp_IssueCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용가능횟수", (object) TableCodeType.Coupon, (object) "cp_UsableCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "캠페인코드", (object) TableCodeType.Coupon, (object) "cp_CampaignCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "프로모션ID", (object) TableCodeType.Coupon, (object) "cp_PromotionID"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "상태", (object) 229, (object) TableCodeType.Coupon, (object) "cp_Status"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "승인일시", (object) TableCodeType.Coupon, (object) "cp_ApprovalDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발송일시", (object) TableCodeType.Coupon, (object) "cp_SendDate"));
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
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("cp_GiftCardID"))
          this.cp_GiftCardID = p_rs.GetFieldLong("cp_GiftCardID");
        if (p_rs.IsFieldName("cp_CouponID"))
          this.cp_CouponID = p_rs.GetFieldLong("cp_CouponID");
        if (p_rs.IsFieldName("cp_SiteID"))
          this.cp_SiteID = p_rs.GetFieldLong("cp_SiteID");
        if (p_rs.IsFieldName("cp_CouponType"))
          this.cp_CouponType = p_rs.GetFieldInt("cp_CouponType");
        if (p_rs.IsFieldName("cp_Apply"))
          this.cp_Apply = p_rs.GetFieldInt("cp_Apply");
        if (p_rs.IsFieldName("cp_EmpCode"))
          this.cp_EmpCode = p_rs.GetFieldInt("cp_EmpCode");
        if (p_rs.IsFieldName("cp_Title"))
          this.cp_Title = p_rs.GetFieldString("cp_Title");
        if (p_rs.IsFieldName("cp_Url"))
          this.cp_Url = p_rs.GetFieldString("cp_Url");
        if (p_rs.IsFieldName("cp_Desc"))
          this.cp_Desc = p_rs.GetFieldString("cp_Desc");
        if (p_rs.IsFieldName("cp_LMSKey"))
          this.cp_LMSKey = p_rs.GetFieldString("cp_LMSKey");
        if (p_rs.IsFieldName("cp_IssueCnt"))
          this.cp_IssueCnt = p_rs.GetFieldInt("cp_IssueCnt");
        if (p_rs.IsFieldName("cp_UsableCnt"))
          this.cp_UsableCnt = p_rs.GetFieldInt("cp_UsableCnt");
        if (p_rs.IsFieldName("cp_CampaignCode"))
          this.cp_CampaignCode = p_rs.GetFieldLong("cp_CampaignCode");
        if (p_rs.IsFieldName("cp_PromotionID"))
          this.cp_PromotionID = p_rs.GetFieldLong("cp_PromotionID");
        if (p_rs.IsFieldName("cp_Status"))
          this.cp_Status = p_rs.GetFieldInt("cp_Status");
        if (p_rs.IsFieldName("cp_ApprovalDate"))
          this.cp_ApprovalDate = p_rs.GetFieldDateTime("cp_ApprovalDate");
        if (p_rs.IsFieldName("cp_SendDate"))
          this.cp_SendDate = p_rs.GetFieldDateTime("cp_SendDate");
        if (p_rs.IsFieldName("cp_InDate"))
          this.cp_InDate = p_rs.GetFieldDateTime("cp_InDate");
        if (p_rs.IsFieldName("cp_InUser"))
          this.cp_InUser = p_rs.GetFieldInt("cp_InUser");
        if (p_rs.IsFieldName("cp_ModDate"))
          this.cp_ModDate = p_rs.GetFieldDateTime("cp_ModDate");
        if (p_rs.IsFieldName("cp_ModUser"))
          this.cp_ModUser = p_rs.GetFieldInt("cp_ModUser");
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
        IList<CouponCreate> couponCreateList = this.OleDB.Create<CouponCreate>().SelectAllListE<CouponCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_CAMPANIGN
          }
        });
        if (couponCreateList == null)
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
        int count = couponCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (couponCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Coupon.ToDescription(), (object) TableCodeType.Coupon) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (CouponCreate couponCreate in (IEnumerable<CouponCreate>) couponCreateList)
        {
          stringBuilder.Append(couponCreate.InsertQuery());
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
        if (couponCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Coupon.ToDescription(), (object) TableCodeType.Coupon) + "\n--------------------------------------------------------------------------------------------------");
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
