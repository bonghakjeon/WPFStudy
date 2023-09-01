// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory.GiftCardHistoryCreate
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

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory
{
  public class GiftCardHistoryCreate : TGiftCardHistory, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = GiftCardHistoryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = GiftCardHistoryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.GiftCardHistory) + string.Format(" {0} VARCHAR({1}) NOT NULL", (object) "gch_GiftCardNo", (object) 40) + ",gch_SiteID BIGINT NOT NULL DEFAULT(0),gch_GiftCardID BIGINT NOT NULL DEFAULT(0),gch_IssueDate DATETIME NOT NULL,gch_IssueStore INT NOT NULL DEFAULT(0),gch_FaceValue INT NOT NULL DEFAULT(0),gch_ExpireDate DATETIME NOT NULL,gch_SaleDate DATETIME NULL,gch_SaleStore INT NOT NULL DEFAULT(0),gch_SalePosNo INT NOT NULL DEFAULT(0),gch_SaleTransNo INT NOT NULL DEFAULT(0),gch_SaleEmpCode INT NOT NULL DEFAULT(0),gch_SaleMemberNo BIGINT NOT NULL DEFAULT(0),gch_SaleKind INT NOT NULL DEFAULT(0),gch_ReturnDate DATETIME NULL,gch_ReturnStore INT NOT NULL DEFAULT(0),gch_ReturnPosNo INT NOT NULL DEFAULT(0),gch_ReturnTransNo INT NOT NULL DEFAULT(0),gch_ReturnMemberNo BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "gch_DisuseYn", (object) 1, (object) "N") + ",gch_DisuseDate DATETIME NULL,gch_DisuseStatement BIGINT NOT NULL DEFAULT(0),gch_DisuseEmpCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "gch_UseYn", (object) 1, (object) "N") + ",gch_InDate DATETIME NULL,gch_InUser INT NOT NULL DEFAULT(0),gch_ModDate DATETIME NULL,gch_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(gch_GiftCardNo) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.GiftCardHistory) + string.Format(" {0} VARCHAR({1}) NOT NULL", (object) "gch_GiftCardNo", (object) 40) + ",gch_SiteID BIGINT NOT NULL DEFAULT 0,gch_GiftCardID BIGINT NOT NULL DEFAULT 0,gch_IssueDate DATETIME NOT NULL,gch_IssueStore INT NOT NULL DEFAULT 0,gch_FaceValue INT NOT NULL DEFAULT 0,gch_ExpireDate DATETIME NOT NULL,gch_SaleDate DATETIME NULL,gch_SaleStore INT NOT NULL DEFAULT 0,gch_SalePosNo INT NOT NULL DEFAULT 0,gch_SaleTransNo INT NOT NULL DEFAULT 0,gch_SaleEmpCode INT NOT NULL DEFAULT 0,gch_SaleMemberNo BIGINT NOT NULL DEFAULT 0,gch_SaleKind INT NOT NULL DEFAULT 0,gch_ReturnDate DATETIME NULL,gch_ReturnStore INT NOT NULL DEFAULT 0,gch_ReturnPosNo INT NOT NULL DEFAULT 0,gch_ReturnTransNo INT NOT NULL DEFAULT 0,gch_ReturnMemberNo BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "gch_DisuseYn", (object) 1, (object) "N") + ",gch_DisuseDate DATETIME NULL,gch_DisuseStatement BIGINT NOT NULL DEFAULT 0,gch_DisuseEmpCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "gch_UseYn", (object) 1, (object) "N") + ",gch_InDate DATETIME NULL,gch_InUser INT NOT NULL DEFAULT 0,gch_ModDate DATETIME NULL,gch_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(gch_GiftCardNo) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(GiftCardHistoryCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.GiftCardHistory.ToDescription(), (object) TableCodeType.GiftCardHistory));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품권No", (object) TableCodeType.GiftCardHistory, (object) "gch_GiftCardNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.GiftCardHistory, (object) "gch_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품권ID", (object) TableCodeType.GiftCardHistory, (object) "gch_GiftCardID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발행일", (object) TableCodeType.GiftCardHistory, (object) "gch_IssueDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "발행매장", (object) TableCodeType.GiftCardHistory, (object) "gch_IssueStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "액면가", (object) TableCodeType.GiftCardHistory, (object) "gch_FaceValue"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "만료일", (object) TableCodeType.GiftCardHistory, (object) "gch_ExpireDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매일자", (object) TableCodeType.GiftCardHistory, (object) "gch_SaleDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매지점", (object) TableCodeType.GiftCardHistory, (object) "gch_SaleStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매POS", (object) TableCodeType.GiftCardHistory, (object) "gch_SalePosNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매영수증No", (object) TableCodeType.GiftCardHistory, (object) "gch_SaleTransNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매담당자", (object) TableCodeType.GiftCardHistory, (object) "gch_SaleEmpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "판매회원번호", (object) TableCodeType.GiftCardHistory, (object) "gch_SaleMemberNo"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "판매구분", (object) 155, (object) TableCodeType.GiftCardHistory, (object) "gch_SaleKind"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용일자", (object) TableCodeType.GiftCardHistory, (object) "gch_ReturnDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용지점", (object) TableCodeType.GiftCardHistory, (object) "gch_ReturnStore"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용POS ", (object) TableCodeType.GiftCardHistory, (object) "gch_ReturnPosNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용영수증N", (object) TableCodeType.GiftCardHistory, (object) "gch_ReturnTransNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용회원", (object) TableCodeType.GiftCardHistory, (object) "gch_ReturnMemberNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "폐기구분 (Y:폐기, N:사용가능)", (object) TableCodeType.GiftCardHistory, (object) "gch_DisuseYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "폐기일 ", (object) TableCodeType.GiftCardHistory, (object) "gch_DisuseDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "폐기전표번호", (object) TableCodeType.GiftCardHistory, (object) "gch_DisuseStatement"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "폐기담당", (object) TableCodeType.GiftCardHistory, (object) "gch_DisuseEmpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용상태", (object) TableCodeType.GiftCardHistory, (object) "gch_UseYn"));
        if (this.OleDB.Execute(stringBuilder.ToString()))
          return true;
        this.message = " " + this.TableCode.ToDescription() + " 주석 Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.DebugColor(this.message);
        return false;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
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
        if (p_rs.IsFieldName("gch_GiftCardNo"))
          this.gch_GiftCardNo = p_rs.GetFieldString("gch_GiftCardNo");
        if (p_rs.IsFieldName("gch_SiteID"))
          this.gch_SiteID = p_rs.GetFieldLong("gch_SiteID");
        if (p_rs.IsFieldName("gch_GiftCardID"))
          this.gch_GiftCardID = p_rs.GetFieldLong("gch_GiftCardID");
        if (p_rs.IsFieldName("gch_IssueDate"))
          this.gch_IssueDate = p_rs.GetFieldDateTime("gch_IssueDate");
        if (p_rs.IsFieldName("gch_IssueStore"))
          this.gch_IssueStore = p_rs.GetFieldInt("gch_IssueStore");
        if (p_rs.IsFieldName("gch_FaceValue"))
          this.gch_FaceValue = p_rs.GetFieldInt("gch_FaceValue");
        if (p_rs.IsFieldName("gch_ExpireDate"))
          this.gch_ExpireDate = p_rs.GetFieldDateTime("gch_ExpireDate");
        if (p_rs.IsFieldName("gch_SaleDate"))
          this.gch_SaleDate = p_rs.GetFieldDateTime("gch_SaleDate");
        if (p_rs.IsFieldName("gch_SaleStore"))
          this.gch_SaleStore = p_rs.GetFieldInt("gch_SaleStore");
        if (p_rs.IsFieldName("gch_SalePosNo"))
          this.gch_SalePosNo = p_rs.GetFieldInt("gch_SalePosNo");
        if (p_rs.IsFieldName("gch_SaleTransNo"))
          this.gch_SaleTransNo = p_rs.GetFieldInt("gch_SaleTransNo");
        if (p_rs.IsFieldName("gch_SaleEmpCode"))
          this.gch_SaleEmpCode = p_rs.GetFieldInt("gch_SaleEmpCode");
        if (p_rs.IsFieldName("gch_SaleMemberNo"))
          this.gch_SaleMemberNo = p_rs.GetFieldLong("gch_SaleMemberNo");
        if (p_rs.IsFieldName("gch_SaleMemberNo"))
          this.gch_SaleKind = p_rs.GetFieldInt("gch_SaleKind");
        if (p_rs.IsFieldName("gch_ReturnDate"))
          this.gch_ReturnDate = p_rs.GetFieldDateTime("gch_ReturnDate");
        if (p_rs.IsFieldName("gch_ReturnStore"))
          this.gch_ReturnStore = p_rs.GetFieldInt("gch_ReturnStore");
        if (p_rs.IsFieldName("gch_ReturnPosNo"))
          this.gch_ReturnPosNo = p_rs.GetFieldInt("gch_ReturnPosNo");
        if (p_rs.IsFieldName("gch_ReturnTransNo"))
          this.gch_ReturnTransNo = p_rs.GetFieldInt("gch_ReturnTransNo");
        if (p_rs.IsFieldName("gch_ReturnMemberNo"))
          this.gch_ReturnMemberNo = p_rs.GetFieldLong("gch_ReturnMemberNo");
        if (p_rs.IsFieldName("gch_DisuseYn"))
          this.gch_DisuseYn = p_rs.GetFieldString("gch_DisuseYn");
        if (p_rs.IsFieldName("gch_DisuseDate"))
          this.gch_DisuseDate = p_rs.GetFieldDateTime("gch_DisuseDate");
        if (p_rs.IsFieldName("gch_DisuseStatement"))
          this.gch_DisuseStatement = p_rs.GetFieldLong("gch_DisuseStatement");
        if (p_rs.IsFieldName("gch_DisuseEmpCode"))
          this.gch_DisuseEmpCode = p_rs.GetFieldInt("gch_DisuseEmpCode");
        if (p_rs.IsFieldName("gch_UseYn"))
          this.gch_UseYn = p_rs.GetFieldString("gch_UseYn");
        if (p_rs.IsFieldName("gch_InDate"))
          this.gch_InDate = p_rs.GetFieldDateTime("gch_InDate");
        if (p_rs.IsFieldName("gch_InUser"))
          this.gch_InUser = p_rs.GetFieldInt("gch_InUser");
        if (p_rs.IsFieldName("gch_ModDate"))
          this.gch_ModDate = p_rs.GetFieldDateTime("gch_ModDate");
        if (p_rs.IsFieldName("gch_ModUser"))
          this.gch_ModUser = p_rs.GetFieldInt("gch_ModUser");
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
        IList<GiftCardHistoryCreate> cardHistoryCreateList = this.OleDB.Create<GiftCardHistoryCreate>().SelectAllListE<GiftCardHistoryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (cardHistoryCreateList == null)
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
        int count = cardHistoryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (cardHistoryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.GiftCardHistory.ToDescription(), (object) TableCodeType.GiftCardHistory) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (GiftCardHistoryCreate cardHistoryCreate in (IEnumerable<GiftCardHistoryCreate>) cardHistoryCreateList)
        {
          stringBuilder.Append(cardHistoryCreate.InsertQuery());
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
        if (cardHistoryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.GiftCardHistory.ToDescription(), (object) TableCodeType.GiftCardHistory) + "\n--------------------------------------------------------------------------------------------------");
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
