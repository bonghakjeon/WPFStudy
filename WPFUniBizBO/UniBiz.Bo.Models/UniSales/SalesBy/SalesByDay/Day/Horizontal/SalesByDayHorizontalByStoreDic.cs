// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal
{
  public class SalesByDayHorizontalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByStore>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByStore>>
  {
    private Dictionary<string, SalesByDayHorizontalByStore> _Source = new Dictionary<string, SalesByDayHorizontalByStore>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByStore> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByStore this[string key]
    {
      get
      {
        SalesByDayHorizontalByStore horizontalByStore;
        return !this.Source.TryGetValue(key, out horizontalByStore) ? (SalesByDayHorizontalByStore) null : horizontalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByStore pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByStore _))
        return;
      SalesByDayHorizontalByStore horizontalByStore = new SalesByDayHorizontalByStore();
      horizontalByStore.si_StoreCode = pData.sbd_StoreCode;
      this._Source.Add(pData.KeyCode, horizontalByStore);
      horizontalByStore.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalByStore info)
    {
      SalesByDayHorizontalByStore horizontalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByStore))
      {
        horizontalByStore = new SalesByDayHorizontalByStore();
        horizontalByStore.si_StoreCode = info.sbd_StoreCode;
        this._Source.Add(info.KeyCode, horizontalByStore);
      }
      horizontalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByDayHorizontalByStore> infos)
    {
      foreach (SalesByDayHorizontalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
