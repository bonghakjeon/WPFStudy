// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByCategoryBotDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Category;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByCategoryBot>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByCategoryBot>>
  {
    private Dictionary<string, SaleByDayVerticalByCategoryBot> _Source = new Dictionary<string, SaleByDayVerticalByCategoryBot>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByCategoryBot> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByCategoryBot this[string key]
    {
      get
      {
        SaleByDayVerticalByCategoryBot verticalByCategoryBot;
        return !this.Source.TryGetValue(key, out verticalByCategoryBot) ? (SaleByDayVerticalByCategoryBot) null : verticalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByCategoryBot pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByCategoryBot _))
        return;
      SaleByDayVerticalByCategoryBot verticalByCategoryBot = new SaleByDayVerticalByCategoryBot();
      verticalByCategoryBot.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryBot);
      verticalByCategoryBot.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByCategoryBot info)
    {
      SaleByDayVerticalByCategoryBot verticalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryBot))
      {
        verticalByCategoryBot = new SaleByDayVerticalByCategoryBot();
        verticalByCategoryBot.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, verticalByCategoryBot);
      }
      verticalByCategoryBot?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByCategoryBot> infos)
    {
      foreach (SaleByDayVerticalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
