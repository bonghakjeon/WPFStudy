// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByStore>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByStore>>
  {
    private Dictionary<string, SaleByMonthVerticalByStore> _Source = new Dictionary<string, SaleByMonthVerticalByStore>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByStore> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByStore this[string key]
    {
      get
      {
        SaleByMonthVerticalByStore monthVerticalByStore;
        return !this.Source.TryGetValue(key, out monthVerticalByStore) ? (SaleByMonthVerticalByStore) null : monthVerticalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByStore pData, IList<StoreInfoView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByStore _))
        return;
      SaleByMonthVerticalByStore monthVerticalByStore = new SaleByMonthVerticalByStore();
      monthVerticalByStore.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, monthVerticalByStore);
      monthVerticalByStore.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByStore info)
    {
      SaleByMonthVerticalByStore monthVerticalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByStore))
      {
        monthVerticalByStore = new SaleByMonthVerticalByStore();
        monthVerticalByStore.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, monthVerticalByStore);
      }
      monthVerticalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByMonthVerticalByStore> infos)
    {
      foreach (SaleByMonthVerticalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
