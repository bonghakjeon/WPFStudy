// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Summary.MemberDaySum.MemberDaySumCreate
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

namespace UniBiz.Bo.Models.UniMembers.Summary.MemberDaySum
{
  public class MemberDaySumCreate : TMemberDaySum, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MemberDaySumCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MemberDaySumCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberDaySum) + " mds_SysDate DATETIME NOT NULL,mds_MemberNo BIGINT NOT NULL,mds_StoreCode INT NOT NULL,mds_SiteID BIGINT NOT NULL DEFAULT(0),mds_TransCnt INT NOT NULL DEFAULT(0),mds_TotalSaleAmt MONEY NOT NULL DEFAULT(0.0000),mds_SaleAmt MONEY NOT NULL DEFAULT(0.0000),mds_PayCashTaxAmt MONEY NOT NULL DEFAULT(0.0000),mds_PayCashVatAmt MONEY NOT NULL DEFAULT(0.0000),mds_PayCashTaxFreeAmt MONEY NOT NULL DEFAULT(0.0000),mds_AddPoint INT NOT NULL DEFAULT(0),mds_UsePoint INT NOT NULL DEFAULT(0),mds_InDate DATETIME NULL,mds_InUser INT NOT NULL DEFAULT(0),mds_ModDate DATETIME NULL,mds_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mds_SysDate,mds_MemberNo,mds_StoreCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberDaySum) + " mds_SysDate DATETIME NOT NULL,mds_MemberNo BIGINT NOT NULL,mds_StoreCode INT NOT NULL,mds_SiteID BIGINT NOT NULL DEFAULT 0,mds_TransCnt INT NOT NULL DEFAULT 0,mds_TotalSaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mds_SaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mds_PayCashTaxAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mds_PayCashVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mds_PayCashTaxFreeAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mds_AddPoint INT NOT NULL DEFAULT 0,mds_UsePoint INT NOT NULL DEFAULT 0,mds_InDate DATETIME NULL,mds_InUser INT NOT NULL DEFAULT 0,mds_ModDate DATETIME NULL,mds_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mds_SysDate,mds_MemberNo,mds_StoreCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MemberDaySumCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.MemberDaySum.ToDescription(), (object) TableCodeType.MemberDaySum));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발생일시", (object) TableCodeType.MemberDaySum, (object) "mds_SysDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원코드", (object) TableCodeType.MemberDaySum, (object) "mds_MemberNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점코드", (object) TableCodeType.MemberDaySum, (object) "mds_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.MemberDaySum, (object) "mds_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "영수증건수", (object) TableCodeType.MemberDaySum, (object) "mds_TransCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "총매출금액", (object) TableCodeType.MemberDaySum, (object) "mds_TotalSaleAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "순매출금액", (object) TableCodeType.MemberDaySum, (object) "mds_SaleAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "현금결제과세금액", (object) TableCodeType.MemberDaySum, (object) "mds_PayCashTaxAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "현금결제부가세", (object) TableCodeType.MemberDaySum, (object) "mds_PayCashVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "현금결제면세금액", (object) TableCodeType.MemberDaySum, (object) "mds_PayCashTaxFreeAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립포인트", (object) TableCodeType.MemberDaySum, (object) "mds_AddPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용포인트", (object) TableCodeType.MemberDaySum, (object) "mds_UsePoint"));
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
        if (p_rs.IsFieldName("mds_SysDate"))
          this.mds_SysDate = p_rs.GetFieldDateTime("mds_SysDate");
        if (p_rs.IsFieldName("mds_MemberNo"))
          this.mds_MemberNo = p_rs.GetFieldLong("mds_MemberNo");
        if (p_rs.IsFieldName("mds_StoreCode"))
          this.mds_StoreCode = p_rs.GetFieldInt("mds_StoreCode");
        if (p_rs.IsFieldName("mds_SiteID"))
          this.mds_SiteID = p_rs.GetFieldLong("mds_SiteID");
        if (p_rs.IsFieldName("mds_TransCnt"))
          this.mds_TransCnt = p_rs.GetFieldInt("mds_TransCnt");
        if (p_rs.IsFieldName("mds_TotalSaleAmt"))
          this.mds_TotalSaleAmt = p_rs.GetFieldDouble("mds_TotalSaleAmt");
        if (p_rs.IsFieldName("mds_SaleAmt"))
          this.mds_SaleAmt = p_rs.GetFieldDouble("mds_SaleAmt");
        if (p_rs.IsFieldName("mds_PayCashTaxAmt"))
          this.mds_PayCashTaxAmt = p_rs.GetFieldDouble("mds_PayCashTaxAmt");
        if (p_rs.IsFieldName("mds_PayCashVatAmt"))
          this.mds_PayCashVatAmt = p_rs.GetFieldDouble("mds_PayCashVatAmt");
        if (p_rs.IsFieldName("mds_PayCashTaxFreeAmt"))
          this.mds_PayCashTaxFreeAmt = p_rs.GetFieldDouble("mds_PayCashTaxFreeAmt");
        if (p_rs.IsFieldName("mds_AddPoint"))
          this.mds_AddPoint = p_rs.GetFieldInt("mds_AddPoint");
        if (p_rs.IsFieldName("mds_UsePoint"))
          this.mds_UsePoint = p_rs.GetFieldInt("mds_UsePoint");
        if (p_rs.IsFieldName("mds_InDate"))
          this.mds_InDate = p_rs.GetFieldDateTime("mds_InDate");
        if (p_rs.IsFieldName("mds_InUser"))
          this.mds_InUser = p_rs.GetFieldInt("mds_InUser");
        if (p_rs.IsFieldName("mds_ModDate"))
          this.mds_ModDate = p_rs.GetFieldDateTime("mds_ModDate");
        if (p_rs.IsFieldName("mds_ModUser"))
          this.mds_ModUser = p_rs.GetFieldInt("mds_ModUser");
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
        IList<MemberDaySumCreate> memberDaySumCreateList = this.OleDB.Create<MemberDaySumCreate>().SelectAllListE<MemberDaySumCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (memberDaySumCreateList == null)
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
        int count = memberDaySumCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (memberDaySumCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.MemberDaySum.ToDescription(), (object) TableCodeType.MemberDaySum) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MemberDaySumCreate memberDaySumCreate in (IEnumerable<MemberDaySumCreate>) memberDaySumCreateList)
        {
          stringBuilder.Append(memberDaySumCreate.InsertQuery());
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
        if (memberDaySumCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.MemberDaySum.ToDescription(), (object) TableCodeType.MemberDaySum) + "\n--------------------------------------------------------------------------------------------------");
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
