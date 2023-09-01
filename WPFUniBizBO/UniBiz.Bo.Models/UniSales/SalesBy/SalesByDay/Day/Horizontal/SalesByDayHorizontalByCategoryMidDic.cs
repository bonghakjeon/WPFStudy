// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByCategoryMidDic
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
  public class SalesByDayHorizontalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryMid>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByCategoryMid>>
  {
    private Dictionary<string, SalesByDayHorizontalByCategoryMid> _Source = new Dictionary<string, SalesByDayHorizontalByCategoryMid>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryMid> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByCategoryMid this[string key]
    {
      get
      {
        SalesByDayHorizontalByCategoryMid horizontalByCategoryMid;
        return !this.Source.TryGetValue(key, out horizontalByCategoryMid) ? (SalesByDayHorizontalByCategoryMid) null : horizontalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByCategoryMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByCategoryMid _))
        return;
      SalesByDayHorizontalByCategoryMid horizontalByCategoryMid = new SalesByDayHorizontalByCategoryMid();
      horizontalByCategoryMid.si_StoreCode = pData.sbd_StoreCode;
      horizontalByCategoryMid.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryMid.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryMid.sbd_DeptCode = pData.sbd_DeptCode;
      horizontalByCategoryMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByCategoryMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByCategoryMid);
      horizontalByCategoryMid.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalByCategoryMid info)
    {
      SalesByDayHorizontalByCategoryMid horizontalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryMid))
      {
        horizontalByCategoryMid = new SalesByDayHorizontalByCategoryMid();
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
      IEnumerable<SalesByDayHorizontalByCategoryMid> infos)
    {
      foreach (SalesByDayHorizontalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
