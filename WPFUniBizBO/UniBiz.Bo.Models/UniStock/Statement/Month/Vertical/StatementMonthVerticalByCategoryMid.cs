// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByCategoryMid
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
using UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByCategoryMid : 
    StatementMonthVerticalByCategoryTop<StatementMonthVerticalByCategoryMid>
  {
    private int _ctg_lv2_ID;
    private string _ctg_lv2_ViewCode;
    private string _ctg_lv2_Name;

    public int ctg_lv2_ID
    {
      get => this._ctg_lv2_ID;
      set
      {
        this._ctg_lv2_ID = value;
        this.Changed(nameof (ctg_lv2_ID));
        this.Changed("KeyCode");
      }
    }

    public string ctg_lv2_ViewCode
    {
      get => this._ctg_lv2_ViewCode;
      set
      {
        this._ctg_lv2_ViewCode = value;
        this.Changed(nameof (ctg_lv2_ViewCode));
      }
    }

    public string ctg_lv2_Name
    {
      get => this._ctg_lv2_Name;
      set
      {
        this._ctg_lv2_Name = value;
        this.Changed(nameof (ctg_lv2_Name));
      }
    }

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (StatementMonthVerticalByCategoryMid), (object) this.sh_ConfirmDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.ctg_lv2_ID = 0;
      this.ctg_lv2_ViewCode = string.Empty;
      this.ctg_lv2_Name = string.Empty;
    }

    public void InitInfo(StatementMonthVerticalByCategoryMid pData, IList<CategoryView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_ConfirmDate] 이 KeyCode 와 다릅니다");
      foreach (CategoryView categoryView in (IEnumerable<CategoryView>) p_Header)
      {
        IList<StatementMonthHorizontal> ltDetails = this.Lt_Details;
        StatementMonthHorizontal statementMonthHorizontal = new StatementMonthHorizontal();
        statementMonthHorizontal.sh_StoreCode = pData.sh_StoreCode;
        statementMonthHorizontal.sd_CategoryCode = categoryView.ctg_ID;
        ltDetails.Add(statementMonthHorizontal);
      }
    }

    public void Add(StatementMonthVerticalByCategoryMid item)
    {
      if (!item.sh_ConfirmDate.HasValue)
        throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
      if (!this.sh_ConfirmDate.HasValue)
        this.sh_ConfirmDate = item.sh_ConfirmDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sh_ConfirmDate 이 sh_ConfirmDate 와 다릅니다");
      this.CalcAddSum((StatementMonthHorizontal) item);
      StatementMonthHorizontal statementMonthHorizontal = this.Lt_Details.FirstOrDefault<StatementMonthHorizontal>((Func<StatementMonthHorizontal, bool>) (it => it.sh_StoreCode == item.sh_StoreCode && it.sd_CategoryCode == item.sd_CategoryCode));
      if (statementMonthHorizontal == null)
        this.Lt_Details.Add((StatementMonthHorizontal) item);
      else
        statementMonthHorizontal.PutData((StatementMonthHorizontal) item);
    }

    public void AddRange(IList<StatementMonthVerticalByCategoryMid> infos)
    {
      foreach (StatementMonthVerticalByCategoryMid info in (IEnumerable<StatementMonthVerticalByCategoryMid>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementMonthVerticalByCategoryMid pSource) => pSource == null || this.IsZero(pCheckType, (StatementMonthVerticalByCategoryTop) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
        this.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
        this.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
        this.sd_CategoryCode = this.ctg_lv2_ID;
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<StatementMonthVerticalByCategoryMid>> SelectMonthVerticalByCategoryMidListAsync(
      object p_param)
    {
      StatementMonthVerticalByCategoryMid verticalByCategoryMid1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryMid1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryMid1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryMid1.GetSelectQuery(p_param)))
        {
          verticalByCategoryMid1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementMonthVerticalByCategoryMid>) null;
        }
        IList<StatementMonthVerticalByCategoryMid> lt_list = (IList<StatementMonthVerticalByCategoryMid>) new List<StatementMonthVerticalByCategoryMid>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementMonthVerticalByCategoryMid verticalByCategoryMid2 = verticalByCategoryMid1.OleDB.Create<StatementMonthVerticalByCategoryMid>();
            if (verticalByCategoryMid2.GetFieldValues(rs))
            {
              verticalByCategoryMid2.row_number = lt_list.Count + 1;
              lt_list.Add(verticalByCategoryMid2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementMonthVerticalByCategoryMid> SelectMonthVerticalByCategoryMidEnumerableAsync(
      object p_param)
    {
      StatementMonthVerticalByCategoryMid verticalByCategoryMid1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryMid1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryMid1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryMid1.GetSelectQuery(p_param)))
        {
          verticalByCategoryMid1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementMonthVerticalByCategoryMid verticalByCategoryMid2 = verticalByCategoryMid1.OleDB.Create<StatementMonthVerticalByCategoryMid>();
            if (verticalByCategoryMid2.GetFieldValues(rs))
            {
              verticalByCategoryMid2.row_number = ++row_number;
              yield return verticalByCategoryMid2;
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

    public override string GetSelectQuery(object p_param) => new StatementMonthHorizontalByCategoryMid().GetSelectQuery(p_param);
  }
}
