// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.Supplier.StatementMonthHorizontalBySupplierDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.Supplier
{
  public class StatementMonthHorizontalBySupplierDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalBySupplier>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalBySupplier>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalBySupplier>>
  {
    private Dictionary<string, StatementMonthHorizontalBySupplier> _Source = new Dictionary<string, StatementMonthHorizontalBySupplier>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalBySupplier> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalBySupplier>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalBySupplier> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalBySupplier this[string key]
    {
      get
      {
        StatementMonthHorizontalBySupplier horizontalBySupplier;
        return !this.Source.TryGetValue(key, out horizontalBySupplier) ? (StatementMonthHorizontalBySupplier) null : horizontalBySupplier;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalBySupplier pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalBySupplier _))
        return;
      StatementMonthHorizontalBySupplier horizontalBySupplier = new StatementMonthHorizontalBySupplier();
      horizontalBySupplier.sh_StoreCode = pData.sh_StoreCode;
      horizontalBySupplier.sh_Supplier = pData.sh_Supplier;
      this._Source.Add(pData.KeyCode, horizontalBySupplier);
      horizontalBySupplier.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalBySupplier info)
    {
      StatementMonthHorizontalBySupplier horizontalBySupplier;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalBySupplier))
      {
        horizontalBySupplier = new StatementMonthHorizontalBySupplier();
        horizontalBySupplier.sh_StoreCode = info.sh_StoreCode;
        horizontalBySupplier.sh_Supplier = info.sh_Supplier;
        this._Source.Add(info.KeyCode, horizontalBySupplier);
      }
      horizontalBySupplier?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthHorizontalBySupplier> infos)
    {
      foreach (StatementMonthHorizontalBySupplier info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalBySupplier>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalBySupplier value) => this.Source.TryGetValue(key, out value);
  }
}
