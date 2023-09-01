// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.ProgOptionGroupDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgOption
{
  public class ProgOptionGroupDic : 
    BindableBase,
    IReadOnlyDictionary<int, ProgOptionGroup>,
    IEnumerable<KeyValuePair<int, ProgOptionGroup>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, ProgOptionGroup>>
  {
    private Dictionary<int, ProgOptionGroup> _Source = new Dictionary<int, ProgOptionGroup>();

    public IReadOnlyDictionary<int, ProgOptionGroup> Source => (IReadOnlyDictionary<int, ProgOptionGroup>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<ProgOptionGroup> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public ProgOptionGroup this[int key]
    {
      get
      {
        ProgOptionGroup progOptionGroup;
        return !this.Source.TryGetValue(key, out progOptionGroup) ? (ProgOptionGroup) null : progOptionGroup;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(ProgOptionView info)
    {
      ProgOptionGroup progOptionGroup;
      if (!this._Source.TryGetValue(info.opt_Code, out progOptionGroup))
      {
        progOptionGroup = new ProgOptionGroup(info.opt_Code);
        this._Source.Add(info.opt_Code, progOptionGroup);
      }
      progOptionGroup?.Add(info);
    }

    public void AddRange(IEnumerable<ProgOptionView> infos)
    {
      foreach (ProgOptionView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, ProgOptionGroup>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out ProgOptionGroup value) => this.Source.TryGetValue(key, out value);
  }
}
