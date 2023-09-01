// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByStore>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByStore>>
  {
    private Dictionary<string, SaleByDayVerticalByStore> _Source = new Dictionary<string, SaleByDayVerticalByStore>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByStore> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByStore this[string key]
    {
      get
      {
        SaleByDayVerticalByStore dayVerticalByStore;
        return !this.Source.TryGetValue(key, out dayVerticalByStore) ? (SaleByDayVerticalByStore) null : dayVerticalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByStore pData, IList<StoreInfoView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByStore _))
        return;
      SaleByDayVerticalByStore dayVerticalByStore = new SaleByDayVerticalByStore();
      dayVerticalByStore.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, dayVerticalByStore);
      dayVerticalByStore.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByStore info)
    {
      SaleByDayVerticalByStore dayVerticalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByStore))
      {
        dayVerticalByStore = new SaleByDayVerticalByStore();
        dayVerticalByStore.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, dayVerticalByStore);
      }
      dayVerticalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByStore> infos)
    {
      foreach (SaleByDayVerticalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
