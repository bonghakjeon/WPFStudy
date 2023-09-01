// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByCategoryTopDic
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
  public class StatementMonthVerticalByCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByCategoryTop>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByCategoryTop>>
  {
    private Dictionary<string, StatementMonthVerticalByCategoryTop> _Source = new Dictionary<string, StatementMonthVerticalByCategoryTop>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByCategoryTop> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByCategoryTop this[string key]
    {
      get
      {
        StatementMonthVerticalByCategoryTop verticalByCategoryTop;
        return !this.Source.TryGetValue(key, out verticalByCategoryTop) ? (StatementMonthVerticalByCategoryTop) null : verticalByCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByCategoryTop pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByCategoryTop _))
        return;
      StatementMonthVerticalByCategoryTop verticalByCategoryTop = new StatementMonthVerticalByCategoryTop();
      verticalByCategoryTop.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryTop);
      verticalByCategoryTop.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByCategoryTop info)
    {
      StatementMonthVerticalByCategoryTop verticalByCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryTop))
      {
        verticalByCategoryTop = new StatementMonthVerticalByCategoryTop();
        verticalByCategoryTop.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, verticalByCategoryTop);
      }
      verticalByCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthVerticalByCategoryTop> infos)
    {
      foreach (StatementMonthVerticalByCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByCategoryTop value) => this.Source.TryGetValue(key, out value);
  }
}
