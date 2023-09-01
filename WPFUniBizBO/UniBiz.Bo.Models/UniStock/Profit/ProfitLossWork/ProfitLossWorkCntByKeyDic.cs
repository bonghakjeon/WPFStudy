// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.ProfitLossWorkCntByKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class ProfitLossWorkCntByKeyDic : 
    BindableBase,
    IReadOnlyDictionary<string, ProfitLossWorkCntView>,
    IEnumerable<KeyValuePair<string, ProfitLossWorkCntView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, ProfitLossWorkCntView>>
  {
    private Dictionary<string, ProfitLossWorkCntView> _Source = new Dictionary<string, ProfitLossWorkCntView>();

    public IReadOnlyDictionary<string, ProfitLossWorkCntView> Source => (IReadOnlyDictionary<string, ProfitLossWorkCntView>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<ProfitLossWorkCntView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public ProfitLossWorkCntView this[string key]
    {
      get
      {
        ProfitLossWorkCntView profitLossWorkCntView;
        return !this.Source.TryGetValue(key, out profitLossWorkCntView) ? (ProfitLossWorkCntView) null : profitLossWorkCntView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(ProfitLossWorkCntView info)
    {
      if (this._Source.TryGetValue(info._dic_Key, out ProfitLossWorkCntView _))
        return;
      ProfitLossWorkCntView profitLossWorkCntView = new ProfitLossWorkCntView();
      this._Source.Add(info._dic_Key, profitLossWorkCntView);
    }

    public void AddRange(IEnumerable<ProfitLossWorkCntView> infos)
    {
      foreach (ProfitLossWorkCntView info in infos)
        this.Add(info);
    }

    public void AddOrigin(ProfitLossWorkCntView info)
    {
      if (this._Source.TryGetValue(info._dic_Key, out ProfitLossWorkCntView _))
        return;
      ProfitLossWorkCntView profitLossWorkCntView = info;
      this._Source.Add(info._dic_Key, profitLossWorkCntView);
    }

    public void AddOriginRange(IEnumerable<ProfitLossWorkCntView> infos)
    {
      foreach (ProfitLossWorkCntView info in infos)
        this.Add(info);
    }

    public void AddOriginRange(IList<ProfitLossWorkCntView> infos)
    {
      foreach (ProfitLossWorkCntView info in (IEnumerable<ProfitLossWorkCntView>) infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, ProfitLossWorkCntView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out ProfitLossWorkCntView value) => this.Source.TryGetValue(key, out value);
  }
}
