// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.StatementMonthHorizontalByDeptDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal
{
  public class StatementMonthHorizontalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalByDept>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalByDept>>
  {
    private Dictionary<string, StatementMonthHorizontalByDept> _Source = new Dictionary<string, StatementMonthHorizontalByDept>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalByDept> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalByDept this[string key]
    {
      get
      {
        StatementMonthHorizontalByDept horizontalByDept;
        return !this.Source.TryGetValue(key, out horizontalByDept) ? (StatementMonthHorizontalByDept) null : horizontalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalByDept pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalByDept _))
        return;
      StatementMonthHorizontalByDept horizontalByDept = new StatementMonthHorizontalByDept();
      horizontalByDept.sh_StoreCode = pData.sh_StoreCode;
      horizontalByDept.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByDept.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByDept.dpt_ID = pData.dpt_ID;
      this._Source.Add(pData.KeyCode, horizontalByDept);
      horizontalByDept.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalByDept info)
    {
      StatementMonthHorizontalByDept horizontalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByDept))
      {
        horizontalByDept = new StatementMonthHorizontalByDept();
        horizontalByDept.sh_StoreCode = info.sh_StoreCode;
        horizontalByDept.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByDept.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByDept.dpt_ID = info.dpt_ID;
        this._Source.Add(info.KeyCode, horizontalByDept);
      }
      horizontalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthHorizontalByDept> infos)
    {
      foreach (StatementMonthHorizontalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
