// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByCategoryTopDic
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
  public class SaleByMonthVerticalByCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryTop>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByCategoryTop>>
  {
    private Dictionary<string, SaleByMonthVerticalByCategoryTop> _Source = new Dictionary<string, SaleByMonthVerticalByCategoryTop>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryTop> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByCategoryTop this[string key]
    {
      get
      {
        SaleByMonthVerticalByCategoryTop verticalByCategoryTop;
        return !this.Source.TryGetValue(key, out verticalByCategoryTop) ? (SaleByMonthVerticalByCategoryTop) null : verticalByCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByCategoryTop pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByCategoryTop _))
        return;
      SaleByMonthVerticalByCategoryTop verticalByCategoryTop = new SaleByMonthVerticalByCategoryTop();
      verticalByCategoryTop.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryTop);
      verticalByCategoryTop.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByCategoryTop info)
    {
      SaleByMonthVerticalByCategoryTop verticalByCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryTop))
      {
        verticalByCategoryTop = new SaleByMonthVerticalByCategoryTop();
        verticalByCategoryTop.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, verticalByCategoryTop);
      }
      verticalByCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<SaleByMonthVerticalByCategoryTop> infos)
    {
      foreach (SaleByMonthVerticalByCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByCategoryTop value) => this.Source.TryGetValue(key, out value);
  }
}
