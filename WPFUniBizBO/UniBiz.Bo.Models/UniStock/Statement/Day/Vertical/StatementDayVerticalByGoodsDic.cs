// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByGoodsDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayVerticalByGoods>,
    IEnumerable<KeyValuePair<string, StatementDayVerticalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayVerticalByGoods>>
  {
    private Dictionary<string, StatementDayVerticalByGoods> _Source = new Dictionary<string, StatementDayVerticalByGoods>();

    public IReadOnlyDictionary<string, StatementDayVerticalByGoods> Source => (IReadOnlyDictionary<string, StatementDayVerticalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayVerticalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayVerticalByGoods this[string key]
    {
      get
      {
        StatementDayVerticalByGoods dayVerticalByGoods;
        return !this.Source.TryGetValue(key, out dayVerticalByGoods) ? (StatementDayVerticalByGoods) null : dayVerticalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayVerticalByGoods pData, IList<TGoods> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayVerticalByGoods _))
        return;
      StatementDayVerticalByGoods dayVerticalByGoods = new StatementDayVerticalByGoods();
      dayVerticalByGoods.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, dayVerticalByGoods);
      dayVerticalByGoods.InitInfo(pData, p_Header);
    }

    public void Add(StatementDayVerticalByGoods info)
    {
      StatementDayVerticalByGoods dayVerticalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out dayVerticalByGoods))
      {
        dayVerticalByGoods = new StatementDayVerticalByGoods();
        dayVerticalByGoods.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, dayVerticalByGoods);
      }
      dayVerticalByGoods?.Add(info);
    }

    public void AddRange(IEnumerable<StatementDayVerticalByGoods> infos)
    {
      foreach (StatementDayVerticalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayVerticalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayVerticalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
