// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.ProfitLossSummaryView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary
{
  public class ProfitLossSummaryView : TProfitLossSummary<ProfitLossSummaryView>
  {
    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear() => base.Clear();

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossSummaryView();

    public override object Clone() => (object) (base.Clone() as ProfitLossSummaryView);

    public void PutData(ProfitLossSummaryView pSource) => this.PutData((TProfitLossSummary) pSource);

    protected override EnumDataCheck DataCheck()
    {
      if (this.pls_SiteID == 0L)
      {
        this.message = "싸이트(pls_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pls_YyyyMm == 0)
      {
        this.message = "년월(pls_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pls_StoreCode == 0)
      {
        this.message = "지점코드(pls_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pls_GoodsCode != 0L)
        return EnumDataCheck.Success;
      this.message = "상품코드(pls_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs) => base.GetFieldValues(p_rs);

    public async Task<ProfitLossSummaryView> SelectOneAsync(
      int p_pls_YyyyMm,
      int p_pls_StoreCode,
      long p_pls_GoodsCode,
      long p_pls_SiteID = 0)
    {
      ProfitLossSummaryView profitLossSummaryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pls_YyyyMm",
          (object) p_pls_YyyyMm
        },
        {
          (object) "pls_StoreCode",
          (object) p_pls_StoreCode
        },
        {
          (object) "pls_GoodsCode",
          (object) p_pls_GoodsCode
        }
      };
      if (p_pls_SiteID > 0L)
        p_param.Add((object) "pls_SiteID", (object) p_pls_SiteID);
      return await profitLossSummaryView.SelectOneTAsync<ProfitLossSummaryView>((object) p_param);
    }

    public async Task<IList<ProfitLossSummaryView>> SelectListAsync(object p_param)
    {
      ProfitLossSummaryView profitLossSummaryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(profitLossSummaryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, profitLossSummaryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(profitLossSummaryView1.GetSelectQuery(p_param)))
        {
          profitLossSummaryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryView>) null;
        }
        IList<ProfitLossSummaryView> lt_list = (IList<ProfitLossSummaryView>) new List<ProfitLossSummaryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossSummaryView profitLossSummaryView2 = profitLossSummaryView1.OleDB.Create<ProfitLossSummaryView>();
            if (profitLossSummaryView2.GetFieldValues(rs))
            {
              profitLossSummaryView2.row_number = lt_list.Count + 1;
              lt_list.Add(profitLossSummaryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ProfitLossSummaryView> SelectEnumerableAsync(object p_param)
    {
      ProfitLossSummaryView profitLossSummaryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(profitLossSummaryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, profitLossSummaryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(profitLossSummaryView1.GetSelectQuery(p_param)))
        {
          profitLossSummaryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ProfitLossSummaryView profitLossSummaryView2 = profitLossSummaryView1.OleDB.Create<ProfitLossSummaryView>();
            if (profitLossSummaryView2.GetFieldValues(rs))
            {
              profitLossSummaryView2.row_number = ++row_number;
              yield return profitLossSummaryView2;
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
      Hashtable hashtable = p_param as Hashtable;
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }
  }
}
