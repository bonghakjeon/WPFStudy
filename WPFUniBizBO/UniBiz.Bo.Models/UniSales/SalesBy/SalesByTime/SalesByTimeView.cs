// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.SalesByTimeView
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime
{
  public class SalesByTimeView : TSalesByTime<SalesByTimeView>
  {
    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear() => base.Clear();

    protected override UbModelBase CreateClone => (UbModelBase) new SalesByTimeView();

    public override object Clone() => (object) (base.Clone() as SalesByTimeView);

    public void PutData(SalesByTimeView pSource) => this.PutData((TSalesByTime) pSource);

    protected override EnumDataCheck DataCheck()
    {
      if (this.sbt_SiteID == 0L)
      {
        this.message = "싸이트(sbt_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.sbt_SaleDate.HasValue)
      {
        this.message = "판매일자(sbt_SaleDate)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sbt_StoreCode == 0)
      {
        this.message = "지점코드(sbt_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sbt_GoodsCode != 0L)
        return EnumDataCheck.Success;
      this.message = "상품코드(sbt_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
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

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.sbt_SiteID == 0L)
            this.sbt_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      SalesByTimeView salesByTimeView = this;
      try
      {
        salesByTimeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != salesByTimeView.DataCheck(p_db))
            throw new UniServiceException(salesByTimeView.message, salesByTimeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (salesByTimeView.sbt_SiteID == 0L)
            salesByTimeView.sbt_SiteID = p_app_employee.emp_SiteID;
          if (!salesByTimeView.IsPermit(p_app_employee))
            throw new UniServiceException(salesByTimeView.message, salesByTimeView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await salesByTimeView.InsertAsync())
          throw new UniServiceException(salesByTimeView.message, salesByTimeView.TableCode.ToDescription() + " 등록 오류");
        salesByTimeView.db_status = 4;
        salesByTimeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        salesByTimeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        salesByTimeView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      SalesByTimeView salesByTimeView = this;
      try
      {
        salesByTimeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != salesByTimeView.DataCheck(p_db))
            throw new UniServiceException(salesByTimeView.message, salesByTimeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!salesByTimeView.IsPermit(p_app_employee))
          throw new UniServiceException(salesByTimeView.message, salesByTimeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await salesByTimeView.UpdateAsync())
          throw new UniServiceException(salesByTimeView.message, salesByTimeView.TableCode.ToDescription() + " 변경 오류");
        salesByTimeView.db_status = 4;
        salesByTimeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        salesByTimeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        salesByTimeView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs) => base.GetFieldValues(p_rs);

    public async Task<SalesByTimeView> SelectOneAsync(
      DateTime p_sbt_SaleDate,
      int p_sbt_StoreCode,
      long p_sbt_CategoryCode,
      long p_sbt_DeptCode,
      int p_sbt_BoxCode,
      int p_sbt_GoodsCode,
      int p_sbt_Supplier,
      int p_sbt_KeySeq,
      long p_sbt_SiteID = 0)
    {
      SalesByTimeView salesByTimeView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sbt_SaleDate",
          (object) p_sbt_SaleDate
        },
        {
          (object) "sbt_StoreCode",
          (object) p_sbt_StoreCode
        },
        {
          (object) "sbt_CategoryCode",
          (object) p_sbt_CategoryCode
        },
        {
          (object) "sbt_DeptCode",
          (object) p_sbt_DeptCode
        },
        {
          (object) "sbt_BoxCode",
          (object) p_sbt_BoxCode
        },
        {
          (object) "sbt_GoodsCode",
          (object) p_sbt_GoodsCode
        },
        {
          (object) "sbt_Supplier",
          (object) p_sbt_Supplier
        },
        {
          (object) "sbt_KeySeq",
          (object) p_sbt_KeySeq
        }
      };
      if (p_sbt_SiteID > 0L)
        p_param.Add((object) "sbt_SiteID", (object) p_sbt_SiteID);
      return await salesByTimeView.SelectOneTAsync<SalesByTimeView>((object) p_param);
    }

    public async Task<IList<SalesByTimeView>> SelectListAsync(object p_param)
    {
      SalesByTimeView salesByTimeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(salesByTimeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, salesByTimeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(salesByTimeView1.GetSelectQuery(p_param)))
        {
          salesByTimeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByTimeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SalesByTimeView>) null;
        }
        IList<SalesByTimeView> lt_list = (IList<SalesByTimeView>) new List<SalesByTimeView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SalesByTimeView salesByTimeView2 = salesByTimeView1.OleDB.Create<SalesByTimeView>();
            if (salesByTimeView2.GetFieldValues(rs))
            {
              salesByTimeView2.row_number = lt_list.Count + 1;
              lt_list.Add(salesByTimeView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByTimeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SalesByTimeView> SelectEnumerableAsync(object p_param)
    {
      SalesByTimeView salesByTimeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(salesByTimeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, salesByTimeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(salesByTimeView1.GetSelectQuery(p_param)))
        {
          salesByTimeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByTimeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SalesByTimeView salesByTimeView2 = salesByTimeView1.OleDB.Create<SalesByTimeView>();
            if (salesByTimeView2.GetFieldValues(rs))
            {
              salesByTimeView2.row_number = ++row_number;
              yield return salesByTimeView2;
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
