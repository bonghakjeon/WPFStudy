// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByGoodsDic
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
  public class SalesByDayHorizontalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByGoods>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByGoods>>
  {
    private Dictionary<string, SalesByDayHorizontalByGoods> _Source = new Dictionary<string, SalesByDayHorizontalByGoods>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByGoods> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByGoods this[string key]
    {
      get
      {
        SalesByDayHorizontalByGoods horizontalByGoods;
        return !this.Source.TryGetValue(key, out horizontalByGoods) ? (SalesByDayHorizontalByGoods) null : horizontalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByGoods pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByGoods _))
        return;
      SalesByDayHorizontalByGoods horizontalByGoods = new SalesByDayHorizontalByGoods();
      horizontalByGoods.si_StoreCode = pData.sbd_StoreCode;
      horizontalByGoods.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByGoods.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByGoods.sbd_DeptCode = pData.sbd_DeptCode;
      horizontalByGoods.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByGoods.ctg_lv2_ID = pData.ctg_lv2_ID;
      horizontalByGoods.sbd_CategoryCode = pData.sbd_CategoryCode;
      horizontalByGoods.sbd_GoodsCode = pData.sbd_GoodsCode;
      this._Source.Add(pData.KeyCode, horizontalByGoods);
      horizontalByGoods.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalByGoods info)
    {
      SalesByDayHorizontalByGoods horizontalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByGoods))
      {
        horizontalByGoods = new SalesByDayHorizontalByGoods();
        horizontalByGoods.si_StoreCode = info.sbd_StoreCode;
        horizontalByGoods.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByGoods.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByGoods.sbd_DeptCode = info.sbd_DeptCode;
        horizontalByGoods.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalByGoods.ctg_lv2_ID = info.ctg_lv2_ID;
        horizontalByGoods.sbd_CategoryCode = info.sbd_CategoryCode;
        horizontalByGoods.sbd_GoodsCode = info.sbd_GoodsCode;
        this._Source.Add(info.KeyCode, horizontalByGoods);
      }
      horizontalByGoods?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByDayHorizontalByGoods> infos)
    {
      foreach (SalesByDayHorizontalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
