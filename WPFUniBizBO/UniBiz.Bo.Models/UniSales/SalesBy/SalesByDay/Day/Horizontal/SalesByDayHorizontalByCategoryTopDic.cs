// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByCategoryTopDic
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
  public class SalesByDayHorizontalByCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryTop>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByCategoryTop>>
  {
    private Dictionary<string, SalesByDayHorizontalByCategoryTop> _Source = new Dictionary<string, SalesByDayHorizontalByCategoryTop>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryTop> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByCategoryTop this[string key]
    {
      get
      {
        SalesByDayHorizontalByCategoryTop horizontalByCategoryTop;
        return !this.Source.TryGetValue(key, out horizontalByCategoryTop) ? (SalesByDayHorizontalByCategoryTop) null : horizontalByCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByCategoryTop pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByCategoryTop _))
        return;
      SalesByDayHorizontalByCategoryTop horizontalByCategoryTop = new SalesByDayHorizontalByCategoryTop();
      horizontalByCategoryTop.si_StoreCode = pData.sbd_StoreCode;
      horizontalByCategoryTop.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryTop.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryTop.sbd_DeptCode = pData.sbd_DeptCode;
      horizontalByCategoryTop.ctg_lv1_ID = pData.ctg_lv1_ID;
      this._Source.Add(pData.KeyCode, horizontalByCategoryTop);
      horizontalByCategoryTop.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalByCategoryTop info)
    {
      SalesByDayHorizontalByCategoryTop horizontalByCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryTop))
      {
        horizontalByCategoryTop = new SalesByDayHorizontalByCategoryTop();
        horizontalByCategoryTop.si_StoreCode = info.sbd_StoreCode;
        horizontalByCategoryTop.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByCategoryTop.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByCategoryTop.sbd_DeptCode = info.sbd_DeptCode;
        horizontalByCategoryTop.ctg_lv1_ID = info.ctg_lv1_ID;
        this._Source.Add(info.KeyCode, horizontalByCategoryTop);
      }
      horizontalByCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByDayHorizontalByCategoryTop> infos)
    {
      foreach (SalesByDayHorizontalByCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByCategoryTop value) => this.Source.TryGetValue(key, out value);
  }
}
