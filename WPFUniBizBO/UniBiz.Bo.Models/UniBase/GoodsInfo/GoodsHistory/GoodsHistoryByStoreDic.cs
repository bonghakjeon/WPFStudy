// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory.GoodsHistoryByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory
{
  public class GoodsHistoryByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<int, GoodsHistoryByStore>,
    IEnumerable<KeyValuePair<int, GoodsHistoryByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, GoodsHistoryByStore>>
  {
    private Dictionary<int, GoodsHistoryByStore> _Source = new Dictionary<int, GoodsHistoryByStore>();

    public IReadOnlyDictionary<int, GoodsHistoryByStore> Source => (IReadOnlyDictionary<int, GoodsHistoryByStore>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<GoodsHistoryByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public GoodsHistoryByStore this[int key]
    {
      get
      {
        GoodsHistoryByStore goodsHistoryByStore;
        return !this.Source.TryGetValue(key, out goodsHistoryByStore) ? (GoodsHistoryByStore) null : goodsHistoryByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(GoodsHistoryView info)
    {
      GoodsHistoryByStore goodsHistoryByStore;
      if (!this._Source.TryGetValue(info.gdh_StoreCode, out goodsHistoryByStore))
      {
        goodsHistoryByStore = new GoodsHistoryByStore(info.gdh_StoreCode);
        this._Source.Add(info.gdh_StoreCode, goodsHistoryByStore);
      }
      goodsHistoryByStore?.Add(info);
    }

    public void AddRange(IEnumerable<GoodsHistoryView> infos)
    {
      foreach (GoodsHistoryView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, GoodsHistoryByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out GoodsHistoryByStore value) => this.Source.TryGetValue(key, out value);
  }
}
