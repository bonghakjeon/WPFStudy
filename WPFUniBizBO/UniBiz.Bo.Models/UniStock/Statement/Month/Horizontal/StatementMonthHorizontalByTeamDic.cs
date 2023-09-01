// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.StatementMonthHorizontalByTeamDic
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
  public class StatementMonthHorizontalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalByTeam>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalByTeam>>
  {
    private Dictionary<string, StatementMonthHorizontalByTeam> _Source = new Dictionary<string, StatementMonthHorizontalByTeam>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalByTeam> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalByTeam this[string key]
    {
      get
      {
        StatementMonthHorizontalByTeam horizontalByTeam;
        return !this.Source.TryGetValue(key, out horizontalByTeam) ? (StatementMonthHorizontalByTeam) null : horizontalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalByTeam pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalByTeam _))
        return;
      StatementMonthHorizontalByTeam horizontalByTeam = new StatementMonthHorizontalByTeam();
      horizontalByTeam.sh_StoreCode = pData.sh_StoreCode;
      horizontalByTeam.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByTeam.dpt_lv2_ID = pData.dpt_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByTeam);
      horizontalByTeam.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalByTeam info)
    {
      StatementMonthHorizontalByTeam horizontalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByTeam))
      {
        horizontalByTeam = new StatementMonthHorizontalByTeam();
        horizontalByTeam.sh_StoreCode = info.sh_StoreCode;
        horizontalByTeam.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByTeam.dpt_lv2_ID = info.dpt_lv2_ID;
        this._Source.Add(info.KeyCode, horizontalByTeam);
      }
      horizontalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthHorizontalByTeam> infos)
    {
      foreach (StatementMonthHorizontalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
