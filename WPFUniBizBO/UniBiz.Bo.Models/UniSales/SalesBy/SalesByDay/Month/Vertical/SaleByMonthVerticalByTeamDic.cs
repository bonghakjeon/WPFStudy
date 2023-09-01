// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByTeamDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByTeam>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByTeam>>
  {
    private Dictionary<string, SaleByMonthVerticalByTeam> _Source = new Dictionary<string, SaleByMonthVerticalByTeam>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByTeam> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByTeam this[string key]
    {
      get
      {
        SaleByMonthVerticalByTeam monthVerticalByTeam;
        return !this.Source.TryGetValue(key, out monthVerticalByTeam) ? (SaleByMonthVerticalByTeam) null : monthVerticalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByTeam pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByTeam _))
        return;
      SaleByMonthVerticalByTeam monthVerticalByTeam = new SaleByMonthVerticalByTeam();
      monthVerticalByTeam.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, monthVerticalByTeam);
      monthVerticalByTeam.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByTeam info)
    {
      SaleByMonthVerticalByTeam monthVerticalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByTeam))
      {
        monthVerticalByTeam = new SaleByMonthVerticalByTeam();
        monthVerticalByTeam.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, monthVerticalByTeam);
      }
      monthVerticalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByMonthVerticalByTeam> infos)
    {
      foreach (SaleByMonthVerticalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
