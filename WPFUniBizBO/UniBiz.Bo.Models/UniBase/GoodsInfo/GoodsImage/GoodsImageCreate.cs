// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage.GoodsImageCreate
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage
{
  public class GoodsImageCreate : TGoodsImage, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = GoodsImageCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = GoodsImageCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_IMAGES, (object) TableCodeType.GoodsImage) + " gi_GoodsCode BIGINT NOT NULL,gi_SiteID BIGINT NOT NULL DEFAULT(0),gi_ImgType INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gi_ImgFileName", (object) 100) + ",gi_ThumbSize INT NOT NULL DEFAULT(0),gi_ThumbData IMAGE NULL,gi_Thumb2Size INT NOT NULL DEFAULT(0),gi_Thumb2Data IMAGE NULL,gi_Thumb3Size INT NOT NULL DEFAULT(0),gi_Thumb3Data IMAGE NULL,gi_Thumb4Size INT NOT NULL DEFAULT(0),gi_Thumb4Data IMAGE NULL,gi_OriginSize INT NOT NULL DEFAULT(0),gi_OriginData IMAGE NULL,gi_InDate DATETIME NULL,gi_InUser INT NOT NULL DEFAULT(0),gi_ModDate DATETIME NULL,gi_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(gi_GoodsCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_IMAGES, (object) TableCodeType.GoodsImage) + " gi_GoodsCode BIGINT NOT NULL,gi_SiteID BIGINT NOT NULL DEFAULT 0,gi_ImgType INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gi_ImgFileName", (object) 100) + ",gi_ThumbSize INT NOT NULL DEFAULT 0,gi_ThumbData MEDIUMBLOB NULL,gi_Thumb2Size INT NOT NULL DEFAULT 0,gi_Thumb2Data MEDIUMBLOB NULL,gi_Thumb3Size INT NOT NULL DEFAULT 0,gi_Thumb3Data MEDIUMBLOB NULL,gi_Thumb4Size INT NOT NULL DEFAULT 0,gi_Thumb4Data MEDIUMBLOB NULL,gi_OriginSize INT NOT NULL DEFAULT 0,gi_OriginData LONGBLOB NULL,gi_InDate DATETIME NULL,gi_InUser INT NOT NULL DEFAULT 0,gi_ModDate DATETIME NULL,gi_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(gi_GoodsCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(GoodsImageCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.GoodsImage.ToDescription(), (object) TableCodeType.GoodsImage));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품코드", (object) TableCodeType.GoodsImage, (object) "gi_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.GoodsImage, (object) "gi_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "파일명", (object) TableCodeType.GoodsImage, (object) "gi_ImgFileName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이미지타입", (object) TableCodeType.GoodsImage, (object) "gi_ImgType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "썸네일 크기", (object) TableCodeType.GoodsImage, (object) "gi_ThumbSize"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "썸네일", (object) TableCodeType.GoodsImage, (object) "gi_ThumbData"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이미지 크기", (object) TableCodeType.GoodsImage, (object) "gi_OriginSize"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이미지", (object) TableCodeType.GoodsImage, (object) "gi_OriginData"));
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
        if (p_rs.IsFieldName("gi_GoodsCode"))
          this.gi_GoodsCode = p_rs.GetFieldLong("gi_GoodsCode");
        if (p_rs.IsFieldName("gi_SiteID"))
          this.gi_SiteID = p_rs.GetFieldLong("gi_SiteID");
        if (p_rs.IsFieldName("gi_ImgFileName"))
          this.gi_ImgFileName = p_rs.GetFieldString("gi_ImgFileName");
        if (p_rs.IsFieldName("gi_ImgType"))
          this.gi_ImgType = p_rs.GetFieldInt("gi_ImgType");
        if (p_rs.IsFieldName("gi_ThumbSize"))
          this.gi_ThumbSize = p_rs.GetFieldInt("gi_ThumbSize");
        if (p_rs.IsFieldName("gi_ThumbData"))
        {
          if (this.gi_ThumbData != null)
            this.gi_ThumbData = (byte[]) null;
          this.gi_ThumbData = p_rs.GetFieldBytes("gi_ThumbData");
        }
        if (p_rs.IsFieldName("gi_Thumb2Size"))
          this.gi_Thumb2Size = p_rs.GetFieldInt("gi_Thumb2Size");
        if (p_rs.IsFieldName("gi_Thumb2Data"))
        {
          if (this.gi_Thumb2Data != null)
            this.gi_Thumb2Data = (byte[]) null;
          this.gi_Thumb2Data = p_rs.GetFieldBytes("gi_Thumb2Data");
        }
        if (p_rs.IsFieldName("gi_Thumb3Size"))
          this.gi_Thumb3Size = p_rs.GetFieldInt("gi_Thumb3Size");
        if (p_rs.IsFieldName("gi_Thumb3Data"))
        {
          if (this.gi_Thumb3Data != null)
            this.gi_Thumb3Data = (byte[]) null;
          this.gi_Thumb3Data = p_rs.GetFieldBytes("gi_Thumb3Data");
        }
        if (p_rs.IsFieldName("gi_Thumb4Size"))
          this.gi_Thumb4Size = p_rs.GetFieldInt("gi_Thumb4Size");
        if (p_rs.IsFieldName("gi_Thumb4Data"))
        {
          if (this.gi_Thumb4Data != null)
            this.gi_Thumb4Data = (byte[]) null;
          this.gi_Thumb4Data = p_rs.GetFieldBytes("gi_Thumb4Data");
        }
        if (p_rs.IsFieldName("gi_OriginSize"))
          this.gi_OriginSize = p_rs.GetFieldInt("gi_OriginSize");
        if (p_rs.IsFieldName("gi_OriginData"))
        {
          if (this.gi_OriginData != null)
            this.gi_OriginData = (byte[]) null;
          this.gi_OriginData = p_rs.GetFieldBytes("gi_OriginData");
        }
        if (p_rs.IsFieldName("gi_InDate"))
          this.gi_InDate = p_rs.GetFieldDateTime("gi_InDate");
        if (p_rs.IsFieldName("gi_InUser"))
          this.gi_InUser = p_rs.GetFieldInt("gi_InUser");
        if (p_rs.IsFieldName("gi_ModDate"))
          this.gi_ModDate = p_rs.GetFieldDateTime("gi_ModDate");
        if (p_rs.IsFieldName("gi_ModUser"))
          this.gi_ModUser = p_rs.GetFieldInt("gi_ModUser");
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
        IList<GoodsImageCreate> goodsImageCreateList = this.OleDB.Create<GoodsImageCreate>().SelectAllListE<GoodsImageCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_IMAGES
          }
        });
        if (goodsImageCreateList == null)
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
        int count = goodsImageCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (goodsImageCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.GoodsImage.ToDescription(), (object) TableCodeType.GoodsImage) + "\n--------------------------------------------------------------------------------------------------");
        foreach (GoodsImageCreate goodsImageCreate in (IEnumerable<GoodsImageCreate>) goodsImageCreateList)
        {
          goodsImageCreate.SetAdoDatabase(this.OleDB);
          if (!goodsImageCreate.Insert())
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          if (goodsImageCreate.IsOriginData)
            goodsImageCreate.UpdateFile();
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
          }
        }
        if (goodsImageCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.GoodsImage.ToDescription(), (object) TableCodeType.GoodsImage) + "\n--------------------------------------------------------------------------------------------------");
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
