// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByGoodsDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByGoods>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByGoods>>
  {
    private Dictionary<string, SaleByDayVerticalByGoods> _Source = new Dictionary<string, SaleByDayVerticalByGoods>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByGoods> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByGoods this[string key]
    {
      get
      {
        SaleByDayVerticalByGoods dayVerticalByGoods;
        return !this.Source.TryGetValue(key, out dayVerticalByGoods) ? (SaleByDayVerticalByGoods) null : dayVerticalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByGoods pData, IList<TGoods> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByGoods _))
        return;
      SaleByDayVerticalByGoods dayVerticalByGoods = new SaleByDayVerticalByGoods();
      dayVerticalByGoods.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, dayVerticalByGoods);
      dayVerticalByGoods.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByGoods info)
    {
      SaleByDayVerticalByGoods dayVerticalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByGoods))
      {
        dayVerticalByGoods = new SaleByDayVerticalByGoods();
        dayVerticalByGoods.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, dayVerticalByGoods);
      }
      dayVerticalByGoods?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByGoods> infos)
    {
      foreach (SaleByDayVerticalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
