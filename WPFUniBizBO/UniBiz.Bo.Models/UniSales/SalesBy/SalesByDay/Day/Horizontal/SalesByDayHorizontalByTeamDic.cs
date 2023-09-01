// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByTeamDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal
{
  public class SalesByDayHorizontalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByTeam>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByTeam>>
  {
    private Dictionary<string, SalesByDayHorizontalByTeam> _Source = new Dictionary<string, SalesByDayHorizontalByTeam>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByTeam> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByTeam this[string key]
    {
      get
      {
        SalesByDayHorizontalByTeam horizontalByTeam;
        return !this.Source.TryGetValue(key, out horizontalByTeam) ? (SalesByDayHorizontalByTeam) null : horizontalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByTeam pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByTeam _))
        return;
      SalesByDayHorizontalByTeam horizontalByTeam = new SalesByDayHorizontalByTeam();
      horizontalByTeam.si_StoreCode = pData.sbd_StoreCode;
      horizontalByTeam.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByTeam.dpt_lv2_ID = pData.dpt_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByTeam);
      horizontalByTeam.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalByTeam info)
    {
      SalesByDayHorizontalByTeam horizontalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByTeam))
      {
        horizontalByTeam = new SalesByDayHorizontalByTeam();
        horizontalByTeam.si_StoreCode = info.sbd_StoreCode;
        horizontalByTeam.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByTeam.dpt_lv2_ID = info.dpt_lv2_ID;
        this._Source.Add(info.KeyCode, horizontalByTeam);
      }
      horizontalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByDayHorizontalByTeam> infos)
    {
      foreach (SalesByDayHorizontalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
