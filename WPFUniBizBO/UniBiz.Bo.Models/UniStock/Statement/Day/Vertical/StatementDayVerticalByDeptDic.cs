// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByDeptDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByDeptDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByDept>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByDept>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByDept>>
  {
    private Dictionary<string, StatementDayVerticalByDept> _Source = new Dictionary<string, StatementDayVerticalByDept>();

    public IReadOnlyDictionary<string, StatementDayVerticalByDept> Source => (IReadOnlyDictionary<string, StatementDayVerticalByDept>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByDept> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByDept this[string key]
    {
      get
      {
        StatementDayVerticalByDept dayVerticalByDept;
        return !this.Source.TryGetValue(key, out dayVerticalByDept) ? (StatementDayVerticalByDept) null : dayVerticalByDept;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByDept pData, IList<DeptView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByDept _))
        return;
      StatementDayVerticalByDept dayVerticalByDept = new StatementDayVerticalByDept();
      dayVerticalByDept.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, dayVerticalByDept);
      dayVerticalByDept.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByDept info)
    {
      StatementDayVerticalByDept dayVerticalByDept;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByDept))
      {
        dayVerticalByDept = new StatementDayVerticalByDept();
        dayVerticalByDept.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, dayVerticalByDept);
      }
      dayVerticalByDept?.Add(info);
    }

    public void AddRange(IEnumerable<StatementDayVerticalByDept> infos)
    {
      foreach (StatementDayVerticalByDept info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByDept>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByDept value) => this.Source.TryGetValue(key, out value);
  }
}
