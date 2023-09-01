// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd.MemberGradeCalcStdCreate
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

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd
{
  public class MemberGradeCalcStdCreate : TMemberGradeCalcStd, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MemberGradeCalcStdCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MemberGradeCalcStdCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberGradeCalcStd) + " mgcs_StoreCode INT NOT NULL,mgcs_MemberGrade INT NOT NULL,mgcs_StartDate DATETIME NOT NULL,mgcs_SiteID BIGINT NOT NULL,mgcs_EndDate DATETIME NOT NULL,mgcs_MinBuyCnt INT NOT NULL DEFAULT(0),mgcs_MaxBuyCnt INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mgcs_Operator", (object) 1) + ",mgcs_MinBuyAmt MONEY NOT NULL DEFAULT(0.0000),mgcs_MaxBuyAmt MONEY NOT NULL DEFAULT(0.0000),mgcs_AddPointRate MONEY NOT NULL DEFAULT(0.0000),mgcs_InDate DATETIME NULL,mgcs_InUser INT NOT NULL DEFAULT(0),mgcs_ModDate DATETIME NULL,mgcs_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mgcs_StoreCode,mgcs_MemberGrade,mgcs_StartDate) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberGradeCalcStd) + " mgcs_StoreCode INT NOT NULL,mgcs_MemberGrade INT NOT NULL,mgcs_StartDate DATETIME NOT NULL,mgcs_SiteID BIGINT NOT NULL,mgcs_EndDate DATETIME NOT NULL,mgcs_MinBuyCnt INT NOT NULL DEFAULT 0,mgcs_MaxBuyCnt INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mgcs_Operator", (object) 1) + ",mgcs_MinBuyAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mgcs_MaxBuyAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mgcs_AddPointRate DECIMAL(19,4) NOT NULL DEFAULT 0.0000,mgcs_InDate DATETIME NULL,mgcs_InUser INT NOT NULL DEFAULT 0,mgcs_ModDate DATETIME NULL,mgcs_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mgcs_StoreCode,mgcs_MemberGrade,mgcs_StartDate) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MemberGradeCalcStdCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.MemberGradeCalcStd.ToDescription(), (object) TableCodeType.MemberGradeCalcStd));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점코드", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원등급", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_MemberGrade"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "시작일", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_StartDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "종료일", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_EndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최소구매횟수", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_MinBuyCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최대구매횟수", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_MaxBuyCnt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "연산자", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_Operator"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최소구매금액", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_MinBuyAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최대구매금액", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_MaxBuyAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "추가적립률", (object) TableCodeType.MemberGradeCalcStd, (object) "mgcs_AddPointRate"));
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
        if (p_rs.IsFieldName("mgcs_StoreCode"))
          this.mgcs_StoreCode = p_rs.GetFieldInt("mgcs_StoreCode");
        if (p_rs.IsFieldName("mgcs_MemberGrade"))
          this.mgcs_MemberGrade = p_rs.GetFieldInt("mgcs_MemberGrade");
        if (p_rs.IsFieldName("mgcs_StartDate"))
          this.mgcs_StartDate = p_rs.GetFieldDateTime("mgcs_StartDate");
        if (p_rs.IsFieldName("mgcs_SiteID"))
          this.mgcs_SiteID = p_rs.GetFieldLong("mgcs_SiteID");
        if (p_rs.IsFieldName("mgcs_EndDate"))
          this.mgcs_EndDate = p_rs.GetFieldDateTime("mgcs_EndDate");
        if (p_rs.IsFieldName("mgcs_MinBuyCnt"))
          this.mgcs_MinBuyCnt = p_rs.GetFieldInt("mgcs_MinBuyCnt");
        if (p_rs.IsFieldName("mgcs_MaxBuyCnt"))
          this.mgcs_MaxBuyCnt = p_rs.GetFieldInt("mgcs_MaxBuyCnt");
        if (p_rs.IsFieldName("mgcs_Operator"))
          this.mgcs_Operator = p_rs.GetFieldString("mgcs_Operator");
        if (p_rs.IsFieldName("mgcs_MinBuyAmt"))
          this.mgcs_MinBuyAmt = p_rs.GetFieldDouble("mgcs_MinBuyAmt");
        if (p_rs.IsFieldName("mgcs_MaxBuyAmt"))
          this.mgcs_MaxBuyAmt = p_rs.GetFieldDouble("mgcs_MaxBuyAmt");
        if (p_rs.IsFieldName("mgcs_AddPointRate"))
          this.mgcs_AddPointRate = p_rs.GetFieldDouble("mgcs_AddPointRate");
        if (p_rs.IsFieldName("mgcs_InDate"))
          this.mgcs_InDate = p_rs.GetFieldDateTime("mgcs_InDate");
        if (p_rs.IsFieldName("mgcs_InUser"))
          this.mgcs_InUser = p_rs.GetFieldInt("mgcs_InUser");
        if (p_rs.IsFieldName("mgcs_ModDate"))
          this.mgcs_ModDate = p_rs.GetFieldDateTime("mgcs_ModDate");
        if (p_rs.IsFieldName("mgcs_ModUser"))
          this.mgcs_ModUser = p_rs.GetFieldInt("mgcs_ModUser");
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
        IList<MemberGradeCalcStdCreate> gradeCalcStdCreateList = this.OleDB.Create<MemberGradeCalcStdCreate>().SelectAllListE<MemberGradeCalcStdCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (gradeCalcStdCreateList == null)
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
        int count = gradeCalcStdCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (gradeCalcStdCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.MemberGradeCalcStd.ToDescription(), (object) TableCodeType.MemberGradeCalcStd) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MemberGradeCalcStdCreate gradeCalcStdCreate in (IEnumerable<MemberGradeCalcStdCreate>) gradeCalcStdCreateList)
        {
          stringBuilder.Append(gradeCalcStdCreate.InsertQuery());
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
        if (gradeCalcStdCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.MemberGradeCalcStd.ToDescription(), (object) TableCodeType.MemberGradeCalcStd) + "\n--------------------------------------------------------------------------------------------------");
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
