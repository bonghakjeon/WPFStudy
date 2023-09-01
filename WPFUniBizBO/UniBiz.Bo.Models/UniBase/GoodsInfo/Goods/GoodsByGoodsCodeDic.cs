// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.Goods.GoodsByGoodsCodeDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.Goods
{
  public class GoodsByGoodsCodeDic : 
    BindableBase,
    IReadOnlyDictionary<long, GoodsByGoodsCode>,
    IEnumerable<KeyValuePair<long, GoodsByGoodsCode>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, GoodsByGoodsCode>>
  {
    private Dictionary<long, GoodsByGoodsCode> _Source = new Dictionary<long, GoodsByGoodsCode>();

    public IReadOnlyDictionary<long, GoodsByGoodsCode> Source => (IReadOnlyDictionary<long, GoodsByGoodsCode>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<GoodsByGoodsCode> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public GoodsByGoodsCode this[long key]
    {
      get
      {
        GoodsByGoodsCode goodsByGoodsCode;
        return !this.Source.TryGetValue(key, out goodsByGoodsCode) ? (GoodsByGoodsCode) null : goodsByGoodsCode;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(GoodsView info)
    {
      GoodsByGoodsCode goodsByGoodsCode;
      if (!this._Source.TryGetValue(info.gd_GoodsCode, out goodsByGoodsCode))
      {
        goodsByGoodsCode = new GoodsByGoodsCode(info.gd_GoodsCode);
        this._Source.Add(info.gd_GoodsCode, goodsByGoodsCode);
      }
      goodsByGoodsCode?.Add(info);
    }

    public void AddRange(IEnumerable<GoodsView> infos)
    {
      foreach (GoodsView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, GoodsByGoodsCode>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out GoodsByGoodsCode value) => this.Source.TryGetValue(key, out value);
  }
}
