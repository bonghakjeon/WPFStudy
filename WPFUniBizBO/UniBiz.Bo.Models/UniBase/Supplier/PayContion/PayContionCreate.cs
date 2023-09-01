// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.PayContion.PayContionCreate
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

namespace UniBiz.Bo.Models.UniBase.Supplier.PayContion
{
  public class PayContionCreate : TPayContion, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = PayContionCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = PayContionCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.PayContion) + " payc_ID INT NOT NULL,payc_Turn INT NOT NULL DEFAULT(0),payc_SiteID BIGINT NOT NULL DEFAULT(0),payc_Round INT NOT NULL DEFAULT(0),payc_PaymentMonth INT NOT NULL DEFAULT(0),payc_PaymentDay INT NOT NULL DEFAULT(0),payc_CalcStartMonth INT NOT NULL DEFAULT(0),payc_CalcStartDay INT NOT NULL DEFAULT(0),payc_CalcEndMonth INT NOT NULL DEFAULT(0),payc_CalcEndDay INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "payc_Memo", (object) 100) + ",payc_InDate DATETIME NULL,payc_InUser INT NOT NULL DEFAULT(0),payc_ModDate DATETIME NULL,payc_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(payc_ID,payc_Turn,payc_SiteID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.PayContion) + " payc_ID INT NOT NULL,payc_Turn INT NOT NULL,payc_SiteID BIGINT NOT NULL,payc_Round INT NOT NULL DEFAULT 0,payc_PaymentMonth INT NOT NULL DEFAULT 0,payc_PaymentDay INT NOT NULL DEFAULT 0,payc_CalcStartMonth INT NOT NULL DEFAULT 0,payc_CalcStartDay INT NOT NULL DEFAULT 0,payc_CalcEndMonth INT NOT NULL DEFAULT 0,payc_CalcEndDay INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "payc_Memo", (object) 100) + ",payc_InDate DATETIME NULL,payc_InUser INT NOT NULL DEFAULT 0,payc_ModDate DATETIME NULL,payc_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(payc_ID,payc_Turn,payc_SiteID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(PayContionCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.PayContion.ToDescription(), (object) TableCodeType.PayContion));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "결제조건 ID", (object) TableCodeType.PayContion, (object) "payc_ID"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "차", (object) 74, (object) TableCodeType.PayContion, (object) "payc_Turn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.PayContion, (object) "payc_SiteID"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "회", (object) 73, (object) TableCodeType.PayContion, (object) "payc_Round"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "결제월", (object) TableCodeType.PayContion, (object) "payc_PaymentMonth"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "결제일", (object) 75, (object) TableCodeType.PayContion, (object) "payc_PaymentDay"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "조회 시작월", (object) TableCodeType.PayContion, (object) "payc_CalcStartMonth"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "조회 시작일", (object) TableCodeType.PayContion, (object) "payc_CalcStartDay"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "조회 종료월", (object) TableCodeType.PayContion, (object) "payc_CalcEndMonth"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "조회 종료일", (object) TableCodeType.PayContion, (object) "payc_CalcEndDay"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.PayContion, (object) "payc_Memo"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.PayContion, (object) UbModelBase.UNI_BASE, (object) TableCodeType.PayContion) + " (payc_SiteID,payc_Turn,payc_Round);");
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
      PayContionView payContionView = this.OleDB.Create<PayContionView>();
      payContionView.payc_SiteID = pSiteID;
      payContionView.payc_PaymentDay = 1;
      payContionView.payc_CalcStartMonth = 0;
      payContionView.payc_CalcStartDay = 0;
      payContionView.payc_CalcEndMonth = 0;
      payContionView.payc_CalcEndDay = 0;
      payContionView.payc_Memo = "미등록";
      this.OleDB.Execute(payContionView.InsertQuery());
      payContionView.payc_ID = 9999;
      payContionView.payc_Turn = 1;
      payContionView.payc_SiteID = pSiteID;
      payContionView.payc_Round = 1;
      payContionView.payc_PaymentMonth = 4095;
      payContionView.payc_PaymentDay = 99;
      payContionView.payc_CalcStartMonth = 0;
      payContionView.payc_CalcStartDay = 0;
      payContionView.payc_CalcEndMonth = 0;
      payContionView.payc_CalcEndDay = 0;
      payContionView.payc_Memo = "수시";
      this.OleDB.Execute(payContionView.InsertQuery());
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("payc_ID"))
          this.payc_ID = p_rs.GetFieldInt("payc_ID");
        if (p_rs.IsFieldName("payc_Turn"))
          this.payc_Turn = p_rs.GetFieldInt("payc_Turn");
        if (p_rs.IsFieldName("payc_SiteID"))
          this.payc_SiteID = p_rs.GetFieldLong("payc_SiteID");
        if (p_rs.IsFieldName("payc_Round"))
          this.payc_Round = p_rs.GetFieldInt("payc_Round");
        if (p_rs.IsFieldName("payc_PaymentMonth"))
          this.payc_PaymentMonth = p_rs.GetFieldInt("payc_PaymentMonth");
        if (p_rs.IsFieldName("payc_PaymentDay"))
          this.payc_PaymentDay = p_rs.GetFieldInt("payc_PaymentDay");
        if (p_rs.IsFieldName("payc_CalcStartMonth"))
          this.payc_CalcStartMonth = p_rs.GetFieldInt("payc_CalcStartMonth");
        if (p_rs.IsFieldName("payc_CalcStartDay"))
          this.payc_CalcStartDay = p_rs.GetFieldInt("payc_CalcStartDay");
        if (p_rs.IsFieldName("payc_CalcEndMonth"))
          this.payc_CalcEndMonth = p_rs.GetFieldInt("payc_CalcEndMonth");
        if (p_rs.IsFieldName("payc_CalcEndDay"))
          this.payc_CalcEndDay = p_rs.GetFieldInt("payc_CalcEndDay");
        if (p_rs.IsFieldName("payc_Memo"))
          this.payc_Memo = p_rs.GetFieldString("payc_Memo");
        if (p_rs.IsFieldName("payc_InDate"))
          this.payc_InDate = p_rs.GetFieldDateTime("payc_InDate");
        if (p_rs.IsFieldName("payc_InUser"))
          this.payc_InUser = p_rs.GetFieldInt("payc_InUser");
        if (p_rs.IsFieldName("payc_ModDate"))
          this.payc_ModDate = p_rs.GetFieldDateTime("payc_ModDate");
        if (p_rs.IsFieldName("payc_ModUser"))
          this.payc_ModUser = p_rs.GetFieldInt("payc_ModUser");
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
        IList<PayContionCreate> payContionCreateList = this.OleDB.Create<PayContionCreate>().SelectAllListE<PayContionCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (payContionCreateList == null)
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
        int count = payContionCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (payContionCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.PayContion.ToDescription(), (object) TableCodeType.PayContion) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PayContionCreate payContionCreate in (IEnumerable<PayContionCreate>) payContionCreateList)
        {
          stringBuilder.Append(payContionCreate.InsertQuery());
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
        if (payContionCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.PayContion.ToDescription(), (object) TableCodeType.PayContion) + "\n--------------------------------------------------------------------------------------------------");
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
