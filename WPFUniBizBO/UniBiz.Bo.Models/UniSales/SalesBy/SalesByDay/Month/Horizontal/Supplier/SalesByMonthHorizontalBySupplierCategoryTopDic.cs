// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier.SalesByMonthHorizontalBySupplierCategoryTopDic
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
  public class SalesByMonthHorizontalBySupplierCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierCategoryTop>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalBySupplierCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalBySupplierCategoryTop>>
  {
    private Dictionary<string, SalesByMonthHorizontalBySupplierCategoryTop> _Source = new Dictionary<string, SalesByMonthHorizontalBySupplierCategoryTop>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierCategoryTop> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalBySupplierCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalBySupplierCategoryTop this[string key]
    {
      get
      {
        SalesByMonthHorizontalBySupplierCategoryTop supplierCategoryTop;
        return !this.Source.TryGetValue(key, out supplierCategoryTop) ? (SalesByMonthHorizontalBySupplierCategoryTop) null : supplierCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalBySupplierCategoryTop pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalBySupplierCategoryTop _))
        return;
      SalesByMonthHorizontalBySupplierCategoryTop supplierCategoryTop = new SalesByMonthHorizontalBySupplierCategoryTop();
      supplierCategoryTop.si_StoreCode = pData.sbd_StoreCode;
      supplierCategoryTop.sbd_Supplier = pData.sbd_Supplier;
      supplierCategoryTop.ctg_lv1_ID = pData.ctg_lv1_ID;
      this._Source.Add(pData.KeyCode, supplierCategoryTop);
      supplierCategoryTop.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalBySupplierCategoryTop info)
    {
      SalesByMonthHorizontalBySupplierCategoryTop supplierCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out supplierCategoryTop))
      {
        supplierCategoryTop = new SalesByMonthHorizontalBySupplierCategoryTop();
        supplierCategoryTop.si_StoreCode = info.sbd_StoreCode;
        supplierCategoryTop.sbd_Supplier = info.sbd_Supplier;
        supplierCategoryTop.ctg_lv1_ID = info.ctg_lv1_ID;
        this._Source.Add(info.KeyCode, supplierCategoryTop);
      }
      supplierCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByMonthHorizontalBySupplierCategoryTop> infos)
    {
      foreach (SalesByMonthHorizontalBySupplierCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalBySupplierCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(
      string key,
      [MaybeNullWhen(false)] out SalesByMonthHorizontalBySupplierCategoryTop value)
    {
      return this.Source.TryGetValue(key, out value);
    }
  }
}
