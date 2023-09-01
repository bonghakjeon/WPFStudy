// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.SalesByDayGoal
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay
{
  public class SalesByDayGoal : TSalesByDay<SalesByDayGoal>
  {
    private int _rowDataType;
    private int _sbd_SaleDays;
    private double _sbd_GoalAmount;
    private double _sbd_GoalProfitAmount;
    private double _sbd_SaleQtyRule;
    private double _sbd_SaleAmtRule;

    public virtual string KeyCode => string.Format("{0}", (object) this.sbd_SaleDate);

    public override DateTime? sbd_SaleDate
    {
      get => this._sbd_SaleDate;
      set
      {
        this._sbd_SaleDate = value;
        this.Changed(nameof (sbd_SaleDate));
        this.Changed("KeyCode");
      }
    }

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
        this.Changed("row_IsDataTypeTotalSum");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    [JsonIgnore]
    public bool row_IsDataTypeTotalSum => this.rowDataType == 3;

    public int sbd_SaleDays
    {
      get => this._sbd_SaleDays;
      set
      {
        this._sbd_SaleDays = value;
        this.Changed(nameof (sbd_SaleDays));
      }
    }

    public double sbd_GoalAmount
    {
      get => this._sbd_GoalAmount;
      set
      {
        this._sbd_GoalAmount = value;
        this.Changed(nameof (sbd_GoalAmount));
      }
    }

    public double sbd_GoalProfitAmount
    {
      get => this._sbd_GoalProfitAmount;
      set
      {
        this._sbd_GoalProfitAmount = value;
        this.Changed(nameof (sbd_GoalProfitAmount));
      }
    }

    public double sbd_SaleQtyRule
    {
      get => this._sbd_SaleQtyRule;
      set
      {
        this._sbd_SaleQtyRule = value;
        this.Changed(nameof (sbd_SaleQtyRule));
      }
    }

    public double sbd_SaleAmtRule
    {
      get => this._sbd_SaleAmtRule;
      set
      {
        this._sbd_SaleAmtRule = value;
        this.Changed(nameof (sbd_SaleAmtRule));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.sbd_SaleDays = 0;
      this.sbd_GoalAmount = this.sbd_SaleQtyRule = this.sbd_SaleAmtRule = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SalesByDayGoal();

    public override object Clone()
    {
      SalesByDayGoal salesByDayGoal = base.Clone() as SalesByDayGoal;
      salesByDayGoal.rowDataType = this.rowDataType;
      salesByDayGoal.sbd_SaleDays = this.sbd_SaleDays;
      salesByDayGoal.sbd_GoalAmount = this.sbd_GoalAmount;
      salesByDayGoal.sbd_SaleQtyRule = this.sbd_SaleQtyRule;
      salesByDayGoal.sbd_SaleAmtRule = this.sbd_SaleAmtRule;
      return (object) salesByDayGoal;
    }

    public void PutData(SalesByDayGoal pSource)
    {
      this.PutData((TSalesByDay) pSource);
      this.rowDataType = pSource.rowDataType;
      this.sbd_SaleDays = pSource.sbd_SaleDays;
      this.sbd_GoalAmount = pSource.sbd_GoalAmount;
      this.sbd_SaleQtyRule = pSource.sbd_SaleQtyRule;
      this.sbd_SaleAmtRule = pSource.sbd_SaleAmtRule;
    }

    public bool CalcAddSum(SalesByDayGoal pSource)
    {
      if (pSource == null || !this.CalcAddSum((TSalesByDay) pSource))
        return false;
      this.sbd_GoalAmount += pSource.sbd_GoalAmount;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, SalesByDayGoal pSource) => pSource == null || this.IsZero(pCheckType, (TSalesByDay) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_GoalAmount.IsZero());

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.sbd_GoalAmount = p_rs.GetFieldDouble("sbd_GoalAmount");
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
