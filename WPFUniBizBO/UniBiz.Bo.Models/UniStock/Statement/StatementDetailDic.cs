// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementDetailDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementDetailDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDetailView>,
    IEnumerable<KeyValuePair<string, StatementDetailView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDetailView>>
  {
    private Dictionary<string, StatementDetailView> _Source = new Dictionary<string, StatementDetailView>();

    public IReadOnlyDictionary<string, StatementDetailView> Source => (IReadOnlyDictionary<string, StatementDetailView>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDetailView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDetailView this[string key]
    {
      get
      {
        StatementDetailView statementDetailView;
        return !this.Source.TryGetValue(key, out statementDetailView) ? (StatementDetailView) null : statementDetailView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void AddOrigin(StatementDetailView info)
    {
      if (this._Source.TryGetValue(info.DicKeyString, out StatementDetailView _))
        return;
      this._Source.Add(info.DicKeyString, info);
    }

    public void AddRangeOrigin(IEnumerable<StatementDetailView> infos)
    {
      foreach (StatementDetailView info in infos)
        this.AddOrigin(info);
    }

    public void AddRangeOrigin(IList<StatementDetailView> pInfos)
    {
      foreach (StatementDetailView pInfo in (IEnumerable<StatementDetailView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(string pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<string, StatementDetailView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string pKey, [MaybeNullWhen(false)] out StatementDetailView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
