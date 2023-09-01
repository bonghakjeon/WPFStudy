// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByStore>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByStore>>
  {
    private Dictionary<string, StatementMonthVerticalByStore> _Source = new Dictionary<string, StatementMonthVerticalByStore>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByStore> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByStore this[string key]
    {
      get
      {
        StatementMonthVerticalByStore monthVerticalByStore;
        return !this.Source.TryGetValue(key, out monthVerticalByStore) ? (StatementMonthVerticalByStore) null : monthVerticalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByStore pData, IList<StoreInfoView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByStore _))
        return;
      StatementMonthVerticalByStore monthVerticalByStore = new StatementMonthVerticalByStore();
      monthVerticalByStore.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, monthVerticalByStore);
      monthVerticalByStore.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByStore info)
    {
      StatementMonthVerticalByStore monthVerticalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByStore))
      {
        monthVerticalByStore = new StatementMonthVerticalByStore();
        monthVerticalByStore.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, monthVerticalByStore);
      }
      monthVerticalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthVerticalByStore> infos)
    {
      foreach (StatementMonthVerticalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
