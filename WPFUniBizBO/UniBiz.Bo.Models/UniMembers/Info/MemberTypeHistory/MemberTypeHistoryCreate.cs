// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory.MemberTypeHistoryCreate
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory
{
  public class MemberTypeHistoryCreate : TMemberTypeHistory, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MemberTypeHistoryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MemberTypeHistoryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberTypeHistory) + " mth_StoreCode INT NOT NULL,mth_TypeCode INT NOT NULL,mth_StartDate DATETIME NOT NULL,mth_SiteID BIGINT NOT NULL DEFAULT(0),mth_EndDate DATETIME NOT NULL,mth_MemberPrice INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "mth_CreditYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "mth_PointAddYn", (object) 1, (object) "Y") + ",mth_EnurySlipRate MONEY NOT NULL DEFAULT(0.0000),mth_EnurySlipStdAmt MONEY NOT NULL DEFAULT(0.0000),mth_PointRateCash MONEY NOT NULL DEFAULT(0.0000),mth_PointRateCard MONEY NOT NULL DEFAULT(0.0000),mth_PointRateInnerGift MONEY NOT NULL DEFAULT(0.0000),mth_PointRateOuterGift MONEY NOT NULL DEFAULT(0.0000),mth_PointRatePoint MONEY NOT NULL DEFAULT(0.0000),mth_PointRateCredit MONEY NOT NULL DEFAULT(0.0000),mth_PointRateSocial MONEY NOT NULL DEFAULT(0.0000),mth_PointRateEtc MONEY NOT NULL DEFAULT(0.0000),mth_InDate DATETIME NULL,mth_InUser INT NOT NULL DEFAULT(0),mth_ModDate DATETIME NULL,mth_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mth_StoreCode,mth_TypeCode,mth_StartDate) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberTypeHistory) + " mth_StoreCode INT NOT NULL,mth_TypeCode INT NOT NULL,mth_StartDate DATETIME NOT NULL,mth_SiteID BIGINT NOT NULL DEFAULT 0,mth_EndDate DATETIME NOT NULL,mth_MemberPrice INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "mth_CreditYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "mth_PointAddYn", (object) 1, (object) "Y") + ",mth_EnurySlipRate DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_EnurySlipStdAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateCash DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateCard DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateInnerGift DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateOuterGift DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRatePoint DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateCredit DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateSocial DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_PointRateEtc DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mth_InDate DATETIME NULL,mth_InUser INT NOT NULL DEFAULT 0,mth_ModDate DATETIME NULL,mth_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mth_StoreCode,mth_TypeCode,mth_StartDate) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MemberTypeHistoryCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.MemberTypeHistory.ToDescription(), (object) TableCodeType.MemberTypeHistory));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점", (object) TableCodeType.MemberTypeHistory, (object) "mth_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원유형코드", (object) TableCodeType.MemberTypeHistory, (object) "mth_TypeCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "시작일", (object) TableCodeType.MemberTypeHistory, (object) "mth_StartDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.MemberTypeHistory, (object) "mth_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "종료일", (object) TableCodeType.MemberTypeHistory, (object) "mth_EndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원가적용", (object) TableCodeType.MemberTypeHistory, (object) "mth_MemberPrice"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "외상가능여부", (object) TableCodeType.MemberTypeHistory, (object) "mth_CreditYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립율사용여부", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointAddYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "현금적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateCash"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "카드적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateCard"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "자사상품권적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateInnerGift"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "타사상품권적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateOuterGift"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "포인트사용적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRatePoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "외상적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateCredit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "소셜/Pay적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateSocial"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "기타적립율", (object) TableCodeType.MemberTypeHistory, (object) "mth_PointRateEtc"));
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
        if (p_rs.IsFieldName("mth_StoreCode"))
          this.mth_StoreCode = p_rs.GetFieldInt("mth_StoreCode");
        if (p_rs.IsFieldName("mth_TypeCode"))
          this.mth_TypeCode = p_rs.GetFieldInt("mth_TypeCode");
        if (p_rs.IsFieldName("mth_StartDate"))
          this.mth_StartDate = p_rs.GetFieldDateTime("mth_StartDate");
        if (p_rs.IsFieldName("mth_SiteID"))
          this.mth_SiteID = p_rs.GetFieldLong("mth_SiteID");
        if (p_rs.IsFieldName("mth_EndDate"))
          this.mth_EndDate = p_rs.GetFieldDateTime("mth_EndDate");
        if (p_rs.IsFieldName("mth_MemberPrice"))
          this.mth_MemberPrice = p_rs.GetFieldInt("mth_MemberPrice");
        if (p_rs.IsFieldName("mth_CreditYn"))
          this.mth_CreditYn = p_rs.GetFieldString("mth_CreditYn");
        if (p_rs.IsFieldName("mth_PointAddYn"))
          this.mth_PointAddYn = p_rs.GetFieldString("mth_PointAddYn");
        if (p_rs.IsFieldName("mth_EnurySlipRate"))
          this.mth_EnurySlipRate = p_rs.GetFieldDouble("mth_EnurySlipRate");
        if (p_rs.IsFieldName("mth_EnurySlipStdAmt"))
          this.mth_EnurySlipStdAmt = p_rs.GetFieldDouble("mth_EnurySlipStdAmt");
        if (p_rs.IsFieldName("mth_PointRateCash"))
          this.mth_PointRateCash = p_rs.GetFieldDouble("mth_PointRateCash");
        if (p_rs.IsFieldName("mth_PointRateCard"))
          this.mth_PointRateCard = p_rs.GetFieldDouble("mth_PointRateCard");
        if (p_rs.IsFieldName("mth_PointRateInnerGift"))
          this.mth_PointRateInnerGift = p_rs.GetFieldDouble("mth_PointRateInnerGift");
        if (p_rs.IsFieldName("mth_PointRateOuterGift"))
          this.mth_PointRateOuterGift = p_rs.GetFieldDouble("mth_PointRateOuterGift");
        if (p_rs.IsFieldName("mth_PointRatePoint"))
          this.mth_PointRatePoint = p_rs.GetFieldDouble("mth_PointRatePoint");
        if (p_rs.IsFieldName("mth_PointRateCredit"))
          this.mth_PointRateCredit = p_rs.GetFieldDouble("mth_PointRateCredit");
        if (p_rs.IsFieldName("mth_PointRateSocial"))
          this.mth_PointRateSocial = p_rs.GetFieldDouble("mth_PointRateSocial");
        if (p_rs.IsFieldName("mth_PointRateEtc"))
          this.mth_PointRateEtc = p_rs.GetFieldDouble("mth_PointRateEtc");
        if (p_rs.IsFieldName("mth_InDate"))
          this.mth_InDate = p_rs.GetFieldDateTime("mth_InDate");
        if (p_rs.IsFieldName("mth_InUser"))
          this.mth_InUser = p_rs.GetFieldInt("mth_InUser");
        if (p_rs.IsFieldName("mth_ModDate"))
          this.mth_ModDate = p_rs.GetFieldDateTime("mth_ModDate");
        if (p_rs.IsFieldName("mth_ModUser"))
          this.mth_ModUser = p_rs.GetFieldInt("mth_ModUser");
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
        IList<MemberTypeHistoryCreate> typeHistoryCreateList = this.OleDB.Create<MemberTypeHistoryCreate>().SelectAllListE<MemberTypeHistoryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (typeHistoryCreateList == null)
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
        int count = typeHistoryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (typeHistoryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.MemberTypeHistory.ToDescription(), (object) TableCodeType.MemberTypeHistory) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MemberTypeHistoryCreate typeHistoryCreate in (IEnumerable<MemberTypeHistoryCreate>) typeHistoryCreateList)
        {
          stringBuilder.Append(typeHistoryCreate.InsertQuery());
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
        if (typeHistoryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.MemberTypeHistory.ToDescription(), (object) TableCodeType.MemberTypeHistory) + "\n--------------------------------------------------------------------------------------------------");
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
