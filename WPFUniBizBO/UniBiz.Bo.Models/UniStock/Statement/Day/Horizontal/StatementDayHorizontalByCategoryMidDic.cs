// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByCategoryMidDic
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
  public class StatementDayHorizontalByCategoryMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalByCategoryMid>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalByCategoryMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalByCategoryMid>>
  {
    private Dictionary<string, StatementDayHorizontalByCategoryMid> _Source = new Dictionary<string, StatementDayHorizontalByCategoryMid>();

    public IReadOnlyDictionary<string, StatementDayHorizontalByCategoryMid> Source => (IReadOnlyDictionary<string, StatementDayHorizontalByCategoryMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalByCategoryMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalByCategoryMid this[string key]
    {
      get
      {
        StatementDayHorizontalByCategoryMid horizontalByCategoryMid;
        return !this.Source.TryGetValue(key, out horizontalByCategoryMid) ? (StatementDayHorizontalByCategoryMid) null : horizontalByCategoryMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalByCategoryMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalByCategoryMid _))
        return;
      StatementDayHorizontalByCategoryMid horizontalByCategoryMid = new StatementDayHorizontalByCategoryMid();
      horizontalByCategoryMid.sh_StoreCode = pData.sh_StoreCode;
      horizontalByCategoryMid.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryMid.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryMid.dpt_ID = pData.dpt_ID;
      horizontalByCategoryMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByCategoryMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, horizontalByCategoryMid);
      horizontalByCategoryMid.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalByCategoryMid info)
    {
      StatementDayHorizontalByCategoryMid horizontalByCategoryMid;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryMid))
      {
        horizontalByCategoryMid = new StatementDayHorizontalByCategoryMid();
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
      IEnumerable<StatementDayHorizontalByCategoryMid> infos)
    {
      foreach (StatementDayHorizontalByCategoryMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalByCategoryMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalByCategoryMid value) => this.Source.TryGetValue(key, out value);
  }
}
