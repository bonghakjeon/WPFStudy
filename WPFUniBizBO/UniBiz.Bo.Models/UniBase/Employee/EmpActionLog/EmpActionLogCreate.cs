// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpActionLog.EmpActionLogCreate
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

namespace UniBiz.Bo.Models.UniBase.Employee.EmpActionLog
{
  public class EmpActionLogCreate : TEmpActionLog, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = EmpActionLogCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = EmpActionLogCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.EmpActionLog) + " eal_ID BIGINT NOT NULL,eal_SiteID BIGINT NOT NULL DEFAULT(0),eal_SysDate DATETIME NOT NULL,eal_StoreCode INT NOT NULL DEFAULT(0),eal_EmpCode INT NOT NULL DEFAULT(0),eal_MenuCode INT NOT NULL DEFAULT(0),eal_SubProgID INT NOT NULL DEFAULT(0),eal_ApplyRowCnt INT NOT NULL DEFAULT(0),eal_ActionKind INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "eal_LocalIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "eal_PublicIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "eal_DeviceName", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "eal_Memo", (object) 1000) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "eal_Memo2", (object) 1000) + ",eal_ProgKind INT NOT NULL DEFAULT(0) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.EmpActionLog) + " eal_ID BIGINT NOT NULL,eal_SiteID BIGINT NOT NULL DEFAULT 0,eal_SysDate DATETIME NOT NULL,eal_StoreCode INT NOT NULL DEFAULT 0,eal_EmpCode INT NOT NULL DEFAULT 0,eal_MenuCode INT NOT NULL DEFAULT 0,eal_SubProgID INT NOT NULL DEFAULT 0,eal_ApplyRowCnt INT NOT NULL DEFAULT 0,eal_ActionKind INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "eal_LocalIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "eal_PublicIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "eal_DeviceName", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "eal_Memo", (object) 1000) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "eal_Memo2", (object) 1000) + ",eal_ProgKind INT NOT NULL DEFAULT 0 ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(EmpActionLogCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.EmpActionLog.ToDescription(), (object) TableCodeType.EmpActionLog));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "ID (Key)", (object) TableCodeType.EmpActionLog, (object) "eal_ID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.EmpActionLog, (object) "eal_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용일시", (object) TableCodeType.EmpActionLog, (object) "eal_SysDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "지점코드", (object) TableCodeType.EmpActionLog, (object) "eal_StoreCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용자코드", (object) TableCodeType.EmpActionLog, (object) "eal_EmpCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "메뉴코드", (object) TableCodeType.EmpActionLog, (object) "eal_MenuCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "Sub화면 ID", (object) TableCodeType.EmpActionLog, (object) "eal_SubProgID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "데이터수", (object) TableCodeType.EmpActionLog, (object) "eal_ApplyRowCnt"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "작업유형", (object) TableCodeType.EmpActionLog, (object) "eal_ActionKind"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "내부 IP", (object) TableCodeType.EmpActionLog, (object) "eal_LocalIP"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "접속 IP", (object) TableCodeType.EmpActionLog, (object) "eal_PublicIP"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "디바이스명", (object) TableCodeType.EmpActionLog, (object) "eal_DeviceName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "메모", (object) TableCodeType.EmpActionLog, (object) "eal_Memo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "메모2", (object) TableCodeType.EmpActionLog, (object) "eal_Memo2"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "프로그램 종류", (object) 1, (object) TableCodeType.EmpActionLog, (object) "eal_ProgKind"));
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
        if (p_rs.IsFieldName("eal_ID"))
          this.eal_ID = p_rs.GetFieldLong("eal_ID");
        if (p_rs.IsFieldName("eal_SiteID"))
          this.eal_SiteID = p_rs.GetFieldLong("eal_SiteID");
        if (p_rs.IsFieldName("eal_SysDate"))
          this.eal_SysDate = p_rs.GetFieldDateTime("eal_SysDate");
        if (p_rs.IsFieldName("eal_StoreCode"))
          this.eal_StoreCode = p_rs.GetFieldInt("eal_StoreCode");
        if (p_rs.IsFieldName("eal_EmpCode"))
          this.eal_EmpCode = p_rs.GetFieldInt("eal_EmpCode");
        if (p_rs.IsFieldName("eal_MenuCode"))
          this.eal_MenuCode = p_rs.GetFieldInt("eal_MenuCode");
        if (p_rs.IsFieldName("eal_SubProgID"))
          this.eal_SubProgID = p_rs.GetFieldInt("eal_SubProgID");
        if (p_rs.IsFieldName("eal_ApplyRowCnt"))
          this.eal_ApplyRowCnt = p_rs.GetFieldInt("eal_ApplyRowCnt");
        if (p_rs.IsFieldName("eal_ActionKind"))
          this.eal_ActionKind = p_rs.GetFieldInt("eal_ActionKind");
        if (p_rs.IsFieldName("eal_LocalIP"))
          this.eal_LocalIP = p_rs.GetFieldString("eal_LocalIP");
        if (p_rs.IsFieldName("eal_PublicIP"))
          this.eal_PublicIP = p_rs.GetFieldString("eal_PublicIP");
        if (p_rs.IsFieldName("eal_DeviceName"))
          this.eal_DeviceName = p_rs.GetFieldString("eal_DeviceName");
        if (p_rs.IsFieldName("eal_Memo"))
          this.eal_Memo = p_rs.GetFieldString("eal_Memo");
        if (p_rs.IsFieldName("eal_Memo2"))
          this.eal_Memo2 = p_rs.GetFieldString("eal_Memo2");
        if (p_rs.IsFieldName("eal_ProgKind"))
          this.eal_ProgKind = p_rs.GetFieldInt("eal_ProgKind");
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
        IList<EmpActionLogCreate> empActionLogCreateList = this.OleDB.Create<EmpActionLogCreate>().SelectAllListE<EmpActionLogCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (empActionLogCreateList == null)
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
        int count = empActionLogCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (empActionLogCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.EmpActionLog.ToDescription(), (object) TableCodeType.EmpActionLog) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (EmpActionLogCreate empActionLogCreate in (IEnumerable<EmpActionLogCreate>) empActionLogCreateList)
        {
          stringBuilder.Append(empActionLogCreate.InsertQuery());
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
        if (empActionLogCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.EmpActionLog.ToDescription(), (object) TableCodeType.EmpActionLog) + "\n--------------------------------------------------------------------------------------------------");
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
