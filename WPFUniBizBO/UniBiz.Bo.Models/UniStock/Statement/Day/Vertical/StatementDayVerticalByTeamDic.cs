// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByTeamDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByTeam>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByTeam>>
  {
    private Dictionary<string, StatementDayVerticalByTeam> _Source = new Dictionary<string, StatementDayVerticalByTeam>();

    public IReadOnlyDictionary<string, StatementDayVerticalByTeam> Source => (IReadOnlyDictionary<string, StatementDayVerticalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByTeam this[string key]
    {
      get
      {
        StatementDayVerticalByTeam dayVerticalByTeam;
        return !this.Source.TryGetValue(key, out dayVerticalByTeam) ? (StatementDayVerticalByTeam) null : dayVerticalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByTeam pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByTeam _))
        return;
      StatementDayVerticalByTeam dayVerticalByTeam = new StatementDayVerticalByTeam();
      dayVerticalByTeam.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, dayVerticalByTeam);
      dayVerticalByTeam.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByTeam info)
    {
      StatementDayVerticalByTeam dayVerticalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByTeam))
      {
        dayVerticalByTeam = new StatementDayVerticalByTeam();
        dayVerticalByTeam.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, dayVerticalByTeam);
      }
      dayVerticalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<StatementDayVerticalByTeam> infos)
    {
      foreach (StatementDayVerticalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
