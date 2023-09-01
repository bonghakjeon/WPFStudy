// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByCategoryBotDic
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
  public class StatementMonthVerticalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByCategoryBot>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByCategoryBot>>
  {
    private Dictionary<string, StatementMonthVerticalByCategoryBot> _Source = new Dictionary<string, StatementMonthVerticalByCategoryBot>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByCategoryBot> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByCategoryBot this[string key]
    {
      get
      {
        StatementMonthVerticalByCategoryBot verticalByCategoryBot;
        return !this.Source.TryGetValue(key, out verticalByCategoryBot) ? (StatementMonthVerticalByCategoryBot) null : verticalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByCategoryBot pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByCategoryBot _))
        return;
      StatementMonthVerticalByCategoryBot verticalByCategoryBot = new StatementMonthVerticalByCategoryBot();
      verticalByCategoryBot.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryBot);
      verticalByCategoryBot.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByCategoryBot info)
    {
      StatementMonthVerticalByCategoryBot verticalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryBot))
      {
        verticalByCategoryBot = new StatementMonthVerticalByCategoryBot();
        verticalByCategoryBot.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, verticalByCategoryBot);
      }
      verticalByCategoryBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthVerticalByCategoryBot> infos)
    {
      foreach (StatementMonthVerticalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
