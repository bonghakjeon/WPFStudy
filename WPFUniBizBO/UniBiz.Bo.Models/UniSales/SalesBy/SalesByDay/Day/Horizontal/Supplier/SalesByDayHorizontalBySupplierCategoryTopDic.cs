// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier.SalesByDayHorizontalBySupplierCategoryTopDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier
{
  public class SalesByDayHorizontalBySupplierCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryTop>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryTop>>
  {
    private Dictionary<string, SalesByDayHorizontalBySupplierCategoryTop> _Source = new Dictionary<string, SalesByDayHorizontalBySupplierCategoryTop>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryTop> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalBySupplierCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalBySupplierCategoryTop this[string key]
    {
      get
      {
        SalesByDayHorizontalBySupplierCategoryTop supplierCategoryTop;
        return !this.Source.TryGetValue(key, out supplierCategoryTop) ? (SalesByDayHorizontalBySupplierCategoryTop) null : supplierCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalBySupplierCategoryTop pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalBySupplierCategoryTop _))
        return;
      SalesByDayHorizontalBySupplierCategoryTop supplierCategoryTop = new SalesByDayHorizontalBySupplierCategoryTop();
      supplierCategoryTop.si_StoreCode = pData.sbd_StoreCode;
      supplierCategoryTop.sbd_Supplier = pData.sbd_Supplier;
      supplierCategoryTop.ctg_lv1_ID = pData.ctg_lv1_ID;
      this._Source.Add(pData.KeyCode, supplierCategoryTop);
      supplierCategoryTop.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalBySupplierCategoryTop info)
    {
      SalesByDayHorizontalBySupplierCategoryTop supplierCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out supplierCategoryTop))
      {
        supplierCategoryTop = new SalesByDayHorizontalBySupplierCategoryTop();
        supplierCategoryTop.si_StoreCode = info.sbd_StoreCode;
        supplierCategoryTop.sbd_Supplier = info.sbd_Supplier;
        supplierCategoryTop.ctg_lv1_ID = info.ctg_lv1_ID;
        this._Source.Add(info.KeyCode, supplierCategoryTop);
      }
      supplierCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByDayHorizontalBySupplierCategoryTop> infos)
    {
      foreach (SalesByDayHorizontalBySupplierCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(
      string key,
      [MaybeNullWhen(false)] out SalesByDayHorizontalBySupplierCategoryTop value)
    {
      return this.Source.TryGetValue(key, out value);
    }
  }
}
