// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy.ProfitLossSummaryGoodsByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy
{
  public class ProfitLossSummaryGoodsByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, ProfitLossSummaryGoodsByStore>,
    IEnumerable<KeyValuePair<string, ProfitLossSummaryGoodsByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, ProfitLossSummaryGoodsByStore>>
  {
    private Dictionary<string, ProfitLossSummaryGoodsByStore> _Source = new Dictionary<string, ProfitLossSummaryGoodsByStore>();

    public IReadOnlyDictionary<string, ProfitLossSummaryGoodsByStore> Source => (IReadOnlyDictionary<string, ProfitLossSummaryGoodsByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<ProfitLossSummaryGoodsByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public ProfitLossSummaryGoodsByStore this[string key]
    {
      get
      {
        ProfitLossSummaryGoodsByStore summaryGoodsByStore;
        return !this.Source.TryGetValue(key, out summaryGoodsByStore) ? (ProfitLossSummaryGoodsByStore) null : summaryGoodsByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(ProfitLossSummaryGoodsByStore pData, IList<StoreInfoView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out ProfitLossSummaryGoodsByStore _))
        return;
      ProfitLossSummaryGoodsByStore summaryGoodsByStore = new ProfitLossSummaryGoodsByStore();
      summaryGoodsByStore.pls_GoodsCode = pData.pls_GoodsCode;
      this._Source.Add(pData.KeyCode, summaryGoodsByStore);
      summaryGoodsByStore.InitInfo(pData, p_Header);
    }

    public void Add(ProfitLossSummaryGoodsByStore info)
    {
      ProfitLossSummaryGoodsByStore summaryGoodsByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out summaryGoodsByStore))
      {
        summaryGoodsByStore = new ProfitLossSummaryGoodsByStore();
        summaryGoodsByStore.pls_GoodsCode = info.pls_GoodsCode;
        this._Source.Add(info.KeyCode, summaryGoodsByStore);
      }
      summaryGoodsByStore?.Add(info);
    }

    public void AddRange(IEnumerable<ProfitLossSummaryGoodsByStore> infos)
    {
      foreach (ProfitLossSummaryGoodsByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, ProfitLossSummaryGoodsByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out ProfitLossSummaryGoodsByStore value) => this.Source.TryGetValue(key, out value);
  }
}
