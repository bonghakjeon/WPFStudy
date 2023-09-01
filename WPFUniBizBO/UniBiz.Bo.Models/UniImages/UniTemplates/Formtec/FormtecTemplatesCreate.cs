// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Formtec.FormtecTemplatesCreate
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

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Formtec
{
  public class FormtecTemplatesCreate : TFormtecTemplates, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = FormtecTemplatesCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = FormtecTemplatesCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_IMAGES, (object) TableCodeType.FormtecTemplates) + " ftf_ID BIGINT NOT NULL,ftf_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ftf_Title", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ftf_Url", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ftf_FileName", (object) 100) + ",ftf_ThumbData IMAGE NULL,ftf_OriginData IMAGE NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ftf_OriginHash", (object) 512) + ",ftf_InDate DATETIME NULL,ftf_InUser INT NOT NULL DEFAULT(0),ftf_ModDate DATETIME NULL,ftf_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(ftf_ID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_IMAGES, (object) TableCodeType.FormtecTemplates) + " ftf_ID BIGINT NOT NULL,ftf_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ftf_Title", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ftf_Url", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ftf_FileName", (object) 100) + ",ftf_ThumbData MEDIUMBLOB NULL,ftf_OriginData LONGBLOB NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ftf_OriginHash", (object) 512) + ",ftf_InDate DATETIME NULL,ftf_InUser INT NOT NULL DEFAULT 0,ftf_ModDate DATETIME NULL,ftf_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(ftf_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(FormtecTemplatesCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_IMAGES, (object) this.TableCode)))
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
        string str = "EXEC " + UbModelBase.UNI_IMAGES + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.FormtecTemplates.ToDescription(), (object) TableCodeType.FormtecTemplates));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "ID", (object) TableCodeType.FormtecTemplates, (object) "ftf_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.FormtecTemplates, (object) "ftf_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "타이틀", (object) TableCodeType.FormtecTemplates, (object) "ftf_Title"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "URL", (object) TableCodeType.FormtecTemplates, (object) "ftf_Url"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "파일명", (object) TableCodeType.FormtecTemplates, (object) "ftf_FileName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "썸네일", (object) TableCodeType.FormtecTemplates, (object) "ftf_ThumbData"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "템플릿", (object) TableCodeType.FormtecTemplates, (object) "ftf_OriginData"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "템플릿 Hash", (object) TableCodeType.FormtecTemplates, (object) "ftf_OriginHash"));
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

    public bool InitTable() => true;

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
        if (p_rs.IsFieldName("ftf_ID"))
          this.ftf_ID = p_rs.GetFieldLong("ftf_ID");
        if (p_rs.IsFieldName("ftf_SiteID"))
          this.ftf_SiteID = p_rs.GetFieldLong("ftf_SiteID");
        if (p_rs.IsFieldName("ftf_Title"))
          this.ftf_Title = p_rs.GetFieldString("ftf_Title");
        if (p_rs.IsFieldName("ftf_Url"))
          this.ftf_Url = p_rs.GetFieldString("ftf_Url");
        if (p_rs.IsFieldName("ftf_FileName"))
          this.ftf_FileName = p_rs.GetFieldString("ftf_FileName");
        if (p_rs.IsFieldName("ftf_ThumbData"))
        {
          if (this.ftf_ThumbData != null)
            this.ftf_ThumbData = (byte[]) null;
          this.ftf_ThumbData = p_rs.GetFieldBytes("ftf_ThumbData");
        }
        if (p_rs.IsFieldName("ftf_OriginData"))
        {
          if (this.ftf_OriginData != null)
            this.ftf_OriginData = (byte[]) null;
          this.ftf_OriginData = p_rs.GetFieldBytes("ftf_OriginData");
        }
        if (p_rs.IsFieldName("ftf_OriginHash"))
          this.ftf_OriginHash = p_rs.GetFieldString("ftf_OriginHash");
        if (p_rs.IsFieldName("ftf_InDate"))
          this.ftf_InDate = p_rs.GetFieldDateTime("ftf_InDate");
        if (p_rs.IsFieldName("ftf_InUser"))
          this.ftf_InUser = p_rs.GetFieldInt("ftf_InUser");
        if (p_rs.IsFieldName("ftf_ModDate"))
          this.ftf_ModDate = p_rs.GetFieldDateTime("ftf_ModDate");
        if (p_rs.IsFieldName("ftf_ModUser"))
          this.ftf_ModUser = p_rs.GetFieldInt("ftf_ModUser");
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
        IList<FormtecTemplatesCreate> formtecTemplatesCreateList = this.OleDB.Create<FormtecTemplatesCreate>().SelectAllListE<FormtecTemplatesCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_IMAGES
          }
        });
        if (formtecTemplatesCreateList == null)
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
        int count = formtecTemplatesCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (formtecTemplatesCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.FormtecTemplates.ToDescription(), (object) TableCodeType.FormtecTemplates) + "\n--------------------------------------------------------------------------------------------------");
        foreach (FormtecTemplatesCreate formtecTemplatesCreate in (IEnumerable<FormtecTemplatesCreate>) formtecTemplatesCreateList)
        {
          formtecTemplatesCreate.SetAdoDatabase(this.OleDB);
          if (!formtecTemplatesCreate.Insert())
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          if (formtecTemplatesCreate.IsOriginData)
            formtecTemplatesCreate.UpdateFile();
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
          }
        }
        if (formtecTemplatesCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.FormtecTemplates.ToDescription(), (object) TableCodeType.FormtecTemplates) + "\n--------------------------------------------------------------------------------------------------");
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
