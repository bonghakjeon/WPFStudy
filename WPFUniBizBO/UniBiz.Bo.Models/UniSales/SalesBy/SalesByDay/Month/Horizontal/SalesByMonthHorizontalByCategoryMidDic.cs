// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.SalesByMonthHorizontalByCategoryMidDic
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
  public class SalesByMonthHorizontalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalByCategoryMid>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalByCategoryMid>>
  {
    private Dictionary<string, SalesByMonthHorizontalByCategoryMid> _Source = new Dictionary<string, SalesByMonthHorizontalByCategoryMid>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalByCategoryMid> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalByCategoryMid this[string key]
    {
      get
      {
        SalesByMonthHorizontalByCategoryMid horizontalByCategoryMid;
        return !this.Source.TryGetValue(key, out horizontalByCategoryMid) ? (SalesByMonthHorizontalByCategoryMid) null : horizontalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalByCategoryMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalByCategoryMid _))
        return;
      SalesByMonthHorizontalByCategoryMid horizontalByCategoryMid = new SalesByMonthHorizontalByCategoryMid();
      horizontalByCategoryMid.si_StoreCode = pData.sbd_StoreCode;
      horizontalByCategoryMid.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryMid.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryMid.sbd_DeptCode = pData.sbd_DeptCode;
      horizontalByCategoryMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByCategoryMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByCategoryMid);
      horizontalByCategoryMid.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalByCategoryMid info)
    {
      SalesByMonthHorizontalByCategoryMid horizontalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryMid))
      {
        horizontalByCategoryMid = new SalesByMonthHorizontalByCategoryMid();
        horizontalByCategoryMid.si_StoreCode = info.sbd_StoreCode;
        horizontalByCategoryMid.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByCategoryMid.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByCategoryMid.sbd_DeptCode = info.sbd_DeptCode;
        horizontalByCategoryMid.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalByCategoryMid.ctg_lv2_ID = info.ctg_lv2_ID;
        this._Source.Add(info.KeyCode, horizontalByCategoryMid);
      }
      horizontalByCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByMonthHorizontalByCategoryMid> infos)
    {
      foreach (SalesByMonthHorizontalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
