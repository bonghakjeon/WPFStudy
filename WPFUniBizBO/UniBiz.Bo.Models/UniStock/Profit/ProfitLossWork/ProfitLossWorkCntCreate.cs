// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.ProfitLossWorkCntCreate
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

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class ProfitLossWorkCntCreate : TProfitLossWorkCnt, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = ProfitLossWorkCntCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = ProfitLossWorkCntCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.ProfitLossWorkCnt) + " plwc_YyyyMm INT NOT NULL,plwc_StoreCode INT NOT NULL,plwc_SiteID BIGINT NOT NULL DEFAULT(0),plwc_WorkCnt INT NOT NULL DEFAULT(0),plwc_WorkDate DATETIME NOT NULL,plwc_WorkEmployee INT NOT NULL DEFAULT(0),plwc_ApplyCnt INT NOT NULL DEFAULT(0),plwc_ApplyDate DATETIME NULL,plwc_AmountWorkCnt INT NOT NULL DEFAULT(0),plwc_AmountWorkDate DATETIME NULL,plwc_QtyWorkCnt INT NOT NULL DEFAULT(0),plwc_QtyWorkDate DATETIME NULL,plwc_WeightWorkCnt INT NOT NULL DEFAULT(0),plwc_WeightWorkDate DATETIME NULL,plwc_MinusToZeroWorkCnt INT NOT NULL DEFAULT(0),plwc_MinusToZeroWorkDate DATETIME NULL,plwc_PoorToZeroWorkCnt INT NOT NULL DEFAULT(0),plwc_PoorToZeroWorkDate DATETIME NULL,plwc_OriginDate DATETIME NULL PRIMARY KEY(plwc_YyyyMm,plwc_StoreCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.ProfitLossWorkCnt) + " plwc_YyyyMm INT NOT NULL,plwc_StoreCode INT NOT NULL,plwc_SiteID BIGINT NOT NULL DEFAULT 0,plwc_WorkCnt INT NOT NULL DEFAULT 0,plwc_WorkDate DATETIME NOT NULL,plwc_WorkEmployee INT NOT NULL DEFAULT 0,plwc_ApplyCnt INT NOT NULL DEFAULT 0,plwc_ApplyDate DATETIME NULL,plwc_AmountWorkCnt INT NOT NULL DEFAULT 0,plwc_AmountWorkDate DATETIME NULL,plwc_QtyWorkCnt INT NOT NULL DEFAULT 0,plwc_QtyWorkDate DATETIME NULL,plwc_WeightWorkCnt INT NOT NULL DEFAULT 0,plwc_WeightWorkDate DATETIME NULL,plwc_MinusToZeroWorkCnt INT NOT NULL DEFAULT 0,plwc_MinusToZeroWorkDate DATETIME NULL,plwc_PoorToZeroWorkCnt INT NOT NULL DEFAULT 0,plwc_PoorToZeroWorkDate DATETIME NULL,plwc_OriginDate DATETIME NULL PRIMARY KEY(plwc_YyyyMm,plwc_StoreCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(ProfitLossWorkCntCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.ProfitLossWorkCnt.ToDescription(), (object) str2, (object) TableCodeType.ProfitLossWorkCnt));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결산년월", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_YyyyMm"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_WorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_WorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "작업사원", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_WorkEmployee"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고 조정", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_ApplyCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "재고 조정 일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_ApplyDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "금액", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_AmountWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "금액 일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_AmountWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "수량", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_QtyWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "수량 일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_QtyWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "중량", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_WeightWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "중량 일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_WeightWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "마이너스재고 0 처리", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_MinusToZeroWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "마이너스재고 0 처리 일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_MinusToZeroWorkDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "불량 재고 0 처리", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_PoorToZeroWorkCnt"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "불량 재고 0 처리 일시", (object) str2, (object) TableCodeType.ProfitLossWorkCnt, (object) "plwc_PoorToZeroWorkDate"));
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
        if (p_rs.IsFieldName("plwc_YyyyMm"))
          this.plwc_YyyyMm = p_rs.GetFieldInt("plwc_YyyyMm");
        if (p_rs.IsFieldName("plwc_StoreCode"))
          this.plwc_StoreCode = p_rs.GetFieldInt("plwc_YyyyMm");
        if (p_rs.IsFieldName("plwc_SiteID"))
          this.plwc_SiteID = p_rs.GetFieldLong("plwc_SiteID");
        if (p_rs.IsFieldName("plwc_WorkCnt"))
          this.plwc_WorkCnt = p_rs.GetFieldInt("plwc_WorkCnt");
        if (p_rs.IsFieldName("plwc_WorkDate"))
          this.plwc_WorkDate = p_rs.GetFieldDateTime("plwc_WorkDate");
        if (p_rs.IsFieldName("plwc_WorkEmployee"))
          this.plwc_WorkEmployee = p_rs.GetFieldInt("plwc_WorkEmployee");
        if (p_rs.IsFieldName("plwc_ApplyCnt"))
          this.plwc_ApplyCnt = p_rs.GetFieldInt("plwc_ApplyCnt");
        if (p_rs.IsFieldName("plwc_ApplyDate"))
          this.plwc_ApplyDate = p_rs.GetFieldDateTime("plwc_ApplyDate");
        if (p_rs.IsFieldName("plwc_AmountWorkCnt"))
          this.plwc_AmountWorkCnt = p_rs.GetFieldInt("plwc_AmountWorkCnt");
        if (p_rs.IsFieldName("plwc_AmountWorkDate"))
          this.plwc_AmountWorkDate = p_rs.GetFieldDateTime("plwc_AmountWorkDate");
        if (p_rs.IsFieldName("plwc_QtyWorkCnt"))
          this.plwc_QtyWorkCnt = p_rs.GetFieldInt("plwc_QtyWorkCnt");
        if (p_rs.IsFieldName("plwc_QtyWorkDate"))
          this.plwc_QtyWorkDate = p_rs.GetFieldDateTime("plwc_QtyWorkDate");
        if (p_rs.IsFieldName("plwc_WeightWorkCnt"))
          this.plwc_WeightWorkCnt = p_rs.GetFieldInt("plwc_WeightWorkCnt");
        if (p_rs.IsFieldName("plwc_WeightWorkDate"))
          this.plwc_WeightWorkDate = p_rs.GetFieldDateTime("plwc_WeightWorkDate");
        if (p_rs.IsFieldName("plwc_PoorToZeroWorkCnt"))
          this.plwc_PoorToZeroWorkCnt = p_rs.GetFieldInt("plwc_PoorToZeroWorkCnt");
        if (p_rs.IsFieldName("plwc_PoorToZeroWorkDate"))
          this.plwc_PoorToZeroWorkDate = p_rs.GetFieldDateTime("plwc_PoorToZeroWorkDate");
        if (p_rs.IsFieldName("plwc_MinusToZeroWorkCnt"))
          this.plwc_MinusToZeroWorkCnt = p_rs.GetFieldInt("plwc_MinusToZeroWorkCnt");
        if (p_rs.IsFieldName("plwc_MinusToZeroWorkDate"))
          this.plwc_MinusToZeroWorkDate = p_rs.GetFieldDateTime("plwc_MinusToZeroWorkDate");
        if (p_rs.IsFieldName("plwc_OriginDate"))
          this.plwc_OriginDate = p_rs.GetFieldDateTime("plwc_OriginDate");
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
        IList<ProfitLossWorkCntCreate> lossWorkCntCreateList = this.OleDB.Create<ProfitLossWorkCntCreate>().SelectAllListE<ProfitLossWorkCntCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (lossWorkCntCreateList == null)
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
        int count = lossWorkCntCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (lossWorkCntCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.ProfitLossWorkCnt.ToDescription(), (object) TableCodeType.ProfitLossWorkCnt) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ProfitLossWorkCntCreate lossWorkCntCreate in (IEnumerable<ProfitLossWorkCntCreate>) lossWorkCntCreateList)
        {
          stringBuilder.Append(lossWorkCntCreate.InsertQuery());
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
        if (lossWorkCntCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.ProfitLossWorkCnt.ToDescription(), (object) TableCodeType.ProfitLossWorkCnt) + "\n--------------------------------------------------------------------------------------------------");
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
