// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier.StatementDayHorizontalBySupplierCatBotDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier
{
  public class StatementDayHorizontalBySupplierCatBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatBot>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalBySupplierCatBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalBySupplierCatBot>>
  {
    private Dictionary<string, StatementDayHorizontalBySupplierCatBot> _Source = new Dictionary<string, StatementDayHorizontalBySupplierCatBot>();

    public IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatBot> Source => (IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalBySupplierCatBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalBySupplierCatBot this[string key]
    {
      get
      {
        StatementDayHorizontalBySupplierCatBot bySupplierCatBot;
        return !this.Source.TryGetValue(key, out bySupplierCatBot) ? (StatementDayHorizontalBySupplierCatBot) null : bySupplierCatBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalBySupplierCatBot pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalBySupplierCatBot _))
        return;
      StatementDayHorizontalBySupplierCatBot bySupplierCatBot = new StatementDayHorizontalBySupplierCatBot();
      bySupplierCatBot.sh_StoreCode = pData.sh_StoreCode;
      bySupplierCatBot.sh_Supplier = pData.sh_Supplier;
      bySupplierCatBot.ctg_lv1_ID = pData.ctg_lv1_ID;
      bySupplierCatBot.ctg_lv2_ID = pData.ctg_lv2_ID;
      bySupplierCatBot.sd_CategoryCode = pData.sd_CategoryCode;
      this._Source.Add(pData.KeyCode, bySupplierCatBot);
      bySupplierCatBot.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalBySupplierCatBot info)
    {
      StatementDayHorizontalBySupplierCatBot bySupplierCatBot;
      if (!this._Source.TryGetValue(info.KeyCode, out bySupplierCatBot))
      {
        bySupplierCatBot = new StatementDayHorizontalBySupplierCatBot();
        bySupplierCatBot.sh_StoreCode = info.sh_StoreCode;
        bySupplierCatBot.sh_Supplier = info.sh_Supplier;
        bySupplierCatBot.ctg_lv1_ID = info.ctg_lv1_ID;
        bySupplierCatBot.ctg_lv2_ID = info.ctg_lv2_ID;
        bySupplierCatBot.sd_CategoryCode = info.sd_CategoryCode;
        this._Source.Add(info.KeyCode, bySupplierCatBot);
      }
      bySupplierCatBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayHorizontalBySupplierCatBot> infos)
    {
      foreach (StatementDayHorizontalBySupplierCatBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalBySupplierCatBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalBySupplierCatBot value) => this.Source.TryGetValue(key, out value);
  }
}
