// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByDeptDic
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
  public class SalesByDayHorizontalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByDept>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByDept>>
  {
    private Dictionary<string, SalesByDayHorizontalByDept> _Source = new Dictionary<string, SalesByDayHorizontalByDept>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByDept> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByDept this[string key]
    {
      get
      {
        SalesByDayHorizontalByDept horizontalByDept;
        return !this.Source.TryGetValue(key, out horizontalByDept) ? (SalesByDayHorizontalByDept) null : horizontalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByDept pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByDept _))
        return;
      SalesByDayHorizontalByDept horizontalByDept = new SalesByDayHorizontalByDept();
      horizontalByDept.si_StoreCode = pData.sbd_StoreCode;
      horizontalByDept.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByDept.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByDept.sbd_DeptCode = pData.sbd_DeptCode;
      this._Source.Add(pData.KeyCode, horizontalByDept);
      horizontalByDept.InitInfo(pData, p_Days);
    }

    public void Add(SalesByDayHorizontalByDept info)
    {
      SalesByDayHorizontalByDept horizontalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByDept))
      {
        horizontalByDept = new SalesByDayHorizontalByDept();
        horizontalByDept.si_StoreCode = info.sbd_StoreCode;
        horizontalByDept.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByDept.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByDept.sbd_DeptCode = info.sbd_DeptCode;
        this._Source.Add(info.KeyCode, horizontalByDept);
      }
      horizontalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<SalesByDayHorizontalByDept> infos)
    {
      foreach (SalesByDayHorizontalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
