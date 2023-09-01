// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal
{
  public class StatementDayHorizontalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalByStore>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalByStore>>
  {
    private Dictionary<string, StatementDayHorizontalByStore> _Source = new Dictionary<string, StatementDayHorizontalByStore>();

    public IReadOnlyDictionary<string, StatementDayHorizontalByStore> Source => (IReadOnlyDictionary<string, StatementDayHorizontalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalByStore this[string key]
    {
      get
      {
        StatementDayHorizontalByStore horizontalByStore;
        return !this.Source.TryGetValue(key, out horizontalByStore) ? (StatementDayHorizontalByStore) null : horizontalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalByStore pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalByStore _))
        return;
      StatementDayHorizontalByStore horizontalByStore = new StatementDayHorizontalByStore();
      horizontalByStore.sh_StoreCode = pData.sh_StoreCode;
      this._Source.Add(pData.KeyCode, horizontalByStore);
      horizontalByStore.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalByStore info)
    {
      StatementDayHorizontalByStore horizontalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByStore))
      {
        horizontalByStore = new StatementDayHorizontalByStore();
        horizontalByStore.sh_StoreCode = info.sh_StoreCode;
        this._Source.Add(info.KeyCode, horizontalByStore);
      }
      horizontalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<StatementDayHorizontalByStore> infos)
    {
      foreach (StatementDayHorizontalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
