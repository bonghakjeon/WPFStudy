// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByCategoryBot
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
using UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByCategoryBot : 
    StatementDayVerticalByCategoryMid<StatementDayVerticalByCategoryBot>
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

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (StatementDayVerticalByCategoryBot), (object) this.sh_ConfirmDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.ctg_ViewCode = string.Empty;
      this.ctg_CategoryName = string.Empty;
    }

    public void InitInfo(StatementDayVerticalByCategoryBot pData, IList<CategoryView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_ConfirmDate] 이 KeyCode 와 다릅니다");
      foreach (CategoryView categoryView in (IEnumerable<CategoryView>) p_Header)
      {
        IList<StatementDayHorizontal> ltDetails = this.Lt_Details;
        StatementDayHorizontal statementDayHorizontal = new StatementDayHorizontal();
        statementDayHorizontal.sh_StoreCode = pData.sh_StoreCode;
        statementDayHorizontal.sd_CategoryCode = categoryView.ctg_ID;
        ltDetails.Add(statementDayHorizontal);
      }
    }

    public void Add(StatementDayVerticalByCategoryBot item)
    {
      if (!item.sh_ConfirmDate.HasValue)
        throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
      if (!this.sh_ConfirmDate.HasValue)
        this.sh_ConfirmDate = item.sh_ConfirmDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sh_ConfirmDate 이 sh_ConfirmDate 와 다릅니다");
      this.CalcAddSum((StatementDayHorizontal) item);
      StatementDayHorizontal statementDayHorizontal = this.Lt_Details.FirstOrDefault<StatementDayHorizontal>((Func<StatementDayHorizontal, bool>) (it => it.sh_StoreCode == item.sh_StoreCode && it.sd_CategoryCode == item.sd_CategoryCode));
      if (statementDayHorizontal == null)
        this.Lt_Details.Add((StatementDayHorizontal) item);
      else
        statementDayHorizontal.PutData((StatementDayHorizontal) item);
    }

    public void AddRange(IList<StatementDayVerticalByCategoryBot> infos)
    {
      foreach (StatementDayVerticalByCategoryBot info in (IEnumerable<StatementDayVerticalByCategoryBot>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementDayVerticalByCategoryBot pSource) => pSource == null || this.IsZero(pCheckType, (StatementDayVerticalByCategoryMid) pSource);

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

    public async Task<IList<StatementDayVerticalByCategoryBot>> SelectDayVerticalByCategoryBotListAsync(
      object p_param)
    {
      StatementDayVerticalByCategoryBot verticalByCategoryBot1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(verticalByCategoryBot1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, verticalByCategoryBot1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(verticalByCategoryBot1.GetSelectQuery(p_param)))
        {
          verticalByCategoryBot1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + verticalByCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDayVerticalByCategoryBot>) null;
        }
        IList<StatementDayVerticalByCategoryBot> lt_list = (IList<StatementDayVerticalByCategoryBot>) new List<StatementDayVerticalByCategoryBot>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDayVerticalByCategoryBot verticalByCategoryBot2 = verticalByCategoryBot1.OleDB.Create<StatementDayVerticalByCategoryBot>();
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

    public async IAsyncEnumerable<StatementDayVerticalByCategoryBot> SelectDayVerticalByCategoryBotEnumerableAsync(
      object p_param)
    {
      StatementDayVerticalByCategoryBot verticalByCategoryBot1 = this;
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
            StatementDayVerticalByCategoryBot verticalByCategoryBot2 = verticalByCategoryBot1.OleDB.Create<StatementDayVerticalByCategoryBot>();
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

    public override string GetSelectQuery(object p_param) => new StatementDayHorizontalByCategoryBot().GetSelectQuery(p_param);
  }
}
