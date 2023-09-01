// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByDeptDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, SaleByDayVerticalByDept>,
    IEnumerable<KeyValuePair<string, SaleByDayVerticalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SaleByDayVerticalByDept>>
  {
    private Dictionary<string, SaleByDayVerticalByDept> _Source = new Dictionary<string, SaleByDayVerticalByDept>();

    public IReadOnlyDictionary<string, SaleByDayVerticalByDept> Source => (IReadOnlyDictionary<string, SaleByDayVerticalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SaleByDayVerticalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByDayVerticalByDept this[string key]
    {
      get
      {
        SaleByDayVerticalByDept dayVerticalByDept;
        return !this.Source.TryGetValue(key, out dayVerticalByDept) ? (SaleByDayVerticalByDept) null : dayVerticalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SaleByDayVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SaleByDayVerticalByDept _))
        return;
      SaleByDayVerticalByDept dayVerticalByDept = new SaleByDayVerticalByDept();
      dayVerticalByDept.sbd_SaleDate = pData.sbd_SaleDate;
      this._Source.Add(pData.KeyCode, dayVerticalByDept);
      dayVerticalByDept.InitInfo(pData, p_Header);
    }

    public void Add(SaleByDayVerticalByDept info)
    {
      SaleByDayVerticalByDept dayVerticalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByDept))
      {
        dayVerticalByDept = new SaleByDayVerticalByDept();
        dayVerticalByDept.sbd_SaleDate = info.sbd_SaleDate;
        this._Source.Add(info.KeyCode, dayVerticalByDept);
      }
      dayVerticalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByDayVerticalByDept> infos)
    {
      foreach (SaleByDayVerticalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SaleByDayVerticalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SaleByDayVerticalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
