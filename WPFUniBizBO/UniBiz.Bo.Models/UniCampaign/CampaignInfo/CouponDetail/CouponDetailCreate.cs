// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail.CouponDetailCreate
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail
{
  public class CouponDetailCreate : TCouponDetail, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = CouponDetailCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = CouponDetailCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_CAMPANIGN, (object) TableCodeType.CouponDetail) + string.Format(" {0} VARCHAR({1}) NOT NULL", (object) "cpd_CouponNo", (object) 20) + ",cpd_GiftCardID BIGINT NOT NULL,cpd_CouponID BIGINT NOT NULL,cpd_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "cpd_ApplyDiv", (object) 0) + ",cpd_MemberNo BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cpd_MobileNo", (object) 100) + ",cpd_UseCnt INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "cpd_StopYn", (object) 1, (object) "N") + ",cpd_InDate DATETIME NULL,cpd_InUser INT NOT NULL DEFAULT(0),cpd_ModDate DATETIME NULL,cpd_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(cpd_CouponNo,cpd_GiftCardID,cpd_CouponID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_CAMPANIGN, (object) TableCodeType.CouponDetail) + string.Format(" {0} VARCHAR({1}) NOT NULL", (object) "cpd_CouponNo", (object) 20) + ",cpd_GiftCardID BIGINT NOT NULL,cpd_CouponID BIGINT NOT NULL,cpd_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "cpd_ApplyDiv", (object) 0) + ",cpd_MemberNo BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cpd_MobileNo", (object) 100) + ",cpd_UseCnt INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "cpd_StopYn", (object) 1, (object) "N") + ",cpd_InDate DATETIME NULL,cpd_InUser INT NOT NULL DEFAULT 0,cpd_ModDate DATETIME NULL,cpd_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(cpd_CouponNo,cpd_GiftCardID,cpd_CouponID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(CouponDetailCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.CouponDetail.ToDescription(), (object) TableCodeType.CouponDetail));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "쿠폰번호", (object) TableCodeType.CouponDetail, (object) "cpd_CouponNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품권코드", (object) TableCodeType.CouponDetail, (object) "cpd_GiftCardID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "쿠폰ID", (object) TableCodeType.CouponDetail, (object) "cpd_CouponID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.CouponDetail, (object) "cpd_SiteID"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "적용구분", (object) 230, (object) TableCodeType.CouponDetail, (object) "cpd_ApplyDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원(회원유형)", (object) TableCodeType.CouponDetail, (object) "cpd_MemberNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "휴대폰번호", (object) TableCodeType.CouponDetail, (object) "cpd_MobileNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용횟수", (object) TableCodeType.CouponDetail, (object) "cpd_UseCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "중지여부", (object) TableCodeType.CouponDetail, (object) "cpd_StopYn"));
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
        if (p_rs.IsFieldName("cpd_CouponNo"))
          this.cpd_CouponNo = p_rs.GetFieldString("cpd_CouponNo");
        if (p_rs.IsFieldName("cpd_GiftCardID"))
          this.cpd_GiftCardID = p_rs.GetFieldLong("cpd_GiftCardID");
        if (p_rs.IsFieldName("cpd_CouponID"))
          this.cpd_CouponID = p_rs.GetFieldLong("cpd_CouponID");
        if (p_rs.IsFieldName("cpd_SiteID"))
          this.cpd_SiteID = p_rs.GetFieldLong("cpd_SiteID");
        if (p_rs.IsFieldName("cpd_ApplyDiv"))
          this.cpd_ApplyDiv = p_rs.GetFieldInt("cpd_ApplyDiv");
        if (p_rs.IsFieldName("cpd_MemberNo"))
          this.cpd_MemberNo = (long) p_rs.GetFieldInt("cpd_MemberNo");
        if (p_rs.IsFieldName("cpd_MobileNo"))
          this.cpd_MobileNo = p_rs.GetFieldString("cpd_MobileNo");
        if (p_rs.IsFieldName("cpd_UseCnt"))
          this.cpd_UseCnt = p_rs.GetFieldInt("cpd_UseCnt");
        if (p_rs.IsFieldName("cpd_StopYn"))
          this.cpd_StopYn = p_rs.GetFieldString("cpd_StopYn");
        if (p_rs.IsFieldName("cpd_InDate"))
          this.cpd_InDate = p_rs.GetFieldDateTime("cpd_InDate");
        if (p_rs.IsFieldName("cpd_InUser"))
          this.cpd_InUser = p_rs.GetFieldInt("cpd_InUser");
        if (p_rs.IsFieldName("cpd_ModDate"))
          this.cpd_ModDate = p_rs.GetFieldDateTime("cpd_ModDate");
        if (p_rs.IsFieldName("cpd_ModUser"))
          this.cpd_ModUser = p_rs.GetFieldInt("cpd_ModUser");
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
        IList<CouponDetailCreate> couponDetailCreateList = this.OleDB.Create<CouponDetailCreate>().SelectAllListE<CouponDetailCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_CAMPANIGN
          }
        });
        if (couponDetailCreateList == null)
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
        int count = couponDetailCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (couponDetailCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.CouponDetail.ToDescription(), (object) TableCodeType.CouponDetail) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (CouponDetailCreate couponDetailCreate in (IEnumerable<CouponDetailCreate>) couponDetailCreateList)
        {
          stringBuilder.Append(couponDetailCreate.InsertQuery());
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
        if (couponDetailCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.CouponDetail.ToDescription(), (object) TableCodeType.CouponDetail) + "\n--------------------------------------------------------------------------------------------------");
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
