// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByCategoryBotDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Category;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryBot>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByCategoryBot>>
  {
    private Dictionary<string, SaleByMonthVerticalByCategoryBot> _Source = new Dictionary<string, SaleByMonthVerticalByCategoryBot>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryBot> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByCategoryBot this[string key]
    {
      get
      {
        SaleByMonthVerticalByCategoryBot verticalByCategoryBot;
        return !this.Source.TryGetValue(key, out verticalByCategoryBot) ? (SaleByMonthVerticalByCategoryBot) null : verticalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByCategoryBot pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByCategoryBot _))
        return;
      SaleByMonthVerticalByCategoryBot verticalByCategoryBot = new SaleByMonthVerticalByCategoryBot();
      verticalByCategoryBot.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryBot);
      verticalByCategoryBot.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByCategoryBot info)
    {
      SaleByMonthVerticalByCategoryBot verticalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryBot))
      {
        verticalByCategoryBot = new SaleByMonthVerticalByCategoryBot();
        verticalByCategoryBot.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, verticalByCategoryBot);
      }
      verticalByCategoryBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<SaleByMonthVerticalByCategoryBot> infos)
    {
      foreach (SaleByMonthVerticalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
