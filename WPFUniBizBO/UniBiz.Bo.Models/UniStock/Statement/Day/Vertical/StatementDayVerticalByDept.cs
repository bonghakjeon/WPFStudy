// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByDept
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
using UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByDept : StatementDayVerticalByTeam<StatementDayVerticalByDept>
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

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (StatementDayVerticalByDept), (object) this.sh_ConfirmDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.dpt_ViewCode = string.Empty;
      this.dpt_DeptName = string.Empty;
    }

    public void InitInfo(StatementDayVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_ConfirmDate] 이 KeyCode 와 다릅니다");
      foreach (DeptView deptView in (IEnumerable<DeptView>) p_Header)
        this.Lt_Details.Add(new StatementDayHorizontal()
        {
          sh_StoreCode = pData.sh_StoreCode,
          sh_DeptCode = deptView.dpt_ID
        });
    }

    public void Add(StatementDayVerticalByDept item)
    {
      if (!item.sh_ConfirmDate.HasValue)
        throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
      if (!this.sh_ConfirmDate.HasValue)
        this.sh_ConfirmDate = item.sh_ConfirmDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sh_ConfirmDate 이 sh_ConfirmDate 와 다릅니다");
      this.CalcAddSum((StatementDayHorizontal) item);
      StatementDayHorizontal statementDayHorizontal = this.Lt_Details.FirstOrDefault<StatementDayHorizontal>((Func<StatementDayHorizontal, bool>) (it => it.sh_StoreCode == item.sh_StoreCode && it.sh_DeptCode == item.sh_DeptCode));
      if (statementDayHorizontal == null)
        this.Lt_Details.Add((StatementDayHorizontal) item);
      else
        statementDayHorizontal.PutData((StatementDayHorizontal) item);
    }

    public void AddRange(IList<StatementDayVerticalByDept> infos)
    {
      foreach (StatementDayVerticalByDept info in (IEnumerable<StatementDayVerticalByDept>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementDayVerticalByDept pSource) => pSource == null || this.IsZero(pCheckType, (StatementDayVerticalByTeam) pSource);

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

    public async Task<IList<StatementDayVerticalByDept>> SelectDayVerticalByDeptListAsync(
      object p_param)
    {
      StatementDayVerticalByDept dayVerticalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dayVerticalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dayVerticalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dayVerticalByDept1.GetSelectQuery(p_param)))
        {
          dayVerticalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dayVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDayVerticalByDept>) null;
        }
        IList<StatementDayVerticalByDept> lt_list = (IList<StatementDayVerticalByDept>) new List<StatementDayVerticalByDept>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDayVerticalByDept dayVerticalByDept2 = dayVerticalByDept1.OleDB.Create<StatementDayVerticalByDept>();
            if (dayVerticalByDept2.GetFieldValues(rs))
            {
              dayVerticalByDept2.row_number = lt_list.Count + 1;
              lt_list.Add(dayVerticalByDept2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dayVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDayVerticalByDept> SelectDayVerticalByDeptEnumerableAsync(
      object p_param)
    {
      StatementDayVerticalByDept dayVerticalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dayVerticalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dayVerticalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dayVerticalByDept1.GetSelectQuery(p_param)))
        {
          dayVerticalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dayVerticalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDayVerticalByDept dayVerticalByDept2 = dayVerticalByDept1.OleDB.Create<StatementDayVerticalByDept>();
            if (dayVerticalByDept2.GetFieldValues(rs))
            {
              dayVerticalByDept2.row_number = ++row_number;
              yield return dayVerticalByDept2;
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

    public override string GetSelectQuery(object p_param) => new StatementDayHorizontalByDept().GetSelectQuery(p_param);
  }
}
