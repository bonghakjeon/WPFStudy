// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryDetailCreate
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

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryDetailCreate : TInventoryDetail, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = InventoryDetailCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = InventoryDetailCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryDetail) + " id_StatementNo BIGINT NOT NULL,id_Seq INT NOT NULL,id_SiteID BIGINT NOT NULL DEFAULT(0),id_Supplier INT NOT NULL DEFAULT(0),id_CategoryCode INT NOT NULL DEFAULT(0),id_GoodsCode BIGINT NOT NULL DEFAULT(0),id_BoxCode BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "id_BarCode", (object) 40) + ",id_TaxDiv INT NOT NULL DEFAULT(0),id_SalesUnit INT NOT NULL DEFAULT(0),id_StockUnit INT NOT NULL DEFAULT(0),id_PackUnit INT NOT NULL DEFAULT(0),id_LinkRowNCount INT NOT NULL DEFAULT(0),id_BoxQty MONEY NOT NULL DEFAULT(0.0),id_InventoryQty MONEY NOT NULL DEFAULT(0.0),id_InventoryCost MONEY NOT NULL DEFAULT(0.0),id_InventoryCostAmt MONEY NOT NULL DEFAULT(0.0),id_InventoryCostVatAmt MONEY NOT NULL DEFAULT(0.0),id_AvgCost MONEY NOT NULL DEFAULT(0.0),id_AvgCostAmt MONEY NOT NULL DEFAULT(0.0),id_AvgCostVatAmt MONEY NOT NULL DEFAULT(0.0),id_InventoryPrice MONEY NOT NULL DEFAULT(0.0),id_InventoryPriceAmt MONEY NOT NULL DEFAULT(0.0),id_MobileSeq INT NOT NULL DEFAULT(0),id_InDate DATETIME NULL,id_InUser INT NOT NULL DEFAULT(0),id_ModDate DATETIME NULL,id_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(id_StatementNo,id_Seq) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryDetail) + " id_StatementNo BIGINT NOT NULL,id_Seq INT NOT NULL,id_SiteID BIGINT NOT NULL DEFAULT(0),id_Supplier INT NOT NULL DEFAULT(0),id_CategoryCode INT NOT NULL DEFAULT(0),id_GoodsCode BIGINT NOT NULL DEFAULT(0),id_BoxCode BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "id_BarCode", (object) 40) + ",id_TaxDiv INT NOT NULL DEFAULT(0),id_SalesUnit INT NOT NULL DEFAULT(0),id_StockUnit INT NOT NULL DEFAULT(0),id_PackUnit INT NOT NULL DEFAULT(0),id_LinkRowNCount INT NOT NULL DEFAULT(0),id_BoxQty DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_InventoryQty DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_InventoryCost DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_InventoryCostAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_InventoryCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_AvgCost DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_AvgCostAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_AvgCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_InventoryPrice DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_InventoryPriceAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),id_MobileSeq INT NOT NULL DEFAULT(0),id_InDate DATETIME NULL,id_InUser INT NOT NULL DEFAULT(0),id_ModDate DATETIME NULL,id_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(id_StatementNo,id_Seq) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(InventoryDetailCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.InventoryDetail.ToDescription(), (object) str2, (object) TableCodeType.InventoryDetail));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고조사전표번호", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_StatementNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "순번", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_Seq"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "협력업체", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "분류", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_CategoryCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "상품코드", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "등록코드", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_BoxCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "상품바코드", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_BarCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "면과세", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_TaxDiv"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "판매단위", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_SalesUnit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고단위", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_StockUnit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "묶음단위", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_PackUnit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "연결행건수", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_LinkRowNCount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "등록량", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_BoxQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고수량", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_InventoryQty"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원단가", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_InventoryCost"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원가합계", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_InventoryCostAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원가합계VAT", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_InventoryCostVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "평균원가", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_AvgCost"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "평균원가합계", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_AvgCostAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "평균원가합계VAT", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_AvgCostVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매단가", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_InventoryPrice"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매가합계", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_InventoryPriceAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "모바일용 순번", (object) str2, (object) TableCodeType.InventoryDetail, (object) "id_MobileSeq"));
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
        if (p_rs.IsFieldName("id_StatementNo"))
          this.id_StatementNo = p_rs.GetFieldLong("id_StatementNo");
        if (p_rs.IsFieldName("id_Seq"))
          this.id_Seq = p_rs.GetFieldInt("id_Seq");
        if (p_rs.IsFieldName("id_SiteID"))
          this.id_SiteID = p_rs.GetFieldLong("id_SiteID");
        if (p_rs.IsFieldName("id_Supplier"))
          this.id_Supplier = p_rs.GetFieldInt("id_Supplier");
        if (p_rs.IsFieldName("id_CategoryCode"))
          this.id_CategoryCode = p_rs.GetFieldInt("id_CategoryCode");
        if (p_rs.IsFieldName("id_GoodsCode"))
          this.id_GoodsCode = p_rs.GetFieldLong("id_GoodsCode");
        if (p_rs.IsFieldName("id_BoxCode"))
          this.id_BoxCode = p_rs.GetFieldLong("id_BoxCode");
        if (p_rs.IsFieldName("id_BarCode"))
          this.id_BarCode = p_rs.GetFieldString("id_BarCode");
        if (p_rs.IsFieldName("id_TaxDiv"))
          this.id_TaxDiv = p_rs.GetFieldInt("id_TaxDiv");
        if (p_rs.IsFieldName("id_SalesUnit"))
          this.id_SalesUnit = p_rs.GetFieldInt("id_SalesUnit");
        if (p_rs.IsFieldName("id_StockUnit"))
          this.id_StockUnit = p_rs.GetFieldInt("id_StockUnit");
        if (p_rs.IsFieldName("id_PackUnit"))
          this.id_PackUnit = p_rs.GetFieldInt("id_PackUnit");
        if (p_rs.IsFieldName("id_LinkRowNCount"))
          this.id_LinkRowNCount = p_rs.GetFieldInt("id_LinkRowNCount");
        if (p_rs.IsFieldName("id_BoxQty"))
          this.id_BoxQty = p_rs.GetFieldDouble("id_BoxQty");
        if (p_rs.IsFieldName("id_InventoryQty"))
          this.id_InventoryQty = p_rs.GetFieldDouble("id_InventoryQty");
        if (p_rs.IsFieldName("id_InventoryCost"))
          this.id_InventoryCost = p_rs.GetFieldDouble("id_InventoryCost");
        if (p_rs.IsFieldName("id_InventoryCostAmt"))
          this.id_InventoryCostAmt = p_rs.GetFieldDouble("id_InventoryCostAmt");
        if (p_rs.IsFieldName("id_InventoryCostVatAmt"))
          this.id_InventoryCostVatAmt = p_rs.GetFieldDouble("id_InventoryCostVatAmt");
        if (p_rs.IsFieldName("id_AvgCost"))
          this.id_AvgCost = p_rs.GetFieldDouble("id_AvgCost");
        if (p_rs.IsFieldName("id_AvgCostAmt"))
          this.id_AvgCostAmt = p_rs.GetFieldDouble("id_AvgCostAmt");
        if (p_rs.IsFieldName("id_AvgCostVatAmt"))
          this.id_AvgCostVatAmt = p_rs.GetFieldDouble("id_AvgCostVatAmt");
        if (p_rs.IsFieldName("id_InventoryPrice"))
          this.id_InventoryPrice = p_rs.GetFieldDouble("id_InventoryPrice");
        if (p_rs.IsFieldName("id_InventoryPriceAmt"))
          this.id_InventoryPriceAmt = p_rs.GetFieldDouble("id_InventoryPriceAmt");
        if (p_rs.IsFieldName("id_MobileSeq"))
          this.id_MobileSeq = p_rs.GetFieldInt("id_MobileSeq");
        if (p_rs.IsFieldName("id_InDate"))
          this.id_InDate = p_rs.GetFieldDateTime("id_InDate");
        if (p_rs.IsFieldName("id_InUser"))
          this.id_InUser = p_rs.GetFieldInt("id_InUser");
        if (p_rs.IsFieldName("id_ModDate"))
          this.id_ModDate = p_rs.GetFieldDateTime("id_ModDate");
        if (p_rs.IsFieldName("id_ModUser"))
          this.id_ModUser = p_rs.GetFieldInt("id_ModUser");
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
        IList<InventoryDetailCreate> inventoryDetailCreateList = this.OleDB.Create<InventoryDetailCreate>().SelectAllListE<InventoryDetailCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (inventoryDetailCreateList == null)
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
        int count = inventoryDetailCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (inventoryDetailCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.InventoryDetail.ToDescription(), (object) TableCodeType.InventoryDetail) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (InventoryDetailCreate inventoryDetailCreate in (IEnumerable<InventoryDetailCreate>) inventoryDetailCreateList)
        {
          stringBuilder.Append(inventoryDetailCreate.InsertQuery());
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
        if (inventoryDetailCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.InventoryDetail.ToDescription(), (object) TableCodeType.InventoryDetail) + "\n--------------------------------------------------------------------------------------------------");
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
