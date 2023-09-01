// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementHeaderForPayment
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
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniStock.Payment.Statement;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementHeaderForPayment : StatementHeaderView<StatementHeaderForPayment>
  {
    private long _pay_Code;

    public long pay_Code
    {
      get => this._pay_Code;
      set
      {
        this._pay_Code = value;
        this.Changed(nameof (pay_Code));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pay_Code", new TTableColumn()
      {
        tc_orgin_name = "pay_Code",
        tc_trans_name = "결제코드"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.pay_Code = 0L;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StatementHeaderForPayment();

    public override object Clone()
    {
      StatementHeaderForPayment headerForPayment = base.Clone() as StatementHeaderForPayment;
      headerForPayment.pay_Code = this.pay_Code;
      return (object) headerForPayment;
    }

    public void PutData(StatementHeaderForPayment pSource)
    {
      this.PutData((StatementHeaderView) pSource);
      this.pay_Code = pSource.pay_Code;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.pay_Code = p_rs.GetFieldLong("pay_Code");
      return true;
    }

    public async Task<IList<StatementHeaderForPayment>> SelectForPaymentListAsync(object p_param)
    {
      StatementHeaderForPayment headerForPayment1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(headerForPayment1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, headerForPayment1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(headerForPayment1.GetSelectQuery(p_param)))
        {
          headerForPayment1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + headerForPayment1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementHeaderForPayment>) null;
        }
        IList<StatementHeaderForPayment> lt_list = (IList<StatementHeaderForPayment>) new List<StatementHeaderForPayment>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementHeaderForPayment headerForPayment2 = headerForPayment1.OleDB.Create<StatementHeaderForPayment>();
            if (headerForPayment2.GetFieldValues(rs))
            {
              headerForPayment2.row_number = lt_list.Count + 1;
              lt_list.Add(headerForPayment2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + headerForPayment1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementHeaderForPayment> SelectForPaymentEnumerableAsync(
      object p_param)
    {
      StatementHeaderForPayment headerForPayment1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(headerForPayment1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, headerForPayment1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(headerForPayment1.GetSelectQuery(p_param)))
        {
          headerForPayment1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + headerForPayment1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementHeaderForPayment headerForPayment2 = headerForPayment1.OleDB.Create<StatementHeaderForPayment>();
            if (headerForPayment2.GetFieldValues(rs))
            {
              headerForPayment2.row_number = ++row_number;
              yield return headerForPayment2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sh_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "sh_DeliveryNumber", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num = 0;
        long p_SiteID = 0;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "sh_SiteID") && Convert.ToInt64(hashtable2[(object) "sh_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "sh_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeadSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeAssignQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithOuterConnAuthQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPaymentQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n SELECT  sh_StatementNo,sh_SiteID,sh_StoreCode,sh_OrderDate,sh_OrderStatus,sh_ConfirmDate,sh_ConfirmStatus,sh_Supplier,sh_SupplierType,sh_InOutDiv,sh_StatementType,sh_ReasonCode,sh_CostTaxAmt,sh_CostTaxFreeAmt,sh_CostVatAmt,sh_Deposit,sh_PriceTaxAmt,sh_PriceTaxFreeAmt,sh_PriceVatAmt,sh_ProfitAmt,sh_DeviceType,sh_OuterConnAuth,sh_AdditionalOpt,sh_Memo,sh_DeliveryNumber,sh_TransmitStatus,sh_TransmitDate,sh_MobieStatementNo,sh_AssignUser,sh_InDate,sh_InUser,sh_ModDate,sh_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_Email,si_LocationUseYn\n,su_HeadSupplier,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement\n,head_su_SupplierName AS su_HeadName,head_su_SupplierViewCode\n,oca_DeviceName\n,inEmpName,modEmpName,sh_AssignUser_Name\n,pay_Code");
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_PAYMENT ON sh_SiteID=pay_SiteID AND sh_StoreCode=pay_StoreCode AND sh_ConfirmDate>=pay_StartDate AND sh_ConfirmDate<=pay_EndDate AND sh_Supplier=pay_Supplier\n LEFT OUTER JOIN T_STORE ON sh_StoreCode=si_StoreCode AND sh_SiteID=si_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON sh_Supplier=su_Supplier AND sh_SiteID=su_SiteID\n LEFT OUTER JOIN T_SUPPLIER_HEAD ON su_HeadSupplier=head_su_Supplier AND sh_SiteID=head_su_SiteID\n LEFT OUTER JOIN T_OUTER_CONN_AUTH ON sh_OuterConnAuth=oca_ID AND sh_SiteID=oca_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON sh_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON sh_ModUser=emp_CodeMod\n LEFT OUTER JOIN T_EMPLOYEE_ASSIGN ON sh_AssignUser=emp_CodeAssign");
        stringBuilder.Append("\n");
        if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
        else
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
        if (num > 0)
        {
          switch (num)
          {
            case 1:
              stringBuilder.Append("\nORDER BY sh_Supplier,sh_StoreCode,sh_ConfirmDate,sh_StatementNo");
              break;
            case 2:
              stringBuilder.Append("\nORDER BY sh_Supplier,sh_StoreCode,sh_ConfirmDate DESC,sh_StatementNo");
              break;
            default:
              stringBuilder.Append("\nORDER BY sh_StatementNo");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY sh_StatementNo");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPaymentQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PAYMENT AS ( SELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,pay_Type,pay_StartDate,pay_EndDate" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()));
        hashtable.Clear();
        if (p_param is Hashtable p_param1)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
        }
        else
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pay_SiteID", (object) 0L));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
