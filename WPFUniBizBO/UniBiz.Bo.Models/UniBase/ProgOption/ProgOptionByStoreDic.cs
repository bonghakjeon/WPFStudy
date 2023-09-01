// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.ProgOptionByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgOption
{
  public class ProgOptionByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<int, ProgOptionByStore>,
    IEnumerable<KeyValuePair<int, ProgOptionByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, ProgOptionByStore>>
  {
    private Dictionary<int, ProgOptionByStore> _Source = new Dictionary<int, ProgOptionByStore>();

    public IReadOnlyDictionary<int, ProgOptionByStore> Source => (IReadOnlyDictionary<int, ProgOptionByStore>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<ProgOptionByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public ProgOptionByStore this[int key]
    {
      get
      {
        ProgOptionByStore progOptionByStore;
        return !this.Source.TryGetValue(key, out progOptionByStore) ? (ProgOptionByStore) null : progOptionByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(ProgOptionView info)
    {
      ProgOptionByStore progOptionByStore;
      if (!this._Source.TryGetValue(info.opt_StoreCode, out progOptionByStore))
      {
        progOptionByStore = new ProgOptionByStore(info.opt_StoreCode);
        this._Source.Add(info.opt_StoreCode, progOptionByStore);
      }
      progOptionByStore?.Add(info);
    }

    public void AddRange(IEnumerable<ProgOptionView> infos)
    {
      foreach (ProgOptionView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, ProgOptionByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out ProgOptionByStore value) => this.Source.TryGetValue(key, out value);
  }
}
