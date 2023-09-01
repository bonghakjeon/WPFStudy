// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.StatementMonthHorizontalByCategoryMidDic
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
  public class StatementMonthHorizontalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalByCategoryMid>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalByCategoryMid>>
  {
    private Dictionary<string, StatementMonthHorizontalByCategoryMid> _Source = new Dictionary<string, StatementMonthHorizontalByCategoryMid>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalByCategoryMid> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalByCategoryMid this[string key]
    {
      get
      {
        StatementMonthHorizontalByCategoryMid horizontalByCategoryMid;
        return !this.Source.TryGetValue(key, out horizontalByCategoryMid) ? (StatementMonthHorizontalByCategoryMid) null : horizontalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalByCategoryMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalByCategoryMid _))
        return;
      StatementMonthHorizontalByCategoryMid horizontalByCategoryMid = new StatementMonthHorizontalByCategoryMid();
      horizontalByCategoryMid.sh_StoreCode = pData.sh_StoreCode;
      horizontalByCategoryMid.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryMid.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryMid.dpt_ID = pData.dpt_ID;
      horizontalByCategoryMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByCategoryMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByCategoryMid);
      horizontalByCategoryMid.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalByCategoryMid info)
    {
      StatementMonthHorizontalByCategoryMid horizontalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryMid))
      {
        horizontalByCategoryMid = new StatementMonthHorizontalByCategoryMid();
        horizontalByCategoryMid.sh_StoreCode = info.sh_StoreCode;
        horizontalByCategoryMid.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByCategoryMid.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByCategoryMid.dpt_ID = info.dpt_ID;
        horizontalByCategoryMid.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalByCategoryMid.ctg_lv2_ID = info.ctg_lv2_ID;
        this._Source.Add(info.KeyCode, horizontalByCategoryMid);
      }
      horizontalByCategoryMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthHorizontalByCategoryMid> infos)
    {
      foreach (StatementMonthHorizontalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
