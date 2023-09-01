// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory.GoodsHistoryCreate
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory
{
  public class GoodsHistoryCreate : TGoodsHistory, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = GoodsHistoryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = GoodsHistoryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " gdh_StoreCode INT NOT NULL,gdh_GoodsCode BIGINT NOT NULL,gdh_StartDate DATETIME NOT NULL,gdh_SiteID BIGINT NOT NULL DEFAULT(0),gdh_EndDate DATETIME NOT NULL,gdh_GoodsCategory INT NOT NULL DEFAULT(0),gdh_Supplier INT NOT NULL DEFAULT(0),gdh_ChargeRate MONEY NOT NULL DEFAULT(0.0000),gdh_BuyCost MONEY NOT NULL DEFAULT(0.0000),gdh_BuyVat MONEY NOT NULL DEFAULT(0.0000),gdh_SalePrice MONEY NOT NULL DEFAULT(0.0000),gdh_EventCost MONEY NOT NULL DEFAULT(0.0000),gdh_EventVat MONEY NOT NULL DEFAULT(0.0000),gdh_EventPrice MONEY NOT NULL DEFAULT(0.0000),gdh_MemberPrice1 MONEY NOT NULL DEFAULT(0.0000),gdh_MemberPrice2 MONEY NOT NULL DEFAULT(0.0000),gdh_MemberPrice3 MONEY NOT NULL DEFAULT(0.0000),gdh_PointRate MONEY NOT NULL DEFAULT(0.0000),gdh_InDate DATETIME NULL,gdh_InUser INT NOT NULL DEFAULT(0),gdh_ModDate DATETIME NULL,gdh_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(gdh_StoreCode,gdh_GoodsCode,gdh_StartDate) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " gdh_StoreCode INT NOT NULL,gdh_GoodsCode BIGINT NOT NULL,gdh_StartDate DATETIME NOT NULL,gdh_SiteID BIGINT NOT NULL DEFAULT 0,gdh_EndDate DATETIME NOT NULL,gdh_GoodsCategory INT NOT NULL DEFAULT 0,gdh_Supplier INT NOT NULL DEFAULT 0,gdh_ChargeRate DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_BuyCost DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_BuyVat DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_SalePrice DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_EventCost DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_EventVat DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_EventPrice DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_MemberPrice1 DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_MemberPrice2 DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_MemberPrice3 DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_PointRate DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdh_InDate DATETIME NULL,gdh_InUser INT NOT NULL DEFAULT 0,gdh_ModDate DATETIME NULL,gdh_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(gdh_StoreCode,gdh_GoodsCode,gdh_StartDate) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(GoodsHistoryCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_BASE, (object) this.TableCode)))
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
        string str = "EXEC " + UbModelBase.UNI_BASE + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.GoodsHistory.ToDescription(), (object) TableCodeType.GoodsHistory));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점코드", (object) TableCodeType.GoodsHistory, (object) "gdh_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품코드", (object) TableCodeType.GoodsHistory, (object) "gdh_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "시작일", (object) TableCodeType.GoodsHistory, (object) "gdh_StartDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.GoodsHistory, (object) "gdh_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "종료일", (object) TableCodeType.GoodsHistory, (object) "gdh_EndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "소분류", (object) TableCodeType.GoodsHistory, (object) "gdh_GoodsCategory"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업체", (object) TableCodeType.GoodsHistory, (object) "gdh_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "수수료율", (object) TableCodeType.GoodsHistory, (object) "gdh_ChargeRate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "매입원가", (object) TableCodeType.GoodsHistory, (object) "gdh_BuyCost"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "매입VAT", (object) TableCodeType.GoodsHistory, (object) "gdh_BuyVat"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매가", (object) TableCodeType.GoodsHistory, (object) "gdh_SalePrice"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "행사원가", (object) TableCodeType.GoodsHistory, (object) "gdh_EventCost"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "행사VAT", (object) TableCodeType.GoodsHistory, (object) "gdh_EventVat"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "행사판매가", (object) TableCodeType.GoodsHistory, (object) "gdh_EventPrice"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원가", (object) TableCodeType.GoodsHistory, (object) "gdh_MemberPrice1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원가2", (object) TableCodeType.GoodsHistory, (object) "gdh_MemberPrice2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원가3", (object) TableCodeType.GoodsHistory, (object) "gdh_MemberPrice3"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원특별적립율", (object) TableCodeType.GoodsHistory, (object) "gdh_PointRate"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2} ({3},{4},{5})", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory, (object) "gdh_StoreCode", (object) "gdh_GoodsCode", (object) "gdh_GoodsCategory") + "\n INCLUDE ( gdh_StartDate,gdh_EndDate)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_2 ON {1}.dbo.{2} ({3},{4},{5},{6})", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory, (object) "gdh_StoreCode", (object) "gdh_Supplier", (object) "gdh_GoodsCode", (object) "gdh_GoodsCategory") + "\n INCLUDE ( gdh_StartDate,gdh_EndDate,gdh_ChargeRate)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_3 ON {1}.dbo.{2}", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " (gdh_GoodsCategory,gdh_StoreCode,gdh_StartDate,gdh_GoodsCode,gdh_Supplier)\n INCLUDE ( gdh_EndDate ) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_1 ON {1}.dbo.{2}", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " (gdh_GoodsCode,gdh_GoodsCategory,gdh_Supplier);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_2 ON {1}.dbo.{2}", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " (gdh_GoodsCategory,gdh_StoreCode);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_3 ON {1}.dbo.{2}", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " (gdh_Supplier,gdh_StoreCode,gdh_GoodsCode);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_4 ON {1}.dbo.{2}", (object) TableCodeType.GoodsHistory, (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsHistory) + " (gdh_StoreCode,gdh_GoodsCode,gdh_GoodsCategory,gdh_Supplier);");
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
        if (p_rs.IsFieldName("gdh_StoreCode"))
          this.gdh_StoreCode = p_rs.GetFieldInt("gdh_StoreCode");
        if (p_rs.IsFieldName("gdh_GoodsCode"))
          this.gdh_GoodsCode = p_rs.GetFieldLong("gdh_GoodsCode");
        if (p_rs.IsFieldName("gdh_StartDate"))
          this.gdh_StartDate = p_rs.GetFieldDateTime("gdh_StartDate");
        if (p_rs.IsFieldName("gdh_SiteID"))
          this.gdh_SiteID = p_rs.GetFieldLong("gdh_SiteID");
        if (p_rs.IsFieldName("gdh_EndDate"))
          this.gdh_EndDate = p_rs.GetFieldDateTime("gdh_EndDate");
        if (p_rs.IsFieldName("gdh_GoodsCategory"))
          this.gdh_GoodsCategory = p_rs.GetFieldInt("gdh_GoodsCategory");
        if (p_rs.IsFieldName("gdh_Supplier"))
          this.gdh_Supplier = p_rs.GetFieldInt("gdh_Supplier");
        if (p_rs.IsFieldName("gdh_ChargeRate"))
          this.gdh_ChargeRate = p_rs.GetFieldDouble("gdh_ChargeRate");
        if (p_rs.IsFieldName("gdh_BuyCost"))
          this.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
        if (p_rs.IsFieldName("gdh_BuyVat"))
          this.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
        if (p_rs.IsFieldName("gdh_SalePrice"))
          this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
        if (p_rs.IsFieldName("gdh_EventCost"))
          this.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
        if (p_rs.IsFieldName("gdh_EventVat"))
          this.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
        if (p_rs.IsFieldName("gdh_EventPrice"))
          this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
        if (p_rs.IsFieldName("gdh_MemberPrice1"))
          this.gdh_MemberPrice1 = p_rs.GetFieldDouble("gdh_MemberPrice1");
        if (p_rs.IsFieldName("gdh_MemberPrice2"))
          this.gdh_MemberPrice2 = p_rs.GetFieldDouble("gdh_MemberPrice2");
        if (p_rs.IsFieldName("gdh_MemberPrice3"))
          this.gdh_MemberPrice3 = p_rs.GetFieldDouble("gdh_MemberPrice3");
        if (p_rs.IsFieldName("gdh_PointRate"))
          this.gdh_PointRate = p_rs.GetFieldDouble("gdh_PointRate");
        if (p_rs.IsFieldName("gdh_InDate"))
          this.gdh_InDate = p_rs.GetFieldDateTime("gdh_InDate");
        if (p_rs.IsFieldName("gdh_InUser"))
          this.gdh_InUser = p_rs.GetFieldInt("gdh_InUser");
        if (p_rs.IsFieldName("gdh_ModDate"))
          this.gdh_ModDate = p_rs.GetFieldDateTime("gdh_ModDate");
        if (p_rs.IsFieldName("gdh_ModUser"))
          this.gdh_ModUser = p_rs.GetFieldInt("gdh_ModUser");
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
        IList<GoodsHistoryCreate> goodsHistoryCreateList = this.OleDB.Create<GoodsHistoryCreate>().SelectAllListE<GoodsHistoryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (goodsHistoryCreateList == null)
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
        int count = goodsHistoryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (goodsHistoryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.GoodsHistory.ToDescription(), (object) TableCodeType.GoodsHistory) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (GoodsHistoryCreate goodsHistoryCreate in (IEnumerable<GoodsHistoryCreate>) goodsHistoryCreateList)
        {
          stringBuilder.Append(goodsHistoryCreate.InsertQuery());
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
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
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
        if (goodsHistoryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.GoodsHistory.ToDescription(), (object) TableCodeType.GoodsHistory) + "\n--------------------------------------------------------------------------------------------------");
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
