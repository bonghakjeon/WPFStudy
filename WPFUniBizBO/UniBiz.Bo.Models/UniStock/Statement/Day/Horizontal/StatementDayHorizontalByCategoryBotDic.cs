// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByCategoryBotDic
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
  public class StatementDayHorizontalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalByCategoryBot>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalByCategoryBot>>
  {
    private Dictionary<string, StatementDayHorizontalByCategoryBot> _Source = new Dictionary<string, StatementDayHorizontalByCategoryBot>();

    public IReadOnlyDictionary<string, StatementDayHorizontalByCategoryBot> Source => (IReadOnlyDictionary<string, StatementDayHorizontalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalByCategoryBot this[string key]
    {
      get
      {
        StatementDayHorizontalByCategoryBot horizontalByCategoryBot;
        return !this.Source.TryGetValue(key, out horizontalByCategoryBot) ? (StatementDayHorizontalByCategoryBot) null : horizontalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalByCategoryBot pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalByCategoryBot _))
        return;
      StatementDayHorizontalByCategoryBot horizontalByCategoryBot = new StatementDayHorizontalByCategoryBot();
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

    public void Add(StatementDayHorizontalByCategoryBot info)
    {
      StatementDayHorizontalByCategoryBot horizontalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryBot))
      {
        horizontalByCategoryBot = new StatementDayHorizontalByCategoryBot();
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
      IEnumerable<StatementDayHorizontalByCategoryBot> infos)
    {
      foreach (StatementDayHorizontalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
