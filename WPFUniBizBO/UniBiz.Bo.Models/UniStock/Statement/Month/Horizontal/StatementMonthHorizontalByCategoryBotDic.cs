// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.StatementMonthHorizontalByCategoryBotDic
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
  public class StatementMonthHorizontalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalByCategoryBot>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalByCategoryBot>>
  {
    private Dictionary<string, StatementMonthHorizontalByCategoryBot> _Source = new Dictionary<string, StatementMonthHorizontalByCategoryBot>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalByCategoryBot> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalByCategoryBot this[string key]
    {
      get
      {
        StatementMonthHorizontalByCategoryBot horizontalByCategoryBot;
        return !this.Source.TryGetValue(key, out horizontalByCategoryBot) ? (StatementMonthHorizontalByCategoryBot) null : horizontalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalByCategoryBot pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalByCategoryBot _))
        return;
      StatementMonthHorizontalByCategoryBot horizontalByCategoryBot = new StatementMonthHorizontalByCategoryBot();
      horizontalByCategoryBot.sh_StoreCode = pData.sh_StoreCode;
      horizontalByCategoryBot.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryBot.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryBot.dpt_ID = pData.dpt_ID;
      horizontalByCategoryBot.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByCategoryBot.ctg_lv2_ID = pData.ctg_lv2_ID;
      horizontalByCategoryBot.sd_CategoryCode = pData.sd_CategoryCode;
      this._Source.Add(pData.KeyCode, horizontalByCategoryBot);
      horizontalByCategoryBot.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalByCategoryBot info)
    {
      StatementMonthHorizontalByCategoryBot horizontalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryBot))
      {
        horizontalByCategoryBot = new StatementMonthHorizontalByCategoryBot();
        horizontalByCategoryBot.sh_StoreCode = info.sh_StoreCode;
        horizontalByCategoryBot.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByCategoryBot.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByCategoryBot.dpt_ID = info.dpt_ID;
        horizontalByCategoryBot.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalByCategoryBot.ctg_lv2_ID = info.ctg_lv2_ID;
        horizontalByCategoryBot.sd_CategoryCode = info.sd_CategoryCode;
        this._Source.Add(info.KeyCode, horizontalByCategoryBot);
      }
      horizontalByCategoryBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthHorizontalByCategoryBot> infos)
    {
      foreach (StatementMonthHorizontalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
