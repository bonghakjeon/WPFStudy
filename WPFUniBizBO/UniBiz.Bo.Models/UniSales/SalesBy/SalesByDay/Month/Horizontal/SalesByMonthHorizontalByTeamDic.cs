// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.SalesByMonthHorizontalByTeamDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal
{
  public class SalesByMonthHorizontalByTeamDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalByTeam>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalByTeam>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalByTeam>>
  {
    private Dictionary<string, SalesByMonthHorizontalByTeam> _Source = new Dictionary<string, SalesByMonthHorizontalByTeam>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalByTeam> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalByTeam>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalByTeam> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalByTeam this[string key]
    {
      get
      {
        SalesByMonthHorizontalByTeam horizontalByTeam;
        return !this.Source.TryGetValue(key, out horizontalByTeam) ? (SalesByMonthHorizontalByTeam) null : horizontalByTeam;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalByTeam pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalByTeam _))
        return;
      SalesByMonthHorizontalByTeam horizontalByTeam = new SalesByMonthHorizontalByTeam();
      horizontalByTeam.si_StoreCode = pData.sbd_StoreCode;
      horizontalByTeam.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByTeam.dpt_lv2_ID = pData.dpt_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByTeam);
      horizontalByTeam.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalByTeam info)
    {
      SalesByMonthHorizontalByTeam horizontalByTeam;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByTeam))
      {
        horizontalByTeam = new SalesByMonthHorizontalByTeam();
        horizontalByTeam.si_StoreCode = info.sbd_StoreCode;
        horizontalByTeam.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByTeam.dpt_lv2_ID = info.dpt_lv2_ID;
        this._Source.Add(info.KeyCode, horizontalByTeam);
      }
      horizontalByTeam?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByMonthHorizontalByTeam> infos)
    {
      foreach (SalesByMonthHorizontalByTeam info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalByTeam>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalByTeam value) => this.Source.TryGetValue(key, out value);
  }
}
