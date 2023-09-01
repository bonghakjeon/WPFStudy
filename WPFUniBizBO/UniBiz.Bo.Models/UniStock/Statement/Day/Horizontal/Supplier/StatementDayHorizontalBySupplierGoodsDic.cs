// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier.StatementDayHorizontalBySupplierGoodsDic
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
  public class StatementDayHorizontalBySupplierGoodsDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalBySupplierGoods>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalBySupplierGoods>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalBySupplierGoods>>
  {
    private Dictionary<string, StatementDayHorizontalBySupplierGoods> _Source = new Dictionary<string, StatementDayHorizontalBySupplierGoods>();

    public IReadOnlyDictionary<string, StatementDayHorizontalBySupplierGoods> Source => (IReadOnlyDictionary<string, StatementDayHorizontalBySupplierGoods>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalBySupplierGoods> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalBySupplierGoods this[string key]
    {
      get
      {
        StatementDayHorizontalBySupplierGoods horizontalBySupplierGoods;
        return !this.Source.TryGetValue(key, out horizontalBySupplierGoods) ? (StatementDayHorizontalBySupplierGoods) null : horizontalBySupplierGoods;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalBySupplierGoods pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalBySupplierGoods _))
        return;
      StatementDayHorizontalBySupplierGoods horizontalBySupplierGoods = new StatementDayHorizontalBySupplierGoods();
      horizontalBySupplierGoods.sh_StoreCode = pData.sh_StoreCode;
      horizontalBySupplierGoods.sh_Supplier = pData.sh_Supplier;
      horizontalBySupplierGoods.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalBySupplierGoods.ctg_lv2_ID = pData.ctg_lv2_ID;
      horizontalBySupplierGoods.sd_CategoryCode = pData.sd_CategoryCode;
      horizontalBySupplierGoods.sd_BoxCode = pData.sd_BoxCode;
      this._Source.Add(pData.KeyCode, horizontalBySupplierGoods);
      horizontalBySupplierGoods.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalBySupplierGoods info)
    {
      StatementDayHorizontalBySupplierGoods horizontalBySupplierGoods;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalBySupplierGoods))
      {
        horizontalBySupplierGoods = new StatementDayHorizontalBySupplierGoods();
        horizontalBySupplierGoods.sh_StoreCode = info.sh_StoreCode;
        horizontalBySupplierGoods.sh_Supplier = info.sh_Supplier;
        horizontalBySupplierGoods.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalBySupplierGoods.ctg_lv2_ID = info.ctg_lv2_ID;
        horizontalBySupplierGoods.sd_CategoryCode = info.sd_CategoryCode;
        horizontalBySupplierGoods.sd_BoxCode = info.sd_BoxCode;
        this._Source.Add(info.KeyCode, horizontalBySupplierGoods);
      }
      horizontalBySupplierGoods?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayHorizontalBySupplierGoods> infos)
    {
      foreach (StatementDayHorizontalBySupplierGoods info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalBySupplierGoods>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalBySupplierGoods value) => this.Source.TryGetValue(key, out value);
  }
}
