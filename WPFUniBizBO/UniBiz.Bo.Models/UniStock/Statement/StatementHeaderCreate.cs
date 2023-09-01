// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementHeaderCreate
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

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementHeaderCreate : TStatementHeader, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = StatementHeaderCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = StatementHeaderCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " sh_StatementNo BIGINT NOT NULL,sh_SiteID BIGINT NOT NULL DEFAULT(0),sh_StoreCode INT NOT NULL DEFAULT(0),sh_OrderDate DATETIME NULL,sh_OrderStatus INT NOT NULL DEFAULT(0),sh_ConfirmDate DATETIME NOT NULL,sh_ConfirmStatus INT NOT NULL DEFAULT(0),sh_Supplier INT NOT NULL DEFAULT(0),sh_SupplierType INT NOT NULL DEFAULT(0),sh_InOutDiv INT NOT NULL DEFAULT(0),sh_StatementType INT NOT NULL DEFAULT(0),sh_ReasonCode INT NOT NULL DEFAULT(0),sh_CostTaxAmt MONEY NOT NULL DEFAULT(0.0),sh_CostTaxFreeAmt MONEY NOT NULL DEFAULT(0.0),sh_CostVatAmt MONEY NOT NULL DEFAULT(0.0),sh_Deposit MONEY NOT NULL DEFAULT(0.0),sh_PriceTaxAmt MONEY NOT NULL DEFAULT(0.0),sh_PriceTaxFreeAmt MONEY NOT NULL DEFAULT(0.0),sh_PriceVatAmt MONEY NOT NULL DEFAULT(0.0),sh_ProfitAmt MONEY NOT NULL DEFAULT(0.0),sh_DeviceType INT NOT NULL DEFAULT(0),sh_OuterConnAuth INT NOT NULL DEFAULT(0),sh_AdditionalOpt INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "sh_Memo", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "sh_DeliveryNumber", (object) 30) + ",sh_TransmitStatus INT NOT NULL DEFAULT(0),sh_TransmitDate DATETIME NULL,sh_MobieStatementNo BIGINT NOT NULL DEFAULT(0),sh_AssignUser INT NOT NULL DEFAULT(0),sh_InDate DATETIME NULL,sh_InUser INT NOT NULL DEFAULT(0),sh_ModDate DATETIME NULL,sh_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(sh_StatementNo) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " sh_StatementNo BIGINT NOT NULL,sh_SiteID BIGINT NOT NULL DEFAULT 0,sh_StoreCode INT NOT NULL DEFAULT 0,sh_OrderDate DATETIME NULL,sh_OrderStatus INT NOT NULL DEFAULT 0,sh_ConfirmDate DATETIME NOT NULL,sh_ConfirmStatus INT NOT NULL DEFAULT 0,sh_Supplier INT NOT NULL DEFAULT 0,sh_SupplierType INT NOT NULL DEFAULT 0,sh_InOutDiv INT NOT NULL DEFAULT 0,sh_StatementType INT NOT NULL DEFAULT 0,sh_ReasonCode INT NOT NULL DEFAULT 0,sh_CostTaxAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_CostTaxFreeAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_CostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_Deposit DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_PriceTaxAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_PriceTaxFreeAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_PriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_ProfitAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sh_DeviceType INT NOT NULL DEFAULT 0,sh_OuterConnAuth INT NOT NULL DEFAULT 0,sh_AdditionalOpt INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "sh_Memo", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "sh_DeliveryNumber", (object) 30) + ",sh_TransmitStatus INT NOT NULL DEFAULT 0,sh_TransmitDate DATETIME NULL,sh_MobieStatementNo BIGINT NOT NULL DEFAULT 0,sh_AssignUser INT NOT NULL DEFAULT 0,sh_InDate DATETIME NULL,sh_InUser INT NOT NULL DEFAULT 0,sh_ModDate DATETIME NULL,sh_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(sh_StatementNo) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(StatementHeaderCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_STOCK, (object) this.TableCode)))
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
        string str1 = "EXEC " + UbModelBase.UNI_STOCK + ".sys.sp_addextendedproperty N'MS_Description', N'";
        string str2 = "', N'schema', N'dbo', N'table', N'";
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.StatementHeader.ToDescription(), (object) str2, (object) TableCodeType.StatementHeader));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전표 코드", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_StatementNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "발주일", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_OrderDate"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "발주상태", (object) 47, (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_OrderStatus"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "확정일", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_ConfirmDate"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "확정상태", (object) 48, (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_ConfirmStatus"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "코드", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "형태", (object) 40, (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_SupplierType"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "입출고 타입", (object) 21, (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_InOutDiv"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "전표 타입", (object) 22, (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_StatementType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "사유 코드", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_ReasonCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "과세계", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_CostTaxAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "면세계", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_CostTaxFreeAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "부가세계", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_CostVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "보증금", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_Deposit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가 과세계", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_PriceTaxAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가 면세계", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_PriceTaxFreeAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가 부가세계", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_PriceVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "세제외이익", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_ProfitAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "장치타입", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_DeviceType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "장치 코드", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_OuterConnAuth"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "추가옵션", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_AdditionalOpt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "메모", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_Memo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "송장번호", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_DeliveryNumber"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전송상태", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_TransmitStatus"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전송일", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_TransmitDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "장치 전표 번호", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_MobieStatementNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "담당사원", (object) str2, (object) TableCodeType.StatementHeader, (object) "sh_AssignUser"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_StoreCode ASC,sh_ConfirmStatus ASC,sh_StatementType ASC,sh_ConfirmDate ASC,sh_Supplier ASC,sh_StatementNo ASC)\n INCLUDE ( sh_InOutDiv )\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_1 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_ConfirmStatus,sh_Supplier,sh_StoreCode);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_2 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_ConfirmDate,sh_Supplier,sh_StoreCode,sh_ConfirmStatus);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_3 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_Supplier,sh_StoreCode,sh_ConfirmDate,sh_StatementType,sh_ConfirmStatus,sh_StatementNo);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_4 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_Supplier,sh_StatementNo,sh_StoreCode,sh_ConfirmStatus,sh_StatementType);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_5 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_StatementNo,sh_StoreCode,sh_ConfirmDate,sh_StatementType);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_6 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_StoreCode,sh_ConfirmDate,sh_StatementType,sh_ConfirmStatus,sh_StatementNo);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_7 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_StatementType,sh_Supplier,sh_StoreCode,sh_ConfirmStatus);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_8 ON {1}.dbo.{2}", (object) TableCodeType.StatementHeader, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementHeader) + " (sh_StatementNo,sh_StoreCode,sh_StatementType,sh_ConfirmStatus);");
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
        if (p_rs.IsFieldName("sh_StatementNo"))
          this.sh_StatementNo = p_rs.GetFieldLong("sh_StatementNo");
        if (p_rs.IsFieldName("sh_SiteID"))
          this.sh_SiteID = p_rs.GetFieldLong("sh_SiteID");
        if (p_rs.IsFieldName("sh_StoreCode"))
          this.sh_StoreCode = p_rs.GetFieldInt("sh_StoreCode");
        if (p_rs.IsFieldName("sh_OrderDate"))
          this.sh_OrderDate = p_rs.GetFieldDateTime("sh_OrderDate");
        if (p_rs.IsFieldName("sh_OrderStatus"))
          this.sh_OrderStatus = p_rs.GetFieldInt("sh_OrderStatus");
        if (p_rs.IsFieldName("sh_ConfirmDate"))
          this.sh_ConfirmDate = p_rs.GetFieldDateTime("sh_ConfirmDate");
        if (p_rs.IsFieldName("sh_ConfirmStatus"))
          this.sh_ConfirmStatus = p_rs.GetFieldInt("sh_ConfirmStatus");
        if (p_rs.IsFieldName("sh_Supplier"))
          this.sh_Supplier = p_rs.GetFieldInt("sh_Supplier");
        if (p_rs.IsFieldName("sh_SupplierType"))
          this.sh_SupplierType = p_rs.GetFieldInt("sh_SupplierType");
        if (p_rs.IsFieldName("sh_InOutDiv"))
          this.sh_InOutDiv = p_rs.GetFieldInt("sh_InOutDiv");
        if (p_rs.IsFieldName("sh_StatementType"))
          this.sh_StatementType = p_rs.GetFieldInt("sh_StatementType");
        if (p_rs.IsFieldName("sh_ReasonCode"))
          this.sh_ReasonCode = p_rs.GetFieldInt("sh_ReasonCode");
        if (p_rs.IsFieldName("sh_CostTaxAmt"))
          this.sh_CostTaxAmt = p_rs.GetFieldDouble("sh_CostTaxAmt");
        if (p_rs.IsFieldName("sh_CostTaxFreeAmt"))
          this.sh_CostTaxFreeAmt = p_rs.GetFieldDouble("sh_CostTaxFreeAmt");
        if (p_rs.IsFieldName("sh_CostVatAmt"))
          this.sh_CostVatAmt = p_rs.GetFieldDouble("sh_CostVatAmt");
        if (p_rs.IsFieldName("sh_Deposit"))
          this.sh_Deposit = p_rs.GetFieldDouble("sh_Deposit");
        if (p_rs.IsFieldName("sh_PriceTaxAmt"))
          this.sh_PriceTaxAmt = p_rs.GetFieldDouble("sh_PriceTaxAmt");
        if (p_rs.IsFieldName("sh_PriceTaxFreeAmt"))
          this.sh_PriceTaxFreeAmt = p_rs.GetFieldDouble("sh_PriceTaxFreeAmt");
        if (p_rs.IsFieldName("sh_PriceVatAmt"))
          this.sh_PriceVatAmt = p_rs.GetFieldDouble("sh_PriceVatAmt");
        if (p_rs.IsFieldName("sh_ProfitAmt"))
          this.sh_ProfitAmt = p_rs.GetFieldDouble("sh_ProfitAmt");
        if (p_rs.IsFieldName("sh_DeviceType"))
          this.sh_DeviceType = p_rs.GetFieldInt("sh_DeviceType");
        if (p_rs.IsFieldName("sh_OuterConnAuth"))
          this.sh_OuterConnAuth = p_rs.GetFieldInt("sh_OuterConnAuth");
        if (p_rs.IsFieldName("sh_AdditionalOpt"))
          this.sh_AdditionalOpt = p_rs.GetFieldInt("sh_AdditionalOpt");
        if (p_rs.IsFieldName("sh_Memo"))
          this.sh_Memo = p_rs.GetFieldString("sh_Memo");
        if (p_rs.IsFieldName("sh_DeliveryNumber"))
          this.sh_DeliveryNumber = p_rs.GetFieldString("sh_DeliveryNumber");
        if (p_rs.IsFieldName("sh_TransmitStatus"))
          this.sh_TransmitStatus = p_rs.GetFieldInt("sh_TransmitStatus");
        if (p_rs.IsFieldName("sh_TransmitDate"))
          this.sh_TransmitDate = p_rs.GetFieldDateTime("sh_TransmitDate");
        if (p_rs.IsFieldName("sh_MobieStatementNo"))
          this.sh_MobieStatementNo = p_rs.GetFieldLong("sh_MobieStatementNo");
        if (p_rs.IsFieldName("sh_AssignUser"))
          this.sh_AssignUser = p_rs.GetFieldInt("sh_AssignUser");
        if (p_rs.IsFieldName("sh_InDate"))
          this.sh_InDate = p_rs.GetFieldDateTime("sh_InDate");
        if (p_rs.IsFieldName("sh_InUser"))
          this.sh_InUser = p_rs.GetFieldInt("sh_InUser");
        if (p_rs.IsFieldName("sh_ModDate"))
          this.sh_ModDate = p_rs.GetFieldDateTime("sh_ModDate");
        if (p_rs.IsFieldName("sh_ModUser"))
          this.sh_ModUser = p_rs.GetFieldInt("sh_ModUser");
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
        IList<StatementHeaderCreate> statementHeaderCreateList = this.OleDB.Create<StatementHeaderCreate>().SelectAllListE<StatementHeaderCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (statementHeaderCreateList == null)
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
        int count = statementHeaderCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (statementHeaderCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.StatementHeader.ToDescription(), (object) TableCodeType.StatementHeader) + "\n - 총 " + statementHeaderCreateList.Count.ToString("n0") + "건\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (StatementHeaderCreate statementHeaderCreate in (IEnumerable<StatementHeaderCreate>) statementHeaderCreateList)
        {
          stringBuilder.Append(statementHeaderCreate.InsertQuery());
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
        if (statementHeaderCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.StatementHeader.ToDescription(), (object) TableCodeType.StatementHeader) + "\n--------------------------------------------------------------------------------------------------");
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
