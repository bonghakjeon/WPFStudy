// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryWork.InventoryWorkCntLogCreate
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
  public class InventoryWorkCntLogCreate : TInventoryWorkCntLog, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = InventoryWorkCntLogCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = InventoryWorkCntLogCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryWorkCntLog) + " iwcl_SysDate DATETIME NOT NULL,iwcl_InventoryDate DATETIME NOT NULL,iwcl_StoreCode INT NOT NULL,iwcl_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_AmountWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_QtyWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_WeightWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_AllWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_MinusToZeroWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_PoorToZeroWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "iwcl_UnRegToZeroWorkYn", (object) 1, (object) "N") + ",iwcl_EmpCode INT NOT NULL DEFAULT(0) PRIMARY KEY(iwcl_SysDate,iwcl_InventoryDate,iwcl_StoreCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.InventoryWorkCntLog) + " iwcl_SysDate DATETIME NOT NULL,iwcl_InventoryDate DATETIME NOT NULL,iwcl_StoreCode INT NOT NULL,iwcl_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_AmountWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_QtyWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_WeightWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_AllWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_MinusToZeroWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_PoorToZeroWorkYn", (object) 1, (object) "N") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "iwcl_UnRegToZeroWorkYn", (object) 1, (object) "N") + ",iwcl_EmpCode INT NOT NULL DEFAULT 0 PRIMARY KEY(iwcl_SysDate,iwcl_InventoryDate,iwcl_StoreCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(InventoryWorkCntLogCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.InventoryWorkCntLog.ToDescription(), (object) str2, (object) TableCodeType.InventoryWorkCntLog));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업일시", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_SysDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고조사일자", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_InventoryDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "금액 작업 여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_AmountWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "수량 작업 여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_QtyWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "중량 작업 여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_WeightWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전체 재고조사 여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_AllWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "마이너스 재고 0 처리 여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_MinusToZeroWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "불량재고 0 처리여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_PoorToZeroWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "미등록 로케이션 0 처리여부", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_UnRegToZeroWorkYn"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "사원코드", (object) str2, (object) TableCodeType.InventoryWorkCntLog, (object) "iwcl_EmpCode"));
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
        if (p_rs.IsFieldName("iwcl_SysDate"))
          this.iwcl_SysDate = p_rs.GetFieldDateTime("iwcl_SysDate");
        if (p_rs.IsFieldName("iwcl_InventoryDate"))
          this.iwcl_InventoryDate = p_rs.GetFieldDateTime("iwcl_InventoryDate");
        if (p_rs.IsFieldName("iwcl_StoreCode"))
          this.iwcl_StoreCode = p_rs.GetFieldInt("iwcl_StoreCode");
        if (p_rs.IsFieldName("iwcl_SiteID"))
          this.iwcl_SiteID = p_rs.GetFieldLong("iwcl_SiteID");
        if (p_rs.IsFieldName("iwcl_AmountWorkYn"))
          this.iwcl_AmountWorkYn = p_rs.GetFieldString("iwcl_AmountWorkYn");
        if (p_rs.IsFieldName("iwcl_QtyWorkYn"))
          this.iwcl_QtyWorkYn = p_rs.GetFieldString("iwcl_QtyWorkYn");
        if (p_rs.IsFieldName("iwcl_WeightWorkYn"))
          this.iwcl_WeightWorkYn = p_rs.GetFieldString("iwcl_WeightWorkYn");
        if (p_rs.IsFieldName("iwcl_AllWorkYn"))
          this.iwcl_AllWorkYn = p_rs.GetFieldString("iwcl_AllWorkYn");
        if (p_rs.IsFieldName("iwcl_MinusToZeroWorkYn"))
          this.iwcl_MinusToZeroWorkYn = p_rs.GetFieldString("iwcl_MinusToZeroWorkYn");
        if (p_rs.IsFieldName("iwcl_PoorToZeroWorkYn"))
          this.iwcl_PoorToZeroWorkYn = p_rs.GetFieldString("iwcl_PoorToZeroWorkYn");
        if (p_rs.IsFieldName("iwcl_UnRegToZeroWorkYn"))
          this.iwcl_UnRegToZeroWorkYn = p_rs.GetFieldString("iwcl_UnRegToZeroWorkYn");
        if (p_rs.IsFieldName("iwcl_EmpCode"))
          this.iwcl_EmpCode = p_rs.GetFieldInt("iwcl_EmpCode");
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
        IList<InventoryWorkCntLogCreate> workCntLogCreateList = this.OleDB.Create<InventoryWorkCntLogCreate>().SelectAllListE<InventoryWorkCntLogCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (workCntLogCreateList == null)
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
        int count = workCntLogCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (workCntLogCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.InventoryWorkCntLog.ToDescription(), (object) TableCodeType.InventoryWorkCntLog) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (InventoryWorkCntLogCreate workCntLogCreate in (IEnumerable<InventoryWorkCntLogCreate>) workCntLogCreateList)
        {
          stringBuilder.Append(workCntLogCreate.InsertQuery());
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
        if (workCntLogCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.InventoryWorkCntLog.ToDescription(), (object) TableCodeType.InventoryWorkCntLog) + "\n--------------------------------------------------------------------------------------------------");
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
