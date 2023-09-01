// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByCategoryMidDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Category;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByCategoryMid>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByCategoryMid>>
  {
    private Dictionary<string, StatementMonthVerticalByCategoryMid> _Source = new Dictionary<string, StatementMonthVerticalByCategoryMid>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByCategoryMid> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByCategoryMid this[string key]
    {
      get
      {
        StatementMonthVerticalByCategoryMid verticalByCategoryMid;
        return !this.Source.TryGetValue(key, out verticalByCategoryMid) ? (StatementMonthVerticalByCategoryMid) null : verticalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByCategoryMid pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByCategoryMid _))
        return;
      StatementMonthVerticalByCategoryMid verticalByCategoryMid = new StatementMonthVerticalByCategoryMid();
      verticalByCategoryMid.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryMid);
      verticalByCategoryMid.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByCategoryMid info)
    {
      StatementMonthVerticalByCategoryMid verticalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryMid))
      {
        verticalByCategoryMid = new StatementMonthVerticalByCategoryMid();
        verticalByCategoryMid.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, verticalByCategoryMid);
      }
      verticalByCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthVerticalByCategoryMid> infos)
    {
      foreach (StatementMonthVerticalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
