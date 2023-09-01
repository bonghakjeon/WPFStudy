// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByCategoryBotDic
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
  public class StatementDayVerticalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByCategoryBot>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByCategoryBot>>
  {
    private Dictionary<string, StatementDayVerticalByCategoryBot> _Source = new Dictionary<string, StatementDayVerticalByCategoryBot>();

    public IReadOnlyDictionary<string, StatementDayVerticalByCategoryBot> Source => (IReadOnlyDictionary<string, StatementDayVerticalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByCategoryBot this[string key]
    {
      get
      {
        StatementDayVerticalByCategoryBot verticalByCategoryBot;
        return !this.Source.TryGetValue(key, out verticalByCategoryBot) ? (StatementDayVerticalByCategoryBot) null : verticalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByCategoryBot pData, IList<CategoryView> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByCategoryBot _))
        return;
      StatementDayVerticalByCategoryBot verticalByCategoryBot = new StatementDayVerticalByCategoryBot();
      verticalByCategoryBot.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, verticalByCategoryBot);
      verticalByCategoryBot.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByCategoryBot info)
    {
      StatementDayVerticalByCategoryBot verticalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out verticalByCategoryBot))
      {
        verticalByCategoryBot = new StatementDayVerticalByCategoryBot();
        verticalByCategoryBot.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, verticalByCategoryBot);
      }
      verticalByCategoryBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayVerticalByCategoryBot> infos)
    {
      foreach (StatementDayVerticalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
