// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByCategoryTopDic
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
  public class SaleByDayVerticalByCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByCategoryTop>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByCategoryTop>>
  {
    private Dictionary<string, SaleByDayVerticalByCategoryTop> _Source = new Dictionary<string, SaleByDayVerticalByCategoryTop>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByCategoryTop> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByCategoryTop this[string key]
    {
      get
      {
        SaleByDayVerticalByCategoryTop verticalByCategoryTop;
        return !this.Source.TryGetValue(key, out verticalByCategoryTop) ? (SaleByDayVerticalByCategoryTop) null : verticalByCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByCategoryTop pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByCategoryTop _))
        return;
      SaleByDayVerticalByCategoryTop verticalByCategoryTop = new SaleByDayVerticalByCategoryTop();
      verticalByCategoryTop.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryTop);
      verticalByCategoryTop.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByCategoryTop info)
    {
      SaleByDayVerticalByCategoryTop verticalByCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryTop))
      {
        verticalByCategoryTop = new SaleByDayVerticalByCategoryTop();
        verticalByCategoryTop.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, verticalByCategoryTop);
      }
      verticalByCategoryTop?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByCategoryTop> infos)
    {
      foreach (SaleByDayVerticalByCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByCategoryTop value) => this.Source.TryGetValue(key, out value);
  }
}
