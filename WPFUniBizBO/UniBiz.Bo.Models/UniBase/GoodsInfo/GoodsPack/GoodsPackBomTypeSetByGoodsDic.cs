// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack.GoodsPackBomTypeSetByGoodsDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack
{
  public class GoodsPackBomTypeSetByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<long, GoodsPackBomTypeSet>,
    IEnumerable<KeyValuePair<long, GoodsPackBomTypeSet>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, GoodsPackBomTypeSet>>
  {
    private Dictionary<long, GoodsPackBomTypeSet> _Source = new Dictionary<long, GoodsPackBomTypeSet>();

    public IReadOnlyDictionary<long, GoodsPackBomTypeSet> Source => (IReadOnlyDictionary<long, GoodsPackBomTypeSet>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<GoodsPackBomTypeSet> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public GoodsPackBomTypeSet this[long key]
    {
      get
      {
        GoodsPackBomTypeSet goodsPackBomTypeSet;
        return !this.Source.TryGetValue(key, out goodsPackBomTypeSet) ? (GoodsPackBomTypeSet) null : goodsPackBomTypeSet;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(GoodsPackBomTypeSet info)
    {
      GoodsPackBomTypeSet goodsPackBomTypeSet1;
      if (!this._Source.TryGetValue(info.gdp_GoodsCode, out goodsPackBomTypeSet1))
      {
        goodsPackBomTypeSet1 = new GoodsPackBomTypeSet();
        goodsPackBomTypeSet1.PutData(info);
        goodsPackBomTypeSet1.gdh_BuyCost = 0.0;
        goodsPackBomTypeSet1.gdh_EventCost = 0.0;
        goodsPackBomTypeSet1.gdh_SalePrice = 0.0;
        goodsPackBomTypeSet1.gdh_EventPrice = 0.0;
        this._Source.Add(info.gdp_GoodsCode, goodsPackBomTypeSet1);
      }
      if (goodsPackBomTypeSet1 == null)
        return;
      GoodsPackBomTypeSet goodsPackBomTypeSet2 = goodsPackBomTypeSet1;
      info.row_number = goodsPackBomTypeSet2.Lt_Details.Count + 1;
      goodsPackBomTypeSet2.Lt_Details.Add(info);
    }

    public void AddRange(IEnumerable<GoodsPackBomTypeSet> infos)
    {
      foreach (GoodsPackBomTypeSet info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, GoodsPackBomTypeSet>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out GoodsPackBomTypeSet value) => this.Source.TryGetValue(key, out value);
  }
}
