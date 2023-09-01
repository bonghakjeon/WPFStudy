// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByDeptDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal
{
  public class StatementDayHorizontalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalByDept>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalByDept>>
  {
    private Dictionary<string, StatementDayHorizontalByDept> _Source = new Dictionary<string, StatementDayHorizontalByDept>();

    public IReadOnlyDictionary<string, StatementDayHorizontalByDept> Source => (IReadOnlyDictionary<string, StatementDayHorizontalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalByDept this[string key]
    {
      get
      {
        StatementDayHorizontalByDept horizontalByDept;
        return !this.Source.TryGetValue(key, out horizontalByDept) ? (StatementDayHorizontalByDept) null : horizontalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalByDept pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalByDept _))
        return;
      StatementDayHorizontalByDept horizontalByDept = new StatementDayHorizontalByDept();
      horizontalByDept.sh_StoreCode = pData.sh_StoreCode;
      horizontalByDept.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByDept.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByDept.dpt_ID = pData.dpt_ID;
      this._Source.Add(pData.KeyCode, horizontalByDept);
      horizontalByDept.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalByDept info)
    {
      StatementDayHorizontalByDept horizontalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByDept))
      {
        horizontalByDept = new StatementDayHorizontalByDept();
        horizontalByDept.sh_StoreCode = info.sh_StoreCode;
        horizontalByDept.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByDept.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByDept.dpt_ID = info.dpt_ID;
        this._Source.Add(info.KeyCode, horizontalByDept);
      }
      horizontalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<StatementDayHorizontalByDept> infos)
    {
      foreach (StatementDayHorizontalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
