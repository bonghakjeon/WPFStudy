// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByDept
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
using UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByDept : 
    StatementMonthVerticalByTeam<StatementMonthVerticalByDept>
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

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (StatementMonthVerticalByDept), (object) this.sh_ConfirmDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.dpt_ViewCode = string.Empty;
      this.dpt_DeptName = string.Empty;
    }

    public void InitInfo(StatementMonthVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_ConfirmDate] 이 KeyCode 와 다릅니다");
      foreach (DeptView deptView in (IEnumerable<DeptView>) p_Header)
        this.Lt_Details.Add(new StatementMonthHorizontal()
        {
          sh_StoreCode = pData.sh_StoreCode,
          sh_DeptCode = deptView.dpt_ID
        });
    }

    public void Add(StatementMonthVerticalByDept item)
    {
      if (!item.sh_ConfirmDate.HasValue)
        throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
      if (!this.sh_ConfirmDate.HasValue)
        this.sh_ConfirmDate = item.sh_ConfirmDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sh_ConfirmDate 이 sh_ConfirmDate 와 다릅니다");
      this.CalcAddSum((StatementMonthHorizontal) item);
      StatementMonthHorizontal statementMonthHorizontal = this.Lt_Details.FirstOrDefault<StatementMonthHorizontal>((Func<StatementMonthHorizontal, bool>) (it => it.sh_StoreCode == item.sh_StoreCode && it.sh_DeptCode == item.sh_DeptCode));
      if (statementMonthHorizontal == null)
        this.Lt_Details.Add((StatementMonthHorizontal) item);
      else
        statementMonthHorizontal.PutData((StatementMonthHorizontal) item);
    }

    public void AddRange(IList<StatementMonthVerticalByDept> infos)
    {
      foreach (StatementMonthVerticalByDept info in (IEnumerable<StatementMonthVerticalByDept>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementMonthVerticalByDept pSource) => pSource == null || this.IsZero(pCheckType, (StatementMonthVerticalByTeam) pSource);

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

    public async Task<IList<StatementMonthVerticalByDept>> SelectMonthVerticalByDeptListAsync(
      object p_param)
    {
      StatementMonthVerticalByDept monthVerticalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByDept1.GetSelectQuery(p_param)))
        {
          monthVerticalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementMonthVerticalByDept>) null;
        }
        IList<StatementMonthVerticalByDept> lt_list = (IList<StatementMonthVerticalByDept>) new List<StatementMonthVerticalByDept>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementMonthVerticalByDept monthVerticalByDept2 = monthVerticalByDept1.OleDB.Create<StatementMonthVerticalByDept>();
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

    public async IAsyncEnumerable<StatementMonthVerticalByDept> SelectMonthVerticalByDeptEnumerableAsync(
      object p_param)
    {
      StatementMonthVerticalByDept monthVerticalByDept1 = this;
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
            StatementMonthVerticalByDept monthVerticalByDept2 = monthVerticalByDept1.OleDB.Create<StatementMonthVerticalByDept>();
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

    public override string GetSelectQuery(object p_param) => new StatementMonthHorizontalByDept().GetSelectQuery(p_param);
  }
}
