﻿// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier.SalesByMonthHorizontalBySupplierDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier
{
  public class SalesByMonthHorizontalBySupplierDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplier>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalBySupplier>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalBySupplier>>
  {
    private Dictionary<string, SalesByMonthHorizontalBySupplier> _Source = new Dictionary<string, SalesByMonthHorizontalBySupplier>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplier> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplier>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalBySupplier> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalBySupplier this[string key]
    {
      get
      {
        SalesByMonthHorizontalBySupplier horizontalBySupplier;
        return !this.Source.TryGetValue(key, out horizontalBySupplier) ? (SalesByMonthHorizontalBySupplier) null : horizontalBySupplier;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalBySupplier pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalBySupplier _))
        return;
      SalesByMonthHorizontalBySupplier horizontalBySupplier = new SalesByMonthHorizontalBySupplier();
      horizontalBySupplier.si_StoreCode = pData.sbd_StoreCode;
      horizontalBySupplier.sbd_Supplier = pData.sbd_Supplier;
      this._Source.Add(pData.KeyCode, horizontalBySupplier);
      horizontalBySupplier.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalBySupplier info)
    {
      SalesByMonthHorizontalBySupplier horizontalBySupplier;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalBySupplier))
      {
        horizontalBySupplier = new SalesByMonthHorizontalBySupplier();
        horizontalBySupplier.si_StoreCode = info.sbd_StoreCode;
        horizontalBySupplier.sbd_Supplier = info.sbd_Supplier;
        this._Source.Add(info.KeyCode, horizontalBySupplier);
      }
      horizontalBySupplier?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByMonthHorizontalBySupplier> infos)
    {
      foreach (SalesByMonthHorizontalBySupplier info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalBySupplier>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalBySupplier value) => this.Source.TryGetValue(key, out value);
  }
}
