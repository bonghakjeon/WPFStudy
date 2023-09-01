// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementDetailCreate
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
  public class StatementDetailCreate : TStatementDetail, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = StatementDetailCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = StatementDetailCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementDetail) + " sd_StatementNo BIGINT NOT NULL,sd_Seq INT NOT NULL,sd_SiteID BIGINT NOT NULL DEFAULT(0),sd_GoodsCode BIGINT NOT NULL DEFAULT(0),sd_BoxCode BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "sd_BarCode", (object) 40) + ",sd_CategoryCode INT NOT NULL DEFAULT(0),sd_TaxDiv INT NOT NULL DEFAULT(0),sd_SalesUnit INT NOT NULL DEFAULT(0),sd_StockUnit INT NOT NULL DEFAULT(0),sd_PackUnit INT NOT NULL DEFAULT(0),sd_LinkRowNCount INT NOT NULL DEFAULT(0),sd_CostGoods MONEY NOT NULL DEFAULT(0.0),sd_PriceGoods MONEY NOT NULL DEFAULT(0.0),sd_OrderQty MONEY NOT NULL DEFAULT(0.0),sd_BoxQty MONEY NOT NULL DEFAULT(0.0),sd_BuyQty MONEY NOT NULL DEFAULT(0.0),sd_CheckQty MONEY NOT NULL DEFAULT(0.0),sd_CostInput MONEY NOT NULL DEFAULT(0.0),sd_CostInputVat MONEY NOT NULL DEFAULT(0.0),sd_CostTaxAmt MONEY NOT NULL DEFAULT(0.0),sd_CostTaxFreeAmt MONEY NOT NULL DEFAULT(0.0),sd_CostVatAmt MONEY NOT NULL DEFAULT(0.0),sd_Deposit MONEY NOT NULL DEFAULT(0.0),sd_PriceTaxAmt MONEY NOT NULL DEFAULT(0.0),sd_PriceTaxFreeAmt MONEY NOT NULL DEFAULT(0.0),sd_PriceVatAmt MONEY NOT NULL DEFAULT(0.0),sd_ProfitAmt MONEY NOT NULL DEFAULT(0.0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "sd_EventYn", (object) 1, (object) "N") + ",sd_Native INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "sd_HistoryID", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "sd_Memo", (object) 100) + ",sd_MobieSeq INT NOT NULL DEFAULT(0),sd_InDate DATETIME NULL,sd_InUser INT NOT NULL DEFAULT(0),sd_ModDate DATETIME NULL,sd_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(sd_StatementNo,sd_Seq) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementDetail) + " sd_StatementNo BIGINT NOT NULL,sd_Seq INT NOT NULL,sd_SiteID BIGINT NOT NULL DEFAULT 0,sd_GoodsCode BIGINT NOT NULL DEFAULT 0,sd_BoxCode BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "sd_BarCode", (object) 40) + ",sd_CategoryCode INT NOT NULL DEFAULT 0,sd_TaxDiv INT NOT NULL DEFAULT 0,sd_SalesUnit INT NOT NULL DEFAULT 0,sd_StockUnit INT NOT NULL DEFAULT 0,sd_PackUnit INT NOT NULL DEFAULT 0,sd_LinkRowNCount INT NOT NULL DEFAULT 0,sd_CostGoods DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_PriceGoods DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_OrderQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_BoxQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_BuyQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_CheckQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_CostInput DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_CostInputVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_CostTaxAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_CostTaxFreeAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_CostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_Deposit DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_PriceTaxAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_PriceTaxFreeAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_PriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,sd_ProfitAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "sd_EventYn", (object) 1, (object) "N") + ",sd_Native INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "sd_HistoryID", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "sd_Memo", (object) 100) + ",sd_MobieSeq INT NOT NULL DEFAULT 0,sd_InDate DATETIME NULL,sd_InUser INT NOT NULL DEFAULT 0,sd_ModDate DATETIME NULL,sd_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(sd_StatementNo,sd_Seq) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(StatementDetailCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.StatementDetail.ToDescription(), (object) str2, (object) TableCodeType.StatementDetail));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전표 코드", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_StatementNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "순서", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_Seq"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "상품코드", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "등록코드", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_BoxCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "스캔코드", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_BarCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "소부류코드", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CategoryCode"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "과면세", (object) 51, (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_TaxDiv"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "판매단위", (object) 52, (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_SalesUnit"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "재고단위", (object) 53, (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_StockUnit"));
        stringBuilder.Append(string.Format("{0}{1}공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "묶음단위", (object) 54, (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_PackUnit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "연결행건수", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_LinkRowNCount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원단가(마스타)", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CostGoods"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매단가(마스타)", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_PriceGoods"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "발주량", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_OrderQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "등록량", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_BoxQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "수량", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_BuyQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "검수량", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CheckQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원단가", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CostInput"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원단가VAT", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CostInputVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "과세금액", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CostTaxAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "면세금액", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CostTaxFreeAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "부가세금액", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_CostVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "보증금", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_Deposit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가 과세금액", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_PriceTaxAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가 면세금액", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_PriceTaxFreeAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가 부가세금액", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_PriceVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "이벤트 사용상태", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_EventYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원산지", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_Native"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "이력 ID", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_HistoryID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "메모", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_Memo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "모바일 전표 순번", (object) str2, (object) TableCodeType.StatementDetail, (object) "sd_MobieSeq"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.StatementDetail, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementDetail) + " (sd_StockUnit ASC,sd_StatementNo ASC,sd_GoodsCode ASC)\n INCLUDE ( sd_BuyQty,sd_CostTaxAmt,sd_CostTaxFreeAmt,sd_CostVatAmt ,sd_PriceTaxAmt,sd_PriceTaxFreeAmt,sd_PriceVatAmt )\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_1 ON {1}.dbo.{2}", (object) TableCodeType.StatementDetail, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementDetail) + " (sd_StockUnit,sd_StatementNo,sd_GoodsCode);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_2 ON {1}.dbo.{2}", (object) TableCodeType.StatementDetail, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementDetail) + " (sd_GoodsCode,sd_StockUnit);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_3 ON {1}.dbo.{2}", (object) TableCodeType.StatementDetail, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.StatementDetail) + " (sd_GoodsCode,sd_StatementNo);");
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
        if (p_rs.IsFieldName("sd_StatementNo"))
          this.sd_StatementNo = p_rs.GetFieldLong("sd_StatementNo");
        if (p_rs.IsFieldName("sd_Seq"))
          this.sd_Seq = p_rs.GetFieldInt("sd_Seq");
        if (p_rs.IsFieldName("sd_SiteID"))
          this.sd_SiteID = p_rs.GetFieldLong("sd_SiteID");
        if (p_rs.IsFieldName("sd_GoodsCode"))
          this.sd_GoodsCode = p_rs.GetFieldLong("sd_GoodsCode");
        if (p_rs.IsFieldName("sd_BoxCode"))
          this.sd_BoxCode = p_rs.GetFieldLong("sd_BoxCode");
        if (p_rs.IsFieldName("sd_BarCode"))
          this.sd_BarCode = p_rs.GetFieldString("sd_BarCode");
        if (p_rs.IsFieldName("sd_CategoryCode"))
          this.sd_CategoryCode = p_rs.GetFieldInt("sd_CategoryCode");
        if (p_rs.IsFieldName("sd_TaxDiv"))
          this.sd_TaxDiv = p_rs.GetFieldInt("sd_TaxDiv");
        if (p_rs.IsFieldName("sd_SalesUnit"))
          this.sd_SalesUnit = p_rs.GetFieldInt("sd_SalesUnit");
        if (p_rs.IsFieldName("sd_StockUnit"))
          this.sd_StockUnit = p_rs.GetFieldInt("sd_StockUnit");
        if (p_rs.IsFieldName("sd_PackUnit"))
          this.sd_PackUnit = p_rs.GetFieldInt("sd_PackUnit");
        if (p_rs.IsFieldName("sd_LinkRowNCount"))
          this.sd_LinkRowNCount = p_rs.GetFieldInt("sd_LinkRowNCount");
        if (p_rs.IsFieldName("sd_CostGoods"))
          this.sd_CostGoods = p_rs.GetFieldDouble("sd_CostGoods");
        if (p_rs.IsFieldName("sd_PriceGoods"))
          this.sd_PriceGoods = p_rs.GetFieldDouble("sd_PriceGoods");
        if (p_rs.IsFieldName("sd_OrderQty"))
          this.sd_OrderQty = p_rs.GetFieldDouble("sd_OrderQty");
        if (p_rs.IsFieldName("sd_BoxQty"))
          this.sd_BoxQty = p_rs.GetFieldDouble("sd_BoxQty");
        if (p_rs.IsFieldName("sd_BuyQty"))
          this.sd_BuyQty = p_rs.GetFieldDouble("sd_BuyQty");
        if (p_rs.IsFieldName("sd_CheckQty"))
          this.sd_CheckQty = p_rs.GetFieldDouble("sd_CheckQty");
        if (p_rs.IsFieldName("sd_CostInput"))
          this.sd_CostInput = p_rs.GetFieldDouble("sd_CostInput");
        if (p_rs.IsFieldName("sd_CostInputVat"))
          this.sd_CostInputVat = p_rs.GetFieldDouble("sd_CostInputVat");
        if (p_rs.IsFieldName("sd_CostTaxAmt"))
          this.sd_CostTaxAmt = p_rs.GetFieldDouble("sd_CostTaxAmt");
        if (p_rs.IsFieldName("sd_CostTaxFreeAmt"))
          this.sd_CostTaxFreeAmt = p_rs.GetFieldDouble("sd_CostTaxFreeAmt");
        if (p_rs.IsFieldName("sd_CostVatAmt"))
          this.sd_CostVatAmt = p_rs.GetFieldDouble("sd_CostVatAmt");
        if (p_rs.IsFieldName("sd_Deposit"))
          this.sd_Deposit = p_rs.GetFieldDouble("sd_Deposit");
        if (p_rs.IsFieldName("sd_PriceTaxAmt"))
          this.sd_PriceTaxAmt = p_rs.GetFieldDouble("sd_PriceTaxAmt");
        if (p_rs.IsFieldName("sd_PriceTaxFreeAmt"))
          this.sd_PriceTaxFreeAmt = p_rs.GetFieldDouble("sd_PriceTaxFreeAmt");
        if (p_rs.IsFieldName("sd_PriceVatAmt"))
          this.sd_PriceVatAmt = p_rs.GetFieldDouble("sd_PriceVatAmt");
        if (p_rs.IsFieldName("sd_EventYn"))
          this.sd_EventYn = p_rs.GetFieldString("sd_EventYn");
        if (p_rs.IsFieldName("sd_Native"))
          this.sd_Native = p_rs.GetFieldInt("sd_Native");
        if (p_rs.IsFieldName("sd_HistoryID"))
          this.sd_HistoryID = p_rs.GetFieldString("sd_HistoryID");
        if (p_rs.IsFieldName("sd_Memo"))
          this.sd_Memo = p_rs.GetFieldString("sd_Memo");
        if (p_rs.IsFieldName("sd_MobieSeq"))
          this.sd_MobieSeq = p_rs.GetFieldInt("sd_MobieSeq");
        if (p_rs.IsFieldName("sd_InDate"))
          this.sd_InDate = p_rs.GetFieldDateTime("sd_InDate");
        if (p_rs.IsFieldName("sd_InUser"))
          this.sd_InUser = p_rs.GetFieldInt("sd_InUser");
        if (p_rs.IsFieldName("sd_ModDate"))
          this.sd_ModDate = p_rs.GetFieldDateTime("sd_ModDate");
        if (p_rs.IsFieldName("sd_ModUser"))
          this.sd_ModUser = p_rs.GetFieldInt("sd_ModUser");
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
        IList<StatementDetailCreate> statementDetailCreateList = this.OleDB.Create<StatementDetailCreate>().SelectAllListE<StatementDetailCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (statementDetailCreateList == null)
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
        int count = statementDetailCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (statementDetailCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.StatementDetail.ToDescription(), (object) TableCodeType.StatementDetail) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (StatementDetailCreate statementDetailCreate in (IEnumerable<StatementDetailCreate>) statementDetailCreateList)
        {
          stringBuilder.Append(statementDetailCreate.InsertQuery());
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
        if (statementDetailCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.StatementDetail.ToDescription(), (object) TableCodeType.StatementDetail) + "\n--------------------------------------------------------------------------------------------------");
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
