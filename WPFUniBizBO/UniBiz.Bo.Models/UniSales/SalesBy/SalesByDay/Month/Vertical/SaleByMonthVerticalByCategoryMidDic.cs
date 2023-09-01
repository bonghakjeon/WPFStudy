// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByCategoryMidDic
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
  public class SaleByMonthVerticalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryMid>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByCategoryMid>>
  {
    private Dictionary<string, SaleByMonthVerticalByCategoryMid> _Source = new Dictionary<string, SaleByMonthVerticalByCategoryMid>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryMid> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByCategoryMid this[string key]
    {
      get
      {
        SaleByMonthVerticalByCategoryMid verticalByCategoryMid;
        return !this.Source.TryGetValue(key, out verticalByCategoryMid) ? (SaleByMonthVerticalByCategoryMid) null : verticalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByCategoryMid pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByCategoryMid _))
        return;
      SaleByMonthVerticalByCategoryMid verticalByCategoryMid = new SaleByMonthVerticalByCategoryMid();
      verticalByCategoryMid.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryMid);
      verticalByCategoryMid.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByCategoryMid info)
    {
      SaleByMonthVerticalByCategoryMid verticalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryMid))
      {
        verticalByCategoryMid = new SaleByMonthVerticalByCategoryMid();
        verticalByCategoryMid.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, verticalByCategoryMid);
      }
      verticalByCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<SaleByMonthVerticalByCategoryMid> infos)
    {
      foreach (SaleByMonthVerticalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
