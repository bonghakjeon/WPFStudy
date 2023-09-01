// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ColStyle.ColStyleCreate
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

namespace UniBiz.Bo.Models.UniBase.ColStyle
{
  public class ColStyleCreate : TColStyle, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = ColStyleCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = ColStyleCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ColStyle) + " cs_Code INT NOT NULL,cs_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cs_Name", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cs_Desc", (object) 200) + ",cs_Width INT NOT NULL DEFAULT(0),cs_Align INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "cs_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "cs_Foreground", (object) 10) + ",cs_BackgroundR INT NOT NULL DEFAULT(0),cs_BackgroundG INT NOT NULL DEFAULT(0),cs_BackgroundB INT NOT NULL DEFAULT(0),cs_BackgroundOpacity MONEY NOT NULL DEFAULT(0.0),cs_Bold INT NOT NULL DEFAULT(0),cs_Italic INT NOT NULL DEFAULT(0),cs_AddProperty INT NOT NULL DEFAULT(0),cs_InDate DATETIME NULL,cs_InUser INT NOT NULL DEFAULT(0),cs_ModDate DATETIME NULL,cs_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(cs_Code,cs_SiteID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ColStyle) + " cs_Code INT NOT NULL,cs_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cs_Name", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cs_Desc", (object) 200) + ",cs_Width INT NOT NULL DEFAULT 0,cs_Align INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "cs_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "cs_Foreground", (object) 10) + ",cs_BackgroundR INT NOT NULL DEFAULT 0,cs_BackgroundG INT NOT NULL DEFAULT 0,cs_BackgroundB INT NOT NULL DEFAULT 0,cs_BackgroundOpacity DECIMAL(19,4) NOT NULL DEFAULT 0.0,cs_Bold INT NOT NULL DEFAULT 0,cs_Italic INT NOT NULL DEFAULT 0,cs_AddProperty INT NOT NULL DEFAULT 0,cs_InDate DATETIME NULL,cs_InUser INT NOT NULL DEFAULT 0,cs_ModDate DATETIME NULL,cs_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(cs_Code,cs_SiteID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(ColStyleCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.ColStyle.ToDescription(), (object) TableCodeType.ColStyle));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "컬럼 코드", (object) TableCodeType.ColStyle, (object) "cs_Code"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.ColStyle, (object) "cs_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "컬럼명", (object) TableCodeType.ColStyle, (object) "cs_Name"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "컬럼명 설명", (object) TableCodeType.ColStyle, (object) "cs_Desc"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용상태", (object) TableCodeType.ColStyle, (object) "cs_UseYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "전경색", (object) TableCodeType.ColStyle, (object) "cs_Foreground"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배경색 RED", (object) TableCodeType.ColStyle, (object) "cs_BackgroundR"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배경색 GREEN", (object) TableCodeType.ColStyle, (object) "cs_BackgroundG"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배경색 BLUE", (object) TableCodeType.ColStyle, (object) "cs_BackgroundB"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "배경색 투명도", (object) TableCodeType.ColStyle, (object) "cs_BackgroundOpacity"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "컬럼 정렬", (object) TableCodeType.ColStyle, (object) "cs_Align"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "글꼴 굵기", (object) TableCodeType.ColStyle, (object) "cs_Bold"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "글꼴 기울기", (object) TableCodeType.ColStyle, (object) "cs_Italic"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "속성타입", (object) TableCodeType.ColStyle, (object) "cs_AddProperty"));
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
        if (p_rs.IsFieldName("cs_Code"))
          this.cs_Code = p_rs.GetFieldInt("cs_Code");
        if (p_rs.IsFieldName("cs_SiteID"))
          this.cs_SiteID = p_rs.GetFieldLong("cs_SiteID");
        if (p_rs.IsFieldName("cs_Name"))
          this.cs_Name = p_rs.GetFieldString("cs_Name");
        if (p_rs.IsFieldName("cs_Desc"))
          this.cs_Desc = p_rs.GetFieldString("cs_Desc");
        if (p_rs.IsFieldName("cs_UseYn"))
          this.cs_UseYn = p_rs.GetFieldString("cs_UseYn");
        if (p_rs.IsFieldName("cs_Foreground"))
          this.cs_Foreground = p_rs.GetFieldString("cs_Foreground");
        if (p_rs.IsFieldName("cs_BackgroundR"))
          this.cs_BackgroundR = p_rs.GetFieldInt("cs_BackgroundR");
        if (p_rs.IsFieldName("cs_BackgroundG"))
          this.cs_BackgroundG = p_rs.GetFieldInt("cs_BackgroundG");
        if (p_rs.IsFieldName("cs_BackgroundB"))
          this.cs_BackgroundB = p_rs.GetFieldInt("cs_BackgroundB");
        if (p_rs.IsFieldName("cs_BackgroundOpacity"))
          this.cs_BackgroundOpacity = p_rs.GetFieldDouble("cs_BackgroundOpacity");
        if (p_rs.IsFieldName("cs_Align"))
          this.cs_Align = p_rs.GetFieldInt("cs_Align");
        if (p_rs.IsFieldName("cs_Bold"))
          this.cs_Bold = p_rs.GetFieldInt("cs_Bold");
        if (p_rs.IsFieldName("cs_Italic"))
          this.cs_Italic = p_rs.GetFieldInt("cs_Italic");
        if (p_rs.IsFieldName("cs_AddProperty"))
          this.cs_AddProperty = p_rs.GetFieldInt("cs_AddProperty");
        if (p_rs.IsFieldName("cs_InDate"))
          this.cs_InDate = p_rs.GetFieldDateTime("cs_InDate");
        if (p_rs.IsFieldName("cs_InUser"))
          this.cs_InUser = p_rs.GetFieldInt("cs_InUser");
        if (p_rs.IsFieldName("cs_ModDate"))
          this.cs_ModDate = p_rs.GetFieldDateTime("cs_ModDate");
        if (p_rs.IsFieldName("cs_ModUser"))
          this.cs_ModUser = p_rs.GetFieldInt("cs_ModUser");
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
        IList<ColStyleCreate> colStyleCreateList = this.OleDB.Create<ColStyleCreate>().SelectAllListE<ColStyleCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (colStyleCreateList == null)
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
        int count = colStyleCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (colStyleCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.ColStyle.ToDescription(), (object) TableCodeType.ColStyle) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ColStyleCreate colStyleCreate in (IEnumerable<ColStyleCreate>) colStyleCreateList)
        {
          stringBuilder.Append(colStyleCreate.InsertQuery());
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
        if (colStyleCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.ColStyle.ToDescription(), (object) TableCodeType.ColStyle) + "\n--------------------------------------------------------------------------------------------------");
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
