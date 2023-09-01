// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Dept.DeptCreate
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

namespace UniBiz.Bo.Models.UniBase.Dept
{
  public class DeptCreate : TDept, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = DeptCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = DeptCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Dept) + " dpt_ID INT NOT NULL,dpt_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dpt_DeptName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dpt_ViewCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dpt_Memo", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "dpt_UseYn", (object) 1, (object) "Y") + ",dpt_Depth INT NOT NULL DEFAULT(0),dpt_ParentsID INT NOT NULL DEFAULT(0),dpt_InDate DATETIME NULL,dpt_InUser INT NOT NULL DEFAULT(0),dpt_ModDate DATETIME NULL,dpt_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(dpt_ID ASC) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Dept) + " dpt_ID INT NOT NULL,dpt_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dpt_DeptName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dpt_ViewCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dpt_Memo", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "dpt_UseYn", (object) 1, (object) "Y") + ",dpt_Depth INT NOT NULL DEFAULT 0,dpt_ParentsID INT NOT NULL DEFAULT 0,dpt_InDate DATETIME NULL,dpt_InUser INT NOT NULL DEFAULT 0,dpt_ModDate DATETIME NULL,dpt_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(dpt_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(DeptCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Dept.ToDescription(), (object) TableCodeType.Dept));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "부서ID", (object) TableCodeType.Dept, (object) "dpt_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Dept, (object) "dpt_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "PC명", (object) TableCodeType.Dept, (object) "dpt_DeptName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "PC코드", (object) TableCodeType.Dept, (object) "dpt_ViewCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "부서설명", (object) TableCodeType.Dept, (object) "dpt_Memo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용상태", (object) TableCodeType.Dept, (object) "dpt_UseYn"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "부서 단계", (object) 38, (object) TableCodeType.Dept, (object) "dpt_Depth"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상위부서", (object) TableCodeType.Dept, (object) "dpt_ParentsID"));
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
      DeptView deptView = this.OleDB.Create<DeptView>();
      if (pSiteID == 1L)
      {
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = "미등록";
        deptView.dpt_Depth = 0;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
        deptView.dpt_ID = 1;
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = "부서";
        deptView.dpt_ViewCode = "70";
        deptView.dpt_Memo = "부서 설명";
        deptView.dpt_Depth = 1;
        deptView.dpt_ParentsID = this.dpt_ParentsID;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
        deptView.dpt_ID = 2;
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = "팀";
        deptView.dpt_ViewCode = "10";
        deptView.dpt_Memo = "팀 설명";
        deptView.dpt_Depth = 2;
        deptView.dpt_ParentsID = this.dpt_ParentsID;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
        deptView.dpt_ID = 3;
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = "PC";
        deptView.dpt_ViewCode = "10";
        deptView.dpt_Memo = "PC 설명";
        deptView.dpt_Depth = 3;
        deptView.dpt_ParentsID = this.dpt_ParentsID;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
      }
      else
      {
        deptView.CreateCode(this.OleDB);
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = string.Format("부서({0})", (object) deptView.dpt_ID);
        deptView.dpt_ViewCode = "70";
        deptView.dpt_Memo = "부서 설명";
        deptView.dpt_Depth = 1;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
        deptView.CreateCode(this.OleDB);
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = "팀({data.dpt_ID})";
        deptView.dpt_ViewCode = "10";
        deptView.dpt_Memo = "팀 설명";
        deptView.dpt_Depth = 2;
        deptView.dpt_ParentsID = this.dpt_ParentsID;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
        deptView.CreateCode(this.OleDB);
        deptView.dpt_SiteID = pSiteID;
        deptView.dpt_DeptName = "PC({data.dpt_ID})";
        deptView.dpt_ViewCode = "10";
        deptView.dpt_Memo = "PC 설명";
        deptView.dpt_Depth = 3;
        deptView.dpt_ParentsID = this.dpt_ParentsID;
        this.OleDB.Execute(deptView.InsertQuery());
        this.dpt_ParentsID = deptView.dpt_ID;
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("dpt_ID"))
          this.dpt_ID = p_rs.GetFieldInt("dpt_ID");
        if (p_rs.IsFieldName("dpt_SiteID"))
          this.dpt_SiteID = p_rs.GetFieldLong("dpt_SiteID");
        if (p_rs.IsFieldName("dpt_DeptName"))
          this.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
        if (p_rs.IsFieldName("dpt_ViewCode"))
          this.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
        if (p_rs.IsFieldName("dpt_Memo"))
          this.dpt_Memo = p_rs.GetFieldString("dpt_Memo");
        if (p_rs.IsFieldName("dpt_UseYn"))
          this.dpt_UseYn = p_rs.GetFieldString("dpt_UseYn");
        if (p_rs.IsFieldName("dpt_Depth"))
          this.dpt_Depth = p_rs.GetFieldInt("dpt_Depth");
        if (p_rs.IsFieldName("dpt_ParentsID"))
          this.dpt_ParentsID = p_rs.GetFieldInt("dpt_ParentsID");
        if (p_rs.IsFieldName("dpt_InDate"))
          this.dpt_InDate = p_rs.GetFieldDateTime("dpt_InDate");
        if (p_rs.IsFieldName("dpt_InUser"))
          this.dpt_InUser = p_rs.GetFieldInt("dpt_InUser");
        if (p_rs.IsFieldName("dpt_ModDate"))
          this.dpt_ModDate = p_rs.GetFieldDateTime("dpt_ModDate");
        if (p_rs.IsFieldName("dpt_ModUser"))
          this.dpt_ModUser = p_rs.GetFieldInt("dpt_ModUser");
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
        IList<DeptCreate> deptCreateList = this.OleDB.Create<DeptCreate>().SelectAllListE<DeptCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (deptCreateList == null)
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
        int count = deptCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (deptCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Dept.ToDescription(), (object) TableCodeType.Dept) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (DeptCreate deptCreate in (IEnumerable<DeptCreate>) deptCreateList)
        {
          stringBuilder.Append(deptCreate.InsertQuery());
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
        DeptView deptView = this.OleDB.Create<DeptView>();
        deptView.dpt_SiteID = 1L;
        deptView.dpt_DeptName = "미등록";
        deptView.dpt_Depth = 0;
        deptView.UpdateExInsert();
        if (deptCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Dept.ToDescription(), (object) TableCodeType.Dept) + "\n--------------------------------------------------------------------------------------------------");
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
