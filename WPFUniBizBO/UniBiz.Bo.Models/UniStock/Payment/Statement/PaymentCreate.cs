// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentCreate
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
  public class PaymentCreate : TPayment, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = PaymentCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = PaymentCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.Payment) + " pay_Code BIGINT NOT NULL,pay_SiteID BIGINT NOT NULL DEFAULT(0),pay_Date DATETIME NOT NULL,pay_StoreCode INT NOT NULL DEFAULT(0),pay_Supplier INT NOT NULL DEFAULT(0),pay_SupplierType INT NOT NULL DEFAULT(0),pay_Type INT NOT NULL DEFAULT(0),pay_StartDate DATETIME NOT NULL,pay_EndDate DATETIME NOT NULL,pay_PayMethod INT NOT NULL DEFAULT(0),pay_Round INT NOT NULL DEFAULT(0),pay_Turn INT NOT NULL DEFAULT(0),pay_ConfirmStatus INT NOT NULL DEFAULT(0),pay_StatementStatus INT NOT NULL DEFAULT(0),pay_TypeCustom1 INT NOT NULL DEFAULT(0),pay_TypeCustom2 INT NOT NULL DEFAULT(0),pay_BaseAmount MONEY NOT NULL DEFAULT(0.0),pay_BuyAmount MONEY NOT NULL DEFAULT(0.0),pay_BuyTax MONEY NOT NULL DEFAULT(0.0),pay_BuyVat MONEY NOT NULL DEFAULT(0.0),pay_BuyFree MONEY NOT NULL DEFAULT(0.0),pay_BuyReturnAmount MONEY NOT NULL DEFAULT(0.0),pay_BuyReturnTax MONEY NOT NULL DEFAULT(0.0),pay_BuyReturnVat MONEY NOT NULL DEFAULT(0.0),pay_BuyReturnFree MONEY NOT NULL DEFAULT(0.0),pay_Deposit MONEY NOT NULL DEFAULT(0.0),pay_SaleAmount MONEY NOT NULL DEFAULT(0.0),pay_SaleTax MONEY NOT NULL DEFAULT(0.0),pay_SaleVat MONEY NOT NULL DEFAULT(0.0),pay_SaleFree MONEY NOT NULL DEFAULT(0.0),pay_DeductionAmount MONEY NOT NULL DEFAULT(0.0),pay_PayAmount MONEY NOT NULL DEFAULT(0.0),pay_AddAmount MONEY NOT NULL DEFAULT(0.0),pay_EndAmount MONEY NOT NULL DEFAULT(0.0),pay_InDate DATETIME NULL,pay_InUser INT NOT NULL DEFAULT(0),pay_ModDate DATETIME NULL,pay_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(pay_Code) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.Payment) + " pay_Code BIGINT NOT NULL,pay_SiteID BIGINT NOT NULL DEFAULT 0,pay_Date DATETIME NOT NULL,pay_StoreCode INT NOT NULL DEFAULT 0,pay_Supplier INT NOT NULL DEFAULT 0,pay_SupplierType INT NOT NULL DEFAULT 0,pay_Type INT NOT NULL DEFAULT 0,pay_StartDate DATETIME NOT NULL,pay_EndDate DATETIME NOT NULL,pay_PayMethod INT NOT NULL DEFAULT 0,pay_Round INT NOT NULL DEFAULT 0,pay_Turn INT NOT NULL DEFAULT 0,pay_ConfirmStatus INT NOT NULL DEFAULT 0,pay_StatementStatus INT NOT NULL DEFAULT 0,pay_TypeCustom1 INT NOT NULL DEFAULT 0,pay_TypeCustom2 INT NOT NULL DEFAULT 0,pay_BaseAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyTax DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyFree DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyReturnAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyReturnTax DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyReturnVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_BuyReturnFree DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_Deposit DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_SaleAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_SaleTax DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_SaleVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_SaleFree DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_DeductionAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_PayAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_AddAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_EndAmount DECIMAL(19,4) NOT NULL DEFAULT 0.0,pay_InDate DATETIME NULL,pay_InUser INT NOT NULL DEFAULT 0,pay_ModDate DATETIME NULL,pay_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(pay_Code) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(PaymentCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.Payment.ToDescription(), (object) str2, (object) TableCodeType.Payment));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제코드", (object) str2, (object) TableCodeType.Payment, (object) "pay_Code"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.Payment, (object) "pay_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제일", (object) str2, (object) TableCodeType.Payment, (object) "pay_Date"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지점코드", (object) str2, (object) TableCodeType.Payment, (object) "pay_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "코드", (object) str2, (object) TableCodeType.Payment, (object) "pay_Supplier"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "형태", (object) 40, (object) str2, (object) TableCodeType.Payment, (object) "pay_SupplierType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "타입", (object) 68, (object) str2, (object) TableCodeType.Payment, (object) "pay_Type"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "시작일자", (object) str2, (object) TableCodeType.Payment, (object) "pay_StartDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "종료일자", (object) str2, (object) TableCodeType.Payment, (object) "pay_EndDate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제수단", (object) str2, (object) TableCodeType.Payment, (object) "pay_PayMethod"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "회", (object) str2, (object) TableCodeType.Payment, (object) "pay_Round"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "차", (object) str2, (object) TableCodeType.Payment, (object) "pay_Turn"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "결제확정", (object) 49, (object) str2, (object) TableCodeType.Payment, (object) "pay_ConfirmStatus"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "전표확정", (object) 72, (object) str2, (object) TableCodeType.Payment, (object) "pay_StatementStatus"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "타입1", (object) 71, (object) str2, (object) TableCodeType.Payment, (object) "pay_TypeCustom1"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2}){3}{4}', N'column', N'{5}';", (object) str1, (object) "타입2", (object) 70, (object) str2, (object) TableCodeType.Payment, (object) "pay_TypeCustom2"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "기초금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_BaseAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입과세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyTax"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입부가세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매입면세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyFree"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyReturnAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품과세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyReturnTax"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품부가세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyReturnVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "반품면세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_BuyReturnFree"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "저장품", (object) str2, (object) TableCodeType.Payment, (object) "pay_Deposit"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_SaleAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출과세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_SaleTax"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출부가세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_SaleVat"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "매출면세계", (object) str2, (object) TableCodeType.Payment, (object) "pay_SaleFree"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "공제금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_DeductionAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "결제금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_PayAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "보정금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_AddAmount"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "기말금액", (object) str2, (object) TableCodeType.Payment, (object) "pay_EndAmount"));
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
        if (p_rs.IsFieldName("pay_Code"))
          this.pay_Code = p_rs.GetFieldLong("pay_Code");
        if (p_rs.IsFieldName("pay_SiteID"))
          this.pay_SiteID = p_rs.GetFieldLong("pay_SiteID");
        if (p_rs.IsFieldName("pay_Date"))
          this.pay_Date = p_rs.GetFieldDateTime("pay_Date");
        if (p_rs.IsFieldName("pay_StoreCode"))
          this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
        if (p_rs.IsFieldName("pay_StoreCode"))
          this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
        if (p_rs.IsFieldName("pay_Supplier"))
          this.pay_Supplier = p_rs.GetFieldInt("pay_Supplier");
        if (p_rs.IsFieldName("pay_SupplierType"))
          this.pay_SupplierType = p_rs.GetFieldInt("pay_SupplierType");
        if (p_rs.IsFieldName("pay_Type"))
          this.pay_Type = p_rs.GetFieldInt("pay_Type");
        if (p_rs.IsFieldName("pay_StartDate"))
          this.pay_StartDate = p_rs.GetFieldDateTime("pay_StartDate");
        if (p_rs.IsFieldName("pay_EndDate"))
          this.pay_EndDate = p_rs.GetFieldDateTime("pay_EndDate");
        if (p_rs.IsFieldName("pay_PayMethod"))
          this.pay_PayMethod = p_rs.GetFieldInt("pay_PayMethod");
        if (p_rs.IsFieldName("pay_Round"))
          this.pay_Round = p_rs.GetFieldInt("pay_Round");
        if (p_rs.IsFieldName("pay_Turn"))
          this.pay_Turn = p_rs.GetFieldInt("pay_Turn");
        if (p_rs.IsFieldName("pay_ConfirmStatus"))
          this.pay_ConfirmStatus = p_rs.GetFieldInt("pay_ConfirmStatus");
        if (p_rs.IsFieldName("pay_StatementStatus"))
          this.pay_StatementStatus = p_rs.GetFieldInt("pay_StatementStatus");
        if (p_rs.IsFieldName("pay_TypeCustom1"))
          this.pay_TypeCustom1 = p_rs.GetFieldInt("pay_TypeCustom1");
        if (p_rs.IsFieldName("pay_TypeCustom2"))
          this.pay_TypeCustom2 = p_rs.GetFieldInt("pay_TypeCustom2");
        if (p_rs.IsFieldName("pay_BaseAmount"))
          this.pay_BaseAmount = p_rs.GetFieldDouble("pay_BaseAmount");
        if (p_rs.IsFieldName("pay_BuyAmount"))
          this.pay_BuyAmount = p_rs.GetFieldDouble("pay_BuyAmount");
        if (p_rs.IsFieldName("pay_BuyTax"))
          this.pay_BuyTax = p_rs.GetFieldDouble("pay_BuyTax");
        if (p_rs.IsFieldName("pay_BuyVat"))
          this.pay_BuyVat = p_rs.GetFieldDouble("pay_BuyVat");
        if (p_rs.IsFieldName("pay_BuyFree"))
          this.pay_BuyFree = p_rs.GetFieldDouble("pay_BuyFree");
        if (p_rs.IsFieldName("pay_BuyReturnAmount"))
          this.pay_BuyReturnAmount = p_rs.GetFieldDouble("pay_BuyReturnAmount");
        if (p_rs.IsFieldName("pay_BuyReturnTax"))
          this.pay_BuyReturnTax = p_rs.GetFieldDouble("pay_BuyReturnTax");
        if (p_rs.IsFieldName("pay_BuyReturnVat"))
          this.pay_BuyReturnVat = p_rs.GetFieldDouble("pay_BuyReturnVat");
        if (p_rs.IsFieldName("pay_BuyReturnFree"))
          this.pay_BuyReturnFree = p_rs.GetFieldDouble("pay_BuyReturnFree");
        if (p_rs.IsFieldName("pay_Deposit"))
          this.pay_Deposit = p_rs.GetFieldDouble("pay_Deposit");
        if (p_rs.IsFieldName("pay_SaleAmount"))
          this.pay_SaleAmount = p_rs.GetFieldDouble("pay_SaleAmount");
        if (p_rs.IsFieldName("pay_SaleTax"))
          this.pay_SaleTax = p_rs.GetFieldDouble("pay_SaleTax");
        if (p_rs.IsFieldName("pay_SaleVat"))
          this.pay_SaleVat = p_rs.GetFieldDouble("pay_SaleVat");
        if (p_rs.IsFieldName("pay_SaleFree"))
          this.pay_SaleFree = p_rs.GetFieldDouble("pay_SaleFree");
        if (p_rs.IsFieldName("pay_DeductionAmount"))
          this.pay_DeductionAmount = p_rs.GetFieldDouble("pay_DeductionAmount");
        if (p_rs.IsFieldName("pay_PayAmount"))
          this.pay_PayAmount = p_rs.GetFieldDouble("pay_PayAmount");
        if (p_rs.IsFieldName("pay_AddAmount"))
          this.pay_AddAmount = p_rs.GetFieldDouble("pay_AddAmount");
        if (p_rs.IsFieldName("pay_EndAmount"))
          this.pay_EndAmount = p_rs.GetFieldDouble("pay_EndAmount");
        if (p_rs.IsFieldName("pay_InDate"))
          this.pay_InDate = p_rs.GetFieldDateTime("pay_InDate");
        if (p_rs.IsFieldName("pay_InUser"))
          this.pay_InUser = p_rs.GetFieldInt("pay_InUser");
        if (p_rs.IsFieldName("pay_ModDate"))
          this.pay_ModDate = p_rs.GetFieldDateTime("pay_ModDate");
        if (p_rs.IsFieldName("pay_ModUser"))
          this.pay_ModUser = p_rs.GetFieldInt("pay_ModUser");
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
        IList<PaymentCreate> paymentCreateList = this.OleDB.Create<PaymentCreate>().SelectAllListE<PaymentCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (paymentCreateList == null)
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
        int count = paymentCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (paymentCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Payment.ToDescription(), (object) TableCodeType.Payment) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PaymentCreate paymentCreate in (IEnumerable<PaymentCreate>) paymentCreateList)
        {
          stringBuilder.Append(paymentCreate.InsertQuery());
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
        if (paymentCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Payment.ToDescription(), (object) TableCodeType.Payment) + "\n--------------------------------------------------------------------------------------------------");
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
