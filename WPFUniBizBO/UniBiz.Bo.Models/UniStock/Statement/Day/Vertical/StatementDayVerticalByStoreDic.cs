// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByStore>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByStore>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByStore>>
  {
    private Dictionary<string, StatementDayVerticalByStore> _Source = new Dictionary<string, StatementDayVerticalByStore>();

    public IReadOnlyDictionary<string, StatementDayVerticalByStore> Source => (IReadOnlyDictionary<string, StatementDayVerticalByStore>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByStore> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByStore this[string key]
    {
      get
      {
        StatementDayVerticalByStore dayVerticalByStore;
        return !this.Source.TryGetValue(key, out dayVerticalByStore) ? (StatementDayVerticalByStore) null : dayVerticalByStore;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByStore pData, IList<StoreInfoView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByStore _))
        return;
      StatementDayVerticalByStore dayVerticalByStore = new StatementDayVerticalByStore();
      dayVerticalByStore.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, dayVerticalByStore);
      dayVerticalByStore.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByStore info)
    {
      StatementDayVerticalByStore dayVerticalByStore;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByStore))
      {
        dayVerticalByStore = new StatementDayVerticalByStore();
        dayVerticalByStore.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, dayVerticalByStore);
      }
      dayVerticalByStore?.Add(info);
    }

    public void AddRange(IEnumerable<StatementDayVerticalByStore> infos)
    {
      foreach (StatementDayVerticalByStore info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByStore>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByStore value) => this.Source.TryGetValue(key, out value);
  }
}
