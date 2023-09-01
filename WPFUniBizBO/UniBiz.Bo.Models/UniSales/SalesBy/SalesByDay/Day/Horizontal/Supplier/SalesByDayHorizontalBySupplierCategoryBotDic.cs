// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier.SalesByDayHorizontalBySupplierCategoryBotDic
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
  public class SalesByDayHorizontalBySupplierCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryBot>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryBot>>
  {
    private Dictionary<string, SalesByDayHorizontalBySupplierCategoryBot> _Source = new Dictionary<string, SalesByDayHorizontalBySupplierCategoryBot>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryBot> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalBySupplierCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalBySupplierCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalBySupplierCategoryBot this[string key]
    {
      get
      {
        SalesByDayHorizontalBySupplierCategoryBot supplierCategoryBot;
        return !this.Source.TryGetValue(key, out supplierCategoryBot) ? (SalesByDayHorizontalBySupplierCategoryBot) null : supplierCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalBySupplierCategoryBot pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalBySupplierCategoryBot _))
        return;
      SalesByDayHorizontalBySupplierCategoryBot supplierCategoryBot = new SalesByDayHorizontalBySupplierCategoryBot();
      supplierCategoryBot.si_StoreCode = pData.sbd_StoreCode;
      supplierCategoryBot.sbd_Supplier = pData.sbd_Supplier;
      supplierCategoryBot.ctg_lv1_ID = pData.ctg_lv1_ID;
      supplierCategoryBot.ctg_lv2_ID = pData.ctg_lv2_ID;
      supplierCategoryBot.sbd_CategoryCode = pData.sbd_CategoryCode;
      this._Source.Add(pData.KeyCode, supplierCategoryBot);
      supplierCategoryBot.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalBySupplierCategoryBot info)
    {
      SalesByDayHorizontalBySupplierCategoryBot supplierCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out supplierCategoryBot))
      {
        supplierCategoryBot = new SalesByDayHorizontalBySupplierCategoryBot();
        supplierCategoryBot.si_StoreCode = info.sbd_StoreCode;
        supplierCategoryBot.sbd_Supplier = info.sbd_Supplier;
        supplierCategoryBot.ctg_lv1_ID = info.ctg_lv1_ID;
        supplierCategoryBot.ctg_lv2_ID = info.ctg_lv2_ID;
        supplierCategoryBot.sbd_CategoryCode = info.sbd_CategoryCode;
        this._Source.Add(info.KeyCode, supplierCategoryBot);
      }
      supplierCategoryBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByDayHorizontalBySupplierCategoryBot> infos)
    {
      foreach (SalesByDayHorizontalBySupplierCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalBySupplierCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(
      string key,
      [MaybeNullWhen(false)] out SalesByDayHorizontalBySupplierCategoryBot value)
    {
      return this.Source.TryGetValue(key, out value);
    }
  }
}
