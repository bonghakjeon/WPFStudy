// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical.SaleByTimeDateVertical
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical
{
  public class SaleByTimeDateVertical : UbModelBase<SaleByTimeDateVertical>
  {
    private int _rowDataType;
    private int _sbt_Time;
    private string _sbt_CodeKey;
    private double _sbt_SaleAmt;
    private double _sbt_BoxQty;
    private double _sbt_SaleQty;
    private double _sbt_SlipCustomer;
    private double _sbt_CategoryCustomer;
    private double _sbt_GoodsCustomer;
    private double _sbt_SupplierCustomer;
    private IList<SaleByTimeDateVertical> _Lt_Details;

    public override object _Key => (object) new object[2]
    {
      (object) this.sbt_Time,
      (object) this.sbt_CodeKey
    };

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    public int sbt_Time
    {
      get => this._sbt_Time;
      set
      {
        this._sbt_Time = value;
        this.Changed(nameof (sbt_Time));
      }
    }

    public string sbt_CodeKey
    {
      get => this._sbt_CodeKey;
      set
      {
        this._sbt_CodeKey = value;
        this.Changed(nameof (sbt_CodeKey));
      }
    }

    public double sbt_SaleAmt
    {
      get => this._sbt_SaleAmt;
      set
      {
        this._sbt_SaleAmt = value;
        this.Changed(nameof (sbt_SaleAmt));
      }
    }

    public double sbt_BoxQty
    {
      get => this._sbt_BoxQty;
      set
      {
        this._sbt_BoxQty = value;
        this.Changed(nameof (sbt_BoxQty));
      }
    }

    public double sbt_SaleQty
    {
      get => this._sbt_SaleQty;
      set
      {
        this._sbt_SaleQty = value;
        this.Changed(nameof (sbt_SaleQty));
      }
    }

    public double sbt_SlipCustomer
    {
      get => this._sbt_SlipCustomer;
      set
      {
        this._sbt_SlipCustomer = value;
        this.Changed(nameof (sbt_SlipCustomer));
      }
    }

    public double sbt_CategoryCustomer
    {
      get => this._sbt_CategoryCustomer;
      set
      {
        this._sbt_CategoryCustomer = value;
        this.Changed(nameof (sbt_CategoryCustomer));
      }
    }

    public double sbt_GoodsCustomer
    {
      get => this._sbt_GoodsCustomer;
      set
      {
        this._sbt_GoodsCustomer = value;
        this.Changed(nameof (sbt_GoodsCustomer));
      }
    }

    public double sbt_SupplierCustomer
    {
      get => this._sbt_SupplierCustomer;
      set
      {
        this._sbt_SupplierCustomer = value;
        this.Changed(nameof (sbt_SupplierCustomer));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<SaleByTimeDateVertical> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<SaleByTimeDateVertical>) new List<SaleByTimeDateVertical>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public SaleByTimeDateVertical() => this.Clear();

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SalesByTime;
      this.rowDataType = 1;
      this.sbt_Time = 0;
      this.sbt_CodeKey = string.Empty;
      this.sbt_SaleAmt = this.sbt_BoxQty = this.sbt_SaleQty = this.sbt_SlipCustomer = this.sbt_CategoryCustomer = this.sbt_GoodsCustomer = this.sbt_SupplierCustomer = 0.0;
      this.Lt_Details = (IList<SaleByTimeDateVertical>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SaleByTimeDateVertical();

    public override object Clone()
    {
      SaleByTimeDateVertical timeDateVertical = base.Clone() as SaleByTimeDateVertical;
      timeDateVertical.rowDataType = this.rowDataType;
      timeDateVertical.sbt_Time = this.sbt_Time;
      timeDateVertical.sbt_CodeKey = this.sbt_CodeKey;
      timeDateVertical.sbt_SaleAmt = this.sbt_SaleAmt;
      timeDateVertical.sbt_BoxQty = this.sbt_BoxQty;
      timeDateVertical.sbt_SaleQty = this.sbt_SaleQty;
      timeDateVertical.sbt_SlipCustomer = this.sbt_SlipCustomer;
      timeDateVertical.sbt_CategoryCustomer = this.sbt_CategoryCustomer;
      timeDateVertical.sbt_GoodsCustomer = this.sbt_GoodsCustomer;
      timeDateVertical.sbt_SupplierCustomer = this.sbt_SupplierCustomer;
      if (this.Lt_Details.Count > 0)
        timeDateVertical.Lt_Details = this.Lt_Details;
      return (object) timeDateVertical;
    }

    public void PutData(SaleByTimeDateVertical pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.rowDataType = pSource.rowDataType;
      this.sbt_Time = pSource.sbt_Time;
      this.sbt_CodeKey = pSource.sbt_CodeKey;
      this.sbt_SaleAmt = pSource.sbt_SaleAmt;
      this.sbt_BoxQty = pSource.sbt_BoxQty;
      this.sbt_SaleQty = pSource.sbt_SaleQty;
      this.sbt_SlipCustomer = pSource.sbt_SlipCustomer;
      this.sbt_CategoryCustomer = pSource.sbt_CategoryCustomer;
      this.sbt_GoodsCustomer = pSource.sbt_GoodsCustomer;
      this.sbt_SupplierCustomer = pSource.sbt_SupplierCustomer;
      this.Lt_Details = (IList<SaleByTimeDateVertical>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (SaleByTimeDateVertical ltDetail in (IEnumerable<SaleByTimeDateVertical>) pSource.Lt_Details)
      {
        SaleByTimeDateVertical timeDateVertical = new SaleByTimeDateVertical();
        timeDateVertical.PutData(ltDetail);
        pSource.Lt_Details.Add(timeDateVertical);
      }
    }
  }
}
