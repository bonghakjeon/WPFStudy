// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByTeamDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByTeam>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByTeam>>
  {
    private Dictionary<string, SaleByDayVerticalByTeam> _Source = new Dictionary<string, SaleByDayVerticalByTeam>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByTeam> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByTeam this[string key]
    {
      get
      {
        SaleByDayVerticalByTeam dayVerticalByTeam;
        return !this.Source.TryGetValue(key, out dayVerticalByTeam) ? (SaleByDayVerticalByTeam) null : dayVerticalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByTeam pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByTeam _))
        return;
      SaleByDayVerticalByTeam dayVerticalByTeam = new SaleByDayVerticalByTeam();
      dayVerticalByTeam.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, dayVerticalByTeam);
      dayVerticalByTeam.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByTeam info)
    {
      SaleByDayVerticalByTeam dayVerticalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByTeam))
      {
        dayVerticalByTeam = new SaleByDayVerticalByTeam();
        dayVerticalByTeam.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, dayVerticalByTeam);
      }
      dayVerticalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByTeam> infos)
    {
      foreach (SaleByDayVerticalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
