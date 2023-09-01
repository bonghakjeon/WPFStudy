// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryHeaderCreate
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
  public class InventoryHeaderCreate : TInventoryHeader, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = InventoryHeaderCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = InventoryHeaderCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryHeader) + " ih_StatementNo BIGINT NOT NULL,ih_SiteID BIGINT NOT NULL DEFAULT(0),ih_StoreCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ih_Title", (object) 500) + ",ih_EmpCode INT NOT NULL DEFAULT(0),ih_InventoryStatus INT NOT NULL DEFAULT(0),ih_InventoryDate DATETIME NOT NULL,ih_ApplyType INT NOT NULL DEFAULT(0),ih_ApplyDate DATETIME NOT NULL,ih_DeviceType INT NOT NULL DEFAULT(0),ih_DeviceKey INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ih_DeviceName", (object) 100) + ",ih_GoodsCount INT NOT NULL DEFAULT(0),ih_CostAmt MONEY NOT NULL DEFAULT(0.0),ih_CostVatAmt MONEY NOT NULL DEFAULT(0.0),ih_AvgCostAmt MONEY NOT NULL DEFAULT(0.0),ih_AvgCostVatAmt MONEY NOT NULL DEFAULT(0.0),ih_PriceAmt MONEY NOT NULL DEFAULT(0.0),ih_PosNo INT NOT NULL DEFAULT(0),ih_TransNo INT NOT NULL DEFAULT(0),ih_LocationCode INT NOT NULL DEFAULT(0),ih_LocationCount INT NOT NULL DEFAULT(0),ih_StockUnit INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ih_Memo", (object) 1000) + ",ih_MobileStatementNo BIGINT NOT NULL DEFAULT(0),ih_InDate DATETIME NULL,ih_InUser INT NOT NULL DEFAULT(0),ih_ModDate DATETIME NULL,ih_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(ih_StatementNo) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryHeader) + " ih_StatementNo BIGINT NOT NULL,ih_SiteID BIGINT NOT NULL DEFAULT(0),ih_StoreCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ih_Title", (object) 500) + ",ih_EmpCode INT NOT NULL DEFAULT(0),ih_InventoryStatus INT NOT NULL DEFAULT(0),ih_InventoryDate DATETIME NOT NULL,ih_ApplyType INT NOT NULL DEFAULT(0),ih_ApplyDate DATETIME NOT NULL,ih_DeviceType INT NOT NULL DEFAULT(0),ih_DeviceKey INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ih_DeviceName", (object) 100) + ",ih_GoodsCount INT NOT NULL DEFAULT(0),ih_CostAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),ih_CostVatAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),ih_AvgCostAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),ih_AvgCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),ih_PriceAmt DECIMAL(19,4) NOT NULL DEFAULT(0.0),ih_PosNo INT NOT NULL DEFAULT(0),ih_TransNo INT NOT NULL DEFAULT(0),ih_LocationCode INT NOT NULL DEFAULT(0),ih_LocationCount INT NOT NULL DEFAULT(0),ih_StockUnit INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ih_Memo", (object) 1000) + ",ih_MobileStatementNo BIGINT NOT NULL DEFAULT(0),ih_InDate DATETIME NULL,ih_InUser INT NOT NULL DEFAULT(0),ih_ModDate DATETIME NULL,ih_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(ih_StatementNo) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(InventoryHeaderCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.InventoryHeader.ToDescription(), (object) str2, (object) TableCodeType.InventoryHeader));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고조사전표번호", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_StatementNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고조사타이틀", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_Title"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "조사자", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_EmpCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고확정", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_InventoryStatus"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고조사일자", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_InventoryDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "변환구분", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_ApplyType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "변환일시", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_ApplyDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "디바이스유형", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_DeviceType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "디바이스ID", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_DeviceKey"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "디바이스명", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_DeviceName"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "상품건수", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_GoodsCount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원가계", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_CostAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "원가VAT계", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_CostVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "평균원가계", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_AvgCostAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "평균원가VAT계", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_AvgCostVatAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "판매가계", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_PriceAmt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "영수번호", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_PosNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "영수번호", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_TransNo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "로케이션 코드", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_LocationCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "로케이션 건", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_LocationCount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고단위", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_StockUnit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "메모", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_Memo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "모바일용 전표번호", (object) str2, (object) TableCodeType.InventoryHeader, (object) "ih_MobileStatementNo"));
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
        if (p_rs.IsFieldName("ih_StatementNo"))
          this.ih_StatementNo = p_rs.GetFieldLong("ih_StatementNo");
        if (p_rs.IsFieldName("ih_SiteID"))
          this.ih_SiteID = p_rs.GetFieldLong("ih_SiteID");
        if (p_rs.IsFieldName("ih_StoreCode"))
          this.ih_StoreCode = p_rs.GetFieldInt("ih_StoreCode");
        if (p_rs.IsFieldName("ih_Title"))
          this.ih_Title = p_rs.GetFieldString("ih_Title");
        if (p_rs.IsFieldName("ih_EmpCode"))
          this.ih_EmpCode = p_rs.GetFieldInt("ih_EmpCode");
        if (p_rs.IsFieldName("ih_InventoryStatus"))
          this.ih_InventoryStatus = p_rs.GetFieldInt("ih_InventoryStatus");
        if (p_rs.IsFieldName("ih_InventoryDate"))
          this.ih_InventoryDate = p_rs.GetFieldDateTime("ih_InventoryDate");
        if (p_rs.IsFieldName("ih_ApplyType"))
          this.ih_ApplyType = p_rs.GetFieldInt("ih_ApplyType");
        if (p_rs.IsFieldName("ih_ApplyDate"))
          this.ih_ApplyDate = p_rs.GetFieldDateTime("ih_ApplyDate");
        if (p_rs.IsFieldName("ih_DeviceType"))
          this.ih_DeviceType = p_rs.GetFieldInt("ih_DeviceType");
        if (p_rs.IsFieldName("ih_DeviceKey"))
          this.ih_DeviceKey = p_rs.GetFieldInt("ih_DeviceKey");
        if (p_rs.IsFieldName("ih_DeviceName"))
          this.ih_DeviceName = p_rs.GetFieldString("ih_DeviceName");
        if (p_rs.IsFieldName("ih_GoodsCount"))
          this.ih_GoodsCount = p_rs.GetFieldInt("ih_GoodsCount");
        if (p_rs.IsFieldName("ih_CostAmt"))
          this.ih_CostAmt = p_rs.GetFieldDouble("ih_CostAmt");
        if (p_rs.IsFieldName("ih_CostVatAmt"))
          this.ih_CostVatAmt = p_rs.GetFieldDouble("ih_CostVatAmt");
        if (p_rs.IsFieldName("ih_AvgCostAmt"))
          this.ih_AvgCostAmt = p_rs.GetFieldDouble("ih_AvgCostAmt");
        if (p_rs.IsFieldName("ih_AvgCostVatAmt"))
          this.ih_AvgCostVatAmt = p_rs.GetFieldDouble("ih_AvgCostVatAmt");
        if (p_rs.IsFieldName("ih_PriceAmt"))
          this.ih_PriceAmt = p_rs.GetFieldDouble("ih_PriceAmt");
        if (p_rs.IsFieldName("ih_PosNo"))
          this.ih_PosNo = p_rs.GetFieldInt("ih_PosNo");
        if (p_rs.IsFieldName("ih_TransNo"))
          this.ih_TransNo = p_rs.GetFieldInt("ih_TransNo");
        if (p_rs.IsFieldName("ih_LocationCode"))
          this.ih_LocationCode = p_rs.GetFieldInt("ih_LocationCode");
        if (p_rs.IsFieldName("ih_LocationCount"))
          this.ih_LocationCount = p_rs.GetFieldInt("ih_LocationCount");
        if (p_rs.IsFieldName("ih_StockUnit"))
          this.ih_StockUnit = p_rs.GetFieldInt("ih_StockUnit");
        if (p_rs.IsFieldName("ih_Memo"))
          this.ih_Memo = p_rs.GetFieldString("ih_Memo");
        if (p_rs.IsFieldName("ih_MobileStatementNo"))
          this.ih_MobileStatementNo = p_rs.GetFieldLong("ih_MobileStatementNo");
        if (p_rs.IsFieldName("ih_InDate"))
          this.ih_InDate = p_rs.GetFieldDateTime("ih_InDate");
        if (p_rs.IsFieldName("ih_InUser"))
          this.ih_InUser = p_rs.GetFieldInt("ih_InUser");
        if (p_rs.IsFieldName("ih_ModDate"))
          this.ih_ModDate = p_rs.GetFieldDateTime("ih_ModDate");
        if (p_rs.IsFieldName("ih_ModUser"))
          this.ih_ModUser = p_rs.GetFieldInt("ih_ModUser");
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
        IList<InventoryHeaderCreate> inventoryHeaderCreateList = this.OleDB.Create<InventoryHeaderCreate>().SelectAllListE<InventoryHeaderCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (inventoryHeaderCreateList == null)
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
        int count = inventoryHeaderCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (inventoryHeaderCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.InventoryHeader.ToDescription(), (object) TableCodeType.InventoryHeader) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (InventoryHeaderCreate inventoryHeaderCreate in (IEnumerable<InventoryHeaderCreate>) inventoryHeaderCreateList)
        {
          stringBuilder.Append(inventoryHeaderCreate.InsertQuery());
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
        if (inventoryHeaderCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.InventoryHeader.ToDescription(), (object) TableCodeType.InventoryHeader) + "\n--------------------------------------------------------------------------------------------------");
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
