// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.History.MemberPointHistory.MemberPointHistoryCreate
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

namespace UniBiz.Bo.Models.UniMembers.History.MemberPointHistory
{
  public class MemberPointHistoryCreate : TMemberPointHistory, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = MemberPointHistoryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = MemberPointHistoryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberPointHistory) + " mph_Seq BIGINT NOT NULL,mph_SiteID BIGINT NOT NULL DEFAULT(0),mph_SysDate DATETIME NOT NULL,mph_MemberNo BIGINT NOT NULL DEFAULT(0),mph_StoreCode INT NOT NULL DEFAULT(0),mph_PointType INT NOT NULL DEFAULT(0),mph_SaleDate DATETIME NOT NULL,mph_PosNo INT NOT NULL DEFAULT(0),mph_TransNo INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mph_MemberCardNo", (object) 20) + ",mph_SaleType INT NOT NULL DEFAULT(0),mph_SaleAmt MONEY NOT NULL DEFAULT(0.0),mph_TodayAddPoint INT NOT NULL DEFAULT(0),mph_TodayUsePoint INT NOT NULL DEFAULT(0),mph_TotalPoint INT NOT NULL DEFAULT(0),mph_UsePoint INT NOT NULL DEFAULT(0),mph_UsablePoint INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mph_Memo", (object) 50) + ",mph_ExtinctionDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "mph_TransmitYn", (object) 1) + ",mph_TransmitDate DATETIME NULL,mph_InputDate DATETIME NOT NULL,mph_InDate DATETIME NULL,mph_InUser INT NOT NULL DEFAULT(0),mph_ModDate DATETIME NULL,mph_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(mph_Seq) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_MEMBERS, (object) TableCodeType.MemberPointHistory) + " mph_Seq BIGINT NOT NULL,mph_SiteID BIGINT NOT NULL DEFAULT 0,mph_SysDate DATETIME NOT NULL,mph_MemberNo BIGINT NOT NULL DEFAULT 0,mph_StoreCode INT NOT NULL DEFAULT 0,mph_PointType INT NOT NULL DEFAULT 0,mph_SaleDate DATETIME NOT NULL,mph_PosNo INT NOT NULL DEFAULT 0,mph_TransNo INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mph_MemberCardNo", (object) 20) + ",mph_SaleType INT NOT NULL DEFAULT 0,mph_SaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,mph_TodayAddPoint INT NOT NULL DEFAULT 0,mph_TodayUsePoint INT NOT NULL DEFAULT 0,mph_TotalPoint INT NOT NULL DEFAULT 0,mph_UsePoint INT NOT NULL DEFAULT 0,mph_UsablePoint INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mph_Memo", (object) 50) + ",mph_ExtinctionDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "mph_TransmitYn", (object) 1) + ",mph_TransmitDate DATETIME NULL,mph_InputDate DATETIME NOT NULL,mph_InDate DATETIME NULL,mph_InUser INT NOT NULL DEFAULT 0,mph_ModDate DATETIME NULL,mph_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(mph_Seq) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(MemberPointHistoryCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.MemberPointHistory.ToDescription(), (object) TableCodeType.MemberPointHistory));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "순번", (object) TableCodeType.MemberPointHistory, (object) "mph_Seq"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.MemberPointHistory, (object) "mph_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발생일자(시스템)", (object) TableCodeType.MemberPointHistory, (object) "mph_SysDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "회원번호", (object) TableCodeType.MemberPointHistory, (object) "mph_MemberNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점", (object) TableCodeType.MemberPointHistory, (object) "mph_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립구분", (object) TableCodeType.MemberPointHistory, (object) "mph_PointType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "영업일자", (object) TableCodeType.MemberPointHistory, (object) "mph_SaleDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "포스번호", (object) TableCodeType.MemberPointHistory, (object) "mph_PosNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "거래번호", (object) TableCodeType.MemberPointHistory, (object) "mph_TransNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용카드", (object) TableCodeType.MemberPointHistory, (object) "mph_MemberCardNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "TrlogTextDesc.trh_SaleType", (object) TableCodeType.MemberPointHistory, (object) "mph_SaleType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립(사용)대상금액", (object) TableCodeType.MemberPointHistory, (object) "mph_SaleAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립포인트", (object) TableCodeType.MemberPointHistory, (object) "mph_TodayAddPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용포인트", (object) TableCodeType.MemberPointHistory, (object) "mph_TodayUsePoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립후 누계포인트", (object) TableCodeType.MemberPointHistory, (object) "mph_TotalPoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립후 사용포인트", (object) TableCodeType.MemberPointHistory, (object) "mph_UsePoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적립후 가용포인트", (object) TableCodeType.MemberPointHistory, (object) "mph_UsablePoint"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.MemberPointHistory, (object) "mph_Memo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "소멸예정일", (object) TableCodeType.MemberPointHistory, (object) "mph_ExtinctionDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "수신여부", (object) TableCodeType.MemberPointHistory, (object) "mph_TransmitYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "수신일자", (object) TableCodeType.MemberPointHistory, (object) "mph_TransmitDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발생일시", (object) TableCodeType.MemberPointHistory, (object) "mph_InputDate"));
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
        if (p_rs.IsFieldName("mph_Seq"))
          this.mph_Seq = (long) p_rs.GetFieldInt("mph_Seq");
        if (p_rs.IsFieldName("mph_SiteID"))
          this.mph_SiteID = p_rs.GetFieldLong("mph_SiteID");
        if (p_rs.IsFieldName("mph_SysDate"))
          this.mph_SysDate = p_rs.GetFieldDateTime("mph_SysDate");
        else
          this.mph_SysDate = new DateTime?(DateTime.Now);
        if (p_rs.IsFieldName("mph_MemberNo"))
          this.mph_MemberNo = p_rs.GetFieldLong("mph_MemberNo");
        if (p_rs.IsFieldName("mph_StoreCode"))
          this.mph_StoreCode = p_rs.GetFieldInt("mph_StoreCode");
        if (p_rs.IsFieldName("mph_PointType"))
          this.mph_PointType = p_rs.GetFieldInt("mph_PointType");
        if (p_rs.IsFieldName("mph_SaleDate"))
          this.mph_SaleDate = p_rs.GetFieldDateTime("mph_SaleDate");
        if (p_rs.IsFieldName("mph_PosNo"))
          this.mph_PosNo = p_rs.GetFieldInt("mph_PosNo");
        if (p_rs.IsFieldName("mph_MemberCardNo"))
          this.mph_MemberCardNo = p_rs.GetFieldString("mph_MemberCardNo");
        if (p_rs.IsFieldName("mph_SaleType"))
          this.mph_SaleType = p_rs.GetFieldInt("mph_SaleType");
        if (p_rs.IsFieldName("mph_SaleAmt"))
          this.mph_SaleAmt = p_rs.GetFieldDouble("mph_SaleAmt");
        if (p_rs.IsFieldName("mph_TodayAddPoint"))
          this.mph_TodayAddPoint = p_rs.GetFieldInt("mph_TodayAddPoint");
        if (p_rs.IsFieldName("mph_TodayUsePoint"))
          this.mph_TodayUsePoint = p_rs.GetFieldInt("mph_TodayUsePoint");
        if (p_rs.IsFieldName("mph_TotalPoint"))
          this.mph_TotalPoint = p_rs.GetFieldInt("mph_TotalPoint");
        if (p_rs.IsFieldName("mph_UsePoint"))
          this.mph_UsePoint = p_rs.GetFieldInt("mph_UsePoint");
        if (p_rs.IsFieldName("mph_UsablePoint"))
          this.mph_UsablePoint = p_rs.GetFieldInt("mph_UsablePoint");
        if (p_rs.IsFieldName("mph_Memo"))
          this.mph_Memo = p_rs.GetFieldString("mph_Memo");
        if (p_rs.IsFieldName("mph_ExtinctionDate"))
          this.mph_ExtinctionDate = p_rs.GetFieldDateTime("mph_ExtinctionDate");
        if (p_rs.IsFieldName("mph_TransmitYn"))
          this.mph_TransmitYn = p_rs.GetFieldString("mph_TransmitYn");
        if (p_rs.IsFieldName("mph_TransmitDate"))
          this.mph_TransmitDate = p_rs.GetFieldDateTime("mph_TransmitDate");
        if (p_rs.IsFieldName("mph_InputDate"))
          this.mph_InputDate = p_rs.GetFieldDateTime("mph_InputDate");
        else
          this.mph_InputDate = new DateTime?(DateTime.Now);
        if (p_rs.IsFieldName("mph_InDate"))
          this.mph_InDate = p_rs.GetFieldDateTime("mph_InDate");
        if (p_rs.IsFieldName("mph_InUser"))
          this.mph_InUser = p_rs.GetFieldInt("mph_InUser");
        if (p_rs.IsFieldName("mph_ModDate"))
          this.mph_ModDate = p_rs.GetFieldDateTime("mph_ModDate");
        if (p_rs.IsFieldName("mph_ModUser"))
          this.mph_ModUser = p_rs.GetFieldInt("mph_ModUser");
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
        IList<MemberPointHistoryCreate> pointHistoryCreateList = this.OleDB.Create<MemberPointHistoryCreate>().SelectAllListE<MemberPointHistoryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_MEMBERS
          }
        });
        if (pointHistoryCreateList == null)
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
        int count = pointHistoryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (pointHistoryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.MemberPointHistory.ToDescription(), (object) TableCodeType.MemberPointHistory) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (MemberPointHistoryCreate pointHistoryCreate in (IEnumerable<MemberPointHistoryCreate>) pointHistoryCreateList)
        {
          stringBuilder.Append(pointHistoryCreate.InsertQuery());
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
        if (pointHistoryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.MemberPointHistory.ToDescription(), (object) TableCodeType.MemberPointHistory) + "\n--------------------------------------------------------------------------------------------------");
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
