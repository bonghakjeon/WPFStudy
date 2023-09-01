// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierImage.SupplierImageCreate
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

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierImage
{
  public class SupplierImageCreate : TSupplierImage, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = SupplierImageCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = SupplierImageCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.SupplierImage) + " sui_ID INT NOT NULL,sui_SiteID BIGINT NOT NULL DEFAULT(0),sui_Supplier INT NOT NULL DEFAULT(0),sui_Kind INT NOT NULL DEFAULT(0),sui_ImgType INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "sui_ImgFileName", (object) 100) + ",sui_ThumbSize INT NOT NULL DEFAULT(0),sui_ThumbData IMAGE NULL,sui_OriginSize INT NOT NULL DEFAULT(0),sui_OriginData IMAGE NULL,sui_InDate DATETIME NULL,sui_InUser INT NOT NULL DEFAULT(0),sui_ModDate DATETIME NULL,sui_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(sui_ID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.SupplierImage) + " sui_ID INT NOT NULL,sui_SiteID BIGINT NOT NULL DEFAULT 0,sui_Supplier INT NOT NULL DEFAULT 0,sui_Kind INT NOT NULL DEFAULT 0,sui_ImgType INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "sui_ImgFileName", (object) 100) + ",sui_ThumbSize INT NOT NULL DEFAULT 0,sui_ThumbData MEDIUMBLOB NULL,sui_OriginSize INT NOT NULL DEFAULT 0,sui_OriginData LONGBLOB NULL,sui_InDate DATETIME NULL,sui_InUser INT NOT NULL DEFAULT 0,sui_ModDate DATETIME NULL,sui_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(sui_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(SupplierImageCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.SupplierImage.ToDescription(), (object) TableCodeType.SupplierImage));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업체 이미지", (object) TableCodeType.SupplierImage, (object) "sui_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.SupplierImage, (object) "sui_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "코드", (object) TableCodeType.SupplierImage, (object) "sui_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이미지 종류", (object) TableCodeType.SupplierImage, (object) "sui_Kind"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "파일 타입", (object) TableCodeType.SupplierImage, (object) "sui_ImgType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "파일명", (object) TableCodeType.SupplierImage, (object) "sui_ImgFileName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "썸네일 사이즈", (object) TableCodeType.SupplierImage, (object) "sui_ThumbSize"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "썸네일", (object) TableCodeType.SupplierImage, (object) "sui_ThumbData"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "원본 사이즈", (object) TableCodeType.SupplierImage, (object) "sui_OriginSize"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "원본", (object) TableCodeType.SupplierImage, (object) "sui_OriginData"));
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

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("sui_ID"))
          this.sui_ID = p_rs.GetFieldInt("sui_ID");
        if (p_rs.IsFieldName("sui_SiteID"))
          this.sui_SiteID = p_rs.GetFieldLong("sui_SiteID");
        if (p_rs.IsFieldName("sui_Supplier"))
          this.sui_Supplier = p_rs.GetFieldInt("sui_Supplier");
        if (p_rs.IsFieldName("sui_Kind"))
          this.sui_Kind = p_rs.GetFieldInt("sui_Kind");
        if (p_rs.IsFieldName("sui_ImgType"))
          this.sui_ImgType = p_rs.GetFieldInt("sui_ImgType");
        if (p_rs.IsFieldName("sui_ImgFileName"))
          this.sui_ImgFileName = p_rs.GetFieldString("sui_ImgFileName");
        if (p_rs.IsFieldName("sui_ThumbSize"))
          this.sui_ThumbSize = p_rs.GetFieldInt("sui_ThumbSize");
        if (p_rs.IsFieldName("sui_ThumbData"))
        {
          if (this.sui_ThumbData != null)
            this.sui_ThumbData = (byte[]) null;
          this.sui_ThumbData = p_rs.GetFieldBytes("sui_ThumbData");
        }
        if (p_rs.IsFieldName("sui_OriginSize"))
          this.sui_OriginSize = p_rs.GetFieldInt("sui_OriginSize");
        if (p_rs.IsFieldName("sui_OriginData"))
        {
          if (this.sui_OriginData != null)
            this.sui_OriginData = (byte[]) null;
          this.sui_OriginData = p_rs.GetFieldBytes("sui_OriginData");
        }
        if (p_rs.IsFieldName("sui_InDate"))
          this.sui_InDate = p_rs.GetFieldDateTime("sui_InDate");
        if (p_rs.IsFieldName("sui_InUser"))
          this.sui_InUser = p_rs.GetFieldInt("sui_InUser");
        if (p_rs.IsFieldName("sui_ModDate"))
          this.sui_ModDate = p_rs.GetFieldDateTime("sui_ModDate");
        if (p_rs.IsFieldName("sui_ModUser"))
          this.sui_ModUser = p_rs.GetFieldInt("sui_ModUser");
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
        IList<SupplierImageCreate> supplierImageCreateList = this.OleDB.Create<SupplierImageCreate>().SelectAllListE<SupplierImageCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (string.IsNullOrEmpty("aa"))
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
        int count = supplierImageCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (supplierImageCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.SupplierImage.ToDescription(), (object) TableCodeType.SupplierImage) + "\n--------------------------------------------------------------------------------------------------");
        foreach (SupplierImageCreate supplierImageCreate in (IEnumerable<SupplierImageCreate>) supplierImageCreateList)
        {
          supplierImageCreate.SetAdoDatabase(this.OleDB);
          if (!supplierImageCreate.Insert())
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          if (supplierImageCreate.IsOriginData)
            supplierImageCreate.UpdateFile();
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
          }
        }
        if (supplierImageCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.SupplierImage.ToDescription(), (object) TableCodeType.SupplierImage) + "\n--------------------------------------------------------------------------------------------------");
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
