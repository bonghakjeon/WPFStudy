// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByGoodsDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthVerticalByGoods>,
    IEnumerable<KeyValuePair<string, StatementMonthVerticalByGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthVerticalByGoods>>
  {
    private Dictionary<string, StatementMonthVerticalByGoods> _Source = new Dictionary<string, StatementMonthVerticalByGoods>();

    public IReadOnlyDictionary<string, StatementMonthVerticalByGoods> Source => (IReadOnlyDictionary<string, StatementMonthVerticalByGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthVerticalByGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthVerticalByGoods this[string key]
    {
      get
      {
        StatementMonthVerticalByGoods monthVerticalByGoods;
        return !this.Source.TryGetValue(key, out monthVerticalByGoods) ? (StatementMonthVerticalByGoods) null : monthVerticalByGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthVerticalByGoods pData, IList<TGoods> p_Header)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthVerticalByGoods _))
        return;
      StatementMonthVerticalByGoods monthVerticalByGoods = new StatementMonthVerticalByGoods();
      monthVerticalByGoods.sh_ConfirmDate = pData.sh_ConfirmDate;
      this._Source.Add(pData.KeyCode, monthVerticalByGoods);
      monthVerticalByGoods.InitInfo(pData, p_Header);
    }

    public void Add(StatementMonthVerticalByGoods info)
    {
      StatementMonthVerticalByGoods monthVerticalByGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out monthVerticalByGoods))
      {
        monthVerticalByGoods = new StatementMonthVerticalByGoods();
        monthVerticalByGoods.sh_ConfirmDate = info.sh_ConfirmDate;
        this._Source.Add(info.KeyCode, monthVerticalByGoods);
      }
      monthVerticalByGoods?.Add(info);
    }

    public void AddRange(IEnumerable<StatementMonthVerticalByGoods> infos)
    {
      foreach (StatementMonthVerticalByGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthVerticalByGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthVerticalByGoods value) => this.Source.TryGetValue(key, out value);
  }
}
