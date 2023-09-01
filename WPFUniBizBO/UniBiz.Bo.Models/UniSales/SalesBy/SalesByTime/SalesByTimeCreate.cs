// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.SalesByTimeCreate
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime
{
  public class SalesByTimeCreate : TSalesByTime, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = SalesByTimeCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = SalesByTimeCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByTime) + " sbt_SaleDate DATETIME NOT NULL,sbt_StoreCode INT NOT NULL,sbt_CategoryCode INT NOT NULL,sbt_DeptCode INT NOT NULL,sbt_BoxCode BIGINT NOT NULL,sbt_GoodsCode BIGINT NOT NULL,sbt_Supplier INT NOT NULL,sbt_KeySeq INT NOT NULL DEFAULT(0),sbt_SiteID BIGINT NOT NULL DEFAULT(0),sbt_DayOfWeek INT NOT NULL DEFAULT(0),sbt_WeekOfYear INT NOT NULL DEFAULT(0),sbt_DayOfYear INT NOT NULL DEFAULT(0)");
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_SaleAmt", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_BoxQty", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_SaleQty", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_SlipCustomer", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_CategoryCustomer", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_GoodsCustomer", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} MONEY NOT NULL DEFAULT(0.0000)", (object) "sbt_SupplierCustomer", (object) index));
      stringBuilder.Append(" PRIMARY KEY( sbt_SaleDate,sbt_StoreCode,sbt_CategoryCode,sbt_DeptCode,sbt_BoxCode,sbt_GoodsCode,sbt_Supplier,sbt_KeySeq )  ) ;");
      return stringBuilder.ToString();
    }

    public static string CreateTableMySql()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByTime) + " sbt_SaleDate DATETIME NOT NULL,sbt_StoreCode INT NOT NULL,sbt_CategoryCode INT NOT NULL,sbt_DeptCode INT NOT NULL,sbt_BoxCode BIGINT NOT NULL,sbt_GoodsCode BIGINT NOT NULL,sbt_Supplier INT NOT NULL,sbt_KeySeq INT NOT NULL DEFAULT 0,sbt_SiteID BIGINT NOT NULL DEFAULT 0,sbt_DayOfWeek INT NOT NULL DEFAULT 0,sbt_WeekOfYear INT NOT NULL DEFAULT 0,sbt_DayOfYear INT NOT NULL DEFAULT 0");
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_SaleAmt", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_BoxQty", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_SaleQty", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_SlipCustomer", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_CategoryCustomer", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_GoodsCustomer", (object) index));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00} DECIMAL(19,4) NOT NULL DEFAULT 0.0000", (object) "sbt_SupplierCustomer", (object) index));
      stringBuilder.Append(" PRIMARY KEY( sbt_SaleDate,sbt_StoreCode,sbt_CategoryCode,sbt_DeptCode,sbt_BoxCode,sbt_GoodsCode,sbt_Supplier,sbt_KeySeq )  ) ;");
      return stringBuilder.ToString();
    }

    public bool CreateTable()
    {
      if (this.OleDB.Execute(SalesByTimeCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_SALES, (object) this.TableCode)))
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
        string str1 = "EXEC " + UbModelBase.UNI_SALES + ".sys.sp_addextendedproperty N'MS_Description', N'";
        string str2 = "', N'schema', N'dbo', N'table', N'";
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.SalesByTime.ToDescription(), (object) str2, (object) TableCodeType.SalesByTime));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "판매일자", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_SaleDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "분류ID", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_CategoryCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "부서ID", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_DeptCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "BOXCODE", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_BoxCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "상품코드", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "코드", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "KEY", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_KeySeq"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "요일 ", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_DayOfWeek"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "년주차 ", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_WeekOfYear"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "일수 ", (object) str2, (object) TableCodeType.SalesByTime, (object) "sbt_DayOfYear"));
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
        if (p_rs.IsFieldName("sbt_SaleDate"))
          this.sbt_SaleDate = p_rs.GetFieldDateTime("sbt_SaleDate");
        if (p_rs.IsFieldName("sbt_StoreCode"))
          this.sbt_StoreCode = p_rs.GetFieldInt("sbt_StoreCode");
        if (p_rs.IsFieldName("sbt_CategoryCode"))
          this.sbt_CategoryCode = p_rs.GetFieldInt("sbt_CategoryCode");
        if (p_rs.IsFieldName("sbt_DeptCode"))
          this.sbt_DeptCode = p_rs.GetFieldInt("sbt_DeptCode");
        if (p_rs.IsFieldName("sbt_BoxCode"))
          this.sbt_BoxCode = p_rs.GetFieldLong("sbt_BoxCode");
        if (p_rs.IsFieldName("sbt_GoodsCode"))
          this.sbt_GoodsCode = p_rs.GetFieldLong("sbt_GoodsCode");
        if (p_rs.IsFieldName("sbt_Supplier"))
          this.sbt_Supplier = p_rs.GetFieldInt("sbt_Supplier");
        if (p_rs.IsFieldName("sbt_KeySeq"))
          this.sbt_KeySeq = p_rs.GetFieldInt("sbt_KeySeq");
        if (p_rs.IsFieldName("sbt_SiteID"))
          this.sbt_SiteID = p_rs.GetFieldLong("sbt_SiteID");
        if (p_rs.IsFieldName("sbt_DayOfWeek"))
          this.sbt_DayOfWeek = p_rs.GetFieldInt("sbt_DayOfWeek");
        if (p_rs.IsFieldName("sbt_WeekOfYear"))
          this.sbt_WeekOfYear = p_rs.GetFieldInt("sbt_WeekOfYear");
        if (p_rs.IsFieldName("sbt_DayOfYear"))
          this.sbt_DayOfYear = p_rs.GetFieldInt("sbt_DayOfYear");
        for (int index = 0; index < 24; ++index)
        {
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_SaleAmt", (object) index)))
            this.sbt_SaleAmt[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SaleAmt", (object) index));
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_SaleAmt", (object) index)))
            this.sbt_BoxQty[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_BoxQty", (object) index));
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_SaleQty", (object) index)))
            this.sbt_SaleQty[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SaleQty", (object) index));
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_SlipCustomer", (object) index)))
            this.sbt_SlipCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SlipCustomer", (object) index));
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index)))
            this.sbt_CategoryCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index));
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index)))
            this.sbt_GoodsCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index));
          if (p_rs.IsFieldName(string.Format("{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index)))
            this.sbt_SupplierCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index));
        }
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
        IList<SalesByTimeCreate> salesByTimeCreateList = this.OleDB.Create<SalesByTimeCreate>().SelectAllListE<SalesByTimeCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_SALES
          }
        });
        if (salesByTimeCreateList == null)
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
        int count = salesByTimeCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (salesByTimeCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.SalesByTime.ToDescription(), (object) TableCodeType.SalesByTime) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (SalesByTimeCreate salesByTimeCreate in (IEnumerable<SalesByTimeCreate>) salesByTimeCreateList)
        {
          stringBuilder.Append(salesByTimeCreate.InsertQuery());
          if (stringBuilder.Length > 8000)
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
        if (salesByTimeCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.SalesByTime.ToDescription(), (object) TableCodeType.SalesByTime) + "\n--------------------------------------------------------------------------------------------------");
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
