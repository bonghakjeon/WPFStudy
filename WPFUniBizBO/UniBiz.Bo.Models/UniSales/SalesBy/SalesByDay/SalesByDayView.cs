// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.SalesByDayView
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay
{
  public class SalesByDayView : TSalesByDay<SalesByDayView>
  {
    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear() => base.Clear();

    protected override UbModelBase CreateClone => (UbModelBase) new SalesByDayView();

    public override object Clone() => (object) (base.Clone() as SalesByDayView);

    public void PutData(SalesByDayView pSource) => this.PutData((TSalesByDay) pSource);

    protected override EnumDataCheck DataCheck()
    {
      if (this.sbd_SiteID == 0L)
      {
        this.message = "싸이트(sbd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.sbd_SaleDate.HasValue)
      {
        this.message = "판매일자(sbd_SaleDate)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sbd_StoreCode == 0)
      {
        this.message = "지점코드(sbd_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sbd_GoodsCode == 0L)
      {
        this.message = "상품코드(sbd_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sbd_SupplierType == 0)
      {
        this.message = "형태(sbd_SupplierType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sbd_CategoryCode != 0)
        return EnumDataCheck.Success;
      this.message = "분류ID(sbd_CategoryCode)  " + EnumDataCheck.CodeZero.ToDescription();
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
          if (this.sbd_SiteID == 0L)
            this.sbd_SiteID = p_app_employee.emp_SiteID;
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
      SalesByDayView salesByDayView = this;
      try
      {
        salesByDayView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != salesByDayView.DataCheck(p_db))
            throw new UniServiceException(salesByDayView.message, salesByDayView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (salesByDayView.sbd_SiteID) == 0L)
          {
            // ISSUE: explicit non-virtual call
            __nonvirtual (salesByDayView.sbd_SiteID) = p_app_employee.emp_SiteID;
          }
          if (!salesByDayView.IsPermit(p_app_employee))
            throw new UniServiceException(salesByDayView.message, salesByDayView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await salesByDayView.InsertAsync())
          throw new UniServiceException(salesByDayView.message, salesByDayView.TableCode.ToDescription() + " 등록 오류");
        salesByDayView.db_status = 4;
        salesByDayView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        salesByDayView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        salesByDayView.message = ex.Message;
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
      SalesByDayView salesByDayView = this;
      try
      {
        salesByDayView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != salesByDayView.DataCheck(p_db))
            throw new UniServiceException(salesByDayView.message, salesByDayView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!salesByDayView.IsPermit(p_app_employee))
          throw new UniServiceException(salesByDayView.message, salesByDayView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await salesByDayView.UpdateAsync())
          throw new UniServiceException(salesByDayView.message, salesByDayView.TableCode.ToDescription() + " 변경 오류");
        salesByDayView.db_status = 4;
        salesByDayView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        salesByDayView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        salesByDayView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs) => base.GetFieldValues(p_rs);

    public async Task<SalesByDayView> SelectOneAsync(
      DateTime p_sbd_SaleDate,
      int p_sbd_StoreCode,
      long p_sbd_BoxCode,
      long p_sbd_GoodsCode,
      int p_sbd_Supplier,
      int p_sbd_SupplierType,
      int p_sbd_CategoryCode,
      int p_sbd_DeptCode,
      int p_sbd_MakerCode,
      int p_sbd_KeySeq,
      long p_sbd_SiteID = 0)
    {
      SalesByDayView salesByDayView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sbd_SaleDate",
          (object) p_sbd_SaleDate
        },
        {
          (object) "sbd_StoreCode",
          (object) p_sbd_StoreCode
        },
        {
          (object) "sbd_BoxCode",
          (object) p_sbd_BoxCode
        },
        {
          (object) "sbd_GoodsCode",
          (object) p_sbd_GoodsCode
        },
        {
          (object) "sbd_Supplier",
          (object) p_sbd_Supplier
        },
        {
          (object) "sbd_SupplierType",
          (object) p_sbd_SupplierType
        },
        {
          (object) "sbd_CategoryCode",
          (object) p_sbd_CategoryCode
        },
        {
          (object) "sbd_DeptCode",
          (object) p_sbd_DeptCode
        },
        {
          (object) "sbd_MakerCode",
          (object) p_sbd_MakerCode
        },
        {
          (object) "sbd_KeySeq",
          (object) p_sbd_KeySeq
        }
      };
      if (p_sbd_SiteID > 0L)
        p_param.Add((object) "sbd_SiteID", (object) p_sbd_SiteID);
      return await salesByDayView.SelectOneTAsync<SalesByDayView>((object) p_param);
    }

    public async Task<IList<SalesByDayView>> SelectListAsync(object p_param)
    {
      SalesByDayView salesByDayView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(salesByDayView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, salesByDayView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(salesByDayView1.GetSelectQuery(p_param)))
        {
          salesByDayView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByDayView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SalesByDayView>) null;
        }
        IList<SalesByDayView> lt_list = (IList<SalesByDayView>) new List<SalesByDayView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SalesByDayView salesByDayView2 = salesByDayView1.OleDB.Create<SalesByDayView>();
            if (salesByDayView2.GetFieldValues(rs))
            {
              salesByDayView2.row_number = lt_list.Count + 1;
              lt_list.Add(salesByDayView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByDayView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SalesByDayView> SelectEnumerableAsync(object p_param)
    {
      SalesByDayView salesByDayView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(salesByDayView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, salesByDayView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(salesByDayView1.GetSelectQuery(p_param)))
        {
          salesByDayView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByDayView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SalesByDayView salesByDayView2 = salesByDayView1.OleDB.Create<SalesByDayView>();
            if (salesByDayView2.GetFieldValues(rs))
            {
              salesByDayView2.row_number = ++row_number;
              yield return salesByDayView2;
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
