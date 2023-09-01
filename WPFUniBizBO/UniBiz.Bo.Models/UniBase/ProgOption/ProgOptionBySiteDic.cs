// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.ProgOptionBySiteDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgOption
{
  public class ProgOptionBySiteDic : 
    BindableBase,
    IReadOnlyDictionary<long, ProgOptionByStoreDic>,
    IEnumerable<KeyValuePair<long, ProgOptionByStoreDic>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, ProgOptionByStoreDic>>
  {
    private Dictionary<long, ProgOptionByStoreDic> _Source = new Dictionary<long, ProgOptionByStoreDic>();

    public IReadOnlyDictionary<long, ProgOptionByStoreDic> Source => (IReadOnlyDictionary<long, ProgOptionByStoreDic>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<ProgOptionByStoreDic> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public ProgOptionByStoreDic this[long key]
    {
      get
      {
        ProgOptionByStoreDic optionByStoreDic;
        return !this.Source.TryGetValue(key, out optionByStoreDic) ? (ProgOptionByStoreDic) null : optionByStoreDic;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(ProgOptionView info)
    {
      ProgOptionByStoreDic optionByStoreDic1;
      if (!this._Source.TryGetValue(info.opt_SiteID, out optionByStoreDic1))
      {
        optionByStoreDic1 = new ProgOptionByStoreDic();
        optionByStoreDic1.Add(info);
        this._Source.Add(info.opt_SiteID, optionByStoreDic1);
      }
      if (optionByStoreDic1 == null)
        return;
      ProgOptionByStoreDic optionByStoreDic2 = optionByStoreDic1;
      if (!optionByStoreDic2.ContainsKey(info.opt_StoreCode))
        optionByStoreDic2.Add(info);
      optionByStoreDic2[info.opt_StoreCode].Add(info);
    }

    public void AddRange(IEnumerable<ProgOptionView> infos)
    {
      foreach (ProgOptionView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, ProgOptionByStoreDic>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out ProgOptionByStoreDic value) => this.Source.TryGetValue(key, out value);
  }
}
