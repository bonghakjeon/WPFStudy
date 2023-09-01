// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryWork.InventoryWorkCntCreate
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

namespace UniBiz.Bo.Models.UniStock.Inventory.InventoryWork
{
  public class InventoryWorkCntCreate : TInventoryWorkCnt, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = InventoryWorkCntCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = InventoryWorkCntCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryWorkCnt) + " iwc_InventoryDate DATETIME NOT NULL,iwc_StoreCode INT NOT NULL,iwc_SiteID BIGINT NOT NULL DEFAULT(0),iwc_WorkCnt INT NOT NULL DEFAULT(0),iwc_WorkDate DATETIME NOT NULL,iwc_WorkEmployee INT NOT NULL DEFAULT(0),iwc_AmountWorkCnt INT NOT NULL DEFAULT(0),iwc_AmountWorkDate DATETIME NULL,iwc_QtyWorkCnt INT NOT NULL DEFAULT(0),iwc_QtyWorkDate DATETIME NULL,iwc_WeightWorkCnt INT NOT NULL DEFAULT(0),iwc_WeightWorkDate DATETIME NULL,iwc_AllWorkCnt INT NOT NULL DEFAULT(0),iwc_AllWorkDate DATETIME NULL,iwc_MinusToZeroWorkCnt INT NOT NULL DEFAULT(0),iwc_MinusToZeroWorkDate DATETIME NULL,iwc_PoorToZeroWorkCnt INT NOT NULL DEFAULT(0),iwc_PoorToZeroWorkDate DATETIME NULL,iwc_UnRegToZeroWorkCnt INT NOT NULL DEFAULT(0),iwc_UnRegToZeroWorkDate DATETIME NULL PRIMARY KEY(iwc_InventoryDate,iwc_StoreCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryWorkCntLog) + " iwc_InventoryDate DATETIME NOT NULL,iwc_StoreCode INT NOT NULL,iwc_SiteID BIGINT NOT NULL DEFAULT(0),iwc_WorkCnt INT NOT NULL DEFAULT(0),iwc_WorkDate DATETIME NOT NULL,iwc_WorkEmployee INT NOT NULL DEFAULT(0),iwc_AmountWorkCnt INT NOT NULL DEFAULT(0),iwc_AmountWorkDate DATETIME NULL,iwc_QtyWorkCnt INT NOT NULL DEFAULT(0),iwc_QtyWorkDate DATETIME NULL,iwc_WeightWorkCnt INT NOT NULL DEFAULT(0),iwc_WeightWorkDate DATETIME NULL,iwc_AllWorkCnt INT NOT NULL DEFAULT(0),iwc_AllWorkDate DATETIME NULL,iwc_MinusToZeroWorkCnt INT NOT NULL DEFAULT(0),iwc_MinusToZeroWorkDate DATETIME NULL,iwc_PoorToZeroWorkCnt INT NOT NULL DEFAULT(0),iwc_PoorToZeroWorkDate DATETIME NULL,iwc_UnRegToZeroWorkCnt INT NOT NULL DEFAULT(0),iwc_UnRegToZeroWorkDate DATETIME NULL PRIMARY KEY(iwc_InventoryDate,iwc_StoreCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(InventoryWorkCntCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.InventoryWorkCnt.ToDescription(), (object) str2, (object) TableCodeType.InventoryWorkCnt));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고조사일자", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_InventoryDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_WorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업일자", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_WorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업자", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_WorkEmployee"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "금액 작업 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_AmountWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "금액 작업일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_AmountWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "수량 작업 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_QtyWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "수량 작업일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_QtyWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "중량 작업 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_WeightWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "중량 작업일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_WeightWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전체 재고조사 작업 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_AllWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전체 재고조사 작업일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_AllWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "마이너스재고 0 처리 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_MinusToZeroWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "마이너스재고 0 처리 일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_MinusToZeroWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "불량재고 0 처리 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_PoorToZeroWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "불량재고 0 처리 일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_PoorToZeroWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "미등록 로케이션 0 처리 건수", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_UnRegToZeroWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "미등록 로케이션 0 처리 일시", (object) str2, (object) TableCodeType.InventoryWorkCnt, (object) "iwc_UnRegToZeroWorkDate"));
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
        if (p_rs.IsFieldName("iwc_InventoryDate"))
          this.iwc_InventoryDate = p_rs.GetFieldDateTime("iwc_InventoryDate");
        if (p_rs.IsFieldName("iwc_StoreCode"))
          this.iwc_StoreCode = p_rs.GetFieldInt("iwc_StoreCode");
        if (p_rs.IsFieldName("iwc_SiteID"))
          this.iwc_SiteID = p_rs.GetFieldLong("iwc_SiteID");
        if (p_rs.IsFieldName("iwc_WorkCnt"))
          this.iwc_WorkCnt = p_rs.GetFieldInt("iwc_WorkCnt");
        if (p_rs.IsFieldName("iwc_WorkDate"))
          this.iwc_WorkDate = p_rs.GetFieldDateTime("iwc_WorkDate");
        if (p_rs.IsFieldName("iwc_WorkEmployee"))
          this.iwc_WorkEmployee = p_rs.GetFieldInt("iwc_WorkEmployee");
        if (p_rs.IsFieldName("iwc_AmountWorkCnt"))
          this.iwc_AmountWorkCnt = p_rs.GetFieldInt("iwc_AmountWorkCnt");
        if (p_rs.IsFieldName("iwc_AmountWorkDate"))
          this.iwc_AmountWorkDate = p_rs.GetFieldDateTime("iwc_AmountWorkDate");
        if (p_rs.IsFieldName("iwc_QtyWorkCnt"))
          this.iwc_QtyWorkCnt = p_rs.GetFieldInt("iwc_QtyWorkCnt");
        if (p_rs.IsFieldName("iwc_QtyWorkDate"))
          this.iwc_QtyWorkDate = p_rs.GetFieldDateTime("iwc_QtyWorkDate");
        if (p_rs.IsFieldName("iwc_WeightWorkCnt"))
          this.iwc_WeightWorkCnt = p_rs.GetFieldInt("iwc_WeightWorkCnt");
        if (p_rs.IsFieldName("iwc_WeightWorkDate"))
          this.iwc_WeightWorkDate = p_rs.GetFieldDateTime("iwc_WeightWorkDate");
        if (p_rs.IsFieldName("iwc_AllWorkCnt"))
          this.iwc_AllWorkCnt = p_rs.GetFieldInt("iwc_AllWorkCnt");
        if (p_rs.IsFieldName("iwc_AllWorkDate"))
          this.iwc_AllWorkDate = p_rs.GetFieldDateTime("iwc_AllWorkDate");
        if (p_rs.IsFieldName("iwc_MinusToZeroWorkCnt"))
          this.iwc_MinusToZeroWorkCnt = p_rs.GetFieldInt("iwc_MinusToZeroWorkCnt");
        if (p_rs.IsFieldName("iwc_MinusToZeroWorkDate"))
          this.iwc_MinusToZeroWorkDate = p_rs.GetFieldDateTime("iwc_MinusToZeroWorkDate");
        if (p_rs.IsFieldName("iwc_PoorToZeroWorkCnt"))
          this.iwc_PoorToZeroWorkCnt = p_rs.GetFieldInt("iwc_PoorToZeroWorkCnt");
        if (p_rs.IsFieldName("iwc_PoorToZeroWorkDate"))
          this.iwc_PoorToZeroWorkDate = p_rs.GetFieldDateTime("iwc_PoorToZeroWorkDate");
        if (p_rs.IsFieldName("iwc_UnRegToZeroWorkCnt"))
          this.iwc_UnRegToZeroWorkCnt = p_rs.GetFieldInt("iwc_UnRegToZeroWorkCnt");
        if (p_rs.IsFieldName("iwc_UnRegToZeroWorkDate"))
          this.iwc_UnRegToZeroWorkDate = p_rs.GetFieldDateTime("iwc_UnRegToZeroWorkDate");
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
        IList<InventoryWorkCntCreate> inventoryWorkCntCreateList = this.OleDB.Create<InventoryWorkCntCreate>().SelectAllListE<InventoryWorkCntCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (inventoryWorkCntCreateList == null)
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
        int count = inventoryWorkCntCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (inventoryWorkCntCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.InventoryWorkCnt.ToDescription(), (object) TableCodeType.InventoryWorkCnt) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (InventoryWorkCntCreate inventoryWorkCntCreate in (IEnumerable<InventoryWorkCntCreate>) inventoryWorkCntCreateList)
        {
          stringBuilder.Append(inventoryWorkCntCreate.InsertQuery());
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
        if (inventoryWorkCntCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.InventoryWorkCnt.ToDescription(), (object) TableCodeType.InventoryWorkCnt) + "\n--------------------------------------------------------------------------------------------------");
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
