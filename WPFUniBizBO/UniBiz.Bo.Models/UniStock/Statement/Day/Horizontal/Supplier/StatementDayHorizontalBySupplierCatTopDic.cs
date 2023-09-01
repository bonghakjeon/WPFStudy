// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier.StatementDayHorizontalBySupplierCatTopDic
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
  public class StatementDayHorizontalBySupplierCatTopDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatTop>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalBySupplierCatTop>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalBySupplierCatTop>>
  {
    private Dictionary<string, StatementDayHorizontalBySupplierCatTop> _Source = new Dictionary<string, StatementDayHorizontalBySupplierCatTop>();

    public IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatTop> Source => (IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatTop>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalBySupplierCatTop> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalBySupplierCatTop this[string key]
    {
      get
      {
        StatementDayHorizontalBySupplierCatTop bySupplierCatTop;
        return !this.Source.TryGetValue(key, out bySupplierCatTop) ? (StatementDayHorizontalBySupplierCatTop) null : bySupplierCatTop;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalBySupplierCatTop pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalBySupplierCatTop _))
        return;
      StatementDayHorizontalBySupplierCatTop bySupplierCatTop = new StatementDayHorizontalBySupplierCatTop();
      bySupplierCatTop.sh_StoreCode = pData.sh_StoreCode;
      bySupplierCatTop.sh_Supplier = pData.sh_Supplier;
      bySupplierCatTop.ctg_lv1_ID = pData.ctg_lv1_ID;
      this._Source.Add(pData.KeyCode, bySupplierCatTop);
      bySupplierCatTop.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalBySupplierCatTop info)
    {
      StatementDayHorizontalBySupplierCatTop bySupplierCatTop;
      if (!this._Source.TryGetValue(info.KeyCode, out bySupplierCatTop))
      {
        bySupplierCatTop = new StatementDayHorizontalBySupplierCatTop();
        bySupplierCatTop.sh_StoreCode = info.sh_StoreCode;
        bySupplierCatTop.sh_Supplier = info.sh_Supplier;
        bySupplierCatTop.ctg_lv1_ID = info.ctg_lv1_ID;
        this._Source.Add(info.KeyCode, bySupplierCatTop);
      }
      bySupplierCatTop?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayHorizontalBySupplierCatTop> infos)
    {
      foreach (StatementDayHorizontalBySupplierCatTop info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalBySupplierCatTop>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalBySupplierCatTop value) => this.Source.TryGetValue(key, out value);
  }
}
