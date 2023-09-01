// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd.MemberCycleStdCreate
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

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd
{
  public class MemberCycleStdCreate : TMemberCycleStd, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MemberCycleStdCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MemberCycleStdCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberCycleStd) + " mcs_StoreCode INT NOT NULL,mcs_StartDate DATETIME NOT NULL,mcs_SiteID BIGINT NOT NULL,mcs_EndDate DATETIME NOT NULL,mcs_NewStdQty INT NOT NULL DEFAULT(0),mcs_Cycle1MinBuyCnt INT NOT NULL DEFAULT(0),mcs_Cycle1MaxBuyCnt INT NOT NULL DEFAULT(0),mcs_Cycle2MinBuyCnt INT NOT NULL DEFAULT(0),mcs_Cycle2MaxBuyCnt INT NOT NULL DEFAULT(0),mcs_DormancyPeriod INT NOT NULL DEFAULT(0),mcs_InDate DATETIME NULL,mcs_InUser INT NOT NULL DEFAULT(0),mcs_ModDate DATETIME NULL,mcs_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mcs_StoreCode,mcs_StartDate) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberCycleStd) + " mcs_StoreCode INT NOT NULL,mcs_StartDate DATETIME NOT NULL,mcs_SiteID BIGINT NOT NULL,mcs_EndDate DATETIME NOT NULL,mcs_NewStdQty INT NOT NULL DEFAULT 0,mcs_Cycle1MinBuyCnt INT NOT NULL DEFAULT 0,mcs_Cycle1MaxBuyCnt INT NOT NULL DEFAULT 0,mcs_Cycle2MinBuyCnt INT NOT NULL DEFAULT 0,mcs_Cycle2MaxBuyCnt INT NOT NULL DEFAULT 0,mcs_DormancyPeriod INT NOT NULL DEFAULT 0,mcs_InDate DATETIME NULL,mcs_InUser INT NOT NULL DEFAULT 0,mcs_ModDate DATETIME NULL,mcs_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mcs_StoreCode,mcs_StartDate) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MemberCycleStdCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_MEMBERS, (object) this.TableCode)))
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
        string str = "EXEC " + UbModelBase.UNI_MEMBERS + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.MemberCycleStd.ToDescription(), (object) TableCodeType.MemberCycleStd));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점코드", (object) TableCodeType.MemberCycleStd, (object) "mcs_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "시작일", (object) TableCodeType.MemberCycleStd, (object) "mcs_StartDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.MemberCycleStd, (object) "mcs_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "종료일", (object) TableCodeType.MemberCycleStd, (object) "mcs_EndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "신규기준횟수", (object) TableCodeType.MemberCycleStd, (object) "mcs_NewStdQty"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주기1최소횟수", (object) TableCodeType.MemberCycleStd, (object) "mcs_Cycle1MinBuyCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주기1최대구매횟수", (object) TableCodeType.MemberCycleStd, (object) "mcs_Cycle1MaxBuyCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주기2최소횟수", (object) TableCodeType.MemberCycleStd, (object) "mcs_Cycle2MinBuyCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주기2최대구매횟수", (object) TableCodeType.MemberCycleStd, (object) "mcs_Cycle2MaxBuyCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "휴면산정기간", (object) TableCodeType.MemberCycleStd, (object) "mcs_DormancyPeriod"));
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
        if (p_rs.IsFieldName("mcs_StoreCode"))
          this.mcs_StoreCode = p_rs.GetFieldInt("mcs_StoreCode");
        if (p_rs.IsFieldName("mcs_StartDate"))
          this.mcs_StartDate = p_rs.GetFieldDateTime("mcs_StartDate");
        if (p_rs.IsFieldName("mcs_SiteID"))
          this.mcs_SiteID = p_rs.GetFieldLong("mcs_SiteID");
        if (p_rs.IsFieldName("mcs_EndDate"))
          this.mcs_EndDate = p_rs.GetFieldDateTime("mcs_EndDate");
        if (p_rs.IsFieldName("mcs_NewStdQty"))
          this.mcs_NewStdQty = p_rs.GetFieldInt("mcs_NewStdQty");
        if (p_rs.IsFieldName("mcs_Cycle1MinBuyCnt"))
          this.mcs_Cycle1MinBuyCnt = p_rs.GetFieldInt("mcs_Cycle1MinBuyCnt");
        if (p_rs.IsFieldName("mcs_Cycle1MaxBuyCnt"))
          this.mcs_Cycle1MaxBuyCnt = p_rs.GetFieldInt("mcs_Cycle1MaxBuyCnt");
        if (p_rs.IsFieldName("mcs_Cycle2MinBuyCnt"))
          this.mcs_Cycle2MinBuyCnt = p_rs.GetFieldInt("mcs_Cycle2MinBuyCnt");
        if (p_rs.IsFieldName("mcs_Cycle2MaxBuyCnt"))
          this.mcs_Cycle2MaxBuyCnt = p_rs.GetFieldInt("mcs_Cycle2MaxBuyCnt");
        if (p_rs.IsFieldName("mcs_DormancyPeriod"))
          this.mcs_DormancyPeriod = p_rs.GetFieldInt("mcs_DormancyPeriod");
        if (p_rs.IsFieldName("mcs_InDate"))
          this.mcs_InDate = p_rs.GetFieldDateTime("mcs_InDate");
        if (p_rs.IsFieldName("mcs_InUser"))
          this.mcs_InUser = p_rs.GetFieldInt("mcs_InUser");
        if (p_rs.IsFieldName("mcs_ModDate"))
          this.mcs_ModDate = p_rs.GetFieldDateTime("mcs_ModDate");
        if (p_rs.IsFieldName("mcs_ModUser"))
          this.mcs_ModUser = p_rs.GetFieldInt("mcs_ModUser");
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
        IList<MemberCycleStdCreate> memberCycleStdCreateList = this.OleDB.Create<MemberCycleStdCreate>().SelectAllListE<MemberCycleStdCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (memberCycleStdCreateList == null)
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
        int count = memberCycleStdCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (memberCycleStdCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.MemberCycleStd.ToDescription(), (object) TableCodeType.MemberCycleStd) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MemberCycleStdCreate memberCycleStdCreate in (IEnumerable<MemberCycleStdCreate>) memberCycleStdCreateList)
        {
          stringBuilder.Append(memberCycleStdCreate.InsertQuery());
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
        if (memberCycleStdCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.MemberCycleStd.ToDescription(), (object) TableCodeType.MemberCycleStd) + "\n--------------------------------------------------------------------------------------------------");
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
