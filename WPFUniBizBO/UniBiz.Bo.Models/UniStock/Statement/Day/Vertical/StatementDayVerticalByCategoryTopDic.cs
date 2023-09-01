// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByCategoryTopDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.Category;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByCategoryTop>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByCategoryTop>>
  {
    private Dictionary<string, StatementDayVerticalByCategoryTop> _Source = new Dictionary<string, StatementDayVerticalByCategoryTop>();

    public IReadOnlyDictionary<string, StatementDayVerticalByCategoryTop> Source => (IReadOnlyDictionary<string, StatementDayVerticalByCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByCategoryTop this[string key]
    {
      get
      {
        StatementDayVerticalByCategoryTop verticalByCategoryTop;
        return !this.Source.TryGetValue(key, out verticalByCategoryTop) ? (StatementDayVerticalByCategoryTop) null : verticalByCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByCategoryTop pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByCategoryTop _))
        return;
      StatementDayVerticalByCategoryTop verticalByCategoryTop = new StatementDayVerticalByCategoryTop();
      verticalByCategoryTop.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryTop);
      verticalByCategoryTop.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByCategoryTop info)
    {
      StatementDayVerticalByCategoryTop verticalByCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryTop))
      {
        verticalByCategoryTop = new StatementDayVerticalByCategoryTop();
        verticalByCategoryTop.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, verticalByCategoryTop);
      }
      verticalByCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayVerticalByCategoryTop> infos)
    {
      foreach (StatementDayVerticalByCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByCategoryTop value) => this.Source.TryGetValue(key, out value);
  }
}
