// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.Employee.EmployeeCreate
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

namespace UniBiz.Bo.Models.UniBase.Employee.Employee
{
  public class EmployeeCreate : TEmployee, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = EmployeeCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = EmployeeCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Employee) + " emp_Code INT NOT NULL,emp_SiteID BIGINT NOT NULL DEFAULT(0),emp_BaseStore INT NOT NULL DEFAULT(0),emp_Position INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Name", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Dept", (object) 6) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_ID", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_ProgPwd", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_PosID", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_PosPwd", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "emp_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Tel", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Mobile", (object) 20) + ",emp_EnterDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_RegidentNo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Email", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_EmailPwd", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Zipcode", (object) 7) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Addr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_Addr2", (object) 100) + ",emp_Gender INT NOT NULL DEFAULT(0),emp_BirthType INT NOT NULL DEFAULT(0),emp_Birthday DATETIME NULL,emp_Anniversary DATETIME NULL,emp_MenuGroupID INT NOT NULL DEFAULT(0),emp_ProgAuth1 INT NOT NULL DEFAULT(0),emp_ProgAuth2 INT NOT NULL DEFAULT(0),emp_ProgAuth3 INT NOT NULL DEFAULT(0),emp_LoginLimitDate DATETIME NULL,emp_PwdLimitDate DATETIME NULL,emp_LoginDeny INT NOT NULL DEFAULT(0),emp_ResignationDate DATETIME NULL,emp_ResignationStatus INT NOT NULL DEFAULT(0),emp_Job INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "emp_ExtensionNumber", (object) 20) + ",emp_InDate DATETIME NULL,emp_InUser INT NOT NULL DEFAULT(0),emp_ModDate DATETIME NULL,emp_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(emp_Code ASC) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Employee) + " emp_Code INT NOT NULL,emp_SiteID BIGINT NOT NULL DEFAULT 0,emp_BaseStore INT NOT NULL DEFAULT 0,emp_Position INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Name", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Dept", (object) 6) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_ID", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_ProgPwd", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_PosID", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_PosPwd", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "emp_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Tel", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Mobile", (object) 20) + ",emp_EnterDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_RegidentNo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Email", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_EmailPwd", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Zipcode", (object) 7) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Addr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_Addr2", (object) 100) + ",emp_Gender INT NOT NULL DEFAULT 0,emp_BirthType INT NOT NULL DEFAULT 0,emp_Birthday DATETIME NULL,emp_Anniversary DATETIME NULL,emp_MenuGroupID INT NOT NULL DEFAULT 0,emp_ProgAuth1 INT NOT NULL DEFAULT 0,emp_ProgAuth2 INT NOT NULL DEFAULT 0,emp_ProgAuth3 INT NOT NULL DEFAULT 0,emp_LoginLimitDate DATETIME NULL,emp_PwdLimitDate DATETIME NULL,emp_LoginDeny INT NOT NULL DEFAULT 0,emp_ResignationDate DATETIME NULL,emp_ResignationStatus INT NOT NULL DEFAULT 0,emp_Job INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "emp_ExtensionNumber", (object) 20) + ",emp_InDate DATETIME NULL,emp_InUser INT NOT NULL DEFAULT 0,emp_ModDate DATETIME NULL,emp_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(emp_Code) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(EmployeeCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Employee.ToDescription(), (object) TableCodeType.Employee));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사원코드", (object) TableCodeType.Employee, (object) "emp_Code"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.Employee, (object) "emp_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "시작지점", (object) TableCodeType.Employee, (object) "emp_BaseStore"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "직위", (object) TableCodeType.Employee, (object) "emp_Position"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사원명", (object) TableCodeType.Employee, (object) "emp_Name"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "부서", (object) TableCodeType.Employee, (object) "emp_Dept"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "ID ", (object) TableCodeType.Employee, (object) "emp_ID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "패스워드", (object) TableCodeType.Employee, (object) "emp_ProgPwd"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "포스 ID", (object) TableCodeType.Employee, (object) "emp_PosID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "포스 패스워드", (object) TableCodeType.Employee, (object) "emp_PosPwd"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용상태", (object) TableCodeType.Employee, (object) "emp_UseYn"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "전화", (object) TableCodeType.Employee, (object) "emp_Tel"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "모바일", (object) TableCodeType.Employee, (object) "emp_Mobile"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "입사일", (object) TableCodeType.Employee, (object) "emp_EnterDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "주민번호", (object) TableCodeType.Employee, (object) "emp_RegidentNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "이메일", (object) TableCodeType.Employee, (object) "emp_Email"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "이메일패스워드", (object) TableCodeType.Employee, (object) "emp_EmailPwd"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "우편번호", (object) TableCodeType.Employee, (object) "emp_Zipcode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "주소", (object) TableCodeType.Employee, (object) "emp_Addr1"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "주소 상세", (object) TableCodeType.Employee, (object) "emp_Addr2"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "성별", (object) TableCodeType.Employee, (object) "emp_Gender"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "양/음력", (object) TableCodeType.Employee, (object) "emp_BirthType"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "생년월일", (object) TableCodeType.Employee, (object) "emp_Birthday"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "기념일", (object) TableCodeType.Employee, (object) "emp_Anniversary"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "화면권한ID", (object) TableCodeType.Employee, (object) "emp_MenuGroupID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "작업 권한1", (object) TableCodeType.Employee, (object) "emp_ProgAuth1"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "작업 권한2", (object) TableCodeType.Employee, (object) "emp_ProgAuth2"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "작업 권한3", (object) TableCodeType.Employee, (object) "emp_ProgAuth3"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "로그인 만료일", (object) TableCodeType.Employee, (object) "emp_LoginLimitDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "패스워드 만료일", (object) TableCodeType.Employee, (object) "emp_PwdLimitDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "접속거절", (object) TableCodeType.Employee, (object) "emp_LoginDeny"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "퇴사일자", (object) TableCodeType.Employee, (object) "emp_ResignationDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "퇴사여부", (object) TableCodeType.Employee, (object) "emp_ResignationStatus"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "직책", (object) TableCodeType.Employee, (object) "emp_Job"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "내선번호", (object) TableCodeType.Employee, (object) "emp_ExtensionNumber"));
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
      TEmployee temployee = this.OleDB.Create<TEmployee>();
      if (pSiteID == 1L)
      {
        temployee.emp_Code = 0;
        temployee.emp_SiteID = pSiteID;
        temployee.emp_Name = "시스템";
        temployee.emp_BaseStore = 1;
        temployee.emp_ID = string.Empty;
        temployee.emp_ProgPwd = string.Empty;
        temployee.emp_UseYn = "Y";
        temployee.emp_EnterDate = new DateTime?(DateTime.Now);
        temployee.emp_MenuGroupID = 0;
        temployee.emp_ProgAuth1 = int.MaxValue;
        temployee.emp_ProgAuth2 = int.MaxValue;
        temployee.emp_ProgAuth3 = int.MaxValue;
        this.OleDB.Execute(temployee.InsertQuery());
        temployee.emp_Code = 1;
        temployee.emp_SiteID = pSiteID;
        temployee.emp_Name = "개발사";
        temployee.emp_BaseStore = 1;
        temployee.emp_ID = "uniinfo";
        temployee.emp_ProgPwd = "uniinfo0000".EncryptAndEncode("emp_ProgPwd");
        temployee.emp_UseYn = "Y";
        temployee.emp_EnterDate = new DateTime?(DateTime.Now);
        temployee.emp_MenuGroupID = 1;
        temployee.emp_ProgAuth1 = 1;
        temployee.emp_ProgAuth2 = 0;
        temployee.emp_ProgAuth3 = 0;
        this.OleDB.Execute(temployee.InsertQuery());
        temployee.emp_Code = 2;
        temployee.emp_SiteID = pSiteID;
        temployee.emp_Name = "AGENT";
        temployee.emp_BaseStore = 1;
        temployee.emp_ID = "agent";
        temployee.emp_ProgPwd = "agent".EncryptAndEncode("emp_ProgPwd");
        temployee.emp_UseYn = "Y";
        temployee.emp_EnterDate = new DateTime?(DateTime.Now);
        temployee.emp_MenuGroupID = 1;
        temployee.emp_ProgAuth1 = 2;
        temployee.emp_ProgAuth2 = 0;
        temployee.emp_ProgAuth3 = 0;
        this.OleDB.Execute(temployee.InsertQuery());
        temployee.emp_Code = 3;
        temployee.emp_SiteID = pSiteID;
        temployee.emp_Name = "개발";
        temployee.emp_BaseStore = 1;
        temployee.emp_ID = "1";
        temployee.emp_ProgPwd = "1".EncryptAndEncode("emp_ProgPwd");
        temployee.emp_UseYn = "Y";
        temployee.emp_EnterDate = new DateTime?(DateTime.Now);
        temployee.emp_MenuGroupID = 1;
        temployee.emp_ProgAuth1 = 1;
        temployee.emp_ProgAuth2 = 0;
        temployee.emp_ProgAuth3 = 0;
        if (this.OleDB.Execute(temployee.InsertQuery()))
          ;
      }
      else
      {
        if (!temployee.CreateCode(this.OleDB))
          return false;
        temployee.emp_SiteID = pSiteID;
        temployee.emp_Name = "개발사";
        temployee.emp_BaseStore = 1;
        temployee.emp_ID = "uniinfo";
        temployee.emp_ProgPwd = "uniinfo0000".EncryptAndEncode("emp_ProgPwd");
        temployee.emp_UseYn = "Y";
        temployee.emp_EnterDate = new DateTime?(DateTime.Now);
        temployee.emp_MenuGroupID = 1;
        temployee.emp_ProgAuth1 = 1;
        temployee.emp_ProgAuth2 = 0;
        temployee.emp_ProgAuth3 = 0;
        this.OleDB.Execute(temployee.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("emp_Code"))
          this.emp_Code = p_rs.GetFieldInt("emp_Code");
        if (p_rs.IsFieldName("emp_SiteID"))
          this.emp_SiteID = p_rs.GetFieldLong("emp_SiteID");
        if (p_rs.IsFieldName("emp_BaseStore"))
          this.emp_BaseStore = p_rs.GetFieldInt("emp_BaseStore");
        if (p_rs.IsFieldName("emp_Position"))
          this.emp_Position = p_rs.GetFieldInt("emp_Position");
        if (p_rs.IsFieldName("emp_Name"))
          this.emp_Name = p_rs.GetFieldString("emp_Name");
        if (p_rs.IsFieldName("emp_Dept"))
          this.emp_Dept = p_rs.GetFieldString("emp_Dept");
        if (p_rs.IsFieldName("emp_ID"))
          this.emp_ID = p_rs.GetFieldString("emp_ID");
        if (p_rs.IsFieldName("emp_ProgPwd"))
          this.emp_ProgPwd = p_rs.GetFieldString("emp_ProgPwd");
        if (p_rs.IsFieldName("emp_PosID"))
          this.emp_PosID = p_rs.GetFieldString("emp_PosID");
        if (p_rs.IsFieldName("emp_PosPwd"))
          this.emp_PosPwd = p_rs.GetFieldString("emp_PosPwd");
        if (p_rs.IsFieldName("emp_UseYn"))
          this.emp_UseYn = p_rs.GetFieldString("emp_UseYn");
        if (p_rs.IsFieldName("emp_Tel"))
          this.emp_Tel = p_rs.GetFieldString("emp_Tel");
        if (p_rs.IsFieldName("emp_Mobile"))
          this.emp_Mobile = p_rs.GetFieldString("emp_Mobile");
        if (p_rs.IsFieldName("emp_EnterDate"))
          this.emp_EnterDate = p_rs.GetFieldDateTime("emp_EnterDate");
        if (p_rs.IsFieldName("emp_RegidentNo"))
          this.emp_RegidentNo = p_rs.GetFieldString("emp_RegidentNo");
        if (p_rs.IsFieldName("emp_Email"))
          this.emp_Email = p_rs.GetFieldString("emp_Email");
        if (p_rs.IsFieldName("emp_EmailPwd"))
          this.emp_EmailPwd = p_rs.GetFieldString("emp_EmailPwd");
        if (p_rs.IsFieldName("emp_Zipcode"))
          this.emp_Zipcode = p_rs.GetFieldString("emp_Zipcode");
        if (p_rs.IsFieldName("emp_Addr1"))
          this.emp_Addr1 = p_rs.GetFieldString("emp_Addr1");
        if (p_rs.IsFieldName("emp_Addr2"))
          this.emp_Addr2 = p_rs.GetFieldString("emp_Addr2");
        if (p_rs.IsFieldName("emp_Gender"))
          this.emp_Gender = p_rs.GetFieldInt("emp_Gender");
        if (p_rs.IsFieldName("emp_BirthType"))
          this.emp_BirthType = p_rs.GetFieldInt("emp_BirthType");
        if (p_rs.IsFieldName("emp_Birthday"))
          this.emp_Birthday = p_rs.GetFieldDateTime("emp_Birthday");
        if (p_rs.IsFieldName("emp_Anniversary"))
          this.emp_Anniversary = p_rs.GetFieldDateTime("emp_Anniversary");
        if (p_rs.IsFieldName("emp_MenuGroupID"))
          this.emp_MenuGroupID = p_rs.GetFieldInt("emp_MenuGroupID");
        if (p_rs.IsFieldName("emp_ProgAuth1"))
          this.emp_ProgAuth1 = p_rs.GetFieldInt("emp_ProgAuth1");
        if (p_rs.IsFieldName("emp_ProgAuth2"))
          this.emp_ProgAuth2 = p_rs.GetFieldInt("emp_ProgAuth2");
        if (p_rs.IsFieldName("emp_ProgAuth3"))
          this.emp_ProgAuth3 = p_rs.GetFieldInt("emp_ProgAuth3");
        if (p_rs.IsFieldName("emp_LoginLimitDate"))
          this.emp_LoginLimitDate = p_rs.GetFieldDateTime("emp_LoginLimitDate");
        if (p_rs.IsFieldName("emp_PwdLimitDate"))
          this.emp_PwdLimitDate = p_rs.GetFieldDateTime("emp_PwdLimitDate");
        if (p_rs.IsFieldName("emp_LoginDeny"))
          this.emp_LoginDeny = p_rs.GetFieldInt("emp_LoginDeny");
        if (p_rs.IsFieldName("emp_ResignationDate"))
          this.emp_ResignationDate = p_rs.GetFieldDateTime("emp_ResignationDate");
        if (p_rs.IsFieldName("emp_ResignationStatus"))
          this.emp_ResignationStatus = p_rs.GetFieldInt("emp_ResignationStatus");
        if (p_rs.IsFieldName("emp_Job"))
          this.emp_Job = p_rs.GetFieldInt("emp_Job");
        if (p_rs.IsFieldName("emp_ExtensionNumber"))
          this.emp_ExtensionNumber = p_rs.GetFieldString("emp_ExtensionNumber");
        if (p_rs.IsFieldName("emp_ModDate"))
          this.emp_ModDate = p_rs.GetFieldDateTime("emp_ModDate");
        if (p_rs.IsFieldName("emp_ModUser"))
          this.emp_ModUser = p_rs.GetFieldInt("emp_ModUser");
        if (p_rs.IsFieldName("emp_ModDate"))
          this.emp_ModDate = p_rs.GetFieldDateTime("emp_ModDate");
        if (p_rs.IsFieldName("emp_ModUser"))
          this.emp_ModUser = p_rs.GetFieldInt("emp_ModUser");
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
        IList<EmployeeCreate> employeeCreateList = this.OleDB.Create<EmployeeCreate>().SelectAllListE<EmployeeCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (employeeCreateList == null)
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
        int count = employeeCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (employeeCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Employee.ToDescription(), (object) TableCodeType.Employee) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (EmployeeCreate employeeCreate in (IEnumerable<EmployeeCreate>) employeeCreateList)
        {
          stringBuilder.Append(employeeCreate.InsertQuery());
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
        TEmployee temployee = this.OleDB.Create<TEmployee>();
        temployee.emp_Code = 0;
        temployee.emp_SiteID = 1L;
        temployee.emp_Name = "시스템";
        temployee.emp_BaseStore = 1;
        temployee.emp_ID = string.Empty;
        temployee.emp_ProgPwd = string.Empty;
        temployee.emp_UseYn = "Y";
        temployee.emp_EnterDate = new DateTime?(DateTime.Now);
        temployee.emp_MenuGroupID = 0;
        temployee.emp_ProgAuth1 = int.MaxValue;
        temployee.emp_ProgAuth2 = int.MaxValue;
        temployee.emp_ProgAuth3 = int.MaxValue;
        temployee.UpdateExInsert();
        if (employeeCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Employee.ToDescription(), (object) TableCodeType.Employee) + "\n--------------------------------------------------------------------------------------------------");
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
