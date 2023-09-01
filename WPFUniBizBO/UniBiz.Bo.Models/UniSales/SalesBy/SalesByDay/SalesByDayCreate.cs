// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.SalesByDayCreate
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay
{
  public class SalesByDayCreate : TSalesByDay, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = SalesByDayCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = SalesByDayCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " sbd_SaleDate DATETIME NOT NULL,sbd_StoreCode INT NOT NULL,sbd_BoxCode BIGINT NOT NULL,sbd_GoodsCode BIGINT NOT NULL,sbd_Supplier INT NOT NULL,sbd_SupplierType INT NOT NULL,sbd_CategoryCode INT NOT NULL,sbd_DeptCode INT NOT NULL,sbd_MakerCode INT NOT NULL,sbd_KeySeq INT NOT NULL,sbd_SiteID BIGINT NOT NULL DEFAULT(0),sbd_DayOfWeek INT NOT NULL DEFAULT(0),sbd_WeekOfYear INT NOT NULL DEFAULT(0),sbd_DayOfYear INT NOT NULL DEFAULT(0),sbd_SkyCondition INT NOT NULL DEFAULT(0),sbd_TaxDiv INT NOT NULL DEFAULT(0),sbd_SalesUnit INT NOT NULL DEFAULT(0),sbd_StockUnit INT NOT NULL DEFAULT(0),sbd_SlipCustomer MONEY NOT NULL DEFAULT(0.0000),sbd_GoodsCustomer MONEY NOT NULL DEFAULT(0.0000),sbd_CategoryCustomer MONEY NOT NULL DEFAULT(0.0000),sbd_SupplierCustomer MONEY NOT NULL DEFAULT(0.0000),sbd_BoxQty MONEY NOT NULL DEFAULT(0.0000),sbd_SaleQty MONEY NOT NULL DEFAULT(0.0000),sbd_DcAmtGoods MONEY NOT NULL DEFAULT(0.0000),sbd_DcAmtEvent MONEY NOT NULL DEFAULT(0.0000),sbd_DcAmtCoupon MONEY NOT NULL DEFAULT(0.0000),sbd_DcAmtPromotion MONEY NOT NULL DEFAULT(0.0000),sbd_DcAmtManual MONEY NOT NULL DEFAULT(0.0000),sbd_DcAmtMember MONEY NOT NULL DEFAULT(0.0000),sbd_EnurySlip MONEY NOT NULL DEFAULT(0.0000),sbd_EnuryEnd MONEY NOT NULL DEFAULT(0.0000),sbd_Deposit MONEY NOT NULL DEFAULT(0.0000),sbd_TotalSaleAmt MONEY NOT NULL DEFAULT(0.0000),sbd_SaleAmt MONEY NOT NULL DEFAULT(0.0000),sbd_SaleVatAmt MONEY NOT NULL DEFAULT(0.0000),sbd_SaleCostAmt MONEY NOT NULL DEFAULT(0.0000),sbd_ChargeAmt MONEY NOT NULL DEFAULT(0.0000),sbd_ProfitAmt MONEY NOT NULL DEFAULT(0.0000),sbd_PreTaxProfitAmt MONEY NOT NULL DEFAULT(0.0000),sbd_AddPoint MONEY NOT NULL DEFAULT(0.0000),sbd_PayCash MONEY NOT NULL DEFAULT(0.0000),sbd_PayCard MONEY NOT NULL DEFAULT(0.0000),sbd_PayEtc MONEY NOT NULL DEFAULT(0.0000) PRIMARY KEY( sbd_SaleDate,sbd_StoreCode,sbd_BoxCode,sbd_GoodsCode,sbd_Supplier,sbd_SupplierType,sbd_CategoryCode,sbd_DeptCode,sbd_MakerCode,sbd_KeySeq )  ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " sbd_SaleDate DATETIME NOT NULL,sbd_StoreCode INT NOT NULL,sbd_BoxCode BIGINT NOT NULL,sbd_GoodsCode BIGINT NOT NULL,sbd_Supplier INT NOT NULL,sbd_SupplierType INT NOT NULL,sbd_CategoryCode INT NOT NULL,sbd_DeptCode INT NOT NULL,sbd_MakerCode INT NOT NULL,sbd_KeySeq INT NOT NULL,sbd_SiteID BIGINT NOT NULL DEFAULT 0,sbd_DayOfWeek INT NOT NULL DEFAULT 0,sbd_WeekOfYear INT NOT NULL DEFAULT 0,sbd_DayOfYear INT NOT NULL DEFAULT 0,sbd_SkyCondition INT NOT NULL DEFAULT 0,sbd_TaxDiv INT NOT NULL DEFAULT 0,sbd_SalesUnit INT NOT NULL DEFAULT 0,sbd_StockUnit INT NOT NULL DEFAULT 0,sbd_SlipCustomer DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_GoodsCustomer DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_CategoryCustomer DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_SupplierCustomer DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_BoxQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_SaleQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_DcAmtGoods DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_DcAmtEvent DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_DcAmtCoupon DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_DcAmtPromotion DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_DcAmtManual DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_DcAmtMember DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_EnurySlip DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_EnuryEnd DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_Deposit DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_TotalSaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_SaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_SaleVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_SaleCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_ChargeAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_ProfitAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_PreTaxProfitAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_AddPoint DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_PayCash DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_PayCard DECIMAL(19,4) NOT NULL DEFAULT 0.0000,sbd_PayEtc DECIMAL(19,4) NOT NULL DEFAULT 0.0000 PRIMARY KEY( sbd_SaleDate,sbd_StoreCode,sbd_BoxCode,sbd_GoodsCode,sbd_Supplier,sbd_SupplierType,sbd_CategoryCode,sbd_DeptCode,sbd_MakerCode,sbd_KeySeq )  ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(SalesByDayCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.SalesByDay.ToDescription(), (object) str2, (object) TableCodeType.SalesByDay));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "판매일자", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SaleDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "BOXCODE", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_BoxCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "상품코드", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "코드", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "형태", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SupplierType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "분류ID", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_CategoryCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "부서ID", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DeptCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "제조사코드", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_MakerCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "KEY", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_KeySeq"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "요일 ", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DayOfWeek"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "년주차 ", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_WeekOfYear"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "일수 ", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DayOfYear"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "날씨 ", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SkyCondition"));
        stringBuilder.Append(string.Format("{0}{1}(공통:{2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "과면세", (object) 51, (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_TaxDiv"));
        stringBuilder.Append(string.Format("{0}{1}(공통:{2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "판매단위", (object) 52, (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SalesUnit"));
        stringBuilder.Append(string.Format("{0}{1}(공통:{2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "재고단위", (object) 53, (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_StockUnit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "객수", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SlipCustomer"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "객수", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_GoodsCustomer"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "객수", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_CategoryCustomer"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "객수", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SupplierCustomer"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출BOX수량", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_BoxQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출수량", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SaleQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "행사할인", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DcAmtGoods"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "이벤트할인", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DcAmtEvent"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "쿠폰할인", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DcAmtCoupon"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "프로모션할인", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DcAmtPromotion"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "키할인", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DcAmtManual"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "회원할인", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_DcAmtMember"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "영수증에누리", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_EnurySlip"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "끝전에누리", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_EnuryEnd"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "보증금", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_Deposit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "총매출금액", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_TotalSaleAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출금액", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SaleAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출부가세", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SaleVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "세제외매출", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_SaleCostAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "판매수수료", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_ChargeAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "세제외이익", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_ProfitAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "세포함이익", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_PreTaxProfitAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "발생포인트", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_AddPoint"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "현금결제", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_PayCash"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "카드결제", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_PayCard"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "기타", (object) str2, (object) TableCodeType.SalesByDay, (object) "sbd_PayEtc"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.SalesByDay, (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " (sbd_StoreCode,sbd_StockUnit,sbd_SaleDate)\n INCLUDE ( sbd_GoodsCode,sbd_SaleQty,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt )\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_2 ON {1}.dbo.{2}", (object) TableCodeType.SalesByDay, (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " (sbd_StoreCode,sbd_StockUnit,sbd_SaleDate,sbd_GoodsCode)\n INCLUDE ( sbd_SaleQty,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_ProfitAmt )\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_3 ON {1}.dbo.{2}", (object) TableCodeType.SalesByDay, (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " (sbd_StoreCode,sbd_GoodsCode,sbd_SaleDate)\n INCLUDE ( sbd_SaleQty,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_ProfitAmt )\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_1 ON {1}.dbo.{2}", (object) TableCodeType.SalesByDay, (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " (sbd_GoodsCode,sbd_StoreCode,sbd_StockUnit,sbd_SaleDate);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_2 ON {1}.dbo.{2}", (object) TableCodeType.SalesByDay, (object) UbModelBase.UNI_SALES, (object) TableCodeType.SalesByDay) + " (sbd_StockUnit,sbd_GoodsCode,sbd_SaleDate);");
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
        if (p_rs.IsFieldName("sbd_SaleDate"))
          this.sbd_SaleDate = p_rs.GetFieldDateTime("sbd_SaleDate");
        if (p_rs.IsFieldName("sbd_StoreCode"))
          this.sbd_StoreCode = p_rs.GetFieldInt("sbd_StoreCode");
        if (p_rs.IsFieldName("sbd_BoxCode"))
          this.sbd_BoxCode = p_rs.GetFieldLong("sbd_BoxCode");
        if (p_rs.IsFieldName("sbd_GoodsCode"))
          this.sbd_GoodsCode = p_rs.GetFieldLong("sbd_GoodsCode");
        if (p_rs.IsFieldName("sbd_Supplier"))
          this.sbd_Supplier = p_rs.GetFieldInt("sbd_Supplier");
        if (p_rs.IsFieldName("sbd_SupplierType"))
          this.sbd_SupplierType = p_rs.GetFieldInt("sbd_SupplierType");
        if (p_rs.IsFieldName("sbd_CategoryCode"))
          this.sbd_CategoryCode = p_rs.GetFieldInt("sbd_CategoryCode");
        if (p_rs.IsFieldName("sbd_DeptCode"))
          this.sbd_DeptCode = p_rs.GetFieldInt("sbd_DeptCode");
        if (p_rs.IsFieldName("sbd_MakerCode"))
          this.sbd_MakerCode = p_rs.GetFieldInt("sbd_MakerCode");
        if (p_rs.IsFieldName("sbd_KeySeq"))
          this.sbd_KeySeq = p_rs.GetFieldInt("sbd_KeySeq");
        if (p_rs.IsFieldName("sbd_KeySeq"))
          this.sbd_SiteID = p_rs.GetFieldLong("sbd_SiteID");
        if (p_rs.IsFieldName("sbd_DayOfWeek"))
          this.sbd_DayOfWeek = p_rs.GetFieldInt("sbd_DayOfWeek");
        if (p_rs.IsFieldName("sbd_WeekOfYear"))
          this.sbd_WeekOfYear = p_rs.GetFieldInt("sbd_WeekOfYear");
        if (p_rs.IsFieldName("sbd_DayOfYear"))
          this.sbd_DayOfYear = p_rs.GetFieldInt("sbd_DayOfYear");
        if (p_rs.IsFieldName("sbd_SkyCondition"))
          this.sbd_SkyCondition = p_rs.GetFieldInt("sbd_SkyCondition");
        if (p_rs.IsFieldName("sbd_TaxDiv"))
          this.sbd_TaxDiv = p_rs.GetFieldInt("sbd_TaxDiv");
        if (p_rs.IsFieldName("sbd_SalesUnit"))
          this.sbd_SalesUnit = p_rs.GetFieldInt("sbd_SalesUnit");
        if (p_rs.IsFieldName("sbd_StockUnit"))
          this.sbd_StockUnit = p_rs.GetFieldInt("sbd_StockUnit");
        if (p_rs.IsFieldName("sbd_SlipCustomer"))
          this.sbd_SlipCustomer = p_rs.GetFieldDouble("sbd_SlipCustomer");
        if (p_rs.IsFieldName("sbd_GoodsCustomer"))
          this.sbd_GoodsCustomer = p_rs.GetFieldDouble("sbd_GoodsCustomer");
        if (p_rs.IsFieldName("sbd_CategoryCustomer"))
          this.sbd_CategoryCustomer = p_rs.GetFieldDouble("sbd_CategoryCustomer");
        if (p_rs.IsFieldName("sbd_SupplierCustomer"))
          this.sbd_SupplierCustomer = p_rs.GetFieldDouble("sbd_SupplierCustomer");
        if (p_rs.IsFieldName("sbd_BoxQty"))
          this.sbd_BoxQty = p_rs.GetFieldDouble("sbd_BoxQty");
        if (p_rs.IsFieldName("sbd_SaleQty"))
          this.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty");
        if (p_rs.IsFieldName("sbd_DcAmtGoods"))
          this.sbd_DcAmtGoods = p_rs.GetFieldDouble("sbd_DcAmtGoods");
        if (p_rs.IsFieldName("sbd_DcAmtEvent"))
          this.sbd_DcAmtEvent = p_rs.GetFieldDouble("sbd_DcAmtEvent");
        if (p_rs.IsFieldName("sbd_DcAmtCoupon"))
          this.sbd_DcAmtCoupon = p_rs.GetFieldDouble("sbd_DcAmtCoupon");
        if (p_rs.IsFieldName("sbd_DcAmtPromotion"))
          this.sbd_DcAmtPromotion = p_rs.GetFieldDouble("sbd_DcAmtPromotion");
        if (p_rs.IsFieldName("sbd_DcAmtManual"))
          this.sbd_DcAmtManual = p_rs.GetFieldDouble("sbd_DcAmtManual");
        if (p_rs.IsFieldName("sbd_DcAmtMember"))
          this.sbd_DcAmtMember = p_rs.GetFieldDouble("sbd_DcAmtMember");
        if (p_rs.IsFieldName("sbd_EnurySlip"))
          this.sbd_EnurySlip = p_rs.GetFieldDouble("sbd_EnurySlip");
        if (p_rs.IsFieldName("sbd_EnuryEnd"))
          this.sbd_EnuryEnd = p_rs.GetFieldDouble("sbd_EnuryEnd");
        if (p_rs.IsFieldName("sbd_Deposit"))
          this.sbd_Deposit = p_rs.GetFieldDouble("sbd_Deposit");
        if (p_rs.IsFieldName("sbd_TotalSaleAmt"))
          this.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt");
        if (p_rs.IsFieldName("sbd_SaleAmt"))
          this.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt");
        if (p_rs.IsFieldName("sbd_SaleVatAmt"))
          this.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt");
        if (p_rs.IsFieldName("sbd_SaleCostAmt"))
          this.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt");
        if (p_rs.IsFieldName("sbd_ChargeAmt"))
          this.sbd_ChargeAmt = p_rs.GetFieldDouble("sbd_ChargeAmt");
        if (p_rs.IsFieldName("sbd_ProfitAmt"))
          this.sbd_ProfitAmt = p_rs.GetFieldDouble("sbd_ProfitAmt");
        if (p_rs.IsFieldName("sbd_PreTaxProfitAmt"))
          this.sbd_PreTaxProfitAmt = p_rs.GetFieldDouble("sbd_PreTaxProfitAmt");
        if (p_rs.IsFieldName("sbd_AddPoint"))
          this.sbd_AddPoint = p_rs.GetFieldDouble("sbd_AddPoint");
        if (p_rs.IsFieldName("sbd_PayCash"))
          this.sbd_PayCash = p_rs.GetFieldDouble("sbd_PayCash");
        if (p_rs.IsFieldName("sbd_PayCard"))
          this.sbd_PayCard = p_rs.GetFieldDouble("sbd_PayCard");
        if (p_rs.IsFieldName("sbd_PayEtc"))
          this.sbd_PayEtc = p_rs.GetFieldDouble("sbd_PayEtc");
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
        IList<SalesByDayCreate> salesByDayCreateList = this.OleDB.Create<SalesByDayCreate>().SelectAllListE<SalesByDayCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_SALES
          }
        });
        if (salesByDayCreateList == null)
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
        int count = salesByDayCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (salesByDayCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.SalesByDay.ToDescription(), (object) TableCodeType.SalesByDay) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (SalesByDayCreate salesByDayCreate in (IEnumerable<SalesByDayCreate>) salesByDayCreateList)
        {
          stringBuilder.Append(salesByDayCreate.InsertQuery());
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
        if (salesByDayCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.SalesByDay.ToDescription(), (object) TableCodeType.SalesByDay) + "\n--------------------------------------------------------------------------------------------------");
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
