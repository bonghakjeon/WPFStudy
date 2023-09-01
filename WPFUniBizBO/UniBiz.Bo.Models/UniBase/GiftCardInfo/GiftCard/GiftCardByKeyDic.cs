// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard.GiftCardByKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard
{
  public class GiftCardByKeyDic : 
    BindableBase,
    IReadOnlyDictionary<long, GiftCardView>,
    IEnumerable<KeyValuePair<long, GiftCardView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, GiftCardView>>
  {
    private Dictionary<long, GiftCardView> _Source = new Dictionary<long, GiftCardView>();

    public IReadOnlyDictionary<long, GiftCardView> Source => (IReadOnlyDictionary<long, GiftCardView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<GiftCardView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public GiftCardView this[long pKey]
    {
      get
      {
        GiftCardView giftCardView;
        return !this.Source.TryGetValue(pKey, out giftCardView) ? (GiftCardView) null : giftCardView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(GiftCardView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.gc_GiftCardID, out GiftCardView _))
        return;
      GiftCardView giftCardView = new GiftCardView();
      this._Source.Add(pInfo.gc_GiftCardID, giftCardView);
    }

    public void AddOrigin(GiftCardView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.gc_GiftCardID, out GiftCardView _))
        return;
      GiftCardView giftCardView = pInfo;
      this._Source.Add(pInfo.gc_GiftCardID, giftCardView);
    }

    public void AddRange(IEnumerable<GiftCardView> pInfos)
    {
      foreach (GiftCardView pInfo in pInfos)
        this.Add(pInfo);
    }

    public void AddRange(IList<GiftCardView> pInfos)
    {
      foreach (GiftCardView pInfo in (IEnumerable<GiftCardView>) pInfos)
        this.Add(pInfo);
    }

    public void AddRangeOrigin(IEnumerable<GiftCardView> pInfos)
    {
      foreach (GiftCardView pInfo in pInfos)
        this.AddOrigin(pInfo);
    }

    public void AddRangeOrigin(IList<GiftCardView> pInfos)
    {
      foreach (GiftCardView pInfo in (IEnumerable<GiftCardView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(long pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<long, GiftCardView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long pKey, [MaybeNullWhen(false)] out GiftCardView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
