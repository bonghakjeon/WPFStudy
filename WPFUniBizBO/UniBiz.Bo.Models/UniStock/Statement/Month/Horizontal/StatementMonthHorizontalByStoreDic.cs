// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.StatementMonthHorizontalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal
{
  public class StatementMonthHorizontalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalByStore>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalByStore>>
  {
    private Dictionary<string, StatementMonthHorizontalByStore> _Source = new Dictionary<string, StatementMonthHorizontalByStore>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalByStore> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalByStore this[string key]
    {
      get
      {
        StatementMonthHorizontalByStore horizontalByStore;
        return !this.Source.TryGetValue(key, out horizontalByStore) ? (StatementMonthHorizontalByStore) null : horizontalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalByStore pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalByStore _))
        return;
      StatementMonthHorizontalByStore horizontalByStore = new StatementMonthHorizontalByStore();
      horizontalByStore.sh_StoreCode = pData.sh_StoreCode;
      this._Source.Add(pData.KeyCode, horizontalByStore);
      horizontalByStore.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalByStore info)
    {
      StatementMonthHorizontalByStore horizontalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByStore))
      {
        horizontalByStore = new StatementMonthHorizontalByStore();
        horizontalByStore.sh_StoreCode = info.sh_StoreCode;
        this._Source.Add(info.KeyCode, horizontalByStore);
      }
      horizontalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthHorizontalByStore> infos)
    {
      foreach (StatementMonthHorizontalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
