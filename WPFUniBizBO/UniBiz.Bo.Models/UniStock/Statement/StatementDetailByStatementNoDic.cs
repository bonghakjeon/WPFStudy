// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementDetailByStatementNoDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementDetailByStatementNoDic : 
    BindableBase,
    IReadOnlyDictionary<long, StatementDetailView>,
    IEnumerable<KeyValuePair<long, StatementDetailView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, StatementDetailView>>
  {
    private Dictionary<long, StatementDetailView> _Source = new Dictionary<long, StatementDetailView>();

    public IReadOnlyDictionary<long, StatementDetailView> Source => (IReadOnlyDictionary<long, StatementDetailView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<StatementDetailView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDetailView this[long key]
    {
      get
      {
        StatementDetailView statementDetailView;
        return !this.Source.TryGetValue(key, out statementDetailView) ? (StatementDetailView) null : statementDetailView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(StatementDetailView info)
    {
      StatementDetailView statementDetailView;
      if (!this._Source.TryGetValue(info.sd_StatementNo, out statementDetailView))
      {
        statementDetailView = new StatementDetailView();
        statementDetailView.sd_StatementNo = info.sd_StatementNo;
        this._Source.Add(info.sd_StatementNo, statementDetailView);
      }
      statementDetailView?.Lt_History.Add(info);
    }

    public void AddRange(IEnumerable<StatementDetailView> infos)
    {
      foreach (StatementDetailView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, StatementDetailView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out StatementDetailView value) => this.Source.TryGetValue(key, out value);
  }
}
