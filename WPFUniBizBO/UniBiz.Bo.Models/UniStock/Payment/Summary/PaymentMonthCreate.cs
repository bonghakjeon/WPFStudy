// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Summary.PaymentMonthCreate
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

namespace UniBiz.Bo.Models.UniStock.Payment.Summary
{
  public class PaymentMonthCreate : TPaymentMonth, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = PaymentMonthCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = PaymentMonthCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.PaymentMonth) + " paym_YyyyMm INT NOT NULL,paym_StoreCode INT NOT NULL,paym_Supplier INT NOT NULL,paym_SiteID BIGINT NOT NULL DEFAULT(0),paym_BaseAmount MONEY NOT NULL DEFAULT(0.0),paym_BuyTax MONEY NOT NULL DEFAULT(0.0),paym_BuyVat MONEY NOT NULL DEFAULT(0.0),paym_BuyFree MONEY NOT NULL DEFAULT(0.0),paym_BuyReturnTax MONEY NOT NULL DEFAULT(0.0),paym_BuyReturnVat MONEY NOT NULL DEFAULT(0.0),paym_BuyReturnFree MONEY NOT NULL DEFAULT(0.0),paym_Deposit MONEY NOT NULL DEFAULT(0.0),paym_SaleTax MONEY NOT NULL DEFAULT(0.0),paym_SaleVat MONEY NOT NULL DEFAULT(0.0),paym_SaleFree MONEY NOT NULL DEFAULT(0.0),paym_DeductionAmount MONEY NOT NULL DEFAULT(0.0),paym_PayAmount MONEY NOT NULL DEFAULT(0.0),paym_AddAmount MONEY NOT NULL DEFAULT(0.0),paym_EndAmount MONEY NOT NULL DEFAULT(0.0) PRIMARY KEY(paym_YyyyMm,paym_StoreCode,paym_Supplier) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.PaymentMonth) + " paym_YyyyMm INT NOT NULL,paym_StoreCode INT NOT NULL,paym_Supplier INT NOT NULL,paym_SiteID BIGINT NOT NULL DEFAULT 0,paym_BaseAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_BuyTax DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_BuyVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_BuyFree DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_BuyReturnTax DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_BuyReturnVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_BuyReturnFree DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_Deposit DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_SaleTax DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_SaleVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_SaleFree DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_DeductionAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_PayAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_AddAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,paym_EndAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0 PRIMARY KEY(paym_YyyyMm,paym_StoreCode,paym_Supplier) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(PaymentMonthCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.PaymentMonth.ToDescription(), (object) str2, (object) TableCodeType.PaymentMonth));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제월", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_YyyyMm"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "코드", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "기초금액", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BaseAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입과세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BuyTax"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입부가세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BuyVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입면세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BuyFree"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품과세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BuyReturnTax"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품부가세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BuyReturnVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품면세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_BuyReturnFree"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "저장품계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_Deposit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출과세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_SaleTax"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출부가세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_SaleVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출면세계", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_SaleFree"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "공제금액", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_DeductionAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제금액", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_PayAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "보정금액", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_AddAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "기말금액", (object) str2, (object) TableCodeType.PaymentMonth, (object) "paym_EndAmount"));
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
        if (p_rs.IsFieldName("paym_YyyyMm"))
          this.paym_YyyyMm = p_rs.GetFieldInt("paym_YyyyMm");
        if (p_rs.IsFieldName("paym_StoreCode"))
          this.paym_StoreCode = p_rs.GetFieldInt("paym_StoreCode");
        if (p_rs.IsFieldName("paym_Supplier"))
          this.paym_Supplier = p_rs.GetFieldInt("paym_Supplier");
        if (p_rs.IsFieldName("paym_SiteID"))
          this.paym_SiteID = p_rs.GetFieldLong("paym_SiteID");
        if (p_rs.IsFieldName("paym_BaseAmount"))
          this.paym_BaseAmount = p_rs.GetFieldDouble("paym_BaseAmount");
        if (p_rs.IsFieldName("paym_BuyTax"))
          this.paym_BuyTax = p_rs.GetFieldDouble("paym_BuyTax");
        if (p_rs.IsFieldName("paym_BuyVat"))
          this.paym_BuyVat = p_rs.GetFieldDouble("paym_BuyVat");
        if (p_rs.IsFieldName("paym_BuyFree"))
          this.paym_BuyFree = p_rs.GetFieldDouble("paym_BuyFree");
        if (p_rs.IsFieldName("paym_BuyReturnTax"))
          this.paym_BuyReturnTax = p_rs.GetFieldDouble("paym_BuyReturnTax");
        if (p_rs.IsFieldName("paym_BuyReturnVat"))
          this.paym_BuyReturnVat = p_rs.GetFieldDouble("paym_BuyReturnVat");
        if (p_rs.IsFieldName("paym_BuyReturnFree"))
          this.paym_BuyReturnFree = p_rs.GetFieldDouble("paym_BuyReturnFree");
        if (p_rs.IsFieldName("paym_Deposit"))
          this.paym_Deposit = p_rs.GetFieldDouble("paym_Deposit");
        if (p_rs.IsFieldName("paym_SaleTax"))
          this.paym_SaleTax = p_rs.GetFieldDouble("paym_SaleTax");
        if (p_rs.IsFieldName("paym_SaleVat"))
          this.paym_SaleVat = p_rs.GetFieldDouble("paym_SaleVat");
        if (p_rs.IsFieldName("paym_SaleFree"))
          this.paym_SaleFree = p_rs.GetFieldDouble("paym_SaleFree");
        if (p_rs.IsFieldName("paym_DeductionAmount"))
          this.paym_DeductionAmount = p_rs.GetFieldDouble("paym_DeductionAmount");
        if (p_rs.IsFieldName("paym_PayAmount"))
          this.paym_PayAmount = p_rs.GetFieldDouble("paym_PayAmount");
        if (p_rs.IsFieldName("paym_AddAmount"))
          this.paym_AddAmount = p_rs.GetFieldDouble("paym_AddAmount");
        if (p_rs.IsFieldName("paym_EndAmount"))
          this.paym_EndAmount = p_rs.GetFieldDouble("paym_EndAmount");
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
        IList<PaymentMonthCreate> paymentMonthCreateList = this.OleDB.Create<PaymentMonthCreate>().SelectAllListE<PaymentMonthCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (paymentMonthCreateList == null)
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
        int count = paymentMonthCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (paymentMonthCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.PaymentMonth.ToDescription(), (object) TableCodeType.PaymentMonth) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PaymentMonthCreate paymentMonthCreate in (IEnumerable<PaymentMonthCreate>) paymentMonthCreateList)
        {
          stringBuilder.Append(paymentMonthCreate.InsertQuery());
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
        if (paymentMonthCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.PaymentMonth.ToDescription(), (object) TableCodeType.PaymentMonth) + "\n--------------------------------------------------------------------------------------------------");
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
