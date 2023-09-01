// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.StatementMonthHorizontalByGoodsDic
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
  public class StatementMonthHorizontalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalByGoods>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalByGoods>>
  {
    private Dictionary<string, StatementMonthHorizontalByGoods> _Source = new Dictionary<string, StatementMonthHorizontalByGoods>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalByGoods> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalByGoods this[string key]
    {
      get
      {
        StatementMonthHorizontalByGoods horizontalByGoods;
        return !this.Source.TryGetValue(key, out horizontalByGoods) ? (StatementMonthHorizontalByGoods) null : horizontalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalByGoods pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalByGoods _))
        return;
      StatementMonthHorizontalByGoods horizontalByGoods = new StatementMonthHorizontalByGoods();
      horizontalByGoods.sh_StoreCode = pData.sh_StoreCode;
      horizontalByGoods.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByGoods.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByGoods.dpt_ID = pData.dpt_ID;
      horizontalByGoods.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByGoods.ctg_lv2_ID = pData.ctg_lv2_ID;
      horizontalByGoods.sd_CategoryCode = pData.sd_CategoryCode;
      horizontalByGoods.sd_BoxCode = pData.sd_BoxCode;
      this._Source.Add(pData.KeyCode, horizontalByGoods);
      horizontalByGoods.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalByGoods info)
    {
      StatementMonthHorizontalByGoods horizontalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByGoods))
      {
        horizontalByGoods = new StatementMonthHorizontalByGoods();
        horizontalByGoods.sh_StoreCode = info.sh_StoreCode;
        horizontalByGoods.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByGoods.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByGoods.dpt_ID = info.dpt_ID;
        horizontalByGoods.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalByGoods.ctg_lv2_ID = info.ctg_lv2_ID;
        horizontalByGoods.sd_CategoryCode = info.sd_CategoryCode;
        horizontalByGoods.sd_BoxCode = info.sd_BoxCode;
        this._Source.Add(info.KeyCode, horizontalByGoods);
      }
      horizontalByGoods?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthHorizontalByGoods> infos)
    {
      foreach (StatementMonthHorizontalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
