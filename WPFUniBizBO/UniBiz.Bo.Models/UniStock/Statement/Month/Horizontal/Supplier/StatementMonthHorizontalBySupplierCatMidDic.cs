// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.Supplier.StatementMonthHorizontalBySupplierCatMidDic
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
  public class StatementMonthHorizontalBySupplierCatMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementMonthHorizontalBySupplierCatMid>,
    IEnumerable<KeyValuePair<string, StatementMonthHorizontalBySupplierCatMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementMonthHorizontalBySupplierCatMid>>
  {
    private Dictionary<string, StatementMonthHorizontalBySupplierCatMid> _Source = new Dictionary<string, StatementMonthHorizontalBySupplierCatMid>();

    public IReadOnlyDictionary<string, StatementMonthHorizontalBySupplierCatMid> Source => (IReadOnlyDictionary<string, StatementMonthHorizontalBySupplierCatMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementMonthHorizontalBySupplierCatMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementMonthHorizontalBySupplierCatMid this[string key]
    {
      get
      {
        StatementMonthHorizontalBySupplierCatMid bySupplierCatMid;
        return !this.Source.TryGetValue(key, out bySupplierCatMid) ? (StatementMonthHorizontalBySupplierCatMid) null : bySupplierCatMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementMonthHorizontalBySupplierCatMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementMonthHorizontalBySupplierCatMid _))
        return;
      StatementMonthHorizontalBySupplierCatMid bySupplierCatMid = new StatementMonthHorizontalBySupplierCatMid();
      bySupplierCatMid.sh_StoreCode = pData.sh_StoreCode;
      bySupplierCatMid.sh_Supplier = pData.sh_Supplier;
      bySupplierCatMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      bySupplierCatMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, bySupplierCatMid);
      bySupplierCatMid.InitInfo(pData, p_Days);
    }

    public void Add(StatementMonthHorizontalBySupplierCatMid info)
    {
      StatementMonthHorizontalBySupplierCatMid bySupplierCatMid;
      if (!this._Source.TryGetValue(info.KeyCode, out bySupplierCatMid))
      {
        bySupplierCatMid = new StatementMonthHorizontalBySupplierCatMid();
        bySupplierCatMid.sh_StoreCode = info.sh_StoreCode;
        bySupplierCatMid.sh_Supplier = info.sh_Supplier;
        bySupplierCatMid.ctg_lv1_ID = info.ctg_lv1_ID;
        bySupplierCatMid.ctg_lv2_ID = info.ctg_lv2_ID;
        this._Source.Add(info.KeyCode, bySupplierCatMid);
      }
      bySupplierCatMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementMonthHorizontalBySupplierCatMid> infos)
    {
      foreach (StatementMonthHorizontalBySupplierCatMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementMonthHorizontalBySupplierCatMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementMonthHorizontalBySupplierCatMid value) => this.Source.TryGetValue(key, out value);
  }
}
