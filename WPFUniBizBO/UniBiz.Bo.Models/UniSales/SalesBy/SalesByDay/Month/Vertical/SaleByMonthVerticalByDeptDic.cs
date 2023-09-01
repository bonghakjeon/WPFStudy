// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByDeptDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByMonthVerticalByDept>,
    IEnumerable<KeyValuePair<string, SaleByMonthVerticalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByMonthVerticalByDept>>
  {
    private Dictionary<string, SaleByMonthVerticalByDept> _Source = new Dictionary<string, SaleByMonthVerticalByDept>();

    public IReadOnlyDictionary<string, SaleByMonthVerticalByDept> Source => (IReadOnlyDictionary<string, SaleByMonthVerticalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByMonthVerticalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByMonthVerticalByDept this[string key]
    {
      get
      {
        SaleByMonthVerticalByDept monthVerticalByDept;
        return !this.Source.TryGetValue(key, out monthVerticalByDept) ? (SaleByMonthVerticalByDept) null : monthVerticalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByMonthVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByMonthVerticalByDept _))
        return;
      SaleByMonthVerticalByDept monthVerticalByDept = new SaleByMonthVerticalByDept();
      monthVerticalByDept.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, monthVerticalByDept);
      monthVerticalByDept.InitInfo(pData, p_Header);
    }

    public void Add(SaleByMonthVerticalByDept info)
    {
      SaleByMonthVerticalByDept monthVerticalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByDept))
      {
        monthVerticalByDept = new SaleByMonthVerticalByDept();
        monthVerticalByDept.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, monthVerticalByDept);
      }
      monthVerticalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByMonthVerticalByDept> infos)
    {
      foreach (SaleByMonthVerticalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByMonthVerticalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByMonthVerticalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
