// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByDeptDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByDept>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByDept>>
  {
    private Dictionary<string, StatementMonthVerticalByDept> _Source = new Dictionary<string, StatementMonthVerticalByDept>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByDept> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByDept this[string key]
    {
      get
      {
        StatementMonthVerticalByDept monthVerticalByDept;
        return !this.Source.TryGetValue(key, out monthVerticalByDept) ? (StatementMonthVerticalByDept) null : monthVerticalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByDept _))
        return;
      StatementMonthVerticalByDept monthVerticalByDept = new StatementMonthVerticalByDept();
      monthVerticalByDept.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, monthVerticalByDept);
      monthVerticalByDept.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByDept info)
    {
      StatementMonthVerticalByDept monthVerticalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByDept))
      {
        monthVerticalByDept = new StatementMonthVerticalByDept();
        monthVerticalByDept.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, monthVerticalByDept);
      }
      monthVerticalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthVerticalByDept> infos)
    {
      foreach (StatementMonthVerticalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
