// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.SalesByMonthHorizontalByGoodsDic
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
  public class SalesByMonthHorizontalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalByGoods>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalByGoods>>
  {
    private Dictionary<string, SalesByMonthHorizontalByGoods> _Source = new Dictionary<string, SalesByMonthHorizontalByGoods>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalByGoods> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalByGoods this[string key]
    {
      get
      {
        SalesByMonthHorizontalByGoods horizontalByGoods;
        return !this.Source.TryGetValue(key, out horizontalByGoods) ? (SalesByMonthHorizontalByGoods) null : horizontalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalByGoods pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalByGoods _))
        return;
      SalesByMonthHorizontalByGoods horizontalByGoods = new SalesByMonthHorizontalByGoods();
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

    public void Add(SalesByMonthHorizontalByGoods info)
    {
      SalesByMonthHorizontalByGoods horizontalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByGoods))
      {
        horizontalByGoods = new SalesByMonthHorizontalByGoods();
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

    public void AddRange(IEnumerable<SalesByMonthHorizontalByGoods> infos)
    {
      foreach (SalesByMonthHorizontalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
