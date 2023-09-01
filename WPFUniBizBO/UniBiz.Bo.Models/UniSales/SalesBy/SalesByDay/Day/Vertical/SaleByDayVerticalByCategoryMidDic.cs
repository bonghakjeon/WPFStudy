// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByCategoryMidDic
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
  public class SaleByDayVerticalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByCategoryMid>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByCategoryMid>>
  {
    private Dictionary<string, SaleByDayVerticalByCategoryMid> _Source = new Dictionary<string, SaleByDayVerticalByCategoryMid>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByCategoryMid> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByCategoryMid this[string key]
    {
      get
      {
        SaleByDayVerticalByCategoryMid verticalByCategoryMid;
        return !this.Source.TryGetValue(key, out verticalByCategoryMid) ? (SaleByDayVerticalByCategoryMid) null : verticalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByCategoryMid pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByCategoryMid _))
        return;
      SaleByDayVerticalByCategoryMid verticalByCategoryMid = new SaleByDayVerticalByCategoryMid();
      verticalByCategoryMid.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryMid);
      verticalByCategoryMid.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByCategoryMid info)
    {
      SaleByDayVerticalByCategoryMid verticalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryMid))
      {
        verticalByCategoryMid = new SaleByDayVerticalByCategoryMid();
        verticalByCategoryMid.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, verticalByCategoryMid);
      }
      verticalByCategoryMid?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByCategoryMid> infos)
    {
      foreach (SaleByDayVerticalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
