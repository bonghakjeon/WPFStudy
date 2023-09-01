// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.CommonCodeCreate
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

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  public class CommonCodeCreate : TCommonCode, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = CommonCodeCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = CommonCodeCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.CommonCode) + " comm_Type INT NOT NULL,comm_TypeNo INT NOT NULL,comm_SiteID BIGINT NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "comm_TypeMemo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "comm_TypeNoMemo", (object) 50) + ",comm_SortNo INT NOT NULL DEFAULT(1),comm_DataInt INT NOT NULL DEFAULT(0),comm_DataMoney MONEY NOT NULL DEFAULT(0.0000)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "comm_DataString", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "comm_UseYn", (object) 1, (object) "Y") + ",comm_InDate DATETIME NULL,comm_InUser INT NOT NULL DEFAULT(0),comm_ModDate DATETIME NULL,comm_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(comm_Type,comm_TypeNo, comm_SiteID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.CommonCode) + " comm_Type INT NOT NULL,comm_TypeNo INT NOT NULL,comm_SiteID BIGINT NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "comm_TypeMemo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "comm_TypeNoMemo", (object) 50) + ",comm_SortNo INT NOT NULL DEFAULT 1,comm_DataInt INT NOT NULL DEFAULT 0,comm_DataMoney MONEY NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "comm_DataString", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "comm_UseYn", (object) 1, (object) "Y") + ",comm_InDate DATETIME NULL,comm_InUser INT NOT NULL DEFAULT 0,comm_ModDate DATETIME NULL,comm_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(comm_Type,comm_TypeNo, comm_SiteID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(CommonCodeCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.CommonCode.ToDescription(), (object) TableCodeType.CommonCode));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "타입", (object) TableCodeType.CommonCode, (object) "comm_Type"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "코드", (object) TableCodeType.CommonCode, (object) "comm_TypeNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.CommonCode, (object) "comm_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "타입설명", (object) TableCodeType.CommonCode, (object) "comm_TypeMemo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "코드명", (object) TableCodeType.CommonCode, (object) "comm_TypeNoMemo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용상태", (object) TableCodeType.CommonCode, (object) "comm_UseYn"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "순서", (object) TableCodeType.CommonCode, (object) "comm_SortNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "실수형", (object) TableCodeType.CommonCode, (object) "comm_DataMoney"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "정수형", (object) TableCodeType.CommonCode, (object) "comm_DataInt"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "문자형", (object) TableCodeType.CommonCode, (object) "comm_DataString"));
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
      this.InitTableType0(pSiteID);
      this.InitTableType100(pSiteID);
      this.InitTableType200(pSiteID);
      this.InitTableType300(pSiteID);
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("comm_Type"))
          this.comm_Type = p_rs.GetFieldInt("comm_Type");
        if (p_rs.IsFieldName("comm_SiteID"))
          this.comm_SiteID = p_rs.GetFieldLong("comm_SiteID");
        if (p_rs.IsFieldName("comm_TypeNo"))
          this.comm_TypeNo = p_rs.GetFieldInt("comm_TypeNo");
        if (p_rs.IsFieldName("comm_TypeMemo"))
          this.comm_TypeMemo = p_rs.GetFieldString("comm_TypeMemo");
        if (p_rs.IsFieldName("comm_TypeNoMemo"))
          this.comm_TypeNoMemo = p_rs.GetFieldString("comm_TypeNoMemo");
        if (p_rs.IsFieldName("comm_SortNo"))
          this.comm_SortNo = p_rs.GetFieldInt("comm_SortNo");
        if (p_rs.IsFieldName("comm_DataInt"))
          this.comm_DataInt = p_rs.GetFieldInt("comm_DataInt");
        if (p_rs.IsFieldName("comm_DataMoney"))
          this.comm_DataMoney = p_rs.GetFieldDouble("comm_DataMoney");
        if (p_rs.IsFieldName("comm_DataString"))
          this.comm_DataString = p_rs.GetFieldString("comm_DataString");
        if (p_rs.IsFieldName("comm_UseYn"))
          this.comm_UseYn = p_rs.GetFieldString("comm_UseYn");
        if (p_rs.IsFieldName("comm_InDate"))
          this.comm_InDate = p_rs.GetFieldDateTime("comm_InDate");
        if (p_rs.IsFieldName("comm_InUser"))
          this.comm_InUser = p_rs.GetFieldInt("comm_InUser");
        if (p_rs.IsFieldName("comm_ModDate"))
          this.comm_ModDate = p_rs.GetFieldDateTime("comm_ModDate");
        if (p_rs.IsFieldName("comm_ModUser"))
          this.comm_ModUser = p_rs.GetFieldInt("comm_ModUser");
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
        IList<CommonCodeCreate> commonCodeCreateList = this.OleDB.Create<CommonCodeCreate>().SelectAllListE<CommonCodeCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (commonCodeCreateList == null)
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
        int count = commonCodeCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (commonCodeCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.CommonCode.ToDescription(), (object) TableCodeType.CommonCode) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (CommonCodeCreate commonCodeCreate in (IEnumerable<CommonCodeCreate>) commonCodeCreateList)
        {
          stringBuilder.Append(commonCodeCreate.InsertQuery());
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
        if (commonCodeCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.CommonCode.ToDescription(), (object) TableCodeType.CommonCode) + "\n--------------------------------------------------------------------------------------------------");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.DebugColor(this.message);
        return false;
      }
      return true;
    }

    private bool InitTableType0(long pSiteID)
    {
      TCommonCode tcommonCode = this.OleDB.Create<TCommonCode>();
      long num = pSiteID;
      foreach (EnumAppType source in Enum.GetValues(typeof (EnumAppType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 1;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.AppType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumAppType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumOsType source in Enum.GetValues(typeof (EnumOsType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 2;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.OsType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumOsType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDevicePermit source in Enum.GetValues(typeof (EnumDevicePermit)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 3;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DevicePermit.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDevicePermit.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 4;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.UserMenuGroup.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.UserMenuGroup.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 4;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.UserMenuGroup.ToDescription();
      tcommonCode.comm_TypeNoMemo = "시스템관리자";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 4;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.UserMenuGroup.ToDescription();
      tcommonCode.comm_TypeNoMemo = "일반";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumEmpAuth1 source in Enum.GetValues(typeof (EnumEmpAuth1)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 5;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpWorkAuth1.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEmpAuth1.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEmpAuth2 source in Enum.GetValues(typeof (EnumEmpAuth2)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 6;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpWorkAuth2.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEmpAuth2.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEmpAuth3 source in Enum.GetValues(typeof (EnumEmpAuth3)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 7;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpWorkAuth3.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEmpAuth3.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumInOutDiv source in Enum.GetValues(typeof (EnumInOutDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 21;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.InOutDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumInOutDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumStatementType source in Enum.GetValues(typeof (EnumStatementType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 22;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.StatementType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumStatementType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumStoreType source in Enum.GetValues(typeof (EnumStoreType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 30;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.StoreType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumStoreType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 31;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.StoreGroupType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.StoreGroupType.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 31;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.StoreGroupType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "공통";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.Bank.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "한국";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "산업";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "IBK기업";
      tcommonCode.comm_DataString = "중소기업은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "KB국민";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 5;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "하나/외환";
      tcommonCode.comm_DataString = "외한은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 6;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "주택은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 7;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "수협";
      tcommonCode.comm_DataString = "수협중앙회수산업협동조합";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 8;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "축협";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 9;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "NH농협";
      tcommonCode.comm_DataString = "농협중앙회단위농협농ㅇ협단위농협";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 10;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "우리";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 11;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "조흥";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 12;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "SC제일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 13;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "서울";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 14;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "신한";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 15;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "한미";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 16;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "대구";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 17;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "부산";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 18;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "광주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 19;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "전북";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 20;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "제주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 21;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "새마을금고 연합회";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 22;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "MG새마을금고";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 23;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "신용협동조합중앙회";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 24;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "신협";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 25;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "상호저축은행중앙회";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 26;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "외국은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 27;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "씨티";
      tcommonCode.comm_DataString = "(주)한국씨티은행한국 씨티은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 28;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "HSBC";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 29;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "도이치은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 30;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "에이비엔암로은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 31;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "UFJ은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 32;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "미즈호코퍼레이트은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 33;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "도쿄미쓰비시은행";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 34;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "B.O.A";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 35;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "우체국";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 36;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "신보";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 37;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "기술신보";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 32;
      tcommonCode.comm_TypeNo = 38;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Bank.ToDescription();
      tcommonCode.comm_TypeNoMemo = "하나";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumMenuType source in Enum.GetValues(typeof (EnumMenuType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 33;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MenuType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMenuType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMenuDepth source in Enum.GetValues(typeof (EnumMenuDepth)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 34;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MenuDepth.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMenuDepth.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.EmpPosition.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "임원";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "부장";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "차장";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "과장";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 5;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "대리";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 6;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "주임";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 7;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "사원";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 35;
      tcommonCode.comm_TypeNo = 8;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpPosition.ToDescription();
      tcommonCode.comm_TypeNoMemo = "파트타임";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumMenuPropType source in Enum.GetValues(typeof (EnumMenuPropType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 36;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MenuPropType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMenuPropType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMenuPropDepth source in Enum.GetValues(typeof (EnumMenuPropDepth)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 37;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MenuPropDepth.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMenuPropDepth.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDeptDepth source in Enum.GetValues(typeof (EnumDeptDepth)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 38;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeptDepth.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeptDepth.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCategoryDepth source in Enum.GetValues(typeof (EnumCategoryDepth)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 39;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CategoryDepth.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCategoryDepth.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupplierType source in Enum.GetValues(typeof (EnumSupplierType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 40;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupplierType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupplierKind source in Enum.GetValues(typeof (EnumSupplierKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 41;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupplierKind.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumStdPreTax source in Enum.GetValues(typeof (EnumStdPreTax)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 42;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.StdPreTax.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumStdPreTax.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupplierMulti source in Enum.GetValues(typeof (EnumSupplierMulti)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 43;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierMulti.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupplierMulti.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupplierDeductionDayType source in Enum.GetValues(typeof (EnumSupplierDeductionDayType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 44;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierDeductionDayType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupplierDeductionDayType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 45;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierPayMethod.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.SupplierPayMethod.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 45;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierPayMethod.ToDescription();
      tcommonCode.comm_TypeNoMemo = "현금";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 45;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierPayMethod.ToDescription();
      tcommonCode.comm_TypeNoMemo = "어음";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 46;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Nateve.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.Nateve.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 46;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Nateve.ToDescription();
      tcommonCode.comm_TypeNoMemo = "국내산";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 46;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.Nateve.ToDescription();
      tcommonCode.comm_TypeNoMemo = "수입산";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumStatementOrderStatus source in Enum.GetValues(typeof (EnumStatementOrderStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 47;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.OrderStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumStatementOrderStatus.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumStatementConfirmStatus source in Enum.GetValues(typeof (EnumStatementConfirmStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 48;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ConfirmStatusDel.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumStatementConfirmStatus.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumConfirmStatus source in Enum.GetValues(typeof (EnumConfirmStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 49;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ConfirmStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumConfirmStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDeviceType source in Enum.GetValues(typeof (EnumDeviceType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 50;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeviceType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeviceType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTaxDiv source in Enum.GetValues(typeof (EnumTaxDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 51;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TaxDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTaxDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSalesUnit source in Enum.GetValues(typeof (EnumSalesUnit)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 52;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SalesUnit.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSalesUnit.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumStockUnit source in Enum.GetValues(typeof (EnumStockUnit)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 53;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.StockUnit.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumStockUnit.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPackUnit source in Enum.GetValues(typeof (EnumPackUnit)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 54;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PackUnit.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPackUnit.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumGoodsAddProperty source in Enum.GetValues(typeof (EnumGoodsAddProperty)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 55;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.GoodsAddProperty.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGoodsAddProperty.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.ABCType.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "A";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "B";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "C";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "D";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 5;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "E";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 56;
      tcommonCode.comm_TypeNo = 6;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ABCType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "F";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 57;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.StorageDiv.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.StorageDiv.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 57;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.StorageDiv.ToDescription();
      tcommonCode.comm_TypeNoMemo = "상온";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 57;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.StorageDiv.ToDescription();
      tcommonCode.comm_TypeNoMemo = "냉장";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 57;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.StorageDiv.ToDescription();
      tcommonCode.comm_TypeNoMemo = "냉동";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumGoodsHistoryDiv source in Enum.GetValues(typeof (EnumGoodsHistoryDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 58;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.GoodsHistoryDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGoodsHistoryDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTransmitStatus source in Enum.GetValues(typeof (EnumTransmitStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 59;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TransmitStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTransmitStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumInnerDeliveryDiv source in Enum.GetValues(typeof (EnumInnerDeliveryDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 60;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.InnerDeliveryDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumInnerDeliveryDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumLocLocationType source in Enum.GetValues(typeof (EnumLocLocationType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 61;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LocLocationType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLocLocationType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumLocPermitDiv source in Enum.GetValues(typeof (EnumLocPermitDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 62;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LocPermitDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLocPermitDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumLocLevel source in Enum.GetValues(typeof (EnumLocLevel)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 63;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LocLevel.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLocLevel.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumWriteType source in Enum.GetValues(typeof (EnumWriteType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 68;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.WriteType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumWriteType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPaymentStatementDiv source in Enum.GetValues(typeof (EnumPaymentStatementDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 69;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentStatementDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPaymentStatementDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 70;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentCustom2.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PaymentCustom2.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 70;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentCustom2.ToDescription();
      tcommonCode.comm_TypeNoMemo = "타입A";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 70;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentCustom2.ToDescription();
      tcommonCode.comm_TypeNoMemo = "타입B";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 71;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentCustom1.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PaymentCustom1.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 71;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentCustom1.ToDescription();
      tcommonCode.comm_TypeNoMemo = "타입1";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 71;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentCustom1.ToDescription();
      tcommonCode.comm_TypeNoMemo = "타입2";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumPayStatementStatus source in Enum.GetValues(typeof (EnumPayStatementStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 72;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PayStatementStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPayStatementStatus.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 73;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentRound.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PaymentRound.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 73;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentRound.ToDescription();
      tcommonCode.comm_TypeNoMemo = "월1회";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 73;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentRound.ToDescription();
      tcommonCode.comm_TypeNoMemo = "월2회";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 73;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentRound.ToDescription();
      tcommonCode.comm_TypeNoMemo = "월3회";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 74;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentTurn.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PaymentTurn.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 74;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentTurn.ToDescription();
      tcommonCode.comm_TypeNoMemo = "1차";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 74;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentTurn.ToDescription();
      tcommonCode.comm_TypeNoMemo = "2차";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 74;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentTurn.ToDescription();
      tcommonCode.comm_TypeNoMemo = "3차";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PaymentDay.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 5;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "5일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 7;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "7일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 9;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "9일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 10;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "10일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 15;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "15일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 17;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "17일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 18;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "18일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 20;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "20일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 22;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "22일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 24;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "24일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 25;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "25일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 28;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "28일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 75;
      tcommonCode.comm_TypeNo = 99;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PaymentDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "말일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumDeductionAutoType source in Enum.GetValues(typeof (EnumDeductionAutoType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 76;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeductionType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeductionAutoType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 76;
      tcommonCode.comm_TypeNo = 51;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeductionType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "기타공제";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumDeductionAutoType source in Enum.GetValues(typeof (EnumDeductionAutoType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 77;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeductionAutoType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeductionAutoType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDeductionAutoCalc source in Enum.GetValues(typeof (EnumDeductionAutoCalc)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 78;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeductionAutoCalc.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeductionAutoCalc.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupRebateStdDate source in Enum.GetValues(typeof (EnumSupRebateStdDate)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 79;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupRebateStdDate.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupRebateStdDate.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupRebateStdAmount source in Enum.GetValues(typeof (EnumSupRebateStdAmount)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 80;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupRebateStdAmount.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupRebateStdAmount.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPosType source in Enum.GetValues(typeof (EnumPosType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 81;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PosType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPosType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPosInfoAddProperty source in Enum.GetValues(typeof (EnumPosInfoAddProperty)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 82;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PosInfoAddProperty.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPosInfoAddProperty.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumConditionDay source in Enum.GetValues(typeof (EnumConditionDay)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 90;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ConditionDay.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumConditionDay.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumConditionDayType source in Enum.GetValues(typeof (EnumConditionDayType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 91;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ConditionDayType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumConditionDayType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumAppResult source in Enum.GetValues(typeof (EnumAppResult)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 92;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ApprResult.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumAppResult.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      return true;
    }

    public bool InitTableType100(long pSiteID)
    {
      TCommonCode tcommonCode = this.OleDB.Create<TCommonCode>();
      long num = pSiteID;
      foreach (EnumGender source in Enum.GetValues(typeof (EnumGender)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 100;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.Gender.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGender.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMonthCalendarType source in Enum.GetValues(typeof (EnumMonthCalendarType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 101;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MonthCalendarType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMonthCalendarType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumFileExtension enumFileExtension in Enum.GetValues(typeof (EnumFileExtension)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 102;
        tcommonCode.comm_TypeNo = (int) enumFileExtension;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.FileExtension.ToDescription();
        tcommonCode.comm_TypeNoMemo = enumFileExtension.ToString();
        tcommonCode.comm_SortNo = enumFileExtension == EnumFileExtension.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSupplierImageKind source in Enum.GetValues(typeof (EnumSupplierImageKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 103;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SupplierImageKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSupplierImageKind.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 106;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderSafeIndices.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.AutoOrderSafeIndices.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 106;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderSafeIndices.ToDescription();
      tcommonCode.comm_TypeNoMemo = "95%";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.comm_DataMoney = 1.65;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 106;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderSafeIndices.ToDescription();
      tcommonCode.comm_TypeNoMemo = "97.73%";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.comm_DataMoney = 2.0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 106;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderSafeIndices.ToDescription();
      tcommonCode.comm_TypeNoMemo = "98%";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.comm_DataMoney = 2.05;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 106;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderSafeIndices.ToDescription();
      tcommonCode.comm_TypeNoMemo = "99%";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.comm_DataMoney = 2.33;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.AutoOrderRefDay.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "2주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "3주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "4주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "5주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 5;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "6주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 6;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "7주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 107;
      tcommonCode.comm_TypeNo = 7;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderRefDay.ToDescription();
      tcommonCode.comm_TypeNoMemo = "8주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 108;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderCycle.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.AutoOrderCycle.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 108;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderCycle.ToDescription();
      tcommonCode.comm_TypeNoMemo = "1주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 108;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderCycle.ToDescription();
      tcommonCode.comm_TypeNoMemo = "2주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 108;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderCycle.ToDescription();
      tcommonCode.comm_TypeNoMemo = "3주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 108;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderCycle.ToDescription();
      tcommonCode.comm_TypeNoMemo = "4주";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 109;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderInvoiceType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.AutoOrderInvoiceType.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 109;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderInvoiceType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "1번";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 109;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.AutoOrderInvoiceType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "2번";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 110;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.LeadTime.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.LeadTime.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 110;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.LeadTime.ToDescription();
      tcommonCode.comm_TypeNoMemo = "+1일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 110;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.LeadTime.ToDescription();
      tcommonCode.comm_TypeNoMemo = "+2일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 110;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.LeadTime.ToDescription();
      tcommonCode.comm_TypeNoMemo = "+3일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 110;
      tcommonCode.comm_TypeNo = 4;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.LeadTime.ToDescription();
      tcommonCode.comm_TypeNoMemo = "+4일";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumEventType source in Enum.GetValues(typeof (EnumEventType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 115;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EventType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEventType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEventTarget source in Enum.GetValues(typeof (EnumEventTarget)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 116;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EventTarget.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEventTarget.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEventAddPointDiv source in Enum.GetValues(typeof (EnumEventAddPointDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 117;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EventAddPointDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEventAddPointDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEventSlipType source in Enum.GetValues(typeof (EnumEventSlipType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 120;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EventSlipType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEventSlipType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSlipTextType source in Enum.GetValues(typeof (EnumSlipTextType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 130;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SlipTextType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSlipTextType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSlipTextAlign source in Enum.GetValues(typeof (EnumSlipTextAlign)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 140;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SlipTextAlign.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSlipTextAlign.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSlipTextFormat source in Enum.GetValues(typeof (EnumSlipTextFormat)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 150;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SlipTextFormat.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSlipTextFormat.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumProgOptionType source in Enum.GetValues(typeof (EnumProgOptionType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 152;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ProgOptionType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumProgOptionType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumProgOptionValueType source in Enum.GetValues(typeof (EnumProgOptionValueType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 153;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ProgOptionValueType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumProgOptionValueType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumGiftCardIssuer source in Enum.GetValues(typeof (EnumGiftCardIssuer)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 154;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftCardIssuer.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGiftCardIssuer.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumGiftCardSaleKind source in Enum.GetValues(typeof (EnumGiftCardSaleKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 155;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftCardSaleKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGiftCardSaleKind.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumInventoryApplyType source in Enum.GetValues(typeof (EnumInventoryApplyType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 156;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.InventoryApplyType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumInventoryApplyType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrSaleType source in Enum.GetValues(typeof (EnumTrSaleType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 157;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrSaleType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrSaleType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrTransType source in Enum.GetValues(typeof (EnumTrTransType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 158;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrTransType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrTransType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrTransKind source in Enum.GetValues(typeof (EnumTrTransKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 159;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrTransKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrTransKind.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrItemKind source in Enum.GetValues(typeof (EnumTrItemKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 160;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrItemKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrItemKind.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrItemType source in Enum.GetValues(typeof (EnumTrItemType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 161;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrItemType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrItemType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrItemStatus source in Enum.GetValues(typeof (EnumTrItemStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 162;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrItemStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrItemStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrApprovalKind source in Enum.GetValues(typeof (EnumTrApprovalKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 163;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ApprovalKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrApprovalKind.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPayID source in Enum.GetValues(typeof (EnumPayID)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 164;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PayID.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPayID.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPosApprovalKind source in Enum.GetValues(typeof (EnumPosApprovalKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 165;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PosApprovalKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPosApprovalKind.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrItemDcType source in Enum.GetValues(typeof (EnumTrItemDcType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 166;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrItemDcType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrItemDcType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumVanType source in Enum.GetValues(typeof (EnumVanType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 167;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.VanType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumVanType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCardCompType source in Enum.GetValues(typeof (EnumCardCompType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 168;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CardCompType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCardCompType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrDeliveryType source in Enum.GetValues(typeof (EnumTrDeliveryType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 169;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrDeliveryType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrDeliveryType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumAppSendType source in Enum.GetValues(typeof (EnumAppSendType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 170;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ApprSendType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumAppSendType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCashReceiptAuth source in Enum.GetValues(typeof (EnumCashReceiptAuth)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 171;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CashReceiptAuth.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCashReceiptAuth.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPosApprovalStatus source in Enum.GetValues(typeof (EnumPosApprovalStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 172;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PosApprovalStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPosApprovalStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTdDcKindType source in Enum.GetValues(typeof (EnumTdDcKindType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 173;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrItemDcKindType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTdDcKindType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTdDcValueDiv source in Enum.GetValues(typeof (EnumTdDcValueDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 174;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrItemDcValueDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTdDcValueDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTrStatus source in Enum.GetValues(typeof (EnumTrStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 175;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TrTransStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTrStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberStatus source in Enum.GetValues(typeof (EnumMemberStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 181;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMemberStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberPointExtinctionAgree source in Enum.GetValues(typeof (EnumMemberPointExtinctionAgree)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 182;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberPointExtinctionAgree.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMemberPointExtinctionAgree.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCashReceiptDiv source in Enum.GetValues(typeof (EnumCashReceiptDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 183;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CashReceiptDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCashReceiptDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSmsSendAgree source in Enum.GetValues(typeof (EnumSmsSendAgree)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 184;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SmsSendAgree.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSmsSendAgree.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberCardType source in Enum.GetValues(typeof (EnumMemberCardType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 185;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberCardType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMemberCardType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberCycle source in Enum.GetValues(typeof (EnumMemberCycle)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 186;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberCycle.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMemberCycle.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 187;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftItemType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.GiftItemType.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 187;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftItemType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "상품권";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 187;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftItemType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "현금";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 187;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftItemType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "상품";
      tcommonCode.comm_SortNo = 3;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 188;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PointHistoryType.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 188;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "사용";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 188;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "소멸";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 189;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryPointType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-" + EnumCommonCodeType.PointHistoryPointType.ToDescription() + "-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 189;
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryPointType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "일반";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 189;
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryPointType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "수기";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 189;
      tcommonCode.comm_TypeNo = 3;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointHistoryPointType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "이벤트";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumGiftGiveStatus source in Enum.GetValues(typeof (EnumGiftGiveStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 190;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.GiftGiveStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGiftGiveStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberCalcCycleDiv source in Enum.GetValues(typeof (EnumMemberCalcCycleDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 191;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberCalcCycleDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMemberCalcCycleDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberTaxBillCycle source in Enum.GetValues(typeof (EnumMemberTaxBillCycle)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 192;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberTaxBillCycle.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMemberTaxBillCycle.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTaxBillType source in Enum.GetValues(typeof (EnumTaxBillType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 193;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TaxBillType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTaxBillType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTaxBillTypeCode source in Enum.GetValues(typeof (EnumTaxBillTypeCode)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 194;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TaxBillTypeCode.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTaxBillTypeCode.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumTaxBillStatementDiv source in Enum.GetValues(typeof (EnumTaxBillStatementDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 195;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TaxBillStatementDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTaxBillStatementDiv.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMemberAgeGroup source in Enum.GetValues(typeof (EnumMemberAgeGroup)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 196;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberAgeGroup.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = (int) source;
        switch (source)
        {
          case EnumMemberAgeGroup.NONE:
            tcommonCode.comm_DataInt = -1;
            tcommonCode.comm_DataString = "-1";
            break;
          case EnumMemberAgeGroup.AGE_10:
            tcommonCode.comm_DataInt = 10;
            tcommonCode.comm_DataString = "19";
            break;
          case EnumMemberAgeGroup.AGE_20:
            tcommonCode.comm_DataInt = 20;
            tcommonCode.comm_DataString = "29";
            break;
          case EnumMemberAgeGroup.AGE_30:
            tcommonCode.comm_DataInt = 30;
            tcommonCode.comm_DataString = "39";
            break;
          case EnumMemberAgeGroup.AGE_40:
            tcommonCode.comm_DataInt = 40;
            tcommonCode.comm_DataString = "49";
            break;
          case EnumMemberAgeGroup.AGE_50:
            tcommonCode.comm_DataInt = 50;
            tcommonCode.comm_DataString = "59";
            break;
          case EnumMemberAgeGroup.AGE_60:
            tcommonCode.comm_DataInt = 60;
            tcommonCode.comm_DataString = "99";
            break;
          case EnumMemberAgeGroup.AGE_ERR:
            tcommonCode.comm_DataInt = 0;
            tcommonCode.comm_DataString = "9";
            break;
        }
        tcommonCode.Insert();
      }
      foreach (EnumMemberBuyCycleGroup source in Enum.GetValues(typeof (EnumMemberBuyCycleGroup)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 197;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MemberBuyCycleGroup.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = (int) source;
        switch (source)
        {
          case EnumMemberBuyCycleGroup.NONE:
            tcommonCode.comm_DataInt = -1;
            tcommonCode.comm_DataString = "-1";
            break;
          case EnumMemberBuyCycleGroup.CYCLE_1:
            tcommonCode.comm_DataInt = 1;
            tcommonCode.comm_DataString = "7";
            break;
          case EnumMemberBuyCycleGroup.CYCLE_2:
            tcommonCode.comm_DataInt = 8;
            tcommonCode.comm_DataString = "14";
            break;
          case EnumMemberBuyCycleGroup.CYCLE_3:
            tcommonCode.comm_DataInt = 15;
            tcommonCode.comm_DataString = "21";
            break;
          case EnumMemberBuyCycleGroup.CYCLE_4:
            tcommonCode.comm_DataInt = 22;
            tcommonCode.comm_DataString = "28";
            break;
          case EnumMemberBuyCycleGroup.CYCLE_8:
            tcommonCode.comm_DataInt = 29;
            tcommonCode.comm_DataString = "56";
            break;
          case EnumMemberBuyCycleGroup.CYCLE_10:
            tcommonCode.comm_DataInt = 57;
            tcommonCode.comm_DataString = "999";
            break;
        }
        tcommonCode.Insert();
      }
      return true;
    }

    public bool InitTableType200(long pSiteID)
    {
      TCommonCode tcommonCode = this.OleDB.Create<TCommonCode>();
      long num = pSiteID;
      foreach (EnumEodInfoType source in Enum.GetValues(typeof (EnumEodInfoType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 211;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EodInfoType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEodInfoType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEodInfoStatus source in Enum.GetValues(typeof (EnumEodInfoStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 212;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EodInfoStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEodInfoStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDbNameType source in Enum.GetValues(typeof (EnumDbNameType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 213;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DbNameType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDbNameType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPromotionKind source in Enum.GetValues(typeof (EnumPromotionKind)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 221;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PromotionKind.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPromotionKind.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPromotionType source in Enum.GetValues(typeof (EnumPromotionType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 222;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PromotionType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPromotionType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPromotionDiv source in Enum.GetValues(typeof (EnumPromotionDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 223;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PromotionDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPromotionDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPromotionTargetGroup source in Enum.GetValues(typeof (EnumPromotionTargetGroup)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 224;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PromotionTargetGroup.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPromotionTargetGroup.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumOperatorAndOr source in Enum.GetValues(typeof (EnumOperatorAndOr)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 225;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.OperatorAndOr.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumOperatorAndOr.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumApplyDiv source in Enum.GetValues(typeof (EnumApplyDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 226;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ApplyDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumApplyDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCouponType source in Enum.GetValues(typeof (EnumCouponType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 227;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CouponType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCouponType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCouponApply source in Enum.GetValues(typeof (EnumCouponApply)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 228;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CouponApply.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCouponApply.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCouponStatus source in Enum.GetValues(typeof (EnumCouponStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 229;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CouponStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCouponStatus.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCouponApplyDiv source in Enum.GetValues(typeof (EnumCouponApplyDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 230;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CouponApplyDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCouponApplyDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCampaignType source in Enum.GetValues(typeof (EnumCampaignType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 231;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CampaignType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCampaignType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCampaignTargetCodeType source in Enum.GetValues(typeof (EnumCampaignTargetCodeType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 232;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CampaignTargetCodeType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCampaignTargetCodeType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumEmpJob source in Enum.GetValues(typeof (EnumEmpJob)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 233;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpJob.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumEmpJob.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumResignStatus source in Enum.GetValues(typeof (EnumResignStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 234;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.EmpResignStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumResignStatus.None ? 0 : 1;
        tcommonCode.Insert();
      }
      return true;
    }

    public bool InitTableType300(long pSiteID)
    {
      TCommonCode tcommonCode = this.OleDB.Create<TCommonCode>();
      long num = pSiteID;
      foreach (EnumLotteSendStatusDiv source in Enum.GetValues(typeof (EnumLotteSendStatusDiv)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 301;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteSendStatusDiv.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLotteSendStatusDiv.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumLotteNotiType source in Enum.GetValues(typeof (EnumLotteNotiType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 302;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteNotiType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLotteNotiType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumLotteResultCodeType source in Enum.GetValues(typeof (EnumLotteResultCodeType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 303;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteResultCodeType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLotteResultCodeType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSmsPayType source in Enum.GetValues(typeof (EnumSmsPayType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 304;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SmsPayType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSmsPayType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumSiteType source in Enum.GetValues(typeof (EnumSiteType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 305;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.SiteType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumSiteType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumUserAuth source in Enum.GetValues(typeof (EnumUserAuth)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 306;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.UserAuth.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumUserAuth.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDeliveryMovingStatus source in Enum.GetValues(typeof (EnumDeliveryMovingStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 307;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeliveryMovingStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeliveryMovingStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDeliverySendStatus source in Enum.GetValues(typeof (EnumDeliverySendStatus)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 308;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeliverySendStatus.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeliverySendStatus.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPointRateMntType source in Enum.GetValues(typeof (EnumPointRateMntType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 309;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointRateMntType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPointRateMntType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumDeliveryPrtForm source in Enum.GetValues(typeof (EnumDeliveryPrtForm)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 310;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeliveryPrtForm.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeliveryPrtForm.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumClosingPrtForm source in Enum.GetValues(typeof (EnumClosingPrtForm)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 311;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.ClosingPrtForm.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumClosingPrtForm.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPackageStore source in Enum.GetValues(typeof (EnumPackageStore)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 312;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PackageStore.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPackageStore.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumCashReceiptType source in Enum.GetValues(typeof (EnumCashReceiptType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 313;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CashReceiptType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCashReceiptType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPointPassWordType source in Enum.GetValues(typeof (EnumPointPassWordType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 314;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointPassWordType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPointPassWordType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPointMemberNameDispType source in Enum.GetValues(typeof (EnumPointMemberNameDispType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 315;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointMemberNameDispType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPointMemberNameDispType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumPointMemberListDispType source in Enum.GetValues(typeof (EnumPointMemberListDispType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 316;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.PointMemberListDispType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumPointMemberListDispType.NONE ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMessageReqType source in Enum.GetValues(typeof (EnumMessageReqType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 317;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MessageReqType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMessageReqType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumLotteTemplateStatue source in Enum.GetValues(typeof (EnumLotteTemplateStatue)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 320;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteTemplateStatue.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        switch (source)
        {
          case EnumLotteTemplateStatue.None:
            tcommonCode.comm_SortNo = 0;
            break;
          case EnumLotteTemplateStatue.Approved:
            tcommonCode.comm_SortNo = 4;
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
          case EnumLotteTemplateStatue.InspectionKakao:
            tcommonCode.comm_SortNo = 3;
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
          case EnumLotteTemplateStatue.InspectionLotte:
            tcommonCode.comm_SortNo = 2;
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
          case EnumLotteTemplateStatue.Companion:
            tcommonCode.comm_SortNo = 5;
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
          case EnumLotteTemplateStatue.Receipt:
            tcommonCode.comm_SortNo = 1;
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
          default:
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
        }
        tcommonCode.Insert();
      }
      foreach (EnumLotteTemplateMessageType source in Enum.GetValues(typeof (EnumLotteTemplateMessageType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 321;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteTemplateMessageType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLotteTemplateMessageType.None ? 0 : 1;
        tcommonCode.comm_DataString = source.ToString();
        tcommonCode.Insert();
      }
      foreach (EnumLotteTemplateEmphasizeType source in Enum.GetValues(typeof (EnumLotteTemplateEmphasizeType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 322;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteTemplateEmphasizeType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLotteTemplateEmphasizeType.None ? 0 : 1;
        tcommonCode.comm_DataString = source.ToString();
        tcommonCode.Insert();
      }
      foreach (EnumLotteKakaoButtonType source in Enum.GetValues(typeof (EnumLotteKakaoButtonType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 323;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteKakaoButtonType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        switch (source)
        {
          case EnumLotteKakaoButtonType.NONE:
            tcommonCode.comm_SortNo = 0;
            break;
          case EnumLotteKakaoButtonType.WL:
          case EnumLotteKakaoButtonType.AL:
          case EnumLotteKakaoButtonType.DS:
          case EnumLotteKakaoButtonType.BK:
          case EnumLotteKakaoButtonType.MD:
          case EnumLotteKakaoButtonType.BC:
          case EnumLotteKakaoButtonType.BT:
          case EnumLotteKakaoButtonType.AC:
            tcommonCode.comm_SortNo = 1;
            tcommonCode.comm_DataString = source.ToString();
            break;
          default:
            tcommonCode.comm_DataString = Convert.ToChar((int) source).ToString();
            break;
        }
        tcommonCode.Insert();
      }
      foreach (EnumDeliveryOrderByType source in Enum.GetValues(typeof (EnumDeliveryOrderByType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 324;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.DeliveryOrderBy.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumDeliveryOrderByType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumGoodsEventDisplayType source in Enum.GetValues(typeof (EnumGoodsEventDisplayType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 325;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.GoodsEventDisplay.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumGoodsEventDisplayType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 326;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.DamagedReasonType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-파손사유-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeNoMemo = "기타";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeNoMemo = "기타2";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumTermsOfUseType source in Enum.GetValues(typeof (EnumTermsOfUseType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 327;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.TermsOfUseType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumTermsOfUseType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 328;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.ComplaintType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-컴플레인 사유-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeNoMemo = "기타";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeNoMemo = "기타2";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 329;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.CommonImageType.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-공통이미지-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeNoMemo = "기타";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 2;
      tcommonCode.comm_TypeNoMemo = "배너이미지";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumCategoryBannerType source in Enum.GetValues(typeof (EnumCategoryBannerType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 330;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.CategoryBannerType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumCategoryBannerType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      foreach (EnumMallMainStartPageType source in Enum.GetValues(typeof (EnumMallMainStartPageType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 331;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.MallMainStartPageType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumMallMainStartPageType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      tcommonCode.Clear();
      tcommonCode.comm_SiteID = num;
      tcommonCode.comm_Type = 332;
      tcommonCode.comm_TypeNo = 0;
      tcommonCode.comm_TypeMemo = EnumCommonCodeType.MallOrderRequest.ToDescription();
      tcommonCode.comm_TypeNoMemo = "-주문 요청 사항-";
      tcommonCode.comm_SortNo = 0;
      tcommonCode.Insert();
      tcommonCode.comm_TypeNo = 1;
      tcommonCode.comm_TypeNoMemo = "거스름돈 준비해 주세요";
      tcommonCode.comm_SortNo = 1;
      tcommonCode.Insert();
      foreach (EnumLotteNoticeTemplateType source in Enum.GetValues(typeof (EnumLotteNoticeTemplateType)))
      {
        tcommonCode.Clear();
        tcommonCode.comm_SiteID = num;
        tcommonCode.comm_Type = 333;
        tcommonCode.comm_TypeNo = (int) source;
        tcommonCode.comm_TypeMemo = EnumCommonCodeType.LotteNoticeTemplateType.ToDescription();
        tcommonCode.comm_TypeNoMemo = source.ToDescription();
        tcommonCode.comm_SortNo = source == EnumLotteNoticeTemplateType.None ? 0 : 1;
        tcommonCode.Insert();
      }
      return true;
    }
  }
}
