// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByCategoryBot
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByCategoryBot : 
    SaleByMonthVerticalByCategoryMid<SaleByMonthVerticalByCategoryBot>
  {
    private string _ctg_ViewCode;
    private string _ctg_CategoryName;

    public string ctg_ViewCode
    {
      get => this._ctg_ViewCode;
      set
      {
        this._ctg_ViewCode = value;
        this.Changed(nameof (ctg_ViewCode));
        this.Changed("ctg_lv3_ViewCode");
      }
    }

    public string ctg_lv3_ViewCode => this.ctg_ViewCode;

    public string ctg_CategoryName
    {
      get => this._ctg_CategoryName;
      set
      {
        this._ctg_CategoryName = value;
        this.Changed(nameof (ctg_CategoryName));
        this.Changed("ctg_lv3_Name");
      }
    }

    public string ctg_lv3_Name => this.ctg_CategoryName;

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (SaleByMonthVerticalByCategoryBot), (object) this.sbd_SaleDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.ctg_ViewCode = string.Empty;
      this.ctg_CategoryName = string.Empty;
    }

    public void InitInfo(SaleByMonthVerticalByCategoryBot pData, IList<CategoryView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sbd_SaleDate] 이 KeyCode 와 다릅니다");
      foreach (CategoryView categoryView in (IEnumerable<CategoryView>) p_Header)
      {
        IList<SalesByDayGoal> ltDetails = this.Lt_Details;
        SalesByMonthGoal salesByMonthGoal = new SalesByMonthGoal();
        salesByMonthGoal.sbd_StoreCode = pData.sbd_StoreCode;
        salesByMonthGoal.sbd_CategoryCode = categoryView.ctg_ID;
        ltDetails.Add((SalesByDayGoal) salesByMonthGoal);
      }
    }

    public void Add(SaleByMonthVerticalByCategoryBot item)
    {
      if (!this.sbd_SaleDate.HasValue)
        this.sbd_SaleDate = item.sbd_SaleDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sbd_SaleDate 이 sbd_SaleDate 와 다릅니다");
      this.CalcAddSum((SalesByMonthGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_StoreCode == item.sbd_StoreCode && it.sbd_CategoryCode == item.sbd_CategoryCode));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(IList<SaleByMonthVerticalByCategoryBot> infos)
    {
      foreach (SaleByMonthVerticalByCategoryBot info in (IEnumerable<SaleByMonthVerticalByCategoryBot>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByMonthVerticalByCategoryBot pSource) => pSource == null || this.IsZero(pCheckType, (SaleByMonthVerticalByCategoryMid) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
        this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByMonthVerticalByCategoryBot>> SelectMonthVerticalByCategoryBotListAsync(
      object p_param)
    {
      SaleByMonthVerticalByCategoryBot verticalByCategoryBot1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryBot1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryBot1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryBot1.GetSelectQuery(p_param)))
        {
          verticalByCategoryBot1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByMonthVerticalByCategoryBot>) null;
        }
        IList<SaleByMonthVerticalByCategoryBot> lt_list = (IList<SaleByMonthVerticalByCategoryBot>) new List<SaleByMonthVerticalByCategoryBot>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByMonthVerticalByCategoryBot verticalByCategoryBot2 = verticalByCategoryBot1.OleDB.Create<SaleByMonthVerticalByCategoryBot>();
            if (verticalByCategoryBot2.GetFieldValues(rs))
            {
              verticalByCategoryBot2.row_number = lt_list.Count + 1;
              lt_list.Add(verticalByCategoryBot2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByMonthVerticalByCategoryBot> SelectMonthVerticalByCategoryBotEnumerableAsync(
      object p_param)
    {
      SaleByMonthVerticalByCategoryBot verticalByCategoryBot1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryBot1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryBot1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryBot1.GetSelectQuery(p_param)))
        {
          verticalByCategoryBot1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByMonthVerticalByCategoryBot verticalByCategoryBot2 = verticalByCategoryBot1.OleDB.Create<SaleByMonthVerticalByCategoryBot>();
            if (verticalByCategoryBot2.GetFieldValues(rs))
            {
              verticalByCategoryBot2.row_number = ++row_number;
              yield return verticalByCategoryBot2;
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

    public override string GetSelectQuery(object p_param) => new SalesByMonthHorizontalByCategoryBot().GetSelectQuery(p_param);
  }
}
