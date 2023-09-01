// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Maker.MakerCreate
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

namespace UniBiz.Bo.Models.UniBase.Maker
{
  public class MakerCreate : TMaker, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MakerCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MakerCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Maker) + " mk_MakerCode INT NOT NULL,mk_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mk_MakerName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mk_MakerFullName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "mk_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mk_Memo", (object) 200) + ",mk_InDate DATETIME NULL,mk_InUser INT NOT NULL DEFAULT(0),mk_ModDate DATETIME NULL,mk_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mk_MakerCode ASC) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Maker) + " mk_MakerCode INT NOT NULL,mk_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mk_MakerName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mk_MakerFullName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "mk_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mk_Memo", (object) 200) + ",mk_InDate DATETIME NULL,mk_InUser INT NOT NULL DEFAULT 0,mk_ModDate DATETIME NULL,mk_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mk_MakerCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MakerCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Maker.ToDescription(), (object) TableCodeType.Maker));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "제조사코드", (object) TableCodeType.Maker, (object) "mk_MakerCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.Maker, (object) "mk_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "제조사명", (object) TableCodeType.Maker, (object) "mk_MakerName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "제조사명(전체)", (object) TableCodeType.Maker, (object) "mk_MakerFullName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용상태", (object) TableCodeType.Maker, (object) "mk_UseYn"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "메모", (object) TableCodeType.Maker, (object) "mk_Memo"));
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
      MakerView makerView = this.OleDB.Create<MakerView>();
      if (pSiteID == 1L)
      {
        makerView.mk_SiteID = pSiteID;
        makerView.mk_MakerName = "미등록";
        makerView.mk_MakerFullName = "미등록";
        if (this.OleDB.Execute(makerView.InsertQuery()))
          ;
      }
      else
      {
        makerView.CreateCode(this.OleDB);
        makerView.mk_SiteID = pSiteID;
        makerView.mk_MakerName = string.Format("TEST({0})", (object) makerView.mk_MakerCode);
        makerView.mk_MakerFullName = "TEST";
        this.OleDB.Execute(makerView.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("mk_MakerCode"))
          this.mk_MakerCode = p_rs.GetFieldInt("mk_MakerCode");
        if (p_rs.IsFieldName("mk_SiteID"))
          this.mk_SiteID = p_rs.GetFieldLong("mk_SiteID");
        if (p_rs.IsFieldName("mk_MakerName"))
          this.mk_MakerName = p_rs.GetFieldString("mk_MakerName");
        if (p_rs.IsFieldName("mk_MakerFullName"))
          this.mk_MakerFullName = p_rs.GetFieldString("mk_MakerFullName");
        if (p_rs.IsFieldName("mk_UseYn"))
          this.mk_UseYn = p_rs.GetFieldString("mk_UseYn");
        if (p_rs.IsFieldName("mk_Memo"))
          this.mk_Memo = p_rs.GetFieldString("mk_Memo");
        if (p_rs.IsFieldName("mk_InDate"))
          this.mk_InDate = p_rs.GetFieldDateTime("mk_InDate");
        if (p_rs.IsFieldName("mk_InUser"))
          this.mk_InUser = p_rs.GetFieldInt("mk_InUser");
        if (p_rs.IsFieldName("mk_ModDate"))
          this.mk_ModDate = p_rs.GetFieldDateTime("mk_ModDate");
        if (p_rs.IsFieldName("mk_ModUser"))
          this.mk_ModUser = p_rs.GetFieldInt("mk_ModUser");
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
        IList<MakerCreate> makerCreateList = this.OleDB.Create<MakerCreate>().SelectAllListE<MakerCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (makerCreateList == null)
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
        int count = makerCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (makerCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Maker.ToDescription(), (object) TableCodeType.Maker) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MakerCreate makerCreate in (IEnumerable<MakerCreate>) makerCreateList)
        {
          stringBuilder.Append(makerCreate.InsertQuery());
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
        MakerView makerView = this.OleDB.Create<MakerView>();
        makerView.mk_SiteID = 1L;
        makerView.mk_MakerName = "미등록";
        makerView.mk_MakerFullName = "미등록";
        makerView.UpdateExInsert();
        if (makerCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Maker.ToDescription(), (object) TableCodeType.Maker) + "\n--------------------------------------------------------------------------------------------------");
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
