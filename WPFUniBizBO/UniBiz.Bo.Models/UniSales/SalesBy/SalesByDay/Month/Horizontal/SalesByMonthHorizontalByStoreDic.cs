// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.SalesByMonthHorizontalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal
{
  public class SalesByMonthHorizontalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalByStore>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalByStore>>
  {
    private Dictionary<string, SalesByMonthHorizontalByStore> _Source = new Dictionary<string, SalesByMonthHorizontalByStore>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalByStore> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalByStore this[string key]
    {
      get
      {
        SalesByMonthHorizontalByStore horizontalByStore;
        return !this.Source.TryGetValue(key, out horizontalByStore) ? (SalesByMonthHorizontalByStore) null : horizontalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalByStore pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalByStore _))
        return;
      SalesByMonthHorizontalByStore horizontalByStore = new SalesByMonthHorizontalByStore();
      horizontalByStore.si_StoreCode = pData.sbd_StoreCode;
      this._Source.Add(pData.KeyCode, horizontalByStore);
      horizontalByStore.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalByStore info)
    {
      SalesByMonthHorizontalByStore horizontalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByStore))
      {
        horizontalByStore = new SalesByMonthHorizontalByStore();
        horizontalByStore.si_StoreCode = info.sbd_StoreCode;
        this._Source.Add(info.KeyCode, horizontalByStore);
      }
      horizontalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByMonthHorizontalByStore> infos)
    {
      foreach (SalesByMonthHorizontalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
