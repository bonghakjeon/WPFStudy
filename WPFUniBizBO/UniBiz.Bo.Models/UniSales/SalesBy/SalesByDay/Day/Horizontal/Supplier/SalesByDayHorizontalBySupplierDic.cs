// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier.SalesByDayHorizontalBySupplierDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier
{
  public class SalesByDayHorizontalBySupplierDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalBySupplier>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalBySupplier>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalBySupplier>>
  {
    private Dictionary<string, SalesByDayHorizontalBySupplier> _Source = new Dictionary<string, SalesByDayHorizontalBySupplier>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalBySupplier> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalBySupplier>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalBySupplier> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalBySupplier this[string key]
    {
      get
      {
        SalesByDayHorizontalBySupplier horizontalBySupplier;
        return !this.Source.TryGetValue(key, out horizontalBySupplier) ? (SalesByDayHorizontalBySupplier) null : horizontalBySupplier;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalBySupplier pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalBySupplier _))
        return;
      SalesByDayHorizontalBySupplier horizontalBySupplier = new SalesByDayHorizontalBySupplier();
      horizontalBySupplier.si_StoreCode = pData.sbd_StoreCode;
      horizontalBySupplier.sbd_Supplier = pData.sbd_Supplier;
      this._Source.Add(pData.KeyCode, horizontalBySupplier);
      horizontalBySupplier.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalBySupplier info)
    {
      SalesByDayHorizontalBySupplier horizontalBySupplier;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalBySupplier))
      {
        horizontalBySupplier = new SalesByDayHorizontalBySupplier();
        horizontalBySupplier.si_StoreCode = info.sbd_StoreCode;
        horizontalBySupplier.sbd_Supplier = info.sbd_Supplier;
        this._Source.Add(info.KeyCode, horizontalBySupplier);
      }
      horizontalBySupplier?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByDayHorizontalBySupplier> infos)
    {
      foreach (SalesByDayHorizontalBySupplier info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalBySupplier>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalBySupplier value) => this.Source.TryGetValue(key, out value);
  }
}
