// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodInfo.EodInfoByDateDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Eod.EodInfo
{
  public class EodInfoByDateDic : 
    BindableBase,
    IReadOnlyDictionary<DateTime, EodInfoByDate>,
    IEnumerable<KeyValuePair<DateTime, EodInfoByDate>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<DateTime, EodInfoByDate>>
  {
    private Dictionary<DateTime, EodInfoByDate> _Source = new Dictionary<DateTime, EodInfoByDate>();

    public IReadOnlyDictionary<DateTime, EodInfoByDate> Source => (IReadOnlyDictionary<DateTime, EodInfoByDate>) this._Source;

    public IEnumerable<DateTime> Keys => this.Source.Keys;

    public IEnumerable<EodInfoByDate> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public EodInfoByDate this[DateTime key]
    {
      get
      {
        EodInfoByDate eodInfoByDate;
        return !this.Source.TryGetValue(key, out eodInfoByDate) ? (EodInfoByDate) null : eodInfoByDate;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(EodInfoView info)
    {
      EodInfoByDate eodInfoByDate;
      if (!this._Source.TryGetValue(info.eod_Date.Value, out eodInfoByDate))
      {
        eodInfoByDate = new EodInfoByDate(info.eod_Date.Value);
        this._Source.Add(info.eod_Date.Value, eodInfoByDate);
      }
      eodInfoByDate?.Add(info);
    }

    public void AddRange(IEnumerable<EodInfoView> infos)
    {
      foreach (EodInfoView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(DateTime key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<DateTime, EodInfoByDate>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(DateTime key, [MaybeNullWhen(false)] out EodInfoByDate value) => this.Source.TryGetValue(key, out value);
  }
}
