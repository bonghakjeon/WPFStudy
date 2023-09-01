// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory.GiftGiveHistoryCreate
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

namespace UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory
{
  public class GiftGiveHistoryCreate : TGiftGiveHistory, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = GiftGiveHistoryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = GiftGiveHistoryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.GiftGiveHistory) + " ggh_GiveNo BIGINT NOT NULL,ggh_SiteID BIGINT NOT NULL DEFAULT(0),ggh_RequestDate DATETIME NOT NULL,ggh_RequestStore INT NOT NULL DEFAULT(0),ggh_RequestEmpCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ggh_RequestEmpName", (object) 100) + ",ggh_MemberNo BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ggh_MemberName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ggh_RecipientTelNo", (object) 20) + ",ggh_GiftCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ggh_GiftName", (object) 50) + ",ggh_GiftPrice INT NOT NULL DEFAULT(0),ggh_DeductionPoint INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ggh_Memo", (object) 100) + ",ggh_GiveStore INT NOT NULL DEFAULT(0),ggh_GiveEmpCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "ggh_GiveEmpName", (object) 100) + ",ggh_GiveDate DATETIME NOT NULL,ggh_Status INT NOT NULL DEFAULT(0),ggh_InDate DATETIME NULL,ggh_InUser INT NOT NULL DEFAULT(0),ggh_ModDate DATETIME NULL,ggh_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(ggh_GiveNo) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.GiftGiveHistory) + " ggh_GiveNo BIGINT NOT NULL,ggh_SiteID BIGINT NOT NULL DEFAULT 0,ggh_RequestDate DATETIME NOT NULL,ggh_RequestStore INT NOT NULL DEFAULT 0,ggh_RequestEmpCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ggh_RequestEmpName", (object) 100) + ",ggh_MemberNo BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ggh_MemberName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ggh_RecipientTelNo", (object) 20) + ",ggh_GiftCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ggh_GiftName", (object) 50) + ",ggh_GiftPrice INT NOT NULL DEFAULT 0,ggh_DeductionPoint INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ggh_Memo", (object) 100) + ",ggh_GiveStore INT NOT NULL DEFAULT 0,ggh_GiveEmpCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "ggh_GiveEmpName", (object) 100) + ",ggh_GiveDate DATETIME NOT NULL,ggh_Status INT NOT NULL DEFAULT 0 PRIMARY KEY(ggh_GiveNo) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(GiftGiveHistoryCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_MEMBERS, (object) this.TableCode)))
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
        string str = "EXEC " + UbModelBase.UNI_MEMBERS + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.GiftGiveHistory.ToDescription(), (object) TableCodeType.GiftGiveHistory));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지급No", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiveNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.GiftGiveHistory, (object) "ggh_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "요청일", (object) TableCodeType.GiftGiveHistory, (object) "ggh_RequestDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "요청지점", (object) TableCodeType.GiftGiveHistory, (object) "ggh_RequestStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "요청사원", (object) TableCodeType.GiftGiveHistory, (object) "ggh_RequestEmpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "요청사원명", (object) TableCodeType.GiftGiveHistory, (object) "ggh_RequestEmpName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원코드", (object) TableCodeType.GiftGiveHistory, (object) "ggh_MemberNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원명", (object) TableCodeType.GiftGiveHistory, (object) "ggh_MemberName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "수령인 연락처", (object) TableCodeType.GiftGiveHistory, (object) "ggh_RecipientTelNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사은품코드", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiftCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사은품명", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiftName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사은품단가", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiftPrice"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "차감포인트", (object) TableCodeType.GiftGiveHistory, (object) "ggh_DeductionPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.GiftGiveHistory, (object) "ggh_Memo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지급지점", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiveStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지급사원", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiveEmpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지급사원명", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiveEmpName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지급일시", (object) TableCodeType.GiftGiveHistory, (object) "ggh_GiveDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용상태", (object) TableCodeType.GiftGiveHistory, (object) "ggh_Status"));
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
        if (p_rs.IsFieldName("ggh_GiveNo"))
          this.ggh_GiveNo = p_rs.GetFieldLong("ggh_GiveNo");
        if (p_rs.IsFieldName("ggh_SiteID"))
          this.ggh_SiteID = p_rs.GetFieldLong("ggh_SiteID");
        if (p_rs.IsFieldName("ggh_RequestDate"))
          this.ggh_RequestDate = p_rs.GetFieldDateTime("ggh_RequestDate");
        if (p_rs.IsFieldName("ggh_RequestStore"))
          this.ggh_RequestStore = p_rs.GetFieldInt("ggh_RequestStore");
        if (p_rs.IsFieldName("ggh_RequestEmpCode"))
          this.ggh_RequestEmpCode = p_rs.GetFieldInt("ggh_RequestEmpCode");
        if (p_rs.IsFieldName("ggh_RequestEmpName"))
          this.ggh_RequestEmpName = p_rs.GetFieldString("ggh_RequestEmpName");
        if (p_rs.IsFieldName("ggh_MemberNo"))
          this.ggh_MemberNo = p_rs.GetFieldLong("ggh_MemberNo");
        if (p_rs.IsFieldName("ggh_MemberName"))
          this.ggh_MemberName = p_rs.GetFieldString("ggh_MemberName");
        if (p_rs.IsFieldName("ggh_RecipientTelNo"))
          this.ggh_RecipientTelNo = p_rs.GetFieldString("ggh_RecipientTelNo");
        if (p_rs.IsFieldName("ggh_GiftCode"))
          this.ggh_GiftCode = p_rs.GetFieldInt("ggh_GiftCode");
        if (p_rs.IsFieldName("ggh_GiftName"))
          this.ggh_GiftName = p_rs.GetFieldString("ggh_GiftName");
        if (p_rs.IsFieldName("ggh_GiftPrice"))
          this.ggh_GiftPrice = p_rs.GetFieldInt("ggh_GiftPrice");
        if (p_rs.IsFieldName("ggh_DeductionPoint"))
          this.ggh_DeductionPoint = p_rs.GetFieldInt("ggh_DeductionPoint");
        if (p_rs.IsFieldName("ggh_Memo"))
          this.ggh_Memo = p_rs.GetFieldString("ggh_Memo");
        if (p_rs.IsFieldName("ggh_GiveStore"))
          this.ggh_GiveStore = p_rs.GetFieldInt("ggh_GiveStore");
        if (p_rs.IsFieldName("ggh_GiveEmpCode"))
          this.ggh_GiveEmpCode = p_rs.GetFieldInt("ggh_GiveEmpCode");
        if (p_rs.IsFieldName("ggh_GiveEmpName"))
          this.ggh_GiveEmpName = p_rs.GetFieldString("ggh_GiveEmpName");
        if (p_rs.IsFieldName("ggh_GiveDate"))
          this.ggh_GiveDate = p_rs.GetFieldDateTime("ggh_GiveDate");
        if (p_rs.IsFieldName("ggh_GiveDate"))
          this.ggh_Status = p_rs.GetFieldInt("ggh_Status");
        if (p_rs.IsFieldName("ggh_InDate"))
          this.ggh_InDate = p_rs.GetFieldDateTime("ggh_InDate");
        if (p_rs.IsFieldName("ggh_InUser"))
          this.ggh_InUser = p_rs.GetFieldInt("ggh_InUser");
        if (p_rs.IsFieldName("ggh_ModDate"))
          this.ggh_ModDate = p_rs.GetFieldDateTime("ggh_ModDate");
        if (p_rs.IsFieldName("ggh_ModUser"))
          this.ggh_ModUser = p_rs.GetFieldInt("ggh_ModUser");
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
        IList<GiftGiveHistoryCreate> giveHistoryCreateList = this.OleDB.Create<GiftGiveHistoryCreate>().SelectAllListE<GiftGiveHistoryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (giveHistoryCreateList == null)
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
        int count = giveHistoryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (giveHistoryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.GiftGiveHistory.ToDescription(), (object) TableCodeType.GiftGiveHistory) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (GiftGiveHistoryCreate giveHistoryCreate in (IEnumerable<GiftGiveHistoryCreate>) giveHistoryCreateList)
        {
          stringBuilder.Append(giveHistoryCreate.InsertQuery());
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
        if (giveHistoryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.GiftGiveHistory.ToDescription(), (object) TableCodeType.GiftGiveHistory) + "\n--------------------------------------------------------------------------------------------------");
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
