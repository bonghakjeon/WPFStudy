// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.Supplier.SupplierCreate
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

namespace UniBiz.Bo.Models.UniBase.Supplier.Supplier
{
  public class SupplierCreate : TSupplier, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = SupplierCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = SupplierCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Supplier) + " su_Supplier INT NOT NULL,su_SiteID BIGINT NOT NULL DEFAULT(0),su_HeadSupplier INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_SupplierViewCode", (object) 6) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_SupplierName", (object) 100) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "su_SupplierType", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "su_SupplierKind", (object) 3) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "su_UseYn", (object) 1, (object) "Y") + ",su_PreTaxDiv INT NOT NULL DEFAULT(0),su_MultiSuplierDiv INT NOT NULL DEFAULT(0),su_DeductionDayDiv INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "su_NewStatementYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_Tel", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_Fax", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_BizNo", (object) 15) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_BizName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_BizCeo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_BizType", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_BizCategory", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_RegidentNo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_Addr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_Addr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ZipCode", (object) 7) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ContactNm1", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ContactMemo1", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ContactEmail1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ContactNm2", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ContactMemo2", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ContactEmail2", (object) 100) + ",su_BankCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_AccountNo", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_AccountName", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_Memo1", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_Memo2", (object) 200) + ",su_LeadTime INT NOT NULL DEFAULT(0),su_Deposit INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_ErpCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_EmailStatement", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "su_EmailTax", (object) 100) + ",su_AssignUser INT NOT NULL DEFAULT(0),su_InDate DATETIME NULL,su_InUser INT NOT NULL DEFAULT(0),su_ModDate DATETIME NULL,su_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(su_Supplier) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Supplier) + " su_Supplier INT NOT NULL,su_SiteID BIGINT NOT NULL DEFAULT 0,su_HeadSupplier INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_SupplierViewCode", (object) 6) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_SupplierName", (object) 100) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "su_SupplierType", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "su_SupplierKind", (object) 3) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "su_UseYn", (object) 1, (object) "Y") + ",su_PreTaxDiv INT NOT NULL DEFAULT 0,su_MultiSuplierDiv INT NOT NULL DEFAULT 0,su_DeductionDayDiv INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "su_NewStatementYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_Tel", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_Fax", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_BizNo", (object) 15) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_BizName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_BizCeo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_BizType", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_BizCategory", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_RegidentNo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_Addr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_Addr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ZipCode", (object) 7) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ContactNm1", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ContactMemo1", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ContactEmail1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ContactNm2", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ContactMemo2", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ContactEmail2", (object) 100) + ",su_BankCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_AccountNo", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_AccountName", (object) 30) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_Memo1", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_Memo2", (object) 200) + ",su_LeadTime INT NOT NULL DEFAULT 0,su_Deposit INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_ErpCode", (object) 10) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_EmailStatement", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "su_EmailTax", (object) 100) + ",su_AssignUser INT NOT NULL DEFAULT 0,su_InDate DATETIME NULL,su_InUser INT NOT NULL DEFAULT 0,su_ModDate DATETIME NULL,su_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(su_Supplier) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(SupplierCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Supplier.ToDescription(), (object) TableCodeType.Supplier));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "코드", (object) TableCodeType.Supplier, (object) "su_Supplier"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Supplier, (object) "su_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "대표코드", (object) TableCodeType.Supplier, (object) "su_HeadSupplier"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "식별코드", (object) TableCodeType.Supplier, (object) "su_SupplierViewCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업체명", (object) TableCodeType.Supplier, (object) "su_SupplierName"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "형태", (object) 40, (object) TableCodeType.Supplier, (object) "su_SupplierType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "타입", (object) 41, (object) TableCodeType.Supplier, (object) "su_SupplierKind"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상태", (object) TableCodeType.Supplier, (object) "su_UseYn"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "기준단가", (object) 42, (object) TableCodeType.Supplier, (object) "su_PreTaxDiv"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "타사상품", (object) 43, (object) TableCodeType.Supplier, (object) "su_MultiSuplierDiv"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "자동공제", (object) 44, (object) TableCodeType.Supplier, (object) "su_DeductionDayDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "신규전표사용상태", (object) TableCodeType.Supplier, (object) "su_NewStatementYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "전화", (object) TableCodeType.Supplier, (object) "su_Tel"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "FAX", (object) TableCodeType.Supplier, (object) "su_Fax"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사업자번호", (object) TableCodeType.Supplier, (object) "su_BizNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사업자명", (object) TableCodeType.Supplier, (object) "su_BizName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "대표자", (object) TableCodeType.Supplier, (object) "su_BizCeo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업태", (object) TableCodeType.Supplier, (object) "su_BizType"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "업종", (object) TableCodeType.Supplier, (object) "su_BizCategory"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주민번호", (object) TableCodeType.Supplier, (object) "su_RegidentNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주소", (object) TableCodeType.Supplier, (object) "su_Addr1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "주소 상세", (object) TableCodeType.Supplier, (object) "su_Addr2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "우편번호", (object) TableCodeType.Supplier, (object) "su_ZipCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자", (object) TableCodeType.Supplier, (object) "su_ContactNm1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자 연락처", (object) TableCodeType.Supplier, (object) "su_ContactMemo1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자 이메일", (object) TableCodeType.Supplier, (object) "su_ContactEmail1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자2", (object) TableCodeType.Supplier, (object) "su_ContactNm2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자2 연락처", (object) TableCodeType.Supplier, (object) "su_ContactMemo2"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자2 이메일", (object) TableCodeType.Supplier, (object) "su_ContactEmail2"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "은행", (object) 32, (object) TableCodeType.Supplier, (object) "su_BankCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "계좌번호", (object) TableCodeType.Supplier, (object) "su_AccountNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "예금주명", (object) TableCodeType.Supplier, (object) "su_AccountName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.Supplier, (object) "su_Memo1"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모 상세", (object) TableCodeType.Supplier, (object) "su_Memo2"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "리드타입", (object) 110, (object) TableCodeType.Supplier, (object) "su_LeadTime"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "보증금", (object) TableCodeType.Supplier, (object) "su_Deposit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "ERP 코드", (object) TableCodeType.Supplier, (object) "su_ErpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "전표용 이메일", (object) TableCodeType.Supplier, (object) "su_EmailStatement"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "계산서용 이메일", (object) TableCodeType.Supplier, (object) "su_EmailTax"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당사원", (object) TableCodeType.Supplier, (object) "su_AssignUser"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.Supplier, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Supplier) + " (su_SupplierType,su_Supplier)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_1 ON {1}.dbo.{2}", (object) TableCodeType.Supplier, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Supplier) + " (su_SupplierType,su_Supplier);");
        stringBuilder.Append(string.Format("CREATE STATISTICS {0}_STATISTICS_2 ON {1}.dbo.{2}", (object) TableCodeType.Supplier, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Supplier) + " (su_NewStatementYn,su_Supplier,su_SupplierType);");
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
      SupplierView supplierView = this.OleDB.Create<SupplierView>();
      if (pSiteID == 1L)
      {
        supplierView.su_Supplier = 1;
        supplierView.su_SiteID = pSiteID;
        supplierView.su_HeadSupplier = 1;
        supplierView.su_SupplierViewCode = "0001";
        supplierView.su_SupplierName = "지점";
        supplierView.su_SupplierType = 1;
        supplierView.su_SupplierKind = 1;
        supplierView.su_PreTaxDiv = 1;
        supplierView.su_MultiSuplierDiv = 2;
        supplierView.su_DeductionDayDiv = 2;
        this.OleDB.Execute(supplierView.InsertQuery());
        supplierView.su_Supplier = 1001;
        supplierView.su_SiteID = pSiteID;
        supplierView.su_HeadSupplier = 1001;
        supplierView.su_SupplierViewCode = "000000";
        supplierView.su_SupplierName = "직영대표";
        supplierView.su_SupplierType = 1;
        supplierView.su_SupplierKind = 3;
        supplierView.su_PreTaxDiv = 1;
        supplierView.su_MultiSuplierDiv = 1;
        supplierView.su_DeductionDayDiv = 2;
        this.OleDB.Execute(supplierView.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("su_Supplier"))
          this.su_Supplier = p_rs.GetFieldInt("su_Supplier");
        if (p_rs.IsFieldName("su_SiteID"))
          this.su_SiteID = p_rs.GetFieldLong("su_SiteID");
        if (p_rs.IsFieldName("su_HeadSupplier"))
          this.su_HeadSupplier = p_rs.GetFieldInt("su_HeadSupplier");
        if (p_rs.IsFieldName("su_SupplierViewCode"))
          this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
        if (p_rs.IsFieldName("su_SupplierName"))
          this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
        if (p_rs.IsFieldName("su_SupplierType"))
          this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
        if (p_rs.IsFieldName("su_UseYn"))
          this.su_UseYn = p_rs.GetFieldString("su_UseYn");
        if (p_rs.IsFieldName("su_PreTaxDiv"))
          this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
        if (p_rs.IsFieldName("su_MultiSuplierDiv"))
          this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
        if (p_rs.IsFieldName("su_DeductionDayDiv"))
          this.su_DeductionDayDiv = p_rs.GetFieldInt("su_DeductionDayDiv");
        if (p_rs.IsFieldName("su_NewStatementYn"))
          this.su_NewStatementYn = p_rs.GetFieldString("su_NewStatementYn");
        if (p_rs.IsFieldName("su_Tel"))
          this.su_Tel = p_rs.GetFieldString("su_Tel");
        if (p_rs.IsFieldName("su_Fax"))
          this.su_Fax = p_rs.GetFieldString("su_Fax");
        if (p_rs.IsFieldName("su_BizNo"))
          this.su_BizNo = p_rs.GetFieldString("su_BizNo");
        if (p_rs.IsFieldName("su_BizName"))
          this.su_BizName = p_rs.GetFieldString("su_BizName");
        if (p_rs.IsFieldName("su_BizCeo"))
          this.su_BizCeo = p_rs.GetFieldString("su_BizCeo");
        if (p_rs.IsFieldName("su_BizType"))
          this.su_BizType = p_rs.GetFieldString("su_BizType");
        if (p_rs.IsFieldName("su_BizCategory"))
          this.su_BizCategory = p_rs.GetFieldString("su_BizCategory");
        if (p_rs.IsFieldName("su_RegidentNo"))
          this.su_RegidentNo = p_rs.GetFieldString("su_RegidentNo");
        if (p_rs.IsFieldName("su_Addr1"))
          this.su_Addr1 = p_rs.GetFieldString("su_Addr1");
        if (p_rs.IsFieldName("su_Addr2"))
          this.su_Addr2 = p_rs.GetFieldString("su_Addr2");
        if (p_rs.IsFieldName("su_ZipCode"))
          this.su_ZipCode = p_rs.GetFieldString("su_ZipCode");
        if (p_rs.IsFieldName("su_ContactNm1"))
          this.su_ContactNm1 = p_rs.GetFieldString("su_ContactNm1");
        if (p_rs.IsFieldName("su_ContactMemo1"))
          this.su_ContactMemo1 = p_rs.GetFieldString("su_ContactMemo1");
        if (p_rs.IsFieldName("su_ContactEmail1"))
          this.su_ContactEmail1 = p_rs.GetFieldString("su_ContactEmail1");
        if (p_rs.IsFieldName("su_ContactNm2"))
          this.su_ContactNm2 = p_rs.GetFieldString("su_ContactNm2");
        if (p_rs.IsFieldName("su_ContactMemo2"))
          this.su_ContactMemo2 = p_rs.GetFieldString("su_ContactMemo2");
        if (p_rs.IsFieldName("su_ContactEmail2"))
          this.su_ContactEmail2 = p_rs.GetFieldString("su_ContactEmail2");
        if (p_rs.IsFieldName("su_BankCode"))
          this.su_BankCode = p_rs.GetFieldInt("su_BankCode");
        if (p_rs.IsFieldName("su_AccountNo"))
          this.su_AccountNo = p_rs.GetFieldString("su_AccountNo");
        if (p_rs.IsFieldName("su_AccountName"))
          this.su_AccountName = p_rs.GetFieldString("su_AccountName");
        if (p_rs.IsFieldName("su_Memo1"))
          this.su_Memo1 = p_rs.GetFieldString("su_Memo1");
        if (p_rs.IsFieldName("su_Memo2"))
          this.su_Memo2 = p_rs.GetFieldString("su_Memo2");
        if (p_rs.IsFieldName("su_LeadTime"))
          this.su_LeadTime = p_rs.GetFieldInt("su_LeadTime");
        if (p_rs.IsFieldName("su_Deposit"))
          this.su_Deposit = p_rs.GetFieldInt("su_Deposit");
        if (p_rs.IsFieldName("su_ErpCode"))
          this.su_ErpCode = p_rs.GetFieldString("su_ErpCode");
        if (p_rs.IsFieldName("su_EmailStatement"))
          this.su_EmailStatement = p_rs.GetFieldString("su_EmailStatement");
        if (p_rs.IsFieldName("su_EmailTax"))
          this.su_EmailTax = p_rs.GetFieldString("su_EmailTax");
        if (p_rs.IsFieldName("su_AssignUser"))
          this.su_AssignUser = p_rs.GetFieldInt("su_AssignUser");
        if (p_rs.IsFieldName("su_InDate"))
          this.su_InDate = p_rs.GetFieldDateTime("su_InDate");
        if (p_rs.IsFieldName("su_InUser"))
          this.su_InUser = p_rs.GetFieldInt("su_InUser");
        if (p_rs.IsFieldName("su_ModDate"))
          this.su_ModDate = p_rs.GetFieldDateTime("su_ModDate");
        if (p_rs.IsFieldName("su_ModUser"))
          this.su_ModUser = p_rs.GetFieldInt("su_ModUser");
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
        IList<SupplierCreate> supplierCreateList = this.OleDB.Create<SupplierCreate>().SelectAllListE<SupplierCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (supplierCreateList == null)
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
        int count = supplierCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (supplierCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Supplier.ToDescription(), (object) TableCodeType.Supplier) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (SupplierCreate supplierCreate in (IEnumerable<SupplierCreate>) supplierCreateList)
        {
          stringBuilder.Append(supplierCreate.InsertQuery());
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
        if (supplierCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Supplier.ToDescription(), (object) TableCodeType.Supplier) + "\n--------------------------------------------------------------------------------------------------");
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
