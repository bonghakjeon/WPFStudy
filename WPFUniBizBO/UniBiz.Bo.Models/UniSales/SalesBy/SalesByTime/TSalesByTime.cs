// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.TSalesByTime
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime
{
  public class TSalesByTime : UbModelBase<TSalesByTime>
  {
    private DateTime? _sbt_SaleDate;
    private int _sbt_StoreCode;
    private int _sbt_CategoryCode;
    private int _sbt_DeptCode;
    private long _sbt_BoxCode;
    private long _sbt_GoodsCode;
    private int _sbt_Supplier;
    private int _sbt_KeySeq;
    private long _sbt_SiteID;
    private int _sbt_DayOfWeek;
    private int _sbt_WeekOfYear;
    private int _sbt_DayOfYear;
    private double[] _sbt_SaleAmt;
    private double[] _sbt_BoxQty;
    private double[] _sbt_SaleQty;
    private double[] _sbt_SlipCustomer;
    private double[] _sbt_CategoryCustomer;
    private double[] _sbt_GoodsCustomer;
    private double[] _sbt_SupplierCustomer;

    public override object _Key => (object) new object[8]
    {
      (object) this.sbt_SaleDate,
      (object) this.sbt_StoreCode,
      (object) this.sbt_CategoryCode,
      (object) this.sbt_DeptCode,
      (object) this.sbt_BoxCode,
      (object) this.sbt_GoodsCode,
      (object) this.sbt_Supplier,
      (object) this.sbt_KeySeq
    };

    public DateTime? sbt_SaleDate
    {
      get => this._sbt_SaleDate;
      set
      {
        this._sbt_SaleDate = value;
        this.Changed(nameof (sbt_SaleDate));
      }
    }

    public int sbt_StoreCode
    {
      get => this._sbt_StoreCode;
      set
      {
        this._sbt_StoreCode = value;
        this.Changed(nameof (sbt_StoreCode));
      }
    }

    public int sbt_CategoryCode
    {
      get => this._sbt_CategoryCode;
      set
      {
        this._sbt_CategoryCode = value;
        this.Changed(nameof (sbt_CategoryCode));
      }
    }

    public int sbt_DeptCode
    {
      get => this._sbt_DeptCode;
      set
      {
        this._sbt_DeptCode = value;
        this.Changed(nameof (sbt_DeptCode));
      }
    }

    public long sbt_BoxCode
    {
      get => this._sbt_BoxCode;
      set
      {
        this._sbt_BoxCode = value;
        this.Changed(nameof (sbt_BoxCode));
      }
    }

    public long sbt_GoodsCode
    {
      get => this._sbt_GoodsCode;
      set
      {
        this._sbt_GoodsCode = value;
        this.Changed(nameof (sbt_GoodsCode));
      }
    }

    public int sbt_Supplier
    {
      get => this._sbt_Supplier;
      set
      {
        this._sbt_Supplier = value;
        this.Changed(nameof (sbt_Supplier));
      }
    }

    public int sbt_KeySeq
    {
      get => this._sbt_KeySeq;
      set
      {
        this._sbt_KeySeq = value;
        this.Changed(nameof (sbt_KeySeq));
      }
    }

    public long sbt_SiteID
    {
      get => this._sbt_SiteID;
      set
      {
        this._sbt_SiteID = value;
        this.Changed(nameof (sbt_SiteID));
      }
    }

    public int sbt_DayOfWeek
    {
      get => this._sbt_DayOfWeek;
      set
      {
        this._sbt_DayOfWeek = value;
        this.Changed(nameof (sbt_DayOfWeek));
      }
    }

    public int sbt_WeekOfYear
    {
      get => this._sbt_WeekOfYear;
      set
      {
        this._sbt_WeekOfYear = value;
        this.Changed(nameof (sbt_WeekOfYear));
      }
    }

    public int sbt_DayOfYear
    {
      get => this._sbt_DayOfYear;
      set
      {
        this._sbt_DayOfYear = value;
        this.Changed(nameof (sbt_DayOfYear));
      }
    }

    public double[] sbt_SaleAmt
    {
      get => this._sbt_SaleAmt ?? (this._sbt_SaleAmt = new double[24]);
      set
      {
        this._sbt_SaleAmt = value;
        this.Changed(nameof (sbt_SaleAmt));
        this.Changed("sbt_SaleAmt00");
        this.Changed("sbt_SaleAmt01");
        this.Changed("sbt_SaleAmt02");
        this.Changed("sbt_SaleAmt03");
        this.Changed("sbt_SaleAmt04");
        this.Changed("sbt_SaleAmt05");
        this.Changed("sbt_SaleAmt06");
        this.Changed("sbt_SaleAmt07");
        this.Changed("sbt_SaleAmt08");
        this.Changed("sbt_SaleAmt09");
        this.Changed("sbt_SaleAmt10");
        this.Changed("sbt_SaleAmt11");
        this.Changed("sbt_SaleAmt12");
        this.Changed("sbt_SaleAmt13");
        this.Changed("sbt_SaleAmt14");
        this.Changed("sbt_SaleAmt15");
        this.Changed("sbt_SaleAmt16");
        this.Changed("sbt_SaleAmt17");
        this.Changed("sbt_SaleAmt18");
        this.Changed("sbt_SaleAmt19");
        this.Changed("sbt_SaleAmt20");
        this.Changed("sbt_SaleAmt21");
        this.Changed("sbt_SaleAmt22");
        this.Changed("sbt_SaleAmt23");
        this.Changed("sbt_SaleAmtTotal");
        this.Changed("sbt_SaleAmt09Before");
        this.Changed("sbt_SaleAmt21After");
        this.Changed("sbt_SlipCustomerPrice00");
        this.Changed("sbt_SlipCustomerPrice01");
        this.Changed("sbt_SlipCustomerPrice02");
        this.Changed("sbt_SlipCustomerPrice03");
        this.Changed("sbt_SlipCustomerPrice04");
        this.Changed("sbt_SlipCustomerPrice05");
        this.Changed("sbt_SlipCustomerPrice06");
        this.Changed("sbt_SlipCustomerPrice07");
        this.Changed("sbt_SlipCustomerPrice08");
        this.Changed("sbt_SlipCustomerPrice09");
        this.Changed("sbt_SlipCustomerPrice10");
        this.Changed("sbt_SlipCustomerPrice11");
        this.Changed("sbt_SlipCustomerPrice12");
        this.Changed("sbt_SlipCustomerPrice13");
        this.Changed("sbt_SlipCustomerPrice14");
        this.Changed("sbt_SlipCustomerPrice15");
        this.Changed("sbt_SlipCustomerPrice16");
        this.Changed("sbt_SlipCustomerPrice17");
        this.Changed("sbt_SlipCustomerPrice18");
        this.Changed("sbt_SlipCustomerPrice19");
        this.Changed("sbt_SlipCustomerPrice20");
        this.Changed("sbt_SlipCustomerPrice21");
        this.Changed("sbt_SlipCustomerPrice22");
        this.Changed("sbt_SlipCustomerPrice23");
        this.Changed("sbt_CategoryCustomerPrice00");
        this.Changed("sbt_CategoryCustomerPrice01");
        this.Changed("sbt_CategoryCustomerPrice02");
        this.Changed("sbt_CategoryCustomerPrice03");
        this.Changed("sbt_CategoryCustomerPrice04");
        this.Changed("sbt_CategoryCustomerPrice05");
        this.Changed("sbt_CategoryCustomerPrice06");
        this.Changed("sbt_CategoryCustomerPrice07");
        this.Changed("sbt_CategoryCustomerPrice08");
        this.Changed("sbt_CategoryCustomerPrice09");
        this.Changed("sbt_CategoryCustomerPrice10");
        this.Changed("sbt_CategoryCustomerPrice11");
        this.Changed("sbt_CategoryCustomerPrice12");
        this.Changed("sbt_CategoryCustomerPrice13");
        this.Changed("sbt_CategoryCustomerPrice14");
        this.Changed("sbt_CategoryCustomerPrice15");
        this.Changed("sbt_CategoryCustomerPrice16");
        this.Changed("sbt_CategoryCustomerPrice17");
        this.Changed("sbt_CategoryCustomerPrice18");
        this.Changed("sbt_CategoryCustomerPrice19");
        this.Changed("sbt_CategoryCustomerPrice20");
        this.Changed("sbt_CategoryCustomerPrice21");
        this.Changed("sbt_CategoryCustomerPrice22");
        this.Changed("sbt_CategoryCustomerPrice23");
        this.Changed("sbt_SupplierCustomerPrice00");
        this.Changed("sbt_SupplierCustomerPrice01");
        this.Changed("sbt_SupplierCustomerPrice02");
        this.Changed("sbt_SupplierCustomerPrice03");
        this.Changed("sbt_SupplierCustomerPrice04");
        this.Changed("sbt_SupplierCustomerPrice05");
        this.Changed("sbt_SupplierCustomerPrice06");
        this.Changed("sbt_SupplierCustomerPrice07");
        this.Changed("sbt_SupplierCustomerPrice08");
        this.Changed("sbt_SupplierCustomerPrice09");
        this.Changed("sbt_SupplierCustomerPrice10");
        this.Changed("sbt_SupplierCustomerPrice11");
        this.Changed("sbt_SupplierCustomerPrice12");
        this.Changed("sbt_SupplierCustomerPrice13");
        this.Changed("sbt_SupplierCustomerPrice14");
        this.Changed("sbt_SupplierCustomerPrice15");
        this.Changed("sbt_SupplierCustomerPrice16");
        this.Changed("sbt_SupplierCustomerPrice17");
        this.Changed("sbt_SupplierCustomerPrice18");
        this.Changed("sbt_SupplierCustomerPrice19");
        this.Changed("sbt_SupplierCustomerPrice20");
        this.Changed("sbt_SupplierCustomerPrice21");
        this.Changed("sbt_SupplierCustomerPrice22");
        this.Changed("sbt_SupplierCustomerPrice23");
        this.Changed("sbt_GoodsCustomerPrice00");
        this.Changed("sbt_GoodsCustomerPrice01");
        this.Changed("sbt_GoodsCustomerPrice02");
        this.Changed("sbt_GoodsCustomerPrice03");
        this.Changed("sbt_GoodsCustomerPrice04");
        this.Changed("sbt_GoodsCustomerPrice05");
        this.Changed("sbt_GoodsCustomerPrice06");
        this.Changed("sbt_GoodsCustomerPrice07");
        this.Changed("sbt_GoodsCustomerPrice08");
        this.Changed("sbt_GoodsCustomerPrice09");
        this.Changed("sbt_GoodsCustomerPrice10");
        this.Changed("sbt_GoodsCustomerPrice11");
        this.Changed("sbt_GoodsCustomerPrice12");
        this.Changed("sbt_GoodsCustomerPrice13");
        this.Changed("sbt_GoodsCustomerPrice14");
        this.Changed("sbt_GoodsCustomerPrice15");
        this.Changed("sbt_GoodsCustomerPrice16");
        this.Changed("sbt_GoodsCustomerPrice17");
        this.Changed("sbt_GoodsCustomerPrice18");
        this.Changed("sbt_GoodsCustomerPrice19");
        this.Changed("sbt_GoodsCustomerPrice20");
        this.Changed("sbt_GoodsCustomerPrice21");
        this.Changed("sbt_GoodsCustomerPrice22");
        this.Changed("sbt_GoodsCustomerPrice23");
      }
    }

    public double sbt_SaleAmt00 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[0] : 0.0;

    public double sbt_SaleAmt01 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[1] : 0.0;

    public double sbt_SaleAmt02 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[2] : 0.0;

    public double sbt_SaleAmt03 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[3] : 0.0;

    public double sbt_SaleAmt04 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[4] : 0.0;

    public double sbt_SaleAmt05 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[5] : 0.0;

    public double sbt_SaleAmt06 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[6] : 0.0;

    public double sbt_SaleAmt07 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[7] : 0.0;

    public double sbt_SaleAmt08 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[8] : 0.0;

    public double sbt_SaleAmt09 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[9] : 0.0;

    public double sbt_SaleAmt10 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[10] : 0.0;

    public double sbt_SaleAmt11 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[11] : 0.0;

    public double sbt_SaleAmt12 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[12] : 0.0;

    public double sbt_SaleAmt13 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[13] : 0.0;

    public double sbt_SaleAmt14 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[14] : 0.0;

    public double sbt_SaleAmt15 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[15] : 0.0;

    public double sbt_SaleAmt16 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[16] : 0.0;

    public double sbt_SaleAmt17 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[17] : 0.0;

    public double sbt_SaleAmt18 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[18] : 0.0;

    public double sbt_SaleAmt19 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[19] : 0.0;

    public double sbt_SaleAmt20 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[20] : 0.0;

    public double sbt_SaleAmt21 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[21] : 0.0;

    public double sbt_SaleAmt22 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[22] : 0.0;

    public double sbt_SaleAmt23 => this.sbt_SaleAmt != null ? this.sbt_SaleAmt[23] : 0.0;

    public double sbt_SaleAmtTotal => this.sbt_SaleAmt != null ? ((IEnumerable<double>) this.sbt_SaleAmt).Sum() : 0.0;

    public double sbt_SaleAmt09Before => this.sbt_SaleAmt != null && this.sbt_SaleAmt.Length >= 8 ? ((IEnumerable<double>) this.sbt_SaleAmt).Take<double>(8).Sum() : 0.0;

    public double sbt_SaleAmt21After => this.sbt_SaleAmt != null && this.sbt_SaleAmt.Length >= 23 ? ((IEnumerable<double>) this.sbt_SaleAmt).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double[] sbt_BoxQty
    {
      get => this._sbt_BoxQty ?? (this._sbt_BoxQty = new double[24]);
      set
      {
        this._sbt_BoxQty = value;
        this.Changed(nameof (sbt_BoxQty));
        this.Changed("sbt_BoxQty00");
        this.Changed("sbt_BoxQty01");
        this.Changed("sbt_BoxQty02");
        this.Changed("sbt_BoxQty03");
        this.Changed("sbt_BoxQty04");
        this.Changed("sbt_BoxQty05");
        this.Changed("sbt_BoxQty06");
        this.Changed("sbt_BoxQty07");
        this.Changed("sbt_BoxQty08");
        this.Changed("sbt_BoxQty09");
        this.Changed("sbt_BoxQty10");
        this.Changed("sbt_BoxQty11");
        this.Changed("sbt_BoxQty12");
        this.Changed("sbt_BoxQty13");
        this.Changed("sbt_BoxQty14");
        this.Changed("sbt_BoxQty15");
        this.Changed("sbt_BoxQty16");
        this.Changed("sbt_BoxQty17");
        this.Changed("sbt_BoxQty18");
        this.Changed("sbt_BoxQty19");
        this.Changed("sbt_BoxQty20");
        this.Changed("sbt_BoxQty21");
        this.Changed("sbt_BoxQty22");
        this.Changed("sbt_BoxQty23");
        this.Changed("sbt_BoxQtyTotal");
        this.Changed("sbt_BoxQty09Before");
        this.Changed("sbt_BoxQty21After");
      }
    }

    public double sbt_BoxQty00 => this.sbt_BoxQty != null ? this.sbt_BoxQty[0] : 0.0;

    public double sbt_BoxQty01 => this.sbt_BoxQty != null ? this.sbt_BoxQty[1] : 0.0;

    public double sbt_BoxQty02 => this.sbt_BoxQty != null ? this.sbt_BoxQty[2] : 0.0;

    public double sbt_BoxQty03 => this.sbt_BoxQty != null ? this.sbt_BoxQty[3] : 0.0;

    public double sbt_BoxQty04 => this.sbt_BoxQty != null ? this.sbt_BoxQty[4] : 0.0;

    public double sbt_BoxQty05 => this.sbt_BoxQty != null ? this.sbt_BoxQty[5] : 0.0;

    public double sbt_BoxQty06 => this.sbt_BoxQty != null ? this.sbt_BoxQty[6] : 0.0;

    public double sbt_BoxQty07 => this.sbt_BoxQty != null ? this.sbt_BoxQty[7] : 0.0;

    public double sbt_BoxQty08 => this.sbt_BoxQty != null ? this.sbt_BoxQty[8] : 0.0;

    public double sbt_BoxQty09 => this.sbt_BoxQty != null ? this.sbt_BoxQty[9] : 0.0;

    public double sbt_BoxQty10 => this.sbt_BoxQty != null ? this.sbt_BoxQty[10] : 0.0;

    public double sbt_BoxQty11 => this.sbt_BoxQty != null ? this.sbt_BoxQty[11] : 0.0;

    public double sbt_BoxQty12 => this.sbt_BoxQty != null ? this.sbt_BoxQty[12] : 0.0;

    public double sbt_BoxQty13 => this.sbt_BoxQty != null ? this.sbt_BoxQty[13] : 0.0;

    public double sbt_BoxQty14 => this.sbt_BoxQty != null ? this.sbt_BoxQty[14] : 0.0;

    public double sbt_BoxQty15 => this.sbt_BoxQty != null ? this.sbt_BoxQty[15] : 0.0;

    public double sbt_BoxQty16 => this.sbt_BoxQty != null ? this.sbt_BoxQty[16] : 0.0;

    public double sbt_BoxQty17 => this.sbt_BoxQty != null ? this.sbt_BoxQty[17] : 0.0;

    public double sbt_BoxQty18 => this.sbt_BoxQty != null ? this.sbt_BoxQty[18] : 0.0;

    public double sbt_BoxQty19 => this.sbt_BoxQty != null ? this.sbt_BoxQty[19] : 0.0;

    public double sbt_BoxQty20 => this.sbt_BoxQty != null ? this.sbt_BoxQty[20] : 0.0;

    public double sbt_BoxQty21 => this.sbt_BoxQty != null ? this.sbt_BoxQty[21] : 0.0;

    public double sbt_BoxQty22 => this.sbt_BoxQty != null ? this.sbt_BoxQty[22] : 0.0;

    public double sbt_BoxQty23 => this.sbt_BoxQty != null ? this.sbt_BoxQty[23] : 0.0;

    public double sbt_BoxQtyTotal => this.sbt_BoxQty != null ? ((IEnumerable<double>) this.sbt_BoxQty).Sum() : 0.0;

    public double sbt_BoxQty09Before => this.sbt_BoxQty != null ? ((IEnumerable<double>) this.sbt_BoxQty).Take<double>(8).Sum() : 0.0;

    public double sbt_BoxQty21After => this.sbt_BoxQty != null ? ((IEnumerable<double>) this.sbt_BoxQty).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double[] sbt_SaleQty
    {
      get => this._sbt_SaleQty ?? (this._sbt_SaleQty = new double[24]);
      set
      {
        this._sbt_SaleQty = value;
        this.Changed(nameof (sbt_SaleQty));
        this.Changed("sbt_SaleQty00");
        this.Changed("sbt_SaleQty01");
        this.Changed("sbt_SaleQty02");
        this.Changed("sbt_SaleQty03");
        this.Changed("sbt_SaleQty04");
        this.Changed("sbt_SaleQty05");
        this.Changed("sbt_SaleQty06");
        this.Changed("sbt_SaleQty07");
        this.Changed("sbt_SaleQty08");
        this.Changed("sbt_SaleQty09");
        this.Changed("sbt_SaleQty10");
        this.Changed("sbt_SaleQty11");
        this.Changed("sbt_SaleQty12");
        this.Changed("sbt_SaleQty13");
        this.Changed("sbt_SaleQty14");
        this.Changed("sbt_SaleQty15");
        this.Changed("sbt_SaleQty16");
        this.Changed("sbt_SaleQty17");
        this.Changed("sbt_SaleQty18");
        this.Changed("sbt_SaleQty19");
        this.Changed("sbt_SaleQty20");
        this.Changed("sbt_SaleQty21");
        this.Changed("sbt_SaleQty22");
        this.Changed("sbt_SaleQty23");
        this.Changed("sbt_SaleQtyTotal");
        this.Changed("sbt_SaleQty09Before");
        this.Changed("sbt_SaleQty21After");
      }
    }

    public double sbt_SaleQty00 => this.sbt_SaleQty != null ? this.sbt_SaleQty[0] : 0.0;

    public double sbt_SaleQty01 => this.sbt_SaleQty != null ? this.sbt_SaleQty[1] : 0.0;

    public double sbt_SaleQty02 => this.sbt_SaleQty != null ? this.sbt_SaleQty[2] : 0.0;

    public double sbt_SaleQty03 => this.sbt_SaleQty != null ? this.sbt_SaleQty[3] : 0.0;

    public double sbt_SaleQty04 => this.sbt_SaleQty != null ? this.sbt_SaleQty[4] : 0.0;

    public double sbt_SaleQty05 => this.sbt_SaleQty != null ? this.sbt_SaleQty[5] : 0.0;

    public double sbt_SaleQty06 => this.sbt_SaleQty != null ? this.sbt_SaleQty[6] : 0.0;

    public double sbt_SaleQty07 => this.sbt_SaleQty != null ? this.sbt_SaleQty[7] : 0.0;

    public double sbt_SaleQty08 => this.sbt_SaleQty != null ? this.sbt_SaleQty[8] : 0.0;

    public double sbt_SaleQty09 => this.sbt_SaleQty != null ? this.sbt_SaleQty[9] : 0.0;

    public double sbt_SaleQty10 => this.sbt_SaleQty != null ? this.sbt_SaleQty[10] : 0.0;

    public double sbt_SaleQty11 => this.sbt_SaleQty != null ? this.sbt_SaleQty[11] : 0.0;

    public double sbt_SaleQty12 => this.sbt_SaleQty != null ? this.sbt_SaleQty[12] : 0.0;

    public double sbt_SaleQty13 => this.sbt_SaleQty != null ? this.sbt_SaleQty[13] : 0.0;

    public double sbt_SaleQty14 => this.sbt_SaleQty != null ? this.sbt_SaleQty[14] : 0.0;

    public double sbt_SaleQty15 => this.sbt_SaleQty != null ? this.sbt_SaleQty[15] : 0.0;

    public double sbt_SaleQty16 => this.sbt_SaleQty != null ? this.sbt_SaleQty[16] : 0.0;

    public double sbt_SaleQty17 => this.sbt_SaleQty != null ? this.sbt_SaleQty[17] : 0.0;

    public double sbt_SaleQty18 => this.sbt_SaleQty != null ? this.sbt_SaleQty[18] : 0.0;

    public double sbt_SaleQty19 => this.sbt_SaleQty != null ? this.sbt_SaleQty[19] : 0.0;

    public double sbt_SaleQty20 => this.sbt_SaleQty != null ? this.sbt_SaleQty[20] : 0.0;

    public double sbt_SaleQty21 => this.sbt_SaleQty != null ? this.sbt_SaleQty[21] : 0.0;

    public double sbt_SaleQty22 => this.sbt_SaleQty != null ? this.sbt_SaleQty[22] : 0.0;

    public double sbt_SaleQty23 => this.sbt_SaleQty != null ? this.sbt_SaleQty[23] : 0.0;

    public double sbt_SaleQtyTotal => this.sbt_SaleQty != null ? ((IEnumerable<double>) this.sbt_SaleQty).Sum() : 0.0;

    public double sbt_SaleQty09Before => this.sbt_SaleQty != null ? ((IEnumerable<double>) this.sbt_SaleQty).Take<double>(8).Sum() : 0.0;

    public double sbt_SaleQty21After => this.sbt_SaleQty != null ? ((IEnumerable<double>) this.sbt_SaleQty).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double[] sbt_SlipCustomer
    {
      get => this._sbt_SlipCustomer ?? (this._sbt_SlipCustomer = new double[24]);
      set
      {
        this._sbt_SlipCustomer = value;
        this.Changed(nameof (sbt_SlipCustomer));
        this.Changed("sbt_SlipCustomer00");
        this.Changed("sbt_SlipCustomer01");
        this.Changed("sbt_SlipCustomer02");
        this.Changed("sbt_SlipCustomer03");
        this.Changed("sbt_SlipCustomer04");
        this.Changed("sbt_SlipCustomer05");
        this.Changed("sbt_SlipCustomer06");
        this.Changed("sbt_SlipCustomer07");
        this.Changed("sbt_SlipCustomer08");
        this.Changed("sbt_SlipCustomer09");
        this.Changed("sbt_SlipCustomer10");
        this.Changed("sbt_SlipCustomer11");
        this.Changed("sbt_SlipCustomer12");
        this.Changed("sbt_SlipCustomer13");
        this.Changed("sbt_SlipCustomer14");
        this.Changed("sbt_SlipCustomer15");
        this.Changed("sbt_SlipCustomer16");
        this.Changed("sbt_SlipCustomer17");
        this.Changed("sbt_SlipCustomer18");
        this.Changed("sbt_SlipCustomer19");
        this.Changed("sbt_SlipCustomer20");
        this.Changed("sbt_SlipCustomer21");
        this.Changed("sbt_SlipCustomer22");
        this.Changed("sbt_SlipCustomer23");
        this.Changed("sbt_SlipCustomerTotal");
        this.Changed("sbt_SlipCustomer09Before");
        this.Changed("sbt_SlipCustomer21After");
        this.Changed("sbt_SlipCustomerPrice00");
        this.Changed("sbt_SlipCustomerPrice01");
        this.Changed("sbt_SlipCustomerPrice02");
        this.Changed("sbt_SlipCustomerPrice03");
        this.Changed("sbt_SlipCustomerPrice04");
        this.Changed("sbt_SlipCustomerPrice05");
        this.Changed("sbt_SlipCustomerPrice06");
        this.Changed("sbt_SlipCustomerPrice07");
        this.Changed("sbt_SlipCustomerPrice08");
        this.Changed("sbt_SlipCustomerPrice09");
        this.Changed("sbt_SlipCustomerPrice10");
        this.Changed("sbt_SlipCustomerPrice11");
        this.Changed("sbt_SlipCustomerPrice12");
        this.Changed("sbt_SlipCustomerPrice13");
        this.Changed("sbt_SlipCustomerPrice14");
        this.Changed("sbt_SlipCustomerPrice15");
        this.Changed("sbt_SlipCustomerPrice16");
        this.Changed("sbt_SlipCustomerPrice17");
        this.Changed("sbt_SlipCustomerPrice18");
        this.Changed("sbt_SlipCustomerPrice19");
        this.Changed("sbt_SlipCustomerPrice20");
        this.Changed("sbt_SlipCustomerPrice21");
        this.Changed("sbt_SlipCustomerPrice22");
        this.Changed("sbt_SlipCustomerPrice23");
      }
    }

    public double sbt_SlipCustomer00 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[0] : 0.0;

    public double sbt_SlipCustomer01 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[1] : 0.0;

    public double sbt_SlipCustomer02 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[2] : 0.0;

    public double sbt_SlipCustomer03 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[3] : 0.0;

    public double sbt_SlipCustomer04 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[4] : 0.0;

    public double sbt_SlipCustomer05 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[5] : 0.0;

    public double sbt_SlipCustomer06 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[6] : 0.0;

    public double sbt_SlipCustomer07 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[7] : 0.0;

    public double sbt_SlipCustomer08 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[8] : 0.0;

    public double sbt_SlipCustomer09 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[9] : 0.0;

    public double sbt_SlipCustomer10 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[10] : 0.0;

    public double sbt_SlipCustomer11 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[11] : 0.0;

    public double sbt_SlipCustomer12 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[12] : 0.0;

    public double sbt_SlipCustomer13 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[13] : 0.0;

    public double sbt_SlipCustomer14 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[14] : 0.0;

    public double sbt_SlipCustomer15 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[15] : 0.0;

    public double sbt_SlipCustomer16 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[16] : 0.0;

    public double sbt_SlipCustomer17 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[17] : 0.0;

    public double sbt_SlipCustomer18 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[18] : 0.0;

    public double sbt_SlipCustomer19 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[19] : 0.0;

    public double sbt_SlipCustomer20 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[20] : 0.0;

    public double sbt_SlipCustomer21 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[21] : 0.0;

    public double sbt_SlipCustomer22 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[22] : 0.0;

    public double sbt_SlipCustomer23 => this.sbt_SlipCustomer != null ? this.sbt_SlipCustomer[23] : 0.0;

    public double sbt_SlipCustomerTotal => this.sbt_SlipCustomer != null ? ((IEnumerable<double>) this.sbt_SlipCustomer).Sum() : 0.0;

    public double sbt_SlipCustomer09Before => this.sbt_SlipCustomer != null ? ((IEnumerable<double>) this.sbt_SlipCustomer).Take<double>(8).Sum() : 0.0;

    public double sbt_SlipCustomer21After => this.sbt_SlipCustomer != null ? ((IEnumerable<double>) this.sbt_SlipCustomer).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double[] sbt_CategoryCustomer
    {
      get => this._sbt_CategoryCustomer ?? (this._sbt_CategoryCustomer = new double[24]);
      set
      {
        this._sbt_CategoryCustomer = value;
        this.Changed(nameof (sbt_CategoryCustomer));
        this.Changed("sbt_CategoryCustomer00");
        this.Changed("sbt_CategoryCustomer01");
        this.Changed("sbt_CategoryCustomer02");
        this.Changed("sbt_CategoryCustomer03");
        this.Changed("sbt_CategoryCustomer04");
        this.Changed("sbt_CategoryCustomer05");
        this.Changed("sbt_CategoryCustomer06");
        this.Changed("sbt_CategoryCustomer07");
        this.Changed("sbt_CategoryCustomer08");
        this.Changed("sbt_CategoryCustomer09");
        this.Changed("sbt_CategoryCustomer10");
        this.Changed("sbt_CategoryCustomer11");
        this.Changed("sbt_CategoryCustomer12");
        this.Changed("sbt_CategoryCustomer13");
        this.Changed("sbt_CategoryCustomer14");
        this.Changed("sbt_CategoryCustomer15");
        this.Changed("sbt_CategoryCustomer16");
        this.Changed("sbt_CategoryCustomer17");
        this.Changed("sbt_CategoryCustomer18");
        this.Changed("sbt_CategoryCustomer19");
        this.Changed("sbt_CategoryCustomer20");
        this.Changed("sbt_CategoryCustomer21");
        this.Changed("sbt_CategoryCustomer22");
        this.Changed("sbt_CategoryCustomer23");
        this.Changed("sbt_CategoryCustomerTotal");
        this.Changed("sbt_CategoryCustomer09Before");
        this.Changed("sbt_CategoryCustomer21After");
        this.Changed("sbt_CategoryCustomerPrice00");
        this.Changed("sbt_CategoryCustomerPrice01");
        this.Changed("sbt_CategoryCustomerPrice02");
        this.Changed("sbt_CategoryCustomerPrice03");
        this.Changed("sbt_CategoryCustomerPrice04");
        this.Changed("sbt_CategoryCustomerPrice05");
        this.Changed("sbt_CategoryCustomerPrice06");
        this.Changed("sbt_CategoryCustomerPrice07");
        this.Changed("sbt_CategoryCustomerPrice08");
        this.Changed("sbt_CategoryCustomerPrice09");
        this.Changed("sbt_CategoryCustomerPrice10");
        this.Changed("sbt_CategoryCustomerPrice11");
        this.Changed("sbt_CategoryCustomerPrice12");
        this.Changed("sbt_CategoryCustomerPrice13");
        this.Changed("sbt_CategoryCustomerPrice14");
        this.Changed("sbt_CategoryCustomerPrice15");
        this.Changed("sbt_CategoryCustomerPrice16");
        this.Changed("sbt_CategoryCustomerPrice17");
        this.Changed("sbt_CategoryCustomerPrice18");
        this.Changed("sbt_CategoryCustomerPrice19");
        this.Changed("sbt_CategoryCustomerPrice20");
        this.Changed("sbt_CategoryCustomerPrice21");
        this.Changed("sbt_CategoryCustomerPrice22");
        this.Changed("sbt_CategoryCustomerPrice23");
      }
    }

    public double sbt_CategoryCustomer00 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[0] : 0.0;

    public double sbt_CategoryCustomer01 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[1] : 0.0;

    public double sbt_CategoryCustomer02 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[2] : 0.0;

    public double sbt_CategoryCustomer03 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[3] : 0.0;

    public double sbt_CategoryCustomer04 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[4] : 0.0;

    public double sbt_CategoryCustomer05 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[5] : 0.0;

    public double sbt_CategoryCustomer06 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[6] : 0.0;

    public double sbt_CategoryCustomer07 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[7] : 0.0;

    public double sbt_CategoryCustomer08 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[8] : 0.0;

    public double sbt_CategoryCustomer09 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[9] : 0.0;

    public double sbt_CategoryCustomer10 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[10] : 0.0;

    public double sbt_CategoryCustomer11 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[11] : 0.0;

    public double sbt_CategoryCustomer12 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[12] : 0.0;

    public double sbt_CategoryCustomer13 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[13] : 0.0;

    public double sbt_CategoryCustomer14 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[14] : 0.0;

    public double sbt_CategoryCustomer15 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[15] : 0.0;

    public double sbt_CategoryCustomer16 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[16] : 0.0;

    public double sbt_CategoryCustomer17 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[17] : 0.0;

    public double sbt_CategoryCustomer18 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[18] : 0.0;

    public double sbt_CategoryCustomer19 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[19] : 0.0;

    public double sbt_CategoryCustomer20 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[20] : 0.0;

    public double sbt_CategoryCustomer21 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[21] : 0.0;

    public double sbt_CategoryCustomer22 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[22] : 0.0;

    public double sbt_CategoryCustomer23 => this.sbt_CategoryCustomer != null ? this.sbt_CategoryCustomer[23] : 0.0;

    public double sbt_CategoryCustomerTotal => this.sbt_CategoryCustomer != null ? ((IEnumerable<double>) this.sbt_CategoryCustomer).Sum() : 0.0;

    public double sbt_CategoryCustomer09Before => this.sbt_CategoryCustomer != null ? ((IEnumerable<double>) this.sbt_CategoryCustomer).Take<double>(8).Sum() : 0.0;

    public double sbt_CategoryCustomer21After => this.sbt_CategoryCustomer != null ? ((IEnumerable<double>) this.sbt_CategoryCustomer).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double[] sbt_GoodsCustomer
    {
      get => this._sbt_GoodsCustomer ?? (this._sbt_GoodsCustomer = new double[24]);
      set
      {
        this._sbt_GoodsCustomer = value;
        this.Changed(nameof (sbt_GoodsCustomer));
        this.Changed("sbt_GoodsCustomer00");
        this.Changed("sbt_GoodsCustomer01");
        this.Changed("sbt_GoodsCustomer02");
        this.Changed("sbt_GoodsCustomer03");
        this.Changed("sbt_GoodsCustomer04");
        this.Changed("sbt_GoodsCustomer05");
        this.Changed("sbt_GoodsCustomer06");
        this.Changed("sbt_GoodsCustomer07");
        this.Changed("sbt_GoodsCustomer08");
        this.Changed("sbt_GoodsCustomer09");
        this.Changed("sbt_GoodsCustomer10");
        this.Changed("sbt_GoodsCustomer11");
        this.Changed("sbt_GoodsCustomer12");
        this.Changed("sbt_GoodsCustomer13");
        this.Changed("sbt_GoodsCustomer14");
        this.Changed("sbt_GoodsCustomer15");
        this.Changed("sbt_GoodsCustomer16");
        this.Changed("sbt_GoodsCustomer17");
        this.Changed("sbt_GoodsCustomer18");
        this.Changed("sbt_GoodsCustomer19");
        this.Changed("sbt_GoodsCustomer20");
        this.Changed("sbt_GoodsCustomer21");
        this.Changed("sbt_GoodsCustomer22");
        this.Changed("sbt_GoodsCustomer23");
        this.Changed("sbt_GoodsCustomerTotal");
        this.Changed("sbt_GoodsCustomer09Before");
        this.Changed("sbt_GoodsCustomer21After");
        this.Changed("sbt_GoodsCustomerPrice00");
        this.Changed("sbt_GoodsCustomerPrice01");
        this.Changed("sbt_GoodsCustomerPrice02");
        this.Changed("sbt_GoodsCustomerPrice03");
        this.Changed("sbt_GoodsCustomerPrice04");
        this.Changed("sbt_GoodsCustomerPrice05");
        this.Changed("sbt_GoodsCustomerPrice06");
        this.Changed("sbt_GoodsCustomerPrice07");
        this.Changed("sbt_GoodsCustomerPrice08");
        this.Changed("sbt_GoodsCustomerPrice09");
        this.Changed("sbt_GoodsCustomerPrice10");
        this.Changed("sbt_GoodsCustomerPrice11");
        this.Changed("sbt_GoodsCustomerPrice12");
        this.Changed("sbt_GoodsCustomerPrice13");
        this.Changed("sbt_GoodsCustomerPrice14");
        this.Changed("sbt_GoodsCustomerPrice15");
        this.Changed("sbt_GoodsCustomerPrice16");
        this.Changed("sbt_GoodsCustomerPrice17");
        this.Changed("sbt_GoodsCustomerPrice18");
        this.Changed("sbt_GoodsCustomerPrice19");
        this.Changed("sbt_GoodsCustomerPrice20");
        this.Changed("sbt_GoodsCustomerPrice21");
        this.Changed("sbt_GoodsCustomerPrice22");
        this.Changed("sbt_GoodsCustomerPrice23");
      }
    }

    public double sbt_GoodsCustomer00 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[0] : 0.0;

    public double sbt_GoodsCustomer01 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[1] : 0.0;

    public double sbt_GoodsCustomer02 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[2] : 0.0;

    public double sbt_GoodsCustomer03 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[3] : 0.0;

    public double sbt_GoodsCustomer04 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[4] : 0.0;

    public double sbt_GoodsCustomer05 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[5] : 0.0;

    public double sbt_GoodsCustomer06 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[6] : 0.0;

    public double sbt_GoodsCustomer07 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[7] : 0.0;

    public double sbt_GoodsCustomer08 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[8] : 0.0;

    public double sbt_GoodsCustomer09 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[9] : 0.0;

    public double sbt_GoodsCustomer10 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[10] : 0.0;

    public double sbt_GoodsCustomer11 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[11] : 0.0;

    public double sbt_GoodsCustomer12 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[12] : 0.0;

    public double sbt_GoodsCustomer13 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[13] : 0.0;

    public double sbt_GoodsCustomer14 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[14] : 0.0;

    public double sbt_GoodsCustomer15 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[15] : 0.0;

    public double sbt_GoodsCustomer16 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[16] : 0.0;

    public double sbt_GoodsCustomer17 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[17] : 0.0;

    public double sbt_GoodsCustomer18 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[18] : 0.0;

    public double sbt_GoodsCustomer19 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[19] : 0.0;

    public double sbt_GoodsCustomer20 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[20] : 0.0;

    public double sbt_GoodsCustomer21 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[21] : 0.0;

    public double sbt_GoodsCustomer22 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[22] : 0.0;

    public double sbt_GoodsCustomer23 => this.sbt_GoodsCustomer != null ? this.sbt_GoodsCustomer[23] : 0.0;

    public double sbt_GoodsCustomerTotal => this.sbt_GoodsCustomer != null ? ((IEnumerable<double>) this.sbt_GoodsCustomer).Sum() : 0.0;

    public double sbt_GoodsCustomer09Before => this.sbt_GoodsCustomer != null ? ((IEnumerable<double>) this.sbt_GoodsCustomer).Take<double>(8).Sum() : 0.0;

    public double sbt_GoodsCustomer21After => this.sbt_GoodsCustomer != null ? ((IEnumerable<double>) this.sbt_GoodsCustomer).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double[] sbt_SupplierCustomer
    {
      get => this._sbt_SupplierCustomer ?? (this._sbt_SupplierCustomer = new double[24]);
      set
      {
        this._sbt_SupplierCustomer = value;
        this.Changed(nameof (sbt_SupplierCustomer));
        this.Changed("sbt_SupplierCustomer00");
        this.Changed("sbt_SupplierCustomer01");
        this.Changed("sbt_SupplierCustomer02");
        this.Changed("sbt_SupplierCustomer03");
        this.Changed("sbt_SupplierCustomer04");
        this.Changed("sbt_SupplierCustomer05");
        this.Changed("sbt_SupplierCustomer06");
        this.Changed("sbt_SupplierCustomer07");
        this.Changed("sbt_SupplierCustomer08");
        this.Changed("sbt_SupplierCustomer09");
        this.Changed("sbt_SupplierCustomer10");
        this.Changed("sbt_SupplierCustomer11");
        this.Changed("sbt_SupplierCustomer12");
        this.Changed("sbt_SupplierCustomer13");
        this.Changed("sbt_SupplierCustomer14");
        this.Changed("sbt_SupplierCustomer15");
        this.Changed("sbt_SupplierCustomer16");
        this.Changed("sbt_SupplierCustomer17");
        this.Changed("sbt_SupplierCustomer18");
        this.Changed("sbt_SupplierCustomer19");
        this.Changed("sbt_SupplierCustomer20");
        this.Changed("sbt_SupplierCustomer21");
        this.Changed("sbt_SupplierCustomer22");
        this.Changed("sbt_SupplierCustomer23");
        this.Changed("sbt_SupplierCustomerTotal");
        this.Changed("sbt_SupplierCustomer09Before");
        this.Changed("sbt_SupplierCustomer21After");
        this.Changed("sbt_SupplierCustomerPrice00");
        this.Changed("sbt_SupplierCustomerPrice01");
        this.Changed("sbt_SupplierCustomerPrice02");
        this.Changed("sbt_SupplierCustomerPrice03");
        this.Changed("sbt_SupplierCustomerPrice04");
        this.Changed("sbt_SupplierCustomerPrice05");
        this.Changed("sbt_SupplierCustomerPrice06");
        this.Changed("sbt_SupplierCustomerPrice07");
        this.Changed("sbt_SupplierCustomerPrice08");
        this.Changed("sbt_SupplierCustomerPrice09");
        this.Changed("sbt_SupplierCustomerPrice10");
        this.Changed("sbt_SupplierCustomerPrice11");
        this.Changed("sbt_SupplierCustomerPrice12");
        this.Changed("sbt_SupplierCustomerPrice13");
        this.Changed("sbt_SupplierCustomerPrice14");
        this.Changed("sbt_SupplierCustomerPrice15");
        this.Changed("sbt_SupplierCustomerPrice16");
        this.Changed("sbt_SupplierCustomerPrice17");
        this.Changed("sbt_SupplierCustomerPrice18");
        this.Changed("sbt_SupplierCustomerPrice19");
        this.Changed("sbt_SupplierCustomerPrice20");
        this.Changed("sbt_SupplierCustomerPrice21");
        this.Changed("sbt_SupplierCustomerPrice22");
        this.Changed("sbt_SupplierCustomerPrice23");
      }
    }

    public double sbt_SupplierCustomer00 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[0] : 0.0;

    public double sbt_SupplierCustomer01 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[1] : 0.0;

    public double sbt_SupplierCustomer02 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[2] : 0.0;

    public double sbt_SupplierCustomer03 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[3] : 0.0;

    public double sbt_SupplierCustomer04 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[4] : 0.0;

    public double sbt_SupplierCustomer05 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[5] : 0.0;

    public double sbt_SupplierCustomer06 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[6] : 0.0;

    public double sbt_SupplierCustomer07 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[7] : 0.0;

    public double sbt_SupplierCustomer08 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[8] : 0.0;

    public double sbt_SupplierCustomer09 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[9] : 0.0;

    public double sbt_SupplierCustomer10 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[10] : 0.0;

    public double sbt_SupplierCustomer11 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[11] : 0.0;

    public double sbt_SupplierCustomer12 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[12] : 0.0;

    public double sbt_SupplierCustomer13 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[13] : 0.0;

    public double sbt_SupplierCustomer14 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[14] : 0.0;

    public double sbt_SupplierCustomer15 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[15] : 0.0;

    public double sbt_SupplierCustomer16 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[16] : 0.0;

    public double sbt_SupplierCustomer17 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[17] : 0.0;

    public double sbt_SupplierCustomer18 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[18] : 0.0;

    public double sbt_SupplierCustomer19 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[19] : 0.0;

    public double sbt_SupplierCustomer20 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[20] : 0.0;

    public double sbt_SupplierCustomer21 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[21] : 0.0;

    public double sbt_SupplierCustomer22 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[22] : 0.0;

    public double sbt_SupplierCustomer23 => this.sbt_SupplierCustomer != null ? this.sbt_SupplierCustomer[23] : 0.0;

    public double sbt_SupplierCustomerTotal => this.sbt_SupplierCustomer != null ? ((IEnumerable<double>) this.sbt_SupplierCustomer).Sum() : 0.0;

    public double sbt_SupplierCustomer09Before => this.sbt_SupplierCustomer != null ? ((IEnumerable<double>) this.sbt_SupplierCustomer).Take<double>(8).Sum() : 0.0;

    public double sbt_SupplierCustomer21After => this.sbt_SupplierCustomer != null ? ((IEnumerable<double>) this.sbt_SupplierCustomer).Skip<double>(21).Take<double>(2).Sum() : 0.0;

    public double sbt_SlipCustomerPrice00 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[0], this.sbt_SlipCustomer[0]) : 0.0;

    public double sbt_SlipCustomerPrice01 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[1], this.sbt_SlipCustomer[1]) : 0.0;

    public double sbt_SlipCustomerPrice02 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[2], this.sbt_SlipCustomer[2]) : 0.0;

    public double sbt_SlipCustomerPrice03 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[3], this.sbt_SlipCustomer[3]) : 0.0;

    public double sbt_SlipCustomerPrice04 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[4], this.sbt_SlipCustomer[4]) : 0.0;

    public double sbt_SlipCustomerPrice05 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[5], this.sbt_SlipCustomer[5]) : 0.0;

    public double sbt_SlipCustomerPrice06 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[6], this.sbt_SlipCustomer[6]) : 0.0;

    public double sbt_SlipCustomerPrice07 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[7], this.sbt_SlipCustomer[7]) : 0.0;

    public double sbt_SlipCustomerPrice08 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[8], this.sbt_SlipCustomer[8]) : 0.0;

    public double sbt_SlipCustomerPrice09 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[9], this.sbt_SlipCustomer[9]) : 0.0;

    public double sbt_SlipCustomerPrice10 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[10], this.sbt_SlipCustomer[10]) : 0.0;

    public double sbt_SlipCustomerPrice11 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[11], this.sbt_SlipCustomer[11]) : 0.0;

    public double sbt_SlipCustomerPrice12 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[12], this.sbt_SlipCustomer[12]) : 0.0;

    public double sbt_SlipCustomerPrice13 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[13], this.sbt_SlipCustomer[13]) : 0.0;

    public double sbt_SlipCustomerPrice14 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[14], this.sbt_SlipCustomer[14]) : 0.0;

    public double sbt_SlipCustomerPrice15 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[15], this.sbt_SlipCustomer[15]) : 0.0;

    public double sbt_SlipCustomerPrice16 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[16], this.sbt_SlipCustomer[16]) : 0.0;

    public double sbt_SlipCustomerPrice17 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[17], this.sbt_SlipCustomer[17]) : 0.0;

    public double sbt_SlipCustomerPrice18 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[18], this.sbt_SlipCustomer[18]) : 0.0;

    public double sbt_SlipCustomerPrice19 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[19], this.sbt_SlipCustomer[19]) : 0.0;

    public double sbt_SlipCustomerPrice20 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[20], this.sbt_SlipCustomer[20]) : 0.0;

    public double sbt_SlipCustomerPrice21 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[21], this.sbt_SlipCustomer[21]) : 0.0;

    public double sbt_SlipCustomerPrice22 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[22], this.sbt_SlipCustomer[22]) : 0.0;

    public double sbt_SlipCustomerPrice23 => this.sbt_SaleAmt != null && this.sbt_SlipCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[23], this.sbt_SlipCustomer[23]) : 0.0;

    public double sbt_CategoryCustomerPrice00 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[0], this.sbt_CategoryCustomer[0]) : 0.0;

    public double sbt_CategoryCustomerPrice01 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[1], this.sbt_CategoryCustomer[1]) : 0.0;

    public double sbt_CategoryCustomerPrice02 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[2], this.sbt_CategoryCustomer[2]) : 0.0;

    public double sbt_CategoryCustomerPrice03 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[3], this.sbt_CategoryCustomer[3]) : 0.0;

    public double sbt_CategoryCustomerPrice04 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[4], this.sbt_CategoryCustomer[4]) : 0.0;

    public double sbt_CategoryCustomerPrice05 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[5], this.sbt_CategoryCustomer[5]) : 0.0;

    public double sbt_CategoryCustomerPrice06 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[6], this.sbt_CategoryCustomer[6]) : 0.0;

    public double sbt_CategoryCustomerPrice07 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[7], this.sbt_CategoryCustomer[7]) : 0.0;

    public double sbt_CategoryCustomerPrice08 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[8], this.sbt_CategoryCustomer[8]) : 0.0;

    public double sbt_CategoryCustomerPrice09 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[9], this.sbt_CategoryCustomer[9]) : 0.0;

    public double sbt_CategoryCustomerPrice10 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[10], this.sbt_CategoryCustomer[10]) : 0.0;

    public double sbt_CategoryCustomerPrice11 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[11], this.sbt_CategoryCustomer[11]) : 0.0;

    public double sbt_CategoryCustomerPrice12 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[12], this.sbt_CategoryCustomer[12]) : 0.0;

    public double sbt_CategoryCustomerPrice13 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[13], this.sbt_CategoryCustomer[13]) : 0.0;

    public double sbt_CategoryCustomerPrice14 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[14], this.sbt_CategoryCustomer[14]) : 0.0;

    public double sbt_CategoryCustomerPrice15 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[15], this.sbt_CategoryCustomer[15]) : 0.0;

    public double sbt_CategoryCustomerPrice16 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[16], this.sbt_CategoryCustomer[16]) : 0.0;

    public double sbt_CategoryCustomerPrice17 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[17], this.sbt_CategoryCustomer[17]) : 0.0;

    public double sbt_CategoryCustomerPrice18 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[18], this.sbt_CategoryCustomer[18]) : 0.0;

    public double sbt_CategoryCustomerPrice19 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[19], this.sbt_CategoryCustomer[19]) : 0.0;

    public double sbt_CategoryCustomerPrice20 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[20], this.sbt_CategoryCustomer[20]) : 0.0;

    public double sbt_CategoryCustomerPrice21 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[21], this.sbt_CategoryCustomer[21]) : 0.0;

    public double sbt_CategoryCustomerPrice22 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[22], this.sbt_CategoryCustomer[22]) : 0.0;

    public double sbt_CategoryCustomerPrice23 => this.sbt_SaleAmt != null && this.sbt_CategoryCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[23], this.sbt_CategoryCustomer[23]) : 0.0;

    public double sbt_SupplierCustomerPrice00 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[0], this.sbt_SupplierCustomer[0]) : 0.0;

    public double sbt_SupplierCustomerPrice01 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[1], this.sbt_SupplierCustomer[1]) : 0.0;

    public double sbt_SupplierCustomerPrice02 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[2], this.sbt_SupplierCustomer[2]) : 0.0;

    public double sbt_SupplierCustomerPrice03 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[3], this.sbt_SupplierCustomer[3]) : 0.0;

    public double sbt_SupplierCustomerPrice04 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[4], this.sbt_SupplierCustomer[4]) : 0.0;

    public double sbt_SupplierCustomerPrice05 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[5], this.sbt_SupplierCustomer[5]) : 0.0;

    public double sbt_SupplierCustomerPrice06 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[6], this.sbt_SupplierCustomer[6]) : 0.0;

    public double sbt_SupplierCustomerPrice07 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[7], this.sbt_SupplierCustomer[7]) : 0.0;

    public double sbt_SupplierCustomerPrice08 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[8], this.sbt_SupplierCustomer[8]) : 0.0;

    public double sbt_SupplierCustomerPrice09 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[9], this.sbt_SupplierCustomer[9]) : 0.0;

    public double sbt_SupplierCustomerPrice10 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[10], this.sbt_SupplierCustomer[10]) : 0.0;

    public double sbt_SupplierCustomerPrice11 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[11], this.sbt_SupplierCustomer[11]) : 0.0;

    public double sbt_SupplierCustomerPrice12 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[12], this.sbt_SupplierCustomer[12]) : 0.0;

    public double sbt_SupplierCustomerPrice13 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[13], this.sbt_SupplierCustomer[13]) : 0.0;

    public double sbt_SupplierCustomerPrice14 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[14], this.sbt_SupplierCustomer[14]) : 0.0;

    public double sbt_SupplierCustomerPrice15 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[15], this.sbt_SupplierCustomer[15]) : 0.0;

    public double sbt_SupplierCustomerPrice16 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[16], this.sbt_SupplierCustomer[16]) : 0.0;

    public double sbt_SupplierCustomerPrice17 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[17], this.sbt_SupplierCustomer[17]) : 0.0;

    public double sbt_SupplierCustomerPrice18 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[18], this.sbt_SupplierCustomer[18]) : 0.0;

    public double sbt_SupplierCustomerPrice19 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[19], this.sbt_SupplierCustomer[19]) : 0.0;

    public double sbt_SupplierCustomerPrice20 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[20], this.sbt_SupplierCustomer[20]) : 0.0;

    public double sbt_SupplierCustomerPrice21 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[21], this.sbt_SupplierCustomer[21]) : 0.0;

    public double sbt_SupplierCustomerPrice22 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[22], this.sbt_SupplierCustomer[22]) : 0.0;

    public double sbt_SupplierCustomerPrice23 => this.sbt_SaleAmt != null && this.sbt_SupplierCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[23], this.sbt_SupplierCustomer[23]) : 0.0;

    public double sbt_GoodsCustomerPrice00 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[0], this.sbt_GoodsCustomer[0]) : 0.0;

    public double sbt_GoodsCustomerPrice01 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[1], this.sbt_GoodsCustomer[1]) : 0.0;

    public double sbt_GoodsCustomerPrice02 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[2], this.sbt_GoodsCustomer[2]) : 0.0;

    public double sbt_GoodsCustomerPrice03 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[3], this.sbt_GoodsCustomer[3]) : 0.0;

    public double sbt_GoodsCustomerPrice04 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[4], this.sbt_GoodsCustomer[4]) : 0.0;

    public double sbt_GoodsCustomerPrice05 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[5], this.sbt_GoodsCustomer[5]) : 0.0;

    public double sbt_GoodsCustomerPrice06 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[6], this.sbt_GoodsCustomer[6]) : 0.0;

    public double sbt_GoodsCustomerPrice07 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[7], this.sbt_GoodsCustomer[7]) : 0.0;

    public double sbt_GoodsCustomerPrice08 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[8], this.sbt_GoodsCustomer[8]) : 0.0;

    public double sbt_GoodsCustomerPrice09 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[9], this.sbt_GoodsCustomer[9]) : 0.0;

    public double sbt_GoodsCustomerPrice10 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[10], this.sbt_GoodsCustomer[10]) : 0.0;

    public double sbt_GoodsCustomerPrice11 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[11], this.sbt_GoodsCustomer[11]) : 0.0;

    public double sbt_GoodsCustomerPrice12 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[12], this.sbt_GoodsCustomer[12]) : 0.0;

    public double sbt_GoodsCustomerPrice13 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[13], this.sbt_GoodsCustomer[13]) : 0.0;

    public double sbt_GoodsCustomerPrice14 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[14], this.sbt_GoodsCustomer[14]) : 0.0;

    public double sbt_GoodsCustomerPrice15 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[15], this.sbt_GoodsCustomer[15]) : 0.0;

    public double sbt_GoodsCustomerPrice16 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[16], this.sbt_GoodsCustomer[16]) : 0.0;

    public double sbt_GoodsCustomerPrice17 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[17], this.sbt_GoodsCustomer[17]) : 0.0;

    public double sbt_GoodsCustomerPrice18 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[18], this.sbt_GoodsCustomer[18]) : 0.0;

    public double sbt_GoodsCustomerPrice19 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[19], this.sbt_GoodsCustomer[19]) : 0.0;

    public double sbt_GoodsCustomerPrice20 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[20], this.sbt_GoodsCustomer[20]) : 0.0;

    public double sbt_GoodsCustomerPrice21 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[21], this.sbt_GoodsCustomer[21]) : 0.0;

    public double sbt_GoodsCustomerPrice22 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[22], this.sbt_GoodsCustomer[22]) : 0.0;

    public double sbt_GoodsCustomerPrice23 => this.sbt_SaleAmt != null && this.sbt_GoodsCustomer != null ? CalcHelper.ToPersonsPrice(this.sbt_SaleAmt[23], this.sbt_GoodsCustomer[23]) : 0.0;

    public TSalesByTime() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sbt_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "sbt_SaleDate",
        tc_trans_name = "판매일자"
      });
      columnInfo.Add("sbt_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "sbt_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("sbt_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "sbt_CategoryCode",
        tc_trans_name = "분류ID"
      });
      columnInfo.Add("sbt_DeptCode", new TTableColumn()
      {
        tc_orgin_name = "sbt_DeptCode",
        tc_trans_name = "부서ID"
      });
      columnInfo.Add("sbt_BoxCode", new TTableColumn()
      {
        tc_orgin_name = "sbt_BoxCode",
        tc_trans_name = "BOXCODE"
      });
      columnInfo.Add("sbt_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "sbt_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("sbt_Supplier", new TTableColumn()
      {
        tc_orgin_name = "sbt_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("sbt_KeySeq", new TTableColumn()
      {
        tc_orgin_name = "sbt_KeySeq",
        tc_trans_name = "KEY"
      });
      columnInfo.Add("sbt_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sbt_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sbt_DayOfWeek", new TTableColumn()
      {
        tc_orgin_name = "sbt_DayOfWeek",
        tc_trans_name = "요일 "
      });
      columnInfo.Add("sbt_WeekOfYear", new TTableColumn()
      {
        tc_orgin_name = "sbt_WeekOfYear",
        tc_trans_name = "년주차 "
      });
      columnInfo.Add("sbt_DayOfYear", new TTableColumn()
      {
        tc_orgin_name = "sbt_DayOfYear",
        tc_trans_name = "일수 "
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SalesByTime;
      this.sbt_SaleDate = new DateTime?();
      this.sbt_StoreCode = this.sbt_CategoryCode = this.sbt_DeptCode = 0;
      this.sbt_BoxCode = this.sbt_GoodsCode = 0L;
      this.sbt_Supplier = this.sbt_KeySeq = 0;
      this.sbt_SiteID = 0L;
      this.sbt_DayOfWeek = this.sbt_WeekOfYear = this.sbt_DayOfYear = 0;
      this.sbt_SaleAmt = (double[]) null;
      this.sbt_BoxQty = (double[]) null;
      this.sbt_SaleQty = (double[]) null;
      this.sbt_SlipCustomer = (double[]) null;
      this.sbt_CategoryCustomer = (double[]) null;
      this.sbt_GoodsCustomer = (double[]) null;
      this.sbt_SupplierCustomer = (double[]) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSalesByTime();

    public override object Clone()
    {
      TSalesByTime tsalesByTime = base.Clone() as TSalesByTime;
      tsalesByTime.sbt_SaleDate = this.sbt_SaleDate;
      tsalesByTime.sbt_StoreCode = this.sbt_StoreCode;
      tsalesByTime.sbt_CategoryCode = this.sbt_CategoryCode;
      tsalesByTime.sbt_DeptCode = this.sbt_DeptCode;
      tsalesByTime.sbt_BoxCode = this.sbt_BoxCode;
      tsalesByTime.sbt_GoodsCode = this.sbt_GoodsCode;
      tsalesByTime.sbt_Supplier = this.sbt_Supplier;
      tsalesByTime.sbt_KeySeq = this.sbt_KeySeq;
      tsalesByTime.sbt_SiteID = this.sbt_SiteID;
      tsalesByTime.sbt_DayOfWeek = this.sbt_DayOfWeek;
      tsalesByTime.sbt_WeekOfYear = this.sbt_WeekOfYear;
      tsalesByTime.sbt_DayOfYear = this.sbt_DayOfYear;
      tsalesByTime.sbt_SaleAmt = this.sbt_SaleAmt;
      tsalesByTime.sbt_BoxQty = this.sbt_BoxQty;
      tsalesByTime.sbt_SaleQty = this.sbt_SaleQty;
      tsalesByTime.sbt_SlipCustomer = this.sbt_SlipCustomer;
      tsalesByTime.sbt_CategoryCustomer = this.sbt_CategoryCustomer;
      tsalesByTime.sbt_GoodsCustomer = this.sbt_GoodsCustomer;
      tsalesByTime.sbt_SupplierCustomer = this.sbt_SupplierCustomer;
      return (object) tsalesByTime;
    }

    public void PutData(TSalesByTime pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sbt_SaleDate = pSource.sbt_SaleDate;
      this.sbt_StoreCode = pSource.sbt_StoreCode;
      this.sbt_CategoryCode = pSource.sbt_CategoryCode;
      this.sbt_DeptCode = pSource.sbt_DeptCode;
      this.sbt_BoxCode = pSource.sbt_BoxCode;
      this.sbt_GoodsCode = pSource.sbt_GoodsCode;
      this.sbt_Supplier = pSource.sbt_Supplier;
      this.sbt_KeySeq = pSource.sbt_KeySeq;
      this.sbt_SiteID = pSource.sbt_SiteID;
      this.sbt_DayOfWeek = pSource.sbt_DayOfWeek;
      this.sbt_WeekOfYear = pSource.sbt_WeekOfYear;
      this.sbt_DayOfYear = pSource.sbt_DayOfYear;
      int num1 = 0;
      foreach (double num2 in pSource.sbt_SaleAmt)
        this.sbt_SaleAmt[num1++] = num2;
      int num3 = 0;
      foreach (double num4 in pSource.sbt_BoxQty)
        this.sbt_BoxQty[num3++] = num4;
      int num5 = 0;
      foreach (double num6 in pSource.sbt_SaleQty)
        this.sbt_SaleQty[num5++] = num6;
      int num7 = 0;
      foreach (double num8 in pSource.sbt_SlipCustomer)
        this.sbt_SlipCustomer[num7++] = num8;
      int num9 = 0;
      foreach (double num10 in pSource.sbt_CategoryCustomer)
        this.sbt_CategoryCustomer[num9++] = num10;
      int num11 = 0;
      foreach (double num12 in pSource.sbt_GoodsCustomer)
        this.sbt_GoodsCustomer[num11++] = num12;
      int num13 = 0;
      foreach (double num14 in pSource.sbt_SupplierCustomer)
        this.sbt_SupplierCustomer[num13++] = num14;
    }

    public virtual bool CalcAddSum(TSalesByTime pSource)
    {
      if (pSource == null)
        return false;
      for (int index = 0; index < 24; ++index)
      {
        this.sbt_SaleAmt[index] += pSource.sbt_SaleAmt[index];
        this.sbt_BoxQty[index] += pSource.sbt_BoxQty[index];
        this.sbt_SaleQty[index] += pSource.sbt_SaleQty[index];
        this.sbt_SlipCustomer[index] += pSource.sbt_SlipCustomer[index];
        this.sbt_CategoryCustomer[index] += pSource.sbt_CategoryCustomer[index];
        this.sbt_GoodsCustomer[index] += pSource.sbt_GoodsCustomer[index];
        this.sbt_SupplierCustomer[index] += pSource.sbt_SupplierCustomer[index];
      }
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType, TSalesByTime pSource)
    {
      if (pSource == null)
        return true;
      if (Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType))
      {
        for (int index = 0; index < 24; ++index)
        {
          if (!pSource.sbt_BoxQty[index].IsZero() || !pSource.sbt_SaleQty[index].IsZero() || !pSource.sbt_SlipCustomer[index].IsZero() || !pSource.sbt_CategoryCustomer[index].IsZero() || !pSource.sbt_GoodsCustomer[index].IsZero() || !pSource.sbt_SupplierCustomer[index].IsZero())
            return false;
        }
      }
      if (Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType))
      {
        for (int index = 0; index < 24; ++index)
        {
          if (!pSource.sbt_SaleAmt[index].IsZero())
            return false;
        }
      }
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sbt_SaleDate = p_rs.GetFieldDateTime("sbt_SaleDate");
        this.sbt_StoreCode = p_rs.GetFieldInt("sbt_StoreCode");
        if (this.sbt_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sbt_CategoryCode = p_rs.GetFieldInt("sbt_CategoryCode");
        this.sbt_DeptCode = p_rs.GetFieldInt("sbt_DeptCode");
        this.sbt_BoxCode = p_rs.GetFieldLong("sbt_BoxCode");
        this.sbt_GoodsCode = p_rs.GetFieldLong("sbt_GoodsCode");
        this.sbt_Supplier = p_rs.GetFieldInt("sbt_Supplier");
        this.sbt_KeySeq = p_rs.GetFieldInt("sbt_KeySeq");
        this.sbt_SiteID = p_rs.GetFieldLong("sbt_SiteID");
        this.sbt_DayOfWeek = p_rs.GetFieldInt("sbt_DayOfWeek");
        this.sbt_WeekOfYear = p_rs.GetFieldInt("sbt_WeekOfYear");
        this.sbt_DayOfYear = p_rs.GetFieldInt("sbt_DayOfYear");
        for (int index = 0; index < 24; ++index)
        {
          this.sbt_SaleAmt[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SaleAmt", (object) index));
          this.sbt_BoxQty[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_BoxQty", (object) index));
          this.sbt_SaleQty[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SaleQty", (object) index));
          this.sbt_SlipCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SlipCustomer", (object) index));
          this.sbt_CategoryCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index));
          this.sbt_GoodsCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index));
          this.sbt_SupplierCustomer[index] = p_rs.GetFieldDouble(string.Format("{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index));
        }
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " sbt_SaleDate,sbt_StoreCode,sbt_CategoryCode,sbt_DeptCode,sbt_BoxCode,sbt_GoodsCode,sbt_Supplier,sbt_KeySeq,sbt_SiteID,sbt_DayOfWeek,sbt_WeekOfYear,sbt_DayOfYear");
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append(string.Format(",{0}{1:00}", (object) "sbt_SaleAmt", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_BoxQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SaleQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SlipCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index));
      stringBuilder.Append(") VALUES ( ");
      stringBuilder.Append(" '" + this.sbt_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(",{0},{1},{2}", (object) this.sbt_StoreCode, (object) this.sbt_CategoryCode, (object) this.sbt_DeptCode) + string.Format(",{0},{1}", (object) this.sbt_BoxCode, (object) this.sbt_GoodsCode) + string.Format(",{0},{1}", (object) this.sbt_Supplier, (object) this.sbt_KeySeq) + string.Format(",{0}", (object) this.sbt_SiteID) + string.Format(",{0},{1},{2}", (object) this.sbt_DayOfWeek, (object) this.sbt_WeekOfYear, (object) this.sbt_DayOfYear));
      for (int index = 0; index < 24; ++index)
        stringBuilder.Append("," + this.sbt_SaleAmt[index].FormatTo("{0:0.0000}") + "," + this.sbt_BoxQty[index].FormatTo("{0:0.0000}") + "," + this.sbt_SaleQty[index].FormatTo("{0:0.0000}") + "," + this.sbt_SlipCustomer[index].FormatTo("{0:0.0000}") + "," + this.sbt_CategoryCustomer[index].FormatTo("{0:0.0000}") + "," + this.sbt_GoodsCustomer[index].FormatTo("{0:0.0000}") + "," + this.sbt_SupplierCustomer[index].FormatTo("{0:0.0000}"));
      stringBuilder.Append(")");
      return stringBuilder.ToString();
    }

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) this.sbt_SaleDate, (object) this.sbt_StoreCode, (object) this.sbt_CategoryCode, (object) this.sbt_DeptCode) + string.Format(",{0},{1},{2},{3})\n", (object) this.sbt_BoxCode, (object) this.sbt_GoodsCode, (object) this.sbt_Supplier, (object) this.sbt_KeySeq) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TSalesByTime tsalesByTime = this;
      // ISSUE: reference to a compiler-generated method
      tsalesByTime.\u003C\u003En__0();
      if (await tsalesByTime.OleDB.ExecuteAsync(tsalesByTime.InsertQuery()))
        return true;
      tsalesByTime.message = " " + tsalesByTime.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsalesByTime.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsalesByTime.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) tsalesByTime.sbt_SaleDate, (object) tsalesByTime.sbt_StoreCode, (object) tsalesByTime.sbt_CategoryCode, (object) tsalesByTime.sbt_DeptCode) + string.Format(",{0},{1},{2},{3})\n", (object) tsalesByTime.sbt_BoxCode, (object) tsalesByTime.sbt_GoodsCode, (object) tsalesByTime.sbt_Supplier, (object) tsalesByTime.sbt_KeySeq) + " 내용 : " + tsalesByTime.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsalesByTime.message);
      return false;
    }

    public override string UpdateQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode));
      for (int index = 0; index < 24; ++index)
      {
        if (index > 0)
          stringBuilder.Append(",");
        stringBuilder.Append(string.Format(" {0}{1:00}={2}", (object) "sbt_SaleAmt", (object) index, (object) this.sbt_SaleAmt[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_BoxQty", (object) index, (object) this.sbt_BoxQty[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_SaleQty", (object) index, (object) this.sbt_SaleQty[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_SlipCustomer", (object) index, (object) this.sbt_SlipCustomer[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_CategoryCustomer", (object) index, (object) this.sbt_CategoryCustomer[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_GoodsCustomer", (object) index, (object) this.sbt_GoodsCustomer[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_SupplierCustomer", (object) index, (object) this.sbt_SupplierCustomer[index].FormatTo("{0:0.0000}")));
      }
      stringBuilder.Append(" WHERE sbt_SaleDate='" + this.sbt_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "sbt_StoreCode", (object) this.sbt_StoreCode) + string.Format(" AND {0}={1}", (object) "sbt_CategoryCode", (object) this.sbt_CategoryCode) + string.Format(" AND {0}={1}", (object) "sbt_DeptCode", (object) this.sbt_DeptCode) + string.Format(" AND {0}={1}", (object) "sbt_BoxCode", (object) this.sbt_BoxCode) + string.Format(" AND {0}={1}", (object) "sbt_GoodsCode", (object) this.sbt_GoodsCode) + string.Format(" AND {0}={1}", (object) "sbt_Supplier", (object) this.sbt_Supplier) + string.Format(" AND {0}={1}", (object) "sbt_KeySeq", (object) this.sbt_KeySeq));
      return stringBuilder.ToString();
    }

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) this.sbt_SaleDate, (object) this.sbt_StoreCode, (object) this.sbt_CategoryCode, (object) this.sbt_DeptCode) + string.Format(",{0},{1},{2},{3})\n", (object) this.sbt_BoxCode, (object) this.sbt_GoodsCode, (object) this.sbt_Supplier, (object) this.sbt_KeySeq) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TSalesByTime tsalesByTime = this;
      // ISSUE: reference to a compiler-generated method
      tsalesByTime.\u003C\u003En__1();
      if (await tsalesByTime.OleDB.ExecuteAsync(tsalesByTime.UpdateQuery()))
        return true;
      tsalesByTime.message = " " + tsalesByTime.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsalesByTime.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsalesByTime.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) tsalesByTime.sbt_SaleDate, (object) tsalesByTime.sbt_StoreCode, (object) tsalesByTime.sbt_CategoryCode, (object) tsalesByTime.sbt_DeptCode) + string.Format(",{0},{1},{2},{3})\n", (object) tsalesByTime.sbt_BoxCode, (object) tsalesByTime.sbt_GoodsCode, (object) tsalesByTime.sbt_Supplier, (object) tsalesByTime.sbt_KeySeq) + " 내용 : " + tsalesByTime.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsalesByTime.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      for (int index = 0; index < 24; ++index)
      {
        if (index > 0)
          stringBuilder.Append(",");
        stringBuilder.Append(string.Format(" {0}{1:00}={2}", (object) "sbt_SaleAmt", (object) index, (object) this.sbt_SaleAmt[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_BoxQty", (object) index, (object) this.sbt_BoxQty[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_SaleQty", (object) index, (object) this.sbt_SaleQty[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_SlipCustomer", (object) index, (object) this.sbt_SlipCustomer[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_CategoryCustomer", (object) index, (object) this.sbt_CategoryCustomer[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_GoodsCustomer", (object) index, (object) this.sbt_GoodsCustomer[index].FormatTo("{0:0.0000}")) + string.Format(",{0}{1:00}={2}", (object) "sbt_SupplierCustomer", (object) index, (object) this.sbt_SupplierCustomer[index].FormatTo("{0:0.0000}")));
      }
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) this.sbt_SaleDate, (object) this.sbt_StoreCode, (object) this.sbt_CategoryCode, (object) this.sbt_DeptCode) + string.Format(",{0},{1},{2},{3})\n", (object) this.sbt_BoxCode, (object) this.sbt_GoodsCode, (object) this.sbt_Supplier, (object) this.sbt_KeySeq) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TSalesByTime tsalesByTime = this;
      // ISSUE: reference to a compiler-generated method
      tsalesByTime.\u003C\u003En__1();
      if (await tsalesByTime.OleDB.ExecuteAsync(tsalesByTime.UpdateExInsertQuery()))
        return true;
      tsalesByTime.message = " " + tsalesByTime.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsalesByTime.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsalesByTime.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) tsalesByTime.sbt_SaleDate, (object) tsalesByTime.sbt_StoreCode, (object) tsalesByTime.sbt_CategoryCode, (object) tsalesByTime.sbt_DeptCode) + string.Format(",{0},{1},{2},{3})\n", (object) tsalesByTime.sbt_BoxCode, (object) tsalesByTime.sbt_GoodsCode, (object) tsalesByTime.sbt_Supplier, (object) tsalesByTime.sbt_KeySeq) + " 내용 : " + tsalesByTime.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsalesByTime.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "sbt_SiteID") && Convert.ToInt64(hashtable[(object) "sbt_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sbt_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sbt_SaleDate"))
        {
          stringBuilder.Append(" AND sbt_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "sbt_SaleDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sbt_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "sbt_SaleDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "sbt_SaleDate_BEGIN_") && hashtable.ContainsKey((object) "sbt_SaleDate_END_"))
        {
          stringBuilder.Append(" AND sbt_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "sbt_SaleDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sbt_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "sbt_SaleDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "sbt_StoreCode") && Convert.ToInt32(hashtable[(object) "sbt_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_StoreCode", hashtable[(object) "sbt_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbt_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "sbt_StoreCode_IN_") && hashtable[(object) "sbt_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "sbt_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbt_StoreCode", hashtable[(object) "sbt_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_StoreCode", hashtable[(object) "sbt_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbt_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "sbt_BoxCode") && Convert.ToInt64(hashtable[(object) "sbt_BoxCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_BoxCode", hashtable[(object) "sbt_BoxCode"]));
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_GoodsCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "sbt_GoodsCode") && Convert.ToInt64(hashtable[(object) "sbt_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_GoodsCode", hashtable[(object) "sbt_GoodsCode"]));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "sbt_Supplier") && Convert.ToInt32(hashtable[(object) "sbt_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_Supplier", hashtable[(object) "sbt_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbt_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "sbt_Supplier_IN_") && hashtable[(object) "sbt_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "sbt_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbt_Supplier", hashtable[(object) "sbt_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_Supplier", hashtable[(object) "sbt_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbt_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "sbt_CategoryCode") && Convert.ToInt32(hashtable[(object) "sbt_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_CategoryCode", hashtable[(object) "sbt_CategoryCode"]));
        if (hashtable.ContainsKey((object) "sbt_DeptCode") && Convert.ToInt32(hashtable[(object) "sbt_DeptCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_DeptCode", hashtable[(object) "sbt_DeptCode"]));
        if (hashtable.ContainsKey((object) "sbt_KeySeq") && Convert.ToInt32(hashtable[(object) "sbt_KeySeq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_KeySeq", hashtable[(object) "sbt_KeySeq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbt_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniSales = UbModelBase.UNI_SALES;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniSales = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  sbt_SaleDate,sbt_StoreCode,sbt_CategoryCode,sbt_DeptCode,sbt_BoxCode,sbt_GoodsCode,sbt_Supplier,sbt_KeySeq,sbt_SiteID,sbt_DayOfWeek,sbt_WeekOfYear,sbt_DayOfYear");
        for (int index = 0; index < 24; ++index)
          stringBuilder.Append(string.Format(",{0}{1:00}", (object) "sbt_SaleAmt", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_BoxQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SaleQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SlipCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index));
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniSales) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------" + string.Format("\n{0}", (object) stringBuilder) + "\n--------------------------------------------------------------------------------------------------");
      return stringBuilder.ToString();
    }
  }
}
