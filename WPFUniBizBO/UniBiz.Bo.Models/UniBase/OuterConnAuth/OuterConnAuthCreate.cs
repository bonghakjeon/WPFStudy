// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.OuterConnAuthCreate
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

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  public class OuterConnAuthCreate : TOuterConnAuth, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = OuterConnAuthCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = OuterConnAuthCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.OuterConnAuth) + " oca_ID INT NOT NULL,oca_SiteID BIGINT NOT NULL DEFAULT(0),oca_ProgKind INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_ProgVer", (object) 100) + ",oca_StoreCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_DeviceName", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_DeviceKey", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_DeviceIpInfo", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_RealIp4", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_Gateway", (object) 20) + ",oca_DevicePort INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_BaseUrl", (object) 200) + ",oca_Count INT NOT NULL DEFAULT(0),oca_Status INT NOT NULL DEFAULT(0),oca_ExpireDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_Memo", (object) 500) + ",oca_OsType INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "oca_OsVersion", (object) 200) + ",oca_AddProperty INT NOT NULL DEFAULT(0),oca_InDate DATETIME NULL,oca_InUser INT NOT NULL DEFAULT(0),oca_ModDate DATETIME NULL,oca_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(oca_ID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.OuterConnAuth) + " oca_ID INT NOT NULL,oca_SiteID BIGINT NOT NULL DEFAULT 0,oca_ProgKind INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_ProgVer", (object) 100) + ",oca_StoreCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_DeviceName", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_DeviceKey", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_DeviceIpInfo", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_RealIp4", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_Gateway", (object) 20) + ",oca_DevicePort INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_BaseUrl", (object) 200) + ",oca_Count INT NOT NULL DEFAULT 0,oca_Status INT NOT NULL DEFAULT 0,oca_ExpireDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_Memo", (object) 500) + ",oca_OsType INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "oca_OsVersion", (object) 200) + ",oca_AddProperty INT NOT NULL DEFAULT 0,oca_InDate DATETIME NULL,oca_InUser INT NOT NULL DEFAULT 0,oca_ModDate DATETIME NULL,oca_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(oca_ID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(OuterConnAuthCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.OuterConnAuth.ToDescription(), (object) TableCodeType.OuterConnAuth));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "장치 코드", (object) TableCodeType.OuterConnAuth, (object) "oca_ID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.OuterConnAuth, (object) "oca_SiteID"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "APP ID", (object) 1, (object) TableCodeType.OuterConnAuth, (object) "oca_ProgKind"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "APP VER", (object) TableCodeType.OuterConnAuth, (object) "oca_ProgVer"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점", (object) TableCodeType.OuterConnAuth, (object) "oca_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "장치명", (object) TableCodeType.OuterConnAuth, (object) "oca_DeviceName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "장치키", (object) TableCodeType.OuterConnAuth, (object) "oca_DeviceKey"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "IP INFO", (object) TableCodeType.OuterConnAuth, (object) "oca_DeviceIpInfo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "IP4", (object) TableCodeType.OuterConnAuth, (object) "oca_RealIp4"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "Gateway", (object) TableCodeType.OuterConnAuth, (object) "oca_Gateway"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "장치 포트", (object) TableCodeType.OuterConnAuth, (object) "oca_DevicePort"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "기본 주소", (object) TableCodeType.OuterConnAuth, (object) "oca_BaseUrl"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "접속 카운트", (object) TableCodeType.OuterConnAuth, (object) "oca_Count"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "허용 상태", (object) 3, (object) TableCodeType.OuterConnAuth, (object) "oca_Status"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "만료일", (object) TableCodeType.OuterConnAuth, (object) "oca_ExpireDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.OuterConnAuth, (object) "oca_Memo"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "OS TYPE", (object) 2, (object) TableCodeType.OuterConnAuth, (object) "oca_OsType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "OS VER", (object) TableCodeType.OuterConnAuth, (object) "oca_OsVersion"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "속성타입", (object) TableCodeType.OuterConnAuth, (object) "oca_AddProperty"));
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
      OuterConnAuthView outerConnAuthView = this.OleDB.Create<OuterConnAuthView>();
      if (pSiteID == 1L)
      {
        outerConnAuthView.oca_SiteID = pSiteID;
        outerConnAuthView.oca_DeviceName = "미등록";
        outerConnAuthView.oca_DeviceKey = "미등록";
        outerConnAuthView.oca_Status = 3;
        this.OleDB.Execute(outerConnAuthView.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("oca_ID"))
          this.oca_ID = p_rs.GetFieldInt("oca_ID");
        if (p_rs.IsFieldName("oca_SiteID"))
          this.oca_SiteID = p_rs.GetFieldLong("oca_SiteID");
        if (p_rs.IsFieldName("oca_ProgKind"))
          this.oca_ProgKind = p_rs.GetFieldInt("oca_ProgKind");
        if (p_rs.IsFieldName("oca_ProgVer"))
          this.oca_ProgVer = p_rs.GetFieldString("oca_ProgVer");
        if (p_rs.IsFieldName("oca_StoreCode"))
          this.oca_StoreCode = p_rs.GetFieldInt("oca_StoreCode");
        if (p_rs.IsFieldName("oca_DeviceName"))
          this.oca_DeviceName = p_rs.GetFieldString("oca_DeviceName");
        if (p_rs.IsFieldName("oca_DeviceKey"))
          this.oca_DeviceKey = p_rs.GetFieldString("oca_DeviceKey");
        if (p_rs.IsFieldName("oca_DeviceIpInfo"))
          this.oca_DeviceIpInfo = p_rs.GetFieldString("oca_DeviceIpInfo");
        if (p_rs.IsFieldName("oca_RealIp4"))
          this.oca_RealIp4 = p_rs.GetFieldString("oca_RealIp4");
        if (p_rs.IsFieldName("oca_Gateway"))
          this.oca_Gateway = p_rs.GetFieldString("oca_Gateway");
        if (p_rs.IsFieldName("oca_DevicePort"))
          this.oca_DevicePort = p_rs.GetFieldInt("oca_DevicePort");
        if (p_rs.IsFieldName("oca_BaseUrl"))
          this.oca_BaseUrl = p_rs.GetFieldString("oca_BaseUrl");
        if (p_rs.IsFieldName("oca_Count"))
          this.oca_Count = p_rs.GetFieldInt("oca_Count");
        if (p_rs.IsFieldName("oca_Status"))
          this.oca_Status = p_rs.GetFieldInt("oca_Status");
        if (p_rs.IsFieldName("oca_ExpireDate"))
          this.oca_ExpireDate = p_rs.GetFieldDateTime("oca_ExpireDate");
        if (p_rs.IsFieldName("oca_Memo"))
          this.oca_Memo = p_rs.GetFieldString("oca_Memo");
        if (p_rs.IsFieldName("oca_OsType"))
          this.oca_OsType = p_rs.GetFieldInt("oca_OsType");
        if (p_rs.IsFieldName("oca_OsVersion"))
          this.oca_OsVersion = p_rs.GetFieldString("oca_OsVersion");
        if (p_rs.IsFieldName("oca_AddProperty"))
          this.oca_AddProperty = p_rs.GetFieldInt("oca_AddProperty");
        if (p_rs.IsFieldName("oca_InDate"))
          this.oca_InDate = p_rs.GetFieldDateTime("oca_InDate");
        if (p_rs.IsFieldName("oca_InUser"))
          this.oca_InUser = p_rs.GetFieldInt("oca_InUser");
        if (p_rs.IsFieldName("oca_ModDate"))
          this.oca_ModDate = p_rs.GetFieldDateTime("oca_ModDate");
        if (p_rs.IsFieldName("oca_ModUser"))
          this.oca_ModUser = p_rs.GetFieldInt("oca_ModUser");
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
        IList<OuterConnAuthCreate> outerConnAuthCreateList = this.OleDB.Create<OuterConnAuthCreate>().SelectAllListE<OuterConnAuthCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (outerConnAuthCreateList == null)
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
        int count = outerConnAuthCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (outerConnAuthCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.OuterConnAuth.ToDescription(), (object) TableCodeType.OuterConnAuth) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (OuterConnAuthCreate outerConnAuthCreate in (IEnumerable<OuterConnAuthCreate>) outerConnAuthCreateList)
        {
          stringBuilder.Append(outerConnAuthCreate.InsertQuery());
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
        OuterConnAuthView outerConnAuthView = this.OleDB.Create<OuterConnAuthView>();
        outerConnAuthView.oca_SiteID = 1L;
        outerConnAuthView.oca_DeviceName = "미등록";
        outerConnAuthView.oca_DeviceKey = "미등록";
        outerConnAuthView.oca_Status = 3;
        outerConnAuthView.UpdateExInsert();
        if (outerConnAuthCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.OuterConnAuth.ToDescription(), (object) TableCodeType.OuterConnAuth) + "\n--------------------------------------------------------------------------------------------------");
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
