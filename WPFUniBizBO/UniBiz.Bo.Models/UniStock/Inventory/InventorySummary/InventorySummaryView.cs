// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.InventorySummaryView
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

namespace UniBiz.Bo.Models.UniStock.Inventory.InventorySummary
{
  public class InventorySummaryView : TInventorySummary<InventorySummaryView>
  {
    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear() => base.Clear();

    protected override UbModelBase CreateClone => (UbModelBase) new InventorySummaryView();

    public override object Clone() => (object) (base.Clone() as InventorySummaryView);

    public void PutData(InventorySummaryView pSource) => this.PutData((TInventorySummary) pSource);

    protected override EnumDataCheck DataCheck()
    {
      if (this.ivts_SiteID == 0L)
      {
        this.message = "싸이트(ivts_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_YyyyMm == 0)
      {
        this.message = "마감년월(ivts_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_Day == 0)
      {
        this.message = "일자(ivts_Day)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_StoreCode == 0)
      {
        this.message = "지점코드(ivts_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_GoodsCode != 0L)
        return EnumDataCheck.Success;
      this.message = "상품코드(ivts_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
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

    public async Task<InventorySummaryView> SelectOneAsync(
      int p_ivts_YyyyMm,
      int p_ivts_Day,
      int p_ivts_StoreCode,
      long p_ivts_GoodsCode,
      long p_ivts_SiteID = 0)
    {
      InventorySummaryView inventorySummaryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ivts_YyyyMm",
          (object) p_ivts_YyyyMm
        },
        {
          (object) "ivts_Day",
          (object) p_ivts_Day
        },
        {
          (object) "ivts_StoreCode",
          (object) p_ivts_StoreCode
        },
        {
          (object) "ivts_GoodsCode",
          (object) p_ivts_GoodsCode
        }
      };
      if (p_ivts_SiteID > 0L)
        p_param.Add((object) "ivts_SiteID", (object) p_ivts_SiteID);
      return await inventorySummaryView.SelectOneTAsync<InventorySummaryView>((object) p_param);
    }

    public async Task<IList<InventorySummaryView>> SelectListAsync(object p_param)
    {
      InventorySummaryView inventorySummaryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventorySummaryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventorySummaryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventorySummaryView1.GetSelectQuery(p_param)))
        {
          inventorySummaryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventorySummaryView>) null;
        }
        IList<InventorySummaryView> lt_list = (IList<InventorySummaryView>) new List<InventorySummaryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventorySummaryView inventorySummaryView2 = inventorySummaryView1.OleDB.Create<InventorySummaryView>();
            if (inventorySummaryView2.GetFieldValues(rs))
            {
              inventorySummaryView2.row_number = lt_list.Count + 1;
              lt_list.Add(inventorySummaryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<InventorySummaryView> SelectEnumerableAsync(object p_param)
    {
      InventorySummaryView inventorySummaryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventorySummaryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventorySummaryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventorySummaryView1.GetSelectQuery(p_param)))
        {
          inventorySummaryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            InventorySummaryView inventorySummaryView2 = inventorySummaryView1.OleDB.Create<InventorySummaryView>();
            if (inventorySummaryView2.GetFieldValues(rs))
            {
              inventorySummaryView2.row_number = ++row_number;
              yield return inventorySummaryView2;
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
