// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByDept
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByDept : SaleByMonthVerticalByTeam<SaleByMonthVerticalByDept>
  {
    private string _dpt_ViewCode;
    private string _dpt_DeptName;

    public string dpt_ViewCode
    {
      get => this._dpt_ViewCode;
      set
      {
        this._dpt_ViewCode = value;
        this.Changed(nameof (dpt_ViewCode));
        this.Changed("dpt_lv3_ViewCode");
      }
    }

    public string dpt_lv3_ViewCode => this.dpt_ViewCode;

    public string dpt_DeptName
    {
      get => this._dpt_DeptName;
      set
      {
        this._dpt_DeptName = value;
        this.Changed(nameof (dpt_DeptName));
        this.Changed("dpt_lv3_Name");
      }
    }

    public string dpt_lv3_Name => this.dpt_DeptName;

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (SaleByMonthVerticalByDept), (object) this.sbd_SaleDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.dpt_ViewCode = string.Empty;
      this.dpt_DeptName = string.Empty;
    }

    public void InitInfo(SaleByMonthVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sbd_SaleDate] 이 KeyCode 와 다릅니다");
      foreach (DeptView deptView in (IEnumerable<DeptView>) p_Header)
      {
        IList<SalesByDayGoal> ltDetails = this.Lt_Details;
        SalesByMonthGoal salesByMonthGoal = new SalesByMonthGoal();
        salesByMonthGoal.sbd_StoreCode = pData.sbd_StoreCode;
        salesByMonthGoal.sbd_DeptCode = deptView.dpt_ID;
        ltDetails.Add((SalesByDayGoal) salesByMonthGoal);
      }
    }

    public void Add(SaleByMonthVerticalByDept item)
    {
      if (!this.sbd_SaleDate.HasValue)
        this.sbd_SaleDate = item.sbd_SaleDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sbd_SaleDate 이 sbd_SaleDate 와 다릅니다");
      this.CalcAddSum((SalesByMonthGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_StoreCode == item.sbd_StoreCode && it.sbd_DeptCode == item.sbd_DeptCode));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(IList<SaleByMonthVerticalByDept> infos)
    {
      foreach (SaleByMonthVerticalByDept info in (IEnumerable<SaleByMonthVerticalByDept>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByMonthVerticalByDept pSource) => pSource == null || this.IsZero(pCheckType, (SaleByMonthVerticalByTeam) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
        this.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByMonthVerticalByDept>> SelectMonthVerticalByDeptListAsync(
      object p_param)
    {
      SaleByMonthVerticalByDept monthVerticalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByDept1.GetSelectQuery(p_param)))
        {
          monthVerticalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByMonthVerticalByDept>) null;
        }
        IList<SaleByMonthVerticalByDept> lt_list = (IList<SaleByMonthVerticalByDept>) new List<SaleByMonthVerticalByDept>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByMonthVerticalByDept monthVerticalByDept2 = monthVerticalByDept1.OleDB.Create<SaleByMonthVerticalByDept>();
            if (monthVerticalByDept2.GetFieldValues(rs))
            {
              monthVerticalByDept2.row_number = lt_list.Count + 1;
              lt_list.Add(monthVerticalByDept2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByMonthVerticalByDept> SelectMonthVerticalByDeptEnumerableAsync(
      object p_param)
    {
      SaleByMonthVerticalByDept monthVerticalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByDept1.GetSelectQuery(p_param)))
        {
          monthVerticalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByMonthVerticalByDept monthVerticalByDept2 = monthVerticalByDept1.OleDB.Create<SaleByMonthVerticalByDept>();
            if (monthVerticalByDept2.GetFieldValues(rs))
            {
              monthVerticalByDept2.row_number = ++row_number;
              yield return monthVerticalByDept2;
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

    public override string GetSelectQuery(object p_param) => new SalesByMonthHorizontalByDept().GetSelectQuery(p_param);
  }
}
