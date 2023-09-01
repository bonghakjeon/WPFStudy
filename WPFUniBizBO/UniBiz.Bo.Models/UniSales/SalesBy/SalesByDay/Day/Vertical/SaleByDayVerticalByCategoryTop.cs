// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByCategoryTop
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
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByCategoryTop : 
    SaleByDayVerticalByDept<SaleByDayVerticalByCategoryTop>
  {
    private int _ctg_lv1_ID;
    private string _ctg_lv1_ViewCode;
    private string _ctg_lv1_Name;

    public int ctg_lv1_ID
    {
      get => this._ctg_lv1_ID;
      set
      {
        this._ctg_lv1_ID = value;
        this.Changed(nameof (ctg_lv1_ID));
        this.Changed("KeyCode");
      }
    }

    public string ctg_lv1_ViewCode
    {
      get => this._ctg_lv1_ViewCode;
      set
      {
        this._ctg_lv1_ViewCode = value;
        this.Changed(nameof (ctg_lv1_ViewCode));
      }
    }

    public string ctg_lv1_Name
    {
      get => this._ctg_lv1_Name;
      set
      {
        this._ctg_lv1_Name = value;
        this.Changed(nameof (ctg_lv1_Name));
      }
    }

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (SaleByDayVerticalByCategoryTop), (object) this.sbd_SaleDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.ctg_lv1_ID = 0;
      this.ctg_lv1_ViewCode = string.Empty;
      this.ctg_lv1_Name = string.Empty;
    }

    public void InitInfo(SaleByDayVerticalByCategoryTop pData, IList<CategoryView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sbd_SaleDate] 이 KeyCode 와 다릅니다");
      foreach (CategoryView categoryView in (IEnumerable<CategoryView>) p_Header)
      {
        IList<SalesByDayGoal> ltDetails = this.Lt_Details;
        SalesByDayGoal salesByDayGoal = new SalesByDayGoal();
        salesByDayGoal.sbd_StoreCode = pData.sbd_StoreCode;
        salesByDayGoal.sbd_CategoryCode = categoryView.ctg_ID;
        ltDetails.Add(salesByDayGoal);
      }
    }

    public void Add(SaleByDayVerticalByCategoryTop item)
    {
      if (!this.sbd_SaleDate.HasValue)
        this.sbd_SaleDate = item.sbd_SaleDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sbd_SaleDate 이 sbd_SaleDate 와 다릅니다");
      this.CalcAddSum((SalesByDayGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_StoreCode == item.sbd_StoreCode && it.sbd_CategoryCode == item.sbd_CategoryCode));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(IList<SaleByDayVerticalByCategoryTop> infos)
    {
      foreach (SaleByDayVerticalByCategoryTop info in (IEnumerable<SaleByDayVerticalByCategoryTop>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByDayVerticalByCategoryTop pSource) => pSource == null || this.IsZero(pCheckType, (SaleByDayVerticalByDept) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
        this.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
        this.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
        this.sbd_CategoryCode = this.ctg_lv1_ID;
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByDayVerticalByCategoryTop>> SelectDayVerticalByCategoryTopListAsync(
      object p_param)
    {
      SaleByDayVerticalByCategoryTop verticalByCategoryTop1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryTop1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryTop1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryTop1.GetSelectQuery(p_param)))
        {
          verticalByCategoryTop1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryTop1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByDayVerticalByCategoryTop>) null;
        }
        IList<SaleByDayVerticalByCategoryTop> lt_list = (IList<SaleByDayVerticalByCategoryTop>) new List<SaleByDayVerticalByCategoryTop>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByDayVerticalByCategoryTop verticalByCategoryTop2 = verticalByCategoryTop1.OleDB.Create<SaleByDayVerticalByCategoryTop>();
            if (verticalByCategoryTop2.GetFieldValues(rs))
            {
              verticalByCategoryTop2.row_number = lt_list.Count + 1;
              lt_list.Add(verticalByCategoryTop2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryTop1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByDayVerticalByCategoryTop> SelectDayVerticalByCategoryTopEnumerableAsync(
      object p_param)
    {
      SaleByDayVerticalByCategoryTop verticalByCategoryTop1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryTop1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryTop1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryTop1.GetSelectQuery(p_param)))
        {
          verticalByCategoryTop1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryTop1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByDayVerticalByCategoryTop verticalByCategoryTop2 = verticalByCategoryTop1.OleDB.Create<SaleByDayVerticalByCategoryTop>();
            if (verticalByCategoryTop2.GetFieldValues(rs))
            {
              verticalByCategoryTop2.row_number = ++row_number;
              yield return verticalByCategoryTop2;
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

    public override string GetSelectQuery(object p_param) => new SalesByDayHorizontalByCategoryTop().GetSelectQuery(p_param);
  }
}
