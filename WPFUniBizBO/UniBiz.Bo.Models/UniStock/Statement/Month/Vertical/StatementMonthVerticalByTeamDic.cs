// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByTeamDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByTeam>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByTeam>>
  {
    private Dictionary<string, StatementMonthVerticalByTeam> _Source = new Dictionary<string, StatementMonthVerticalByTeam>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByTeam> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByTeam this[string key]
    {
      get
      {
        StatementMonthVerticalByTeam monthVerticalByTeam;
        return !this.Source.TryGetValue(key, out monthVerticalByTeam) ? (StatementMonthVerticalByTeam) null : monthVerticalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByTeam pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByTeam _))
        return;
      StatementMonthVerticalByTeam monthVerticalByTeam = new StatementMonthVerticalByTeam();
      monthVerticalByTeam.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, monthVerticalByTeam);
      monthVerticalByTeam.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByTeam info)
    {
      StatementMonthVerticalByTeam monthVerticalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByTeam))
      {
        monthVerticalByTeam = new StatementMonthVerticalByTeam();
        monthVerticalByTeam.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, monthVerticalByTeam);
      }
      monthVerticalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthVerticalByTeam> infos)
    {
      foreach (StatementMonthVerticalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
