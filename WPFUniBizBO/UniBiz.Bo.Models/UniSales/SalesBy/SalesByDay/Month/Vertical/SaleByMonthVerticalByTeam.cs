// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByTeam
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
  public class SaleByMonthVerticalByTeam : SaleByMonthVerticalByStore<SaleByMonthVerticalByTeam>
  {
    private int _dpt_lv1_ID;
    private string _dpt_lv1_ViewCode;
    private string _dpt_lv1_Name;
    private int _dpt_lv2_ID;
    private string _dpt_lv2_ViewCode;
    private string _dpt_lv2_Name;

    public int dpt_lv1_ID
    {
      get => this._dpt_lv1_ID;
      set
      {
        this._dpt_lv1_ID = value;
        this.Changed(nameof (dpt_lv1_ID));
        this.Changed("KeyCode");
      }
    }

    public string dpt_lv1_ViewCode
    {
      get => this._dpt_lv1_ViewCode;
      set
      {
        this._dpt_lv1_ViewCode = value;
        this.Changed(nameof (dpt_lv1_ViewCode));
      }
    }

    public string dpt_lv1_Name
    {
      get => this._dpt_lv1_Name;
      set
      {
        this._dpt_lv1_Name = value;
        this.Changed(nameof (dpt_lv1_Name));
      }
    }

    public int dpt_lv2_ID
    {
      get => this._dpt_lv2_ID;
      set
      {
        this._dpt_lv2_ID = value;
        this.Changed(nameof (dpt_lv2_ID));
        this.Changed("KeyCode");
      }
    }

    public string dpt_lv2_ViewCode
    {
      get => this._dpt_lv2_ViewCode;
      set
      {
        this._dpt_lv2_ViewCode = value;
        this.Changed(nameof (dpt_lv2_ViewCode));
      }
    }

    public string dpt_lv2_Name
    {
      get => this._dpt_lv2_Name;
      set
      {
        this._dpt_lv2_Name = value;
        this.Changed(nameof (dpt_lv2_Name));
      }
    }

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (SaleByMonthVerticalByTeam), (object) this.sbd_SaleDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.dpt_lv1_ID = 0;
      this.dpt_lv1_ViewCode = string.Empty;
      this.dpt_lv1_Name = string.Empty;
      this.dpt_lv2_ID = 0;
      this.dpt_lv2_ViewCode = string.Empty;
      this.dpt_lv2_Name = string.Empty;
    }

    public void InitInfo(SaleByMonthVerticalByTeam pData, IList<DeptView> p_Header)
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

    public void Add(SaleByMonthVerticalByTeam item)
    {
      if (!this.sbd_SaleDate.HasValue)
        this.sbd_SaleDate = item.sbd_SaleDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sbd_SaleDate 이 sbd_SaleDate 와 다릅니다");
      this.CalcAddSum((SalesByMonthGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_StoreCode == item.sbd_StoreCode && it.sbd_DeptCode == item.dpt_lv2_ID));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(IList<SaleByMonthVerticalByTeam> infos)
    {
      foreach (SaleByMonthVerticalByTeam info in (IEnumerable<SaleByMonthVerticalByTeam>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByMonthVerticalByTeam pSource) => pSource == null || this.IsZero(pCheckType, (SaleByMonthVerticalByStore) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
        this.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
        this.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
        this.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
        this.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
        this.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
        this.sbd_DeptCode = this.dpt_lv2_ID;
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByMonthVerticalByTeam>> SelectMonthVerticalByTeamListAsync(
      object p_param)
    {
      SaleByMonthVerticalByTeam monthVerticalByTeam1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByTeam1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByTeam1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByTeam1.GetSelectQuery(p_param)))
        {
          monthVerticalByTeam1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByTeam1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByMonthVerticalByTeam>) null;
        }
        IList<SaleByMonthVerticalByTeam> lt_list = (IList<SaleByMonthVerticalByTeam>) new List<SaleByMonthVerticalByTeam>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByMonthVerticalByTeam monthVerticalByTeam2 = monthVerticalByTeam1.OleDB.Create<SaleByMonthVerticalByTeam>();
            if (monthVerticalByTeam2.GetFieldValues(rs))
            {
              monthVerticalByTeam2.row_number = lt_list.Count + 1;
              lt_list.Add(monthVerticalByTeam2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByTeam1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByMonthVerticalByTeam> SelectMonthVerticalByTeamEnumerableAsync(
      object p_param)
    {
      SaleByMonthVerticalByTeam monthVerticalByTeam1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByTeam1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByTeam1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByTeam1.GetSelectQuery(p_param)))
        {
          monthVerticalByTeam1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByTeam1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByMonthVerticalByTeam monthVerticalByTeam2 = monthVerticalByTeam1.OleDB.Create<SaleByMonthVerticalByTeam>();
            if (monthVerticalByTeam2.GetFieldValues(rs))
            {
              monthVerticalByTeam2.row_number = ++row_number;
              yield return monthVerticalByTeam2;
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

    public override string GetSelectQuery(object p_param) => new SalesByMonthHorizontalByTeam().GetSelectQuery(p_param);
  }
}
