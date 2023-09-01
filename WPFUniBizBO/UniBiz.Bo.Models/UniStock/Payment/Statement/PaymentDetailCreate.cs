// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentDetailCreate
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

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentDetailCreate : TPaymentDetail, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = PaymentDetailCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = PaymentDetailCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.PaymentDetail) + " pd_PaymentID BIGINT NOT NULL,pd_Seq INT NOT NULL DEFAULT(0),pd_SiteID BIGINT NOT NULL DEFAULT(0),pd_ConfirmDate DATETIME NOT NULL,pd_ConfirmStatus INT NOT NULL DEFAULT(0),pd_InOutDiv INT NOT NULL DEFAULT(0),pd_StatementType INT NOT NULL DEFAULT(0),pd_ReasonType INT NOT NULL DEFAULT(0),pd_WriteType INT NOT NULL DEFAULT(0),pd_Amount MONEY NOT NULL DEFAULT(0.0),pd_PayAmount MONEY NOT NULL DEFAULT(0.0),pd_DeductAmount MONEY NOT NULL DEFAULT(0.0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pd_Memo", (object) 100) + ",pd_TransmitStatus INT NOT NULL DEFAULT(0),pd_TransmitDate DATETIME NULL,pd_InDate DATETIME NULL,pd_InUser INT NOT NULL DEFAULT(0),pd_ModDate DATETIME NULL,pd_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(pd_PaymentID,pd_Seq) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.PaymentDetail) + " pd_PaymentID BIGINT NOT NULL,pd_Seq INT NOT NULL DEFAULT 0,pd_SiteID BIGINT NOT NULL DEFAULT 0,pd_ConfirmDate DATETIME NOT NULL,pd_ConfirmStatus INT NOT NULL DEFAULT 0,pd_InOutDiv INT NOT NULL DEFAULT 0,pd_StatementType INT NOT NULL DEFAULT 0,pd_ReasonType INT NOT NULL DEFAULT 0,pd_WriteType INT NOT NULL DEFAULT 0,pd_Amount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pd_PayAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pd_DeductAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pd_Memo", (object) 100) + ",pd_TransmitStatus INT NOT NULL DEFAULT 0,pd_TransmitDate DATETIME NULL,pd_InDate DATETIME NULL,pd_InUser INT NOT NULL DEFAULT 0,pd_ModDate DATETIME NULL,pd_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(pd_PaymentID,pd_Seq) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(PaymentDetailCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_STOCK, (object) this.TableCode)))
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
        string str1 = "EXEC " + UbModelBase.UNI_STOCK + ".sys.sp_addextendedproperty N'MS_Description', N'";
        string str2 = "', N'schema', N'dbo', N'table', N'";
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.PaymentDetail.ToDescription(), (object) str2, (object) TableCodeType.PaymentDetail));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제코드", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_PaymentID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "순번", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_Seq"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "확정일자", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_ConfirmDate"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "확정타입", (object) 72, (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_ConfirmStatus"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "입출금", (object) 21, (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_InOutDiv"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "종목", (object) 69, (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_StatementType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "타입", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_ReasonType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "작성", (object) 68, (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_WriteType"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "금액", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_Amount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제금액", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_PayAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "공제금액", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_DeductAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "메모", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_Memo"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전송상태", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_TransmitStatus"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "전송일시", (object) str2, (object) TableCodeType.PaymentDetail, (object) "pd_TransmitDate"));
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
        if (p_rs.IsFieldName("pd_PaymentID"))
          this.pd_PaymentID = p_rs.GetFieldLong("pd_PaymentID");
        if (p_rs.IsFieldName("pd_Seq"))
          this.pd_Seq = p_rs.GetFieldInt("pd_Seq");
        if (p_rs.IsFieldName("pd_SiteID"))
          this.pd_SiteID = p_rs.GetFieldLong("pd_SiteID");
        if (p_rs.IsFieldName("pd_ConfirmDate"))
          this.pd_ConfirmDate = p_rs.GetFieldDateTime("pd_ConfirmDate");
        if (p_rs.IsFieldName("pd_ConfirmStatus"))
          this.pd_ConfirmStatus = p_rs.GetFieldInt("pd_ConfirmStatus");
        if (p_rs.IsFieldName("pd_InOutDiv"))
          this.pd_InOutDiv = p_rs.GetFieldInt("pd_InOutDiv");
        if (p_rs.IsFieldName("pd_StatementType"))
          this.pd_StatementType = p_rs.GetFieldInt("pd_StatementType");
        if (p_rs.IsFieldName("pd_ReasonType"))
          this.pd_ReasonType = p_rs.GetFieldInt("pd_ReasonType");
        if (p_rs.IsFieldName("pd_WriteType"))
          this.pd_WriteType = p_rs.GetFieldInt("pd_WriteType");
        if (p_rs.IsFieldName("pd_Amount"))
          this.pd_Amount = p_rs.GetFieldDouble("pd_Amount");
        if (p_rs.IsFieldName("pd_PayAmount"))
          this.pd_PayAmount = p_rs.GetFieldDouble("pd_PayAmount");
        if (p_rs.IsFieldName("pd_DeductAmount"))
          this.pd_DeductAmount = p_rs.GetFieldDouble("pd_DeductAmount");
        if (p_rs.IsFieldName("pd_Memo"))
          this.pd_Memo = p_rs.GetFieldString("pd_Memo");
        if (p_rs.IsFieldName("pd_TransmitStatus"))
          this.pd_TransmitStatus = p_rs.GetFieldInt("pd_TransmitStatus");
        if (p_rs.IsFieldName("pd_TransmitDate"))
          this.pd_TransmitDate = p_rs.GetFieldDateTime("pd_TransmitDate");
        if (p_rs.IsFieldName("pd_InDate"))
          this.pd_InDate = p_rs.GetFieldDateTime("pd_InDate");
        if (p_rs.IsFieldName("pd_InUser"))
          this.pd_InUser = p_rs.GetFieldInt("pd_InUser");
        if (p_rs.IsFieldName("pd_ModDate"))
          this.pd_ModDate = p_rs.GetFieldDateTime("pd_ModDate");
        if (p_rs.IsFieldName("pd_ModUser"))
          this.pd_ModUser = p_rs.GetFieldInt("pd_ModUser");
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
        IList<PaymentDetailCreate> paymentDetailCreateList = this.OleDB.Create<PaymentDetailCreate>().SelectAllListE<PaymentDetailCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (paymentDetailCreateList == null)
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
        int count = paymentDetailCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (paymentDetailCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.PaymentDetail.ToDescription(), (object) TableCodeType.PaymentDetail) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PaymentDetailCreate paymentDetailCreate in (IEnumerable<PaymentDetailCreate>) paymentDetailCreateList)
        {
          stringBuilder.Append(paymentDetailCreate.InsertQuery());
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
        if (paymentDetailCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.PaymentDetail.ToDescription(), (object) TableCodeType.PaymentDetail) + "\n--------------------------------------------------------------------------------------------------");
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
