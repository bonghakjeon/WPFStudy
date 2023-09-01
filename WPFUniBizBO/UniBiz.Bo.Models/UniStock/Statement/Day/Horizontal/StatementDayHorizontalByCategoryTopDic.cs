// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByCategoryTopDic
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
  public class StatementDayHorizontalByCategoryTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalByCategoryTop>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalByCategoryTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalByCategoryTop>>
  {
    private Dictionary<string, StatementDayHorizontalByCategoryTop> _Source = new Dictionary<string, StatementDayHorizontalByCategoryTop>();

    public IReadOnlyDictionary<string, StatementDayHorizontalByCategoryTop> Source => (IReadOnlyDictionary<string, StatementDayHorizontalByCategoryTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalByCategoryTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalByCategoryTop this[string key]
    {
      get
      {
        StatementDayHorizontalByCategoryTop horizontalByCategoryTop;
        return !this.Source.TryGetValue(key, out horizontalByCategoryTop) ? (StatementDayHorizontalByCategoryTop) null : horizontalByCategoryTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalByCategoryTop pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalByCategoryTop _))
        return;
      StatementDayHorizontalByCategoryTop horizontalByCategoryTop = new StatementDayHorizontalByCategoryTop();
      horizontalByCategoryTop.sh_StoreCode = pData.sh_StoreCode;
      horizontalByCategoryTop.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryTop.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryTop.dpt_ID = pData.dpt_ID;
      horizontalByCategoryTop.ctg_lv1_ID = pData.ctg_lv1_ID;
      this._Source.Add(pData.KeyCode, horizontalByCategoryTop);
      horizontalByCategoryTop.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalByCategoryTop info)
    {
      StatementDayHorizontalByCategoryTop horizontalByCategoryTop;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryTop))
      {
        horizontalByCategoryTop = new StatementDayHorizontalByCategoryTop();
        horizontalByCategoryTop.sh_StoreCode = info.sh_StoreCode;
        horizontalByCategoryTop.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByCategoryTop.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByCategoryTop.dpt_ID = info.dpt_ID;
        horizontalByCategoryTop.ctg_lv1_ID = info.ctg_lv1_ID;
        this._Source.Add(info.KeyCode, horizontalByCategoryTop);
      }
      horizontalByCategoryTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayHorizontalByCategoryTop> infos)
    {
      foreach (StatementDayHorizontalByCategoryTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalByCategoryTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalByCategoryTop value) => this.Source.TryGetValue(key, out value);
  }
}
