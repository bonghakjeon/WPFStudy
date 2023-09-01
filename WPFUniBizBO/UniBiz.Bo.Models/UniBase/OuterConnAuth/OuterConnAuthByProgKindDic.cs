// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.OuterConnAuthByProgKindDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  public class OuterConnAuthByProgKindDic : 
    BindableBase,
    IReadOnlyDictionary<int, OuterConnAuthByProgKind>,
    IEnumerable<KeyValuePair<int, OuterConnAuthByProgKind>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, OuterConnAuthByProgKind>>
  {
    private Dictionary<int, OuterConnAuthByProgKind> _Source = new Dictionary<int, OuterConnAuthByProgKind>();

    public IReadOnlyDictionary<int, OuterConnAuthByProgKind> Source => (IReadOnlyDictionary<int, OuterConnAuthByProgKind>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<OuterConnAuthByProgKind> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public OuterConnAuthByProgKind this[int key]
    {
      get
      {
        OuterConnAuthByProgKind connAuthByProgKind;
        return !this.Source.TryGetValue(key, out connAuthByProgKind) ? (OuterConnAuthByProgKind) null : connAuthByProgKind;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(OuterConnAuthView info)
    {
      OuterConnAuthByProgKind connAuthByProgKind;
      if (!this._Source.TryGetValue(info.oca_ProgKind, out connAuthByProgKind))
      {
        connAuthByProgKind = new OuterConnAuthByProgKind(info.oca_ProgKind);
        this._Source.Add(info.oca_ProgKind, connAuthByProgKind);
      }
      connAuthByProgKind?.Add(info);
    }

    public void AddRange(IEnumerable<OuterConnAuthView> infos)
    {
      foreach (OuterConnAuthView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, OuterConnAuthByProgKind>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out OuterConnAuthByProgKind value) => this.Source.TryGetValue(key, out value);
  }
}
