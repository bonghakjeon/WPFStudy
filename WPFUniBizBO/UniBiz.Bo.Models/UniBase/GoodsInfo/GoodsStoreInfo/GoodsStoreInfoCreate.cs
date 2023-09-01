// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo.GoodsStoreInfoCreate
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo
{
  public class GoodsStoreInfoCreate : TGoodsStoreInfo, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = GoodsStoreInfoCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = GoodsStoreInfoCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsStoreInfo) + " gdsh_StoreCode INT NOT NULL,gdsh_GoodsCode BIGINT NOT NULL,gdsh_SiteID BIGINT NOT NULL DEFAULT(0),gdsh_DeliveryDiv INT NOT NULL DEFAULT(0),gdsh_MinOrderUnit MONEY NOT NULL DEFAULT(0.0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "gdsh_MultiSuplierYn", (object) 1, (object) "N") + ",gdsh_OrderType INT NOT NULL DEFAULT(0),gdsh_AutoOrderMonth INT NOT NULL DEFAULT(0),gdsh_OrderWeekDay INT NOT NULL DEFAULT(0),gdsh_AutoOrderMonths INT NOT NULL DEFAULT(0),gdsh_AutoOrderDays INT NOT NULL DEFAULT(0),gdsh_AutoOrderType INT NOT NULL DEFAULT(0),gdsh_AutoSafeQty MONEY NOT NULL DEFAULT(0.0),gdsh_AutoMinQty MONEY NOT NULL DEFAULT(0.0),gdsh_AutoMidQty MONEY NOT NULL DEFAULT(0.0),gdsh_AutoMaxQty MONEY NOT NULL DEFAULT(0.0),gdsh_StorageStockQty MONEY NOT NULL DEFAULT(0.0),gdsh_OrderEndDate DATETIME NULL,gdsh_SaleEndDate DATETIME NULL,gdsh_AddProperty INT NOT NULL DEFAULT(0),gdsh_InDate DATETIME NULL,gdsh_InUser INT NOT NULL DEFAULT(0),gdsh_ModDate DATETIME NULL,gdsh_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(gdsh_StoreCode,gdsh_GoodsCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.GoodsStoreInfo) + " gdsh_StoreCode INT NOT NULL,gdsh_GoodsCode BIGINT NOT NULL,gdsh_SiteID BIGINT NOT NULL DEFAULT 0,gdsh_DeliveryDiv INT NOT NULL DEFAULT 0,gdsh_MinOrderUnit DECIMAL(19,4) NOT NULL DEFAULT 0.0000" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "gdsh_MultiSuplierYn", (object) 1, (object) "N") + ",gdsh_OrderType INT NOT NULL DEFAULT 0,gdsh_AutoOrderMonth INT NOT NULL DEFAULT 0,gdsh_OrderWeekDay INT NOT NULL DEFAULT 0,gdsh_AutoOrderMonths INT NOT NULL DEFAULT 0,gdsh_AutoOrderDays INT NOT NULL DEFAULT 0,gdsh_AutoOrderType INT NOT NULL DEFAULT 0,gdsh_AutoSafeQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdsh_AutoMinQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdsh_AutoMidQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdsh_AutoMaxQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdsh_StorageStockQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gdsh_OrderEndDate DATETIME NULL,gdsh_SaleEndDate DATETIME NULL,gdsh_AddProperty INT NOT NULL DEFAULT 0,gdsh_InDate DATETIME NULL,gdsh_InUser INT NOT NULL DEFAULT 0,gdsh_ModDate DATETIME NULL,gdsh_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(gdsh_StoreCode,gdsh_GoodsCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(GoodsStoreInfoCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.GoodsStoreInfo.ToDescription(), (object) TableCodeType.GoodsStoreInfo));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점코드", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품코드", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배송 구분", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_DeliveryDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최소 발주량", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_MinOrderUnit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "복수거래처 여부", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_MultiSuplierYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발주중지", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_OrderEndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매중지", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_SaleEndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "속성타입", (object) TableCodeType.GoodsStoreInfo, (object) "gdsh_AddProperty"));
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
        if (p_rs.IsFieldName("gdsh_StoreCode"))
          this.gdsh_StoreCode = p_rs.GetFieldInt("gdsh_StoreCode");
        if (p_rs.IsFieldName("gdsh_GoodsCode"))
          this.gdsh_GoodsCode = p_rs.GetFieldLong("gdsh_GoodsCode");
        if (p_rs.IsFieldName("gdsh_SiteID"))
          this.gdsh_SiteID = p_rs.GetFieldLong("gdsh_SiteID");
        if (p_rs.IsFieldName("gdsh_DeliveryDiv"))
          this.gdsh_DeliveryDiv = p_rs.GetFieldInt("gdsh_DeliveryDiv");
        if (p_rs.IsFieldName("gdsh_MinOrderUnit"))
          this.gdsh_MinOrderUnit = p_rs.GetFieldDouble("gdsh_MinOrderUnit");
        if (p_rs.IsFieldName("gdsh_MultiSuplierYn"))
          this.gdsh_MultiSuplierYn = p_rs.GetFieldString("gdsh_MultiSuplierYn");
        if (p_rs.IsFieldName("gdsh_OrderType"))
          this.gdsh_OrderType = p_rs.GetFieldInt("gdsh_OrderType");
        if (p_rs.IsFieldName("gdsh_AutoOrderMonth"))
          this.gdsh_AutoOrderMonth = p_rs.GetFieldInt("gdsh_AutoOrderMonth");
        if (p_rs.IsFieldName("gdsh_OrderWeekDay"))
          this.gdsh_OrderWeekDay = p_rs.GetFieldInt("gdsh_OrderWeekDay");
        if (p_rs.IsFieldName("gdsh_AutoOrderMonths"))
          this.gdsh_AutoOrderMonths = p_rs.GetFieldInt("gdsh_AutoOrderMonths");
        if (p_rs.IsFieldName("gdsh_AutoOrderDays"))
          this.gdsh_AutoOrderDays = p_rs.GetFieldInt("gdsh_AutoOrderDays");
        if (p_rs.IsFieldName("gdsh_AutoOrderType"))
          this.gdsh_AutoOrderType = p_rs.GetFieldInt("gdsh_AutoOrderType");
        if (p_rs.IsFieldName("gdsh_AutoSafeQty"))
          this.gdsh_AutoSafeQty = p_rs.GetFieldDouble("gdsh_AutoSafeQty");
        if (p_rs.IsFieldName("gdsh_AutoMinQty"))
          this.gdsh_AutoMinQty = p_rs.GetFieldDouble("gdsh_AutoMinQty");
        if (p_rs.IsFieldName("gdsh_AutoMidQty"))
          this.gdsh_AutoMidQty = p_rs.GetFieldDouble("gdsh_AutoMidQty");
        if (p_rs.IsFieldName("gdsh_AutoMaxQty"))
          this.gdsh_AutoMaxQty = p_rs.GetFieldDouble("gdsh_AutoMaxQty");
        if (p_rs.IsFieldName("gdsh_StorageStockQty"))
          this.gdsh_StorageStockQty = p_rs.GetFieldDouble("gdsh_StorageStockQty");
        if (p_rs.IsFieldName("gdsh_OrderEndDate"))
          this.gdsh_OrderEndDate = p_rs.GetFieldDateTime("gdsh_OrderEndDate");
        if (p_rs.IsFieldName("gdsh_SaleEndDate"))
          this.gdsh_SaleEndDate = p_rs.GetFieldDateTime("gdsh_SaleEndDate");
        if (p_rs.IsFieldName("gdsh_AddProperty"))
          this.gdsh_AddProperty = p_rs.GetFieldInt("gdsh_AddProperty");
        if (p_rs.IsFieldName("gdsh_InDate"))
          this.gdsh_InDate = p_rs.GetFieldDateTime("gdsh_InDate");
        if (p_rs.IsFieldName("gdsh_InUser"))
          this.gdsh_InUser = p_rs.GetFieldInt("gdsh_InUser");
        if (p_rs.IsFieldName("gdsh_ModDate"))
          this.gdsh_ModDate = p_rs.GetFieldDateTime("gdsh_ModDate");
        if (p_rs.IsFieldName("gdsh_ModUser"))
          this.gdsh_ModUser = p_rs.GetFieldInt("gdsh_ModUser");
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
        IList<GoodsStoreInfoCreate> goodsStoreInfoCreateList = this.OleDB.Create<GoodsStoreInfoCreate>().SelectAllListE<GoodsStoreInfoCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (goodsStoreInfoCreateList == null)
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
        int count = goodsStoreInfoCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (goodsStoreInfoCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.GoodsStoreInfo.ToDescription(), (object) TableCodeType.GoodsStoreInfo) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (GoodsStoreInfoCreate goodsStoreInfoCreate in (IEnumerable<GoodsStoreInfoCreate>) goodsStoreInfoCreateList)
        {
          stringBuilder.Append(goodsStoreInfoCreate.InsertQuery());
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
        if (goodsStoreInfoCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.GoodsStoreInfo.ToDescription(), (object) TableCodeType.GoodsStoreInfo) + "\n--------------------------------------------------------------------------------------------------");
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
