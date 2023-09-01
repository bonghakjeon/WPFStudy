// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark.ProgMenuBookMarkCreate
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark
{
  public class ProgMenuBookMarkCreate : TProgMenuBookMark, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = ProgMenuBookMarkCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = ProgMenuBookMarkCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenuBookMark) + " pmbm_ID BIGINT NOT NULL,pmbm_SiteID BIGINT NOT NULL DEFAULT(0),pmbm_Parent BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pmbm_AppType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pmbm_ViewType", (object) 0) + ",pmbm_EmpCode INT NOT NULL DEFAULT(0),pmbm_MenuCode INT NOT NULL DEFAULT(0),pmbm_Order INT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pmbm_Depth", (object) 0) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pmbm_Title", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pmbm_Desc", (object) 500) + ",pmbm_InDate DATETIME NULL,pmbm_ModDate DATETIME NULL PRIMARY KEY(pmbm_ID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenuBookMark) + " pmbm_ID BIGINT NOT NULL,pmbm_SiteID BIGINT NOT NULL DEFAULT 0,pmbm_Parent INT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pmbm_AppType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pmbm_ViewType", (object) 0) + ",pmbm_EmpCode INT NOT NULL DEFAULT 0,pmbm_MenuCode INT NOT NULL DEFAULT 0,pmbm_Order INT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pmbm_Depth", (object) 0) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pmbm_Title", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pmbm_Desc", (object) 500) + ",pmbm_InDate DATETIME NULL,pmbm_ModDate DATETIME NULL PRIMARY KEY(pmbm_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(ProgMenuBookMarkCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.ProgMenuBookMark.ToDescription(), (object) TableCodeType.ProgMenuBookMark));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "ID", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "부모", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_Parent"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "프로그램 종류", (object) 1, (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_AppType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "뷰타입", (object) 33, (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_ViewType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용자 코드", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_EmpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메뉴 코드", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_MenuCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "순서", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_Order"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "단계", (object) 34, (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_Depth"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "즐겨찿기", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_Title"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "설명", (object) TableCodeType.ProgMenuBookMark, (object) "pmbm_Desc"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.ProgMenuBookMark, (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenuBookMark) + " (pmbm_SiteID,pmbm_AppType,pmbm_EmpCode,pmbm_Depth,pmbm_MenuCode)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        if (this.OleDB.Execute(stringBuilder.ToString()))
          return true;
        this.message = " " + this.TableCode.ToDescription() + " 주석 Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.DebugColor(this.message);
        return false;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
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
        if (p_rs.IsFieldName("pmbm_ID"))
          this.pmbm_ID = p_rs.GetFieldLong("pmbm_ID");
        if (p_rs.IsFieldName("pmbm_SiteID"))
          this.pmbm_SiteID = p_rs.GetFieldLong("pmbm_SiteID");
        if (p_rs.IsFieldName("pmbm_Parent"))
          this.pmbm_Parent = p_rs.GetFieldLong("pmbm_Parent");
        if (p_rs.IsFieldName("pmbm_AppType"))
          this.pmbm_AppType = p_rs.GetFieldInt("pmbm_AppType");
        if (p_rs.IsFieldName("pmbm_ViewType"))
          this.pmbm_ViewType = p_rs.GetFieldInt("pmbm_ViewType");
        if (p_rs.IsFieldName("pmbm_EmpCode"))
          this.pmbm_EmpCode = p_rs.GetFieldInt("pmbm_EmpCode");
        if (p_rs.IsFieldName("pmbm_MenuCode"))
          this.pmbm_MenuCode = p_rs.GetFieldInt("pmbm_MenuCode");
        if (p_rs.IsFieldName("pmbm_Order"))
          this.pmbm_Order = p_rs.GetFieldInt("pmbm_Order");
        if (p_rs.IsFieldName("pmbm_Depth"))
          this.pmbm_Depth = p_rs.GetFieldInt("pmbm_Depth");
        if (p_rs.IsFieldName("pmbm_Title"))
          this.pmbm_Title = p_rs.GetFieldString("pmbm_Title");
        if (p_rs.IsFieldName("pmbm_Desc"))
          this.pmbm_Desc = p_rs.GetFieldString("pmbm_Desc");
        if (p_rs.IsFieldName("pmbm_InDate"))
          this.pmbm_InDate = p_rs.GetFieldDateTime("pmbm_InDate");
        if (p_rs.IsFieldName("pmbm_ModDate"))
          this.pmbm_ModDate = p_rs.GetFieldDateTime("pmbm_ModDate");
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
        IList<ProgMenuBookMarkCreate> menuBookMarkCreateList = this.OleDB.Create<ProgMenuBookMarkCreate>().SelectAllListE<ProgMenuBookMarkCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (menuBookMarkCreateList == null)
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
        int count = menuBookMarkCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (menuBookMarkCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.ProgMenuBookMark.ToDescription(), (object) TableCodeType.ProgMenuBookMark) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ProgMenuBookMarkCreate menuBookMarkCreate in (IEnumerable<ProgMenuBookMarkCreate>) menuBookMarkCreateList)
        {
          stringBuilder.Append(menuBookMarkCreate.InsertQuery());
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
        if (menuBookMarkCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.ProgMenuBookMark.ToDescription(), (object) TableCodeType.ProgMenuBookMark) + "\n--------------------------------------------------------------------------------------------------");
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
