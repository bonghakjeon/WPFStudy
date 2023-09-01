// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier.SalesByMonthHorizontalBySupplierCategoryMidDic
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
  public class SalesByMonthHorizontalBySupplierCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierCategoryMid>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalBySupplierCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalBySupplierCategoryMid>>
  {
    private Dictionary<string, SalesByMonthHorizontalBySupplierCategoryMid> _Source = new Dictionary<string, SalesByMonthHorizontalBySupplierCategoryMid>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierCategoryMid> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalBySupplierCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalBySupplierCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalBySupplierCategoryMid this[string key]
    {
      get
      {
        SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid;
        return !this.Source.TryGetValue(key, out supplierCategoryMid) ? (SalesByMonthHorizontalBySupplierCategoryMid) null : supplierCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalBySupplierCategoryMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalBySupplierCategoryMid _))
        return;
      SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid = new SalesByMonthHorizontalBySupplierCategoryMid();
      supplierCategoryMid.si_StoreCode = pData.sbd_StoreCode;
      supplierCategoryMid.sbd_Supplier = pData.sbd_Supplier;
      supplierCategoryMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      supplierCategoryMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, supplierCategoryMid);
      supplierCategoryMid.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalBySupplierCategoryMid info)
    {
      SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out supplierCategoryMid))
      {
        supplierCategoryMid = new SalesByMonthHorizontalBySupplierCategoryMid();
        supplierCategoryMid.si_StoreCode = info.sbd_StoreCode;
        supplierCategoryMid.sbd_Supplier = info.sbd_Supplier;
        supplierCategoryMid.ctg_lv1_ID = info.ctg_lv1_ID;
        supplierCategoryMid.ctg_lv2_ID = info.ctg_lv2_ID;
        this._Source.Add(info.KeyCode, supplierCategoryMid);
      }
      supplierCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByMonthHorizontalBySupplierCategoryMid> infos)
    {
      foreach (SalesByMonthHorizontalBySupplierCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalBySupplierCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(
      string key,
      [MaybeNullWhen(false)] out SalesByMonthHorizontalBySupplierCategoryMid value)
    {
      return this.Source.TryGetValue(key, out value);
    }
  }
}
