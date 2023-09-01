// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Category.CategoryCreate
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
using UniBiz.Bo.Models.UniBase.Dept;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Category
{
  public class CategoryCreate : TCategory, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = CategoryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = CategoryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Category) + " ctg_ID INT NOT NULL,ctg_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ctg_CategoryName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ctg_ViewCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ctg_Memo", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "ctg_UseYn", (object) 1, (object) "Y") + ",ctg_Depth INT NOT NULL DEFAULT(0),ctg_ParentsID INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "ctg_DepositYn", (object) 1, (object) "N") + ",ctg_AddProperty INT NOT NULL DEFAULT(0),ctg_InDate DATETIME NULL,ctg_InUser INT NOT NULL DEFAULT(0),ctg_ModDate DATETIME NULL,ctg_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(ctg_ID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Category) + " ctg_ID INT NOT NULL,ctg_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ctg_CategoryName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ctg_ViewCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ctg_Memo", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "ctg_UseYn", (object) 1, (object) "Y") + ",ctg_Depth INT NOT NULL DEFAULT 0,ctg_ParentsID INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "ctg_DepositYn", (object) 1, (object) "N") + ",ctg_AddProperty INT NOT NULL DEFAULT 0,ctg_InDate DATETIME NULL,ctg_InUser INT NOT NULL DEFAULT 0,ctg_ModDate DATETIME NULL,ctg_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(ctg_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(CategoryCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Category.ToDescription(), (object) TableCodeType.Category));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "분류ID", (object) TableCodeType.Category, (object) "ctg_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Category, (object) "ctg_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "소분류명", (object) TableCodeType.Category, (object) "ctg_CategoryName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "소분류코드", (object) TableCodeType.Category, (object) "ctg_ViewCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "분류설명", (object) TableCodeType.Category, (object) "ctg_Memo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용상태", (object) TableCodeType.Category, (object) "ctg_UseYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "저장품", (object) TableCodeType.Category, (object) "ctg_DepositYn"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "분류단계", (object) 39, (object) TableCodeType.Category, (object) "ctg_Depth"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상위분류", (object) TableCodeType.Category, (object) "ctg_ParentsID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "속성타입", (object) TableCodeType.Category, (object) "ctg_AddProperty"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.Category, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Category) + " (ctg_Depth,ctg_ID,ctg_ParentsID)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_1 ON {1}.dbo.{2} ({3},{4});", (object) TableCodeType.Category, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Category, (object) "ctg_Depth", (object) "ctg_ID"));
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_2 ON {1}.dbo.{2} ({3},{4},{5});", (object) TableCodeType.Category, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Category, (object) "ctg_Depth", (object) "ctg_ID", (object) "ctg_ParentsID"));
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
      CategoryView categoryView = this.OleDB.Create<CategoryView>();
      if (pSiteID == 1L)
      {
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = "미등록";
        categoryView.ctg_Depth = 0;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
        IList<DeptView> deptViewList = this.OleDB.Create<DeptView>().SelectListE<DeptView>((object) new Hashtable()
        {
          {
            (object) "dpt_Depth",
            (object) 3
          },
          {
            (object) "dpt_SiteID",
            (object) pSiteID
          }
        });
        if (deptViewList != null && deptViewList.Count > 0)
          this.ctg_ParentsID = deptViewList[0].dpt_ID;
        categoryView.ctg_ID = 1;
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = "대분류";
        categoryView.ctg_ViewCode = "10";
        categoryView.ctg_Memo = "분류 설명";
        categoryView.ctg_Depth = 1;
        categoryView.ctg_ParentsID = this.ctg_ParentsID;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
        categoryView.ctg_ID = 2;
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = "중분류";
        categoryView.ctg_ViewCode = "10";
        categoryView.ctg_Memo = "중분류 설명";
        categoryView.ctg_Depth = 2;
        categoryView.ctg_ParentsID = this.ctg_ParentsID;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
        categoryView.ctg_ID = 3;
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = "소분류";
        categoryView.ctg_ViewCode = "10";
        categoryView.ctg_Memo = "소분류 설명";
        categoryView.ctg_Depth = 3;
        categoryView.ctg_ParentsID = this.ctg_ParentsID;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
      }
      else
      {
        IList<DeptView> deptViewList = this.OleDB.Create<DeptView>().SelectListE<DeptView>((object) new Hashtable()
        {
          {
            (object) "dpt_Depth",
            (object) 3
          },
          {
            (object) "dpt_SiteID",
            (object) pSiteID
          }
        });
        if (deptViewList != null && deptViewList.Count > 0)
          this.ctg_ParentsID = deptViewList[0].dpt_ID;
        categoryView.CreateCode(this.OleDB);
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = string.Format("대분류({0})", (object) categoryView.ctg_ID);
        categoryView.ctg_ViewCode = "10";
        categoryView.ctg_Memo = "대분류 설명";
        categoryView.ctg_Depth = 1;
        categoryView.ctg_ParentsID = this.ctg_ParentsID;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
        categoryView.CreateCode(this.OleDB);
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = string.Format("중분류({0})", (object) categoryView.ctg_ID);
        categoryView.ctg_ViewCode = "10";
        categoryView.ctg_Memo = "중분류 설명";
        categoryView.ctg_Depth = 2;
        categoryView.ctg_ParentsID = this.ctg_ParentsID;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
        categoryView.CreateCode(this.OleDB);
        categoryView.ctg_SiteID = pSiteID;
        categoryView.ctg_CategoryName = string.Format("소분류({0})", (object) categoryView.ctg_ID);
        categoryView.ctg_ViewCode = "10";
        categoryView.ctg_Memo = "소분류 설명";
        categoryView.ctg_Depth = 3;
        categoryView.ctg_ParentsID = this.ctg_ParentsID;
        this.OleDB.Execute(categoryView.InsertQuery());
        this.ctg_ParentsID = categoryView.ctg_ID;
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("ctg_ID"))
          this.ctg_ID = p_rs.GetFieldInt("ctg_ID");
        if (p_rs.IsFieldName("ctg_SiteID"))
          this.ctg_SiteID = p_rs.GetFieldLong("ctg_SiteID");
        if (p_rs.IsFieldName("ctg_CategoryName"))
          this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
        if (p_rs.IsFieldName("ctg_ViewCode"))
          this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
        if (p_rs.IsFieldName("ctg_Memo"))
          this.ctg_Memo = p_rs.GetFieldString("ctg_Memo");
        if (p_rs.IsFieldName("ctg_UseYn"))
          this.ctg_UseYn = p_rs.GetFieldString("ctg_UseYn");
        if (p_rs.IsFieldName("ctg_DepositYn"))
          this.ctg_DepositYn = p_rs.GetFieldString("ctg_DepositYn");
        if (p_rs.IsFieldName("ctg_Depth"))
          this.ctg_Depth = p_rs.GetFieldInt("ctg_Depth");
        if (p_rs.IsFieldName("ctg_ParentsID"))
          this.ctg_ParentsID = p_rs.GetFieldInt("ctg_ParentsID");
        if (p_rs.IsFieldName("ctg_AddProperty"))
          this.ctg_AddProperty = p_rs.GetFieldInt("ctg_AddProperty");
        if (p_rs.IsFieldName("ctg_InDate"))
          this.ctg_InDate = p_rs.GetFieldDateTime("ctg_InDate");
        if (p_rs.IsFieldName("ctg_InUser"))
          this.ctg_InUser = p_rs.GetFieldInt("ctg_InUser");
        if (p_rs.IsFieldName("ctg_ModDate"))
          this.ctg_ModDate = p_rs.GetFieldDateTime("ctg_ModDate");
        if (p_rs.IsFieldName("ctg_ModUser"))
          this.ctg_ModUser = p_rs.GetFieldInt("ctg_ModUser");
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
        IList<CategoryCreate> categoryCreateList = this.OleDB.Create<CategoryCreate>().SelectAllListE<CategoryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (categoryCreateList == null)
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
        int count = categoryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (categoryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Category.ToDescription(), (object) TableCodeType.Category) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (CategoryCreate categoryCreate in (IEnumerable<CategoryCreate>) categoryCreateList)
        {
          stringBuilder.Append(categoryCreate.InsertQuery());
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
        CategoryView categoryView = this.OleDB.Create<CategoryView>();
        categoryView.ctg_SiteID = 1L;
        categoryView.ctg_CategoryName = "미등록";
        categoryView.ctg_Depth = 0;
        categoryView.UpdateExInsert();
        if (categoryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Category.ToDescription(), (object) TableCodeType.Category) + "\n--------------------------------------------------------------------------------------------------");
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
