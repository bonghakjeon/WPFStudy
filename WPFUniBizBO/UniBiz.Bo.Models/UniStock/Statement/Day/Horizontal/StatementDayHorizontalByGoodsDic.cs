// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByGoodsDic
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
  public class StatementDayHorizontalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalByGoods>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalByGoods>>
  {
    private Dictionary<string, StatementDayHorizontalByGoods> _Source = new Dictionary<string, StatementDayHorizontalByGoods>();

    public IReadOnlyDictionary<string, StatementDayHorizontalByGoods> Source => (IReadOnlyDictionary<string, StatementDayHorizontalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalByGoods this[string key]
    {
      get
      {
        StatementDayHorizontalByGoods horizontalByGoods;
        return !this.Source.TryGetValue(key, out horizontalByGoods) ? (StatementDayHorizontalByGoods) null : horizontalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalByGoods pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalByGoods _))
        return;
      StatementDayHorizontalByGoods horizontalByGoods = new StatementDayHorizontalByGoods();
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

    public void Add(StatementDayHorizontalByGoods info)
    {
      StatementDayHorizontalByGoods horizontalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByGoods))
      {
        horizontalByGoods = new StatementDayHorizontalByGoods();
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

    public void AddRange(IEnumerable<StatementDayHorizontalByGoods> infos)
    {
      foreach (StatementDayHorizontalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
