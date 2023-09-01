// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier.StatementDayHorizontalBySupplierDic
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
  public class StatementDayHorizontalBySupplierDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalBySupplier>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalBySupplier>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalBySupplier>>
  {
    private Dictionary<string, StatementDayHorizontalBySupplier> _Source = new Dictionary<string, StatementDayHorizontalBySupplier>();

    public IReadOnlyDictionary<string, StatementDayHorizontalBySupplier> Source => (IReadOnlyDictionary<string, StatementDayHorizontalBySupplier>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalBySupplier> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalBySupplier this[string key]
    {
      get
      {
        StatementDayHorizontalBySupplier horizontalBySupplier;
        return !this.Source.TryGetValue(key, out horizontalBySupplier) ? (StatementDayHorizontalBySupplier) null : horizontalBySupplier;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalBySupplier pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalBySupplier _))
        return;
      StatementDayHorizontalBySupplier horizontalBySupplier = new StatementDayHorizontalBySupplier();
      horizontalBySupplier.sh_StoreCode = pData.sh_StoreCode;
      horizontalBySupplier.sh_Supplier = pData.sh_Supplier;
      this._Source.Add(pData.KeyCode, horizontalBySupplier);
      horizontalBySupplier.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalBySupplier info)
    {
      StatementDayHorizontalBySupplier horizontalBySupplier;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalBySupplier))
      {
        horizontalBySupplier = new StatementDayHorizontalBySupplier();
        horizontalBySupplier.sh_StoreCode = info.sh_StoreCode;
        horizontalBySupplier.sh_Supplier = info.sh_Supplier;
        this._Source.Add(info.KeyCode, horizontalBySupplier);
      }
      horizontalBySupplier?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayHorizontalBySupplier> infos)
    {
      foreach (StatementDayHorizontalBySupplier info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalBySupplier>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalBySupplier value) => this.Source.TryGetValue(key, out value);
  }
}
