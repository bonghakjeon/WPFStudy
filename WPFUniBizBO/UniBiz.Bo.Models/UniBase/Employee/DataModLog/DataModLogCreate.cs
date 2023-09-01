// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.DataModLog.DataModLogCreate
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

namespace UniBiz.Bo.Models.UniBase.Employee.DataModLog
{
  public class DataModLogCreate : TDataModLog, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = DataModLogCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = DataModLogCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.DataModLog) + " dml_ID BIGINT NOT NULL,dml_SiteID BIGINT NOT NULL DEFAULT(0),dml_SysDate DATETIME NOT NULL,dml_StoreCode INT NOT NULL DEFAULT(0),dml_EmpCode INT NOT NULL DEFAULT(0),dml_CodeInt INT NOT NULL DEFAULT(0),dml_CodeLong BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_CodeStr", (object) 200) + ",dml_ActionKind INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_ActionType", (object) 50) + ",dml_TableSeq INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_ModColumn", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_ModColumnDesc", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_BeforeValue", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_AfterValue", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_DeviceKey", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "dml_DeviceName", (object) 100) + " ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.DataModLog) + " dml_ID BIGINT NOT NULL,dml_SiteID BIGINT NOT NULL DEFAULT 0,dml_SysDate DATETIME NOT NULL,dml_StoreCode INT NOT NULL DEFAULT 0,dml_EmpCode INT NOT NULL DEFAULT 0,dml_CodeInt INT NOT NULL DEFAULT 0,dml_CodeLong BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_CodeStr", (object) 200) + ",dml_ActionKind INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_ActionType", (object) 50) + ",dml_TableSeq INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_ModColumn", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_ModColumnDesc", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_BeforeValue", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_AfterValue", (object) 500) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_DeviceKey", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "dml_DeviceName", (object) 100) + " ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(DataModLogCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.DataModLog.ToDescription(), (object) TableCodeType.DataModLog));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "ID (Key)", (object) TableCodeType.DataModLog, (object) "dml_ID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.DataModLog, (object) "dml_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경일시", (object) TableCodeType.DataModLog, (object) "dml_SysDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "지점코드", (object) TableCodeType.DataModLog, (object) "dml_StoreCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용자코드", (object) TableCodeType.DataModLog, (object) "dml_EmpCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "키값", (object) TableCodeType.DataModLog, (object) "dml_CodeInt"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "키값2", (object) TableCodeType.DataModLog, (object) "dml_CodeLong"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "키값3", (object) TableCodeType.DataModLog, (object) "dml_CodeStr"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경유형", (object) TableCodeType.DataModLog, (object) "dml_ActionKind"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "동작유형", (object) TableCodeType.DataModLog, (object) "dml_ActionType"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경테이블", (object) TableCodeType.DataModLog, (object) "dml_TableSeq"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경컬럼", (object) TableCodeType.DataModLog, (object) "dml_ModColumn"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경컬럼설명", (object) TableCodeType.DataModLog, (object) "dml_ModColumnDesc"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경전Data", (object) TableCodeType.DataModLog, (object) "dml_BeforeValue"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "변경후Data", (object) TableCodeType.DataModLog, (object) "dml_AfterValue"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "디바이스ID코드", (object) TableCodeType.DataModLog, (object) "dml_DeviceKey"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "디바이스명", (object) TableCodeType.DataModLog, (object) "dml_DeviceName"));
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
        if (p_rs.IsFieldName("dml_ID"))
          this.dml_ID = p_rs.GetFieldLong("dml_ID");
        if (p_rs.IsFieldName("dml_SiteID"))
          this.dml_SiteID = p_rs.GetFieldLong("dml_SiteID");
        if (p_rs.IsFieldName("dml_SysDate"))
          this.dml_SysDate = p_rs.GetFieldDateTime("dml_SysDate");
        if (p_rs.IsFieldName("dml_StoreCode"))
          this.dml_StoreCode = p_rs.GetFieldInt("dml_StoreCode");
        if (p_rs.IsFieldName("dml_EmpCode"))
          this.dml_EmpCode = p_rs.GetFieldInt("dml_EmpCode");
        if (p_rs.IsFieldName("dml_CodeInt"))
          this.dml_CodeInt = p_rs.GetFieldInt("dml_CodeInt");
        if (p_rs.IsFieldName("dml_CodeLong"))
          this.dml_CodeLong = p_rs.GetFieldLong("dml_CodeLong");
        if (p_rs.IsFieldName("dml_CodeStr"))
          this.dml_CodeStr = p_rs.GetFieldString("dml_CodeStr");
        if (p_rs.IsFieldName("dml_ActionType"))
          this.dml_ActionType = p_rs.GetFieldString("dml_ActionType");
        if (p_rs.IsFieldName("dml_ActionKind"))
          this.dml_ActionKind = p_rs.GetFieldInt("dml_ActionKind");
        if (this.dml_ActionKind == 0 && p_rs.IsFieldName("dml_ActionType"))
        {
          if (EnumEmpActionKind.NEW.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 1;
          else if ("INSERT".Equals(this.dml_ActionType.ToUpper()))
            this.dml_ActionKind = 1;
          else if (EnumEmpActionKind.UPDATE.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 2;
          else if (EnumEmpActionKind.DELETE.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 3;
          else if (EnumEmpActionKind.SEARCH.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 4;
          else if (EnumEmpActionKind.LOG_IN.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 8;
          else if (EnumEmpActionKind.LOG_IN.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 8;
          else if (EnumEmpActionKind.EXCEL.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 10;
          else if (EnumEmpActionKind.PRINT.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 11;
          else if (EnumEmpActionKind.PDF.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 12;
          else if (EnumEmpActionKind.EMAIL.ToString().Equals(this.dml_ActionType))
            this.dml_ActionKind = 13;
        }
        if (p_rs.IsFieldName("dml_TableSeq"))
          this.dml_TableSeq = p_rs.GetFieldInt("dml_TableSeq");
        if (p_rs.IsFieldName("dml_ModColumn"))
          this.dml_ModColumn = p_rs.GetFieldString("dml_ModColumn");
        if (p_rs.IsFieldName("dml_ModColumnDesc"))
          this.dml_ModColumnDesc = p_rs.GetFieldString("dml_ModColumnDesc");
        else if (p_rs.IsFieldName("dml_ModColumn"))
          this.dml_ModColumnDesc = this.dml_ModColumn;
        if (p_rs.IsFieldName("dml_BeforeValue"))
          this.dml_BeforeValue = p_rs.GetFieldString("dml_BeforeValue");
        if (p_rs.IsFieldName("dml_AfterValue"))
          this.dml_AfterValue = p_rs.GetFieldString("dml_AfterValue");
        if (p_rs.IsFieldName("dml_DeviceKey"))
          this.dml_DeviceKey = p_rs.GetFieldString("dml_DeviceKey");
        if (p_rs.IsFieldName("dml_DeviceName"))
          this.dml_DeviceName = p_rs.GetFieldString("dml_DeviceName");
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
        IList<DataModLogCreate> dataModLogCreateList = this.OleDB.Create<DataModLogCreate>().SelectAllListE<DataModLogCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (dataModLogCreateList == null)
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
        int count = dataModLogCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (dataModLogCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.DataModLog.ToDescription(), (object) TableCodeType.DataModLog) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (DataModLogCreate dataModLogCreate in (IEnumerable<DataModLogCreate>) dataModLogCreateList)
        {
          stringBuilder.Append(dataModLogCreate.InsertQuery());
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
        if (dataModLogCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.DataModLog.ToDescription(), (object) TableCodeType.DataModLog) + "\n--------------------------------------------------------------------------------------------------");
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
