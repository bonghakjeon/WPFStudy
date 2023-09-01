// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier.StatementDayHorizontalBySupplierCatMidDic
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
  public class StatementDayHorizontalBySupplierCatMidDic : 
    BindableBase,
    IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatMid>,
    IEnumerable<KeyValuePair<string, StatementDayHorizontalBySupplierCatMid>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, StatementDayHorizontalBySupplierCatMid>>
  {
    private Dictionary<string, StatementDayHorizontalBySupplierCatMid> _Source = new Dictionary<string, StatementDayHorizontalBySupplierCatMid>();

    public IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatMid> Source => (IReadOnlyDictionary<string, StatementDayHorizontalBySupplierCatMid>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<StatementDayHorizontalBySupplierCatMid> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public StatementDayHorizontalBySupplierCatMid this[string key]
    {
      get
      {
        StatementDayHorizontalBySupplierCatMid bySupplierCatMid;
        return !this.Source.TryGetValue(key, out bySupplierCatMid) ? (StatementDayHorizontalBySupplierCatMid) null : bySupplierCatMid;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(StatementDayHorizontalBySupplierCatMid pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out StatementDayHorizontalBySupplierCatMid _))
        return;
      StatementDayHorizontalBySupplierCatMid bySupplierCatMid = new StatementDayHorizontalBySupplierCatMid();
      bySupplierCatMid.sh_StoreCode = pData.sh_StoreCode;
      bySupplierCatMid.sh_Supplier = pData.sh_Supplier;
      bySupplierCatMid.ctg_lv1_ID = pData.ctg_lv1_ID;
      bySupplierCatMid.ctg_lv2_ID = pData.ctg_lv2_ID;
      this._Source.Add(pData.KeyCode, bySupplierCatMid);
      bySupplierCatMid.InitInfo(pData, p_Days);
    }

    public void Add(StatementDayHorizontalBySupplierCatMid info)
    {
      StatementDayHorizontalBySupplierCatMid bySupplierCatMid;
      if (!this._Source.TryGetValue(info.KeyCode, out bySupplierCatMid))
      {
        bySupplierCatMid = new StatementDayHorizontalBySupplierCatMid();
        bySupplierCatMid.sh_StoreCode = info.sh_StoreCode;
        bySupplierCatMid.sh_Supplier = info.sh_Supplier;
        bySupplierCatMid.ctg_lv1_ID = info.ctg_lv1_ID;
        bySupplierCatMid.ctg_lv2_ID = info.ctg_lv2_ID;
        this._Source.Add(info.KeyCode, bySupplierCatMid);
      }
      bySupplierCatMid?.Add(info);
    }

    public void AddRange(
      IEnumerable<StatementDayHorizontalBySupplierCatMid> infos)
    {
      foreach (StatementDayHorizontalBySupplierCatMid info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, StatementDayHorizontalBySupplierCatMid>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out StatementDayHorizontalBySupplierCatMid value) => this.Source.TryGetValue(key, out value);
  }
}
