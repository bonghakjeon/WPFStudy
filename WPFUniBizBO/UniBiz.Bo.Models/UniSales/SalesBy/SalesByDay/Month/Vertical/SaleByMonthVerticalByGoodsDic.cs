// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByGoodsDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByGoods>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByGoods>>
  {
    private Dictionary<string, SaleByMonthVerticalByGoods> _Source = new Dictionary<string, SaleByMonthVerticalByGoods>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByGoods> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByGoods this[string key]
    {
      get
      {
        SaleByMonthVerticalByGoods monthVerticalByGoods;
        return !this.Source.TryGetValue(key, out monthVerticalByGoods) ? (SaleByMonthVerticalByGoods) null : monthVerticalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByGoods pData, IList<TGoods> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByGoods _))
        return;
      SaleByMonthVerticalByGoods monthVerticalByGoods = new SaleByMonthVerticalByGoods();
      monthVerticalByGoods.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, monthVerticalByGoods);
      monthVerticalByGoods.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByGoods info)
    {
      SaleByMonthVerticalByGoods monthVerticalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByGoods))
      {
        monthVerticalByGoods = new SaleByMonthVerticalByGoods();
        monthVerticalByGoods.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, monthVerticalByGoods);
      }
      monthVerticalByGoods?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByMonthVerticalByGoods> infos)
    {
      foreach (SaleByMonthVerticalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
