// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier.SalesByMonthHorizontalBySupplierGoodsDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier
{
  public class SalesByMonthHorizontalBySupplierGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierGoods>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalBySupplierGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalBySupplierGoods>>
  {
    private Dictionary<string, SalesByMonthHorizontalBySupplierGoods> _Source = new Dictionary<string, SalesByMonthHorizontalBySupplierGoods>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierGoods> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalBySupplierGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalBySupplierGoods this[string key]
    {
      get
      {
        SalesByMonthHorizontalBySupplierGoods horizontalBySupplierGoods;
        return !this.Source.TryGetValue(key, out horizontalBySupplierGoods) ? (SalesByMonthHorizontalBySupplierGoods) null : horizontalBySupplierGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalBySupplierGoods pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalBySupplierGoods _))
        return;
      SalesByMonthHorizontalBySupplierGoods horizontalBySupplierGoods = new SalesByMonthHorizontalBySupplierGoods();
      horizontalBySupplierGoods.si_StoreCode = pData.sbd_StoreCode;
      horizontalBySupplierGoods.sbd_Supplier = pData.sbd_Supplier;
      horizontalBySupplierGoods.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalBySupplierGoods.ctg_lv2_ID = pData.ctg_lv2_ID;
      horizontalBySupplierGoods.sbd_CategoryCode = pData.sbd_CategoryCode;
      horizontalBySupplierGoods.sbd_GoodsCode = pData.sbd_GoodsCode;
      this._Source.Add(pData.KeyCode, horizontalBySupplierGoods);
      horizontalBySupplierGoods.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalBySupplierGoods info)
    {
      SalesByMonthHorizontalBySupplierGoods horizontalBySupplierGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalBySupplierGoods))
      {
        horizontalBySupplierGoods = new SalesByMonthHorizontalBySupplierGoods();
        horizontalBySupplierGoods.si_StoreCode = info.sbd_StoreCode;
        horizontalBySupplierGoods.sbd_Supplier = info.sbd_Supplier;
        horizontalBySupplierGoods.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalBySupplierGoods.ctg_lv2_ID = info.ctg_lv2_ID;
        horizontalBySupplierGoods.sbd_CategoryCode = info.sbd_CategoryCode;
        horizontalBySupplierGoods.sbd_GoodsCode = info.sbd_GoodsCode;
        this._Source.Add(info.KeyCode, horizontalBySupplierGoods);
      }
      horizontalBySupplierGoods?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByMonthHorizontalBySupplierGoods> infos)
    {
      foreach (SalesByMonthHorizontalBySupplierGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalBySupplierGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalBySupplierGoods value) => this.Source.TryGetValue(key, out value);
  }
}
