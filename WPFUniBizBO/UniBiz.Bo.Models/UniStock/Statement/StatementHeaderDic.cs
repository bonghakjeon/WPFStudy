// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementHeaderDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementHeaderDic : 
    BindableBase,
    IReadOnlyDictionary<long, StatementHeaderView>,
    IEnumerable<KeyValuePair<long, StatementHeaderView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, StatementHeaderView>>
  {
    private Dictionary<long, StatementHeaderView> _Source = new Dictionary<long, StatementHeaderView>();

    public IReadOnlyDictionary<long, StatementHeaderView> Source => (IReadOnlyDictionary<long, StatementHeaderView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<StatementHeaderView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementHeaderView this[long key]
    {
      get
      {
        StatementHeaderView statementHeaderView;
        return !this.Source.TryGetValue(key, out statementHeaderView) ? (StatementHeaderView) null : statementHeaderView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void AddOrigin(StatementHeaderView info)
    {
      if (this._Source.TryGetValue(info.sh_StatementNo, out StatementHeaderView _))
        return;
      this._Source.Add(info.sh_StatementNo, info);
    }

    public void AddRangeOrigin(IEnumerable<StatementHeaderView> infos)
    {
      foreach (StatementHeaderView info in infos)
        this.AddOrigin(info);
    }

    public void AddRangeOrigin(IList<StatementHeaderView> pInfos)
    {
      foreach (StatementHeaderView pInfo in (IEnumerable<StatementHeaderView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(long pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<long, StatementHeaderView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long pKey, [MaybeNullWhen(false)] out StatementHeaderView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
