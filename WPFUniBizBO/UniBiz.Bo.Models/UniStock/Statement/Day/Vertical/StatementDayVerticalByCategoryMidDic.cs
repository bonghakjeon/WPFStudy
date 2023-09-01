// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByCategoryMidDic
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
  public class StatementDayVerticalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByCategoryMid>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByCategoryMid>>
  {
    private Dictionary<string, StatementDayVerticalByCategoryMid> _Source = new Dictionary<string, StatementDayVerticalByCategoryMid>();

    public IReadOnlyDictionary<string, StatementDayVerticalByCategoryMid> Source => (IReadOnlyDictionary<string, StatementDayVerticalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByCategoryMid this[string key]
    {
      get
      {
        StatementDayVerticalByCategoryMid verticalByCategoryMid;
        return !this.Source.TryGetValue(key, out verticalByCategoryMid) ? (StatementDayVerticalByCategoryMid) null : verticalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByCategoryMid pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByCategoryMid _))
        return;
      StatementDayVerticalByCategoryMid verticalByCategoryMid = new StatementDayVerticalByCategoryMid();
      verticalByCategoryMid.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryMid);
      verticalByCategoryMid.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByCategoryMid info)
    {
      StatementDayVerticalByCategoryMid verticalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryMid))
      {
        verticalByCategoryMid = new StatementDayVerticalByCategoryMid();
        verticalByCategoryMid.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, verticalByCategoryMid);
      }
      verticalByCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayVerticalByCategoryMid> infos)
    {
      foreach (StatementDayVerticalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
