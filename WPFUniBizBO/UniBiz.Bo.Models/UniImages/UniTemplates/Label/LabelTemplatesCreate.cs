// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Label.LabelTemplatesCreate
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

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Label
{
  public class LabelTemplatesCreate : TLabelTemplates, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = LabelTemplatesCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = LabelTemplatesCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_IMAGES, (object) TableCodeType.LabelTemplates) + " ltf_ID BIGINT NOT NULL,ltf_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ltf_Title", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ltf_Url", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ltf_FileName", (object) 100) + ",ltf_ThumbData IMAGE NULL,ltf_OriginData IMAGE NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ltf_OriginHash", (object) 512) + ",ltf_InDate DATETIME NULL,ltf_InUser INT NOT NULL DEFAULT(0),ltf_ModDate DATETIME NULL,ltf_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(ltf_ID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_IMAGES, (object) TableCodeType.LabelTemplates) + " ltf_ID BIGINT NOT NULL,ltf_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ltf_Title", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ltf_Url", (object) 300) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ltf_FileName", (object) 100) + ",ltf_ThumbData MEDIUMBLOB NULL,ltf_OriginData LONGBLOB NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ltf_OriginHash", (object) 512) + ",ltf_InDate DATETIME NULL,ltf_InUser INT NOT NULL DEFAULT 0,ltf_ModDate DATETIME NULL,ltf_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(ltf_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(LabelTemplatesCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.LabelTemplates.ToDescription(), (object) TableCodeType.LabelTemplates));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "ID", (object) TableCodeType.LabelTemplates, (object) "ltf_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.LabelTemplates, (object) "ltf_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "타이틀", (object) TableCodeType.LabelTemplates, (object) "ltf_Title"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "URL", (object) TableCodeType.LabelTemplates, (object) "ltf_Url"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "파일명", (object) TableCodeType.LabelTemplates, (object) "ltf_FileName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "썸네일", (object) TableCodeType.LabelTemplates, (object) "ltf_ThumbData"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "템플릿", (object) TableCodeType.LabelTemplates, (object) "ltf_OriginData"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "템플릿 Hash", (object) TableCodeType.LabelTemplates, (object) "ltf_OriginHash"));
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
        if (p_rs.IsFieldName("ltf_ID"))
          this.ltf_ID = p_rs.GetFieldLong("ltf_ID");
        if (p_rs.IsFieldName("ltf_SiteID"))
          this.ltf_SiteID = p_rs.GetFieldLong("ltf_SiteID");
        if (p_rs.IsFieldName("ltf_Title"))
          this.ltf_Title = p_rs.GetFieldString("ltf_Title");
        if (p_rs.IsFieldName("ltf_Url"))
          this.ltf_Url = p_rs.GetFieldString("ltf_Url");
        if (p_rs.IsFieldName("ltf_FileName"))
          this.ltf_FileName = p_rs.GetFieldString("ltf_FileName");
        if (p_rs.IsFieldName("ltf_ThumbData"))
        {
          if (this.ltf_ThumbData != null)
            this.ltf_ThumbData = (byte[]) null;
          this.ltf_ThumbData = p_rs.GetFieldBytes("ltf_ThumbData");
        }
        if (p_rs.IsFieldName("ltf_OriginData"))
        {
          if (this.ltf_OriginData != null)
            this.ltf_OriginData = (byte[]) null;
          this.ltf_OriginData = p_rs.GetFieldBytes("ltf_OriginData");
        }
        if (p_rs.IsFieldName("ltf_OriginHash"))
          this.ltf_OriginHash = p_rs.GetFieldString("ltf_OriginHash");
        if (p_rs.IsFieldName("ltf_InDate"))
          this.ltf_InDate = p_rs.GetFieldDateTime("ltf_InDate");
        if (p_rs.IsFieldName("ltf_InUser"))
          this.ltf_InUser = p_rs.GetFieldInt("ltf_InUser");
        if (p_rs.IsFieldName("ltf_ModDate"))
          this.ltf_ModDate = p_rs.GetFieldDateTime("ltf_ModDate");
        if (p_rs.IsFieldName("ltf_ModUser"))
          this.ltf_ModUser = p_rs.GetFieldInt("ltf_ModUser");
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
        IList<LabelTemplatesCreate> labelTemplatesCreateList = this.OleDB.Create<LabelTemplatesCreate>().SelectAllListE<LabelTemplatesCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_IMAGES
          }
        });
        if (labelTemplatesCreateList == null)
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
        int count = labelTemplatesCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (labelTemplatesCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.LabelTemplates.ToDescription(), (object) TableCodeType.LabelTemplates) + "\n--------------------------------------------------------------------------------------------------");
        foreach (LabelTemplatesCreate labelTemplatesCreate in (IEnumerable<LabelTemplatesCreate>) labelTemplatesCreateList)
        {
          labelTemplatesCreate.SetAdoDatabase(this.OleDB);
          if (!labelTemplatesCreate.Insert())
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          if (labelTemplatesCreate.IsOriginData)
            labelTemplatesCreate.UpdateFile();
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
          }
        }
        if (labelTemplatesCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.LabelTemplates.ToDescription(), (object) TableCodeType.LabelTemplates) + "\n--------------------------------------------------------------------------------------------------");
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
