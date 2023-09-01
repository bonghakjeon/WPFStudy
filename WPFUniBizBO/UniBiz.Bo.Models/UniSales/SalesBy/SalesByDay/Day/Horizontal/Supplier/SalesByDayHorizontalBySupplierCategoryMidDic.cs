// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier.SalesByDayHorizontalBySupplierCategoryMidDic
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
  public class SalesByDayHorizontalBySupplierCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryMid>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryMid>>
  {
    private Dictionary<string, SalesByDayHorizontalBySupplierCategoryMid> _Source = new Dictionary<string, SalesByDayHorizontalBySupplierCategoryMid>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryMid> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalBySupplierCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalBySupplierCategoryMid this[string key]
    {
      get
      {
        SalesByDayHorizontalBySupplierCategoryMid supplierCategoryMid;
        return !this.Source.TryGetValue(key, out supplierCategoryMid) ? (SalesByDayHorizontalBySupplierCategoryMid) null : supplierCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalBySupplierCategoryMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalBySupplierCategoryMid _))
        return;
      SalesByDayHorizontalBySupplierCategoryMid supplierCategoryMid = new SalesByDayHorizontalBySupplierCategoryMid();
      supplierCategoryMid.si_StoreCode = pData.sbd_StoreCode;
      supplierCategoryMid.sbd_Supplier = pData.sbd_Supplier;
      supplierCategoryMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      supplierCategoryMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, supplierCategoryMid);
      supplierCategoryMid.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalBySupplierCategoryMid info)
    {
      SalesByDayHorizontalBySupplierCategoryMid supplierCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out supplierCategoryMid))
      {
        supplierCategoryMid = new SalesByDayHorizontalBySupplierCategoryMid();
        supplierCategoryMid.si_StoreCode = info.sbd_StoreCode;
        supplierCategoryMid.sbd_Supplier = info.sbd_Supplier;
        supplierCategoryMid.ctg_lv1_ID = info.ctg_lv1_ID;
        supplierCategoryMid.ctg_lv2_ID = info.ctg_lv2_ID;
        this._Source.Add(info.KeyCode, supplierCategoryMid);
      }
      supplierCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByDayHorizontalBySupplierCategoryMid> infos)
    {
      foreach (SalesByDayHorizontalBySupplierCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(
      string key,
      [MaybeNullWhen(false)] out SalesByDayHorizontalBySupplierCategoryMid value)
    {
      return this.Source.TryGetValue(key, out value);
    }
  }
}
