// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontal
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

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal
{
  public class StatementDayHorizontal : TStatementDetail<StatementDayHorizontal>
  {
    private DateTime? _sh_ConfirmDate;
    protected int _sh_StoreCode;
    private int _rowDataType;
    private int _sh_DayCount;
    private int _sh_DeptCode;
    private double _sbd_SaleQty;
    private double _sbd_TotalSaleAmt;
    private double _sbd_SaleAmt;
    private double _sbd_SaleVatAmt;
    private double _sbd_SaleCostAmt;

    public virtual string KeyCode => string.Format("{0}", (object) this.sh_ConfirmDate);

    public DateTime? sh_ConfirmDate
    {
      get => this._sh_ConfirmDate;
      set
      {
        this._sh_ConfirmDate = value;
        this.Changed(nameof (sh_ConfirmDate));
        this.Changed("KeyCode");
      }
    }

    public virtual int sh_StoreCode
    {
      get => this._sh_StoreCode;
      set
      {
        this._sh_StoreCode = value;
        this.Changed(nameof (sh_StoreCode));
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

    public int sh_DayCount
    {
      get => this._sh_DayCount;
      set
      {
        this._sh_DayCount = value;
        this.Changed(nameof (sh_DayCount));
      }
    }

    public int sh_DeptCode
    {
      get => this._sh_DeptCode;
      set
      {
        this._sh_DeptCode = value;
        this.Changed(nameof (sh_DeptCode));
      }
    }

    public double sbd_SaleQty
    {
      get => this._sbd_SaleQty;
      set
      {
        this._sbd_SaleQty = value;
        this.Changed(nameof (sbd_SaleQty));
      }
    }

    public double sbd_TotalSaleAmt
    {
      get => this._sbd_TotalSaleAmt;
      set
      {
        this._sbd_TotalSaleAmt = value;
        this.Changed(nameof (sbd_TotalSaleAmt));
      }
    }

    public double sbd_SaleAmt
    {
      get => this._sbd_SaleAmt;
      set
      {
        this._sbd_SaleAmt = value;
        this.Changed(nameof (sbd_SaleAmt));
      }
    }

    public double sbd_SaleVatAmt
    {
      get => this._sbd_SaleVatAmt;
      set
      {
        this._sbd_SaleVatAmt = value;
        this.Changed(nameof (sbd_SaleVatAmt));
      }
    }

    public double sbd_SaleCostAmt
    {
      get => this._sbd_SaleCostAmt;
      set
      {
        this._sbd_SaleCostAmt = value;
        this.Changed(nameof (sbd_SaleCostAmt));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.sh_DayCount = 0;
      this.sh_ConfirmDate = new DateTime?();
      this.sh_StoreCode = 0;
      this.sh_DeptCode = 0;
      this.sbd_SaleQty = this.sbd_TotalSaleAmt = this.sbd_SaleAmt = this.sbd_SaleVatAmt = this.sbd_SaleCostAmt = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StatementDayHorizontal();

    public override object Clone()
    {
      StatementDayHorizontal statementDayHorizontal = base.Clone() as StatementDayHorizontal;
      statementDayHorizontal.rowDataType = this.rowDataType;
      statementDayHorizontal.sh_DayCount = this.sh_DayCount;
      statementDayHorizontal.sh_ConfirmDate = this.sh_ConfirmDate;
      statementDayHorizontal.sh_StoreCode = this.sh_StoreCode;
      statementDayHorizontal.sh_DeptCode = this.sh_DeptCode;
      statementDayHorizontal.sbd_SaleQty = this.sbd_SaleQty;
      statementDayHorizontal.sbd_TotalSaleAmt = this.sbd_TotalSaleAmt;
      statementDayHorizontal.sbd_SaleAmt = this.sbd_SaleAmt;
      statementDayHorizontal.sbd_SaleVatAmt = this.sbd_SaleVatAmt;
      statementDayHorizontal.sbd_SaleCostAmt = this.sbd_SaleCostAmt;
      return (object) statementDayHorizontal;
    }

    public void PutData(StatementDayHorizontal pSource)
    {
      this.PutData((TStatementDetail) pSource);
      this.rowDataType = pSource.rowDataType;
      this.sh_DayCount = pSource.sh_DayCount;
      this.sh_ConfirmDate = pSource.sh_ConfirmDate;
      this.sh_StoreCode = pSource.sh_StoreCode;
      this.sh_DeptCode = pSource.sh_DeptCode;
      this.sbd_SaleQty = pSource.sbd_SaleQty;
      this.sbd_TotalSaleAmt = pSource.sbd_TotalSaleAmt;
      this.sbd_SaleAmt = pSource.sbd_SaleAmt;
      this.sbd_SaleVatAmt = pSource.sbd_SaleVatAmt;
      this.sbd_SaleCostAmt = pSource.sbd_SaleCostAmt;
    }

    public bool CalcAddSum(StatementDayHorizontal pSource)
    {
      if (pSource == null || !this.CalcAddSum((TStatementDetail) pSource))
        return false;
      this.sbd_SaleQty += pSource.sbd_SaleQty;
      this.sbd_TotalSaleAmt += pSource.sbd_TotalSaleAmt;
      this.sbd_SaleAmt += pSource.sbd_SaleAmt;
      this.sbd_SaleVatAmt += pSource.sbd_SaleVatAmt;
      this.sbd_SaleCostAmt += pSource.sbd_SaleCostAmt;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementDayHorizontal pSource) => pSource == null || this.IsZero(pCheckType, (TStatementDetail) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.sbd_SaleQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_SaleAmt.IsZero() && pSource.sbd_SaleVatAmt.IsZero() && pSource.sbd_SaleCostAmt.IsZero() && pSource.sbd_TotalSaleAmt.IsZero());

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.sh_ConfirmDate = p_rs.GetFieldDateTime("sh_ConfirmDate");
        this.sh_StoreCode = p_rs.GetFieldInt("sh_StoreCode");
        this.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty");
        this.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt");
        this.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt");
        this.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt");
        this.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt");
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
