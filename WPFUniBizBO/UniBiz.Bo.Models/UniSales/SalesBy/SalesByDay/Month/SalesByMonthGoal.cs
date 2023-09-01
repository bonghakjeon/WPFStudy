// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.SalesByMonthGoal
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month
{
  public class SalesByMonthGoal : SalesByDayGoal<SalesByMonthGoal>
  {
    private string _sbd_SaleMonth;

    public string sbd_SaleMonth
    {
      get => this._sbd_SaleMonth;
      set
      {
        this._sbd_SaleMonth = value;
        this.Changed(nameof (sbd_SaleMonth));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.sbd_SaleMonth = (string) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SalesByMonthGoal();

    public override object Clone()
    {
      SalesByMonthGoal salesByMonthGoal = base.Clone() as SalesByMonthGoal;
      salesByMonthGoal.sbd_SaleMonth = this.sbd_SaleMonth;
      return (object) salesByMonthGoal;
    }

    public void PutData(SalesByMonthGoal pSource)
    {
      this.PutData((SalesByDayGoal) pSource);
      this.sbd_SaleMonth = pSource.sbd_SaleMonth;
    }

    public bool CalcAddSum(SalesByMonthGoal pSource) => pSource != null && this.CalcAddSum((SalesByDayGoal) pSource);

    public bool IsZero(EnumZeroCheck pCheckType, SalesByMonthGoal pSource) => pSource == null || this.IsZero(pCheckType, (SalesByDayGoal) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.sbd_SaleMonth = p_rs.GetFieldString("sbd_SaleMonth");
        if (!string.IsNullOrEmpty(this.sbd_SaleMonth) && this.sbd_SaleMonth.Length == 6)
          this.sbd_SaleDate = (this.sbd_SaleMonth + "01").GetStr2Date("yyyyMMdd");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }
  }
}
