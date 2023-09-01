// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical.SaleByTimeDateVerticalByHour
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical
{
  public class SaleByTimeDateVerticalByHour : 
    BindableBase,
    ICollection<SaleByTimeDateVertical>,
    IEnumerable<SaleByTimeDateVertical>,
    IEnumerable
  {
    private List<SaleByTimeDateVertical> _Items;

    public List<SaleByTimeDateVertical> Items
    {
      get => this._Items ?? (this._Items = new List<SaleByTimeDateVertical>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int Hour { get; set; }

    public bool IsHour24 { get; set; }

    public bool IsReadOnly { get; }

    public SaleByTimeDateVerticalByHour(int p_Hour, bool p_IsHour24 = true)
    {
      this.Hour = p_Hour;
      this.IsHour24 = p_IsHour24;
      this.Items = new List<SaleByTimeDateVertical>();
    }

    public SaleByTimeDateVerticalByHour(
      int p_Hour,
      IEnumerable<SaleByTimeDateVertical> items,
      bool p_IsHour24 = true)
      : this(p_Hour, p_IsHour24)
    {
      this.Items.AddRange(items);
    }

    public SaleByTimeDateVertical this[int p_Hour] => this.FirstOrDefault<SaleByTimeDateVertical>((Func<SaleByTimeDateVertical, bool>) (it => it.sbt_Time == p_Hour));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (SaleByTimeDateVerticalByHour), (object) this.Hour, (object) this.Count);

    public IEnumerator<SaleByTimeDateVertical> GetEnumerator() => (IEnumerator<SaleByTimeDateVertical>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(SaleByTimeDateVertical item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(SaleByTimeDateVertical item) => this.Items.Contains(item);

    public void CopyTo(SaleByTimeDateVertical[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(SaleByTimeDateVertical item) => this.Items.Remove(item);
  }
}
