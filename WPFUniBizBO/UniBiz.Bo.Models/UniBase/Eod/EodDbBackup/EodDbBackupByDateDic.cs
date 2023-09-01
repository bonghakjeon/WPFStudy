// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodDbBackup.EodDbBackupByDateDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Eod.EodDbBackup
{
  public class EodDbBackupByDateDic : 
    BindableBase,
    IReadOnlyDictionary<DateTime, EodDbBackupByDate>,
    IEnumerable<KeyValuePair<DateTime, EodDbBackupByDate>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<DateTime, EodDbBackupByDate>>
  {
    private Dictionary<DateTime, EodDbBackupByDate> _Source = new Dictionary<DateTime, EodDbBackupByDate>();

    public IReadOnlyDictionary<DateTime, EodDbBackupByDate> Source => (IReadOnlyDictionary<DateTime, EodDbBackupByDate>) this._Source;

    public IEnumerable<DateTime> Keys => this.Source.Keys;

    public IEnumerable<EodDbBackupByDate> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public EodDbBackupByDate this[DateTime key]
    {
      get
      {
        EodDbBackupByDate eodDbBackupByDate;
        return !this.Source.TryGetValue(key, out eodDbBackupByDate) ? (EodDbBackupByDate) null : eodDbBackupByDate;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(EodDbBackupView info)
    {
      EodDbBackupByDate eodDbBackupByDate;
      if (!this._Source.TryGetValue(info.eodb_date.Value, out eodDbBackupByDate))
      {
        eodDbBackupByDate = new EodDbBackupByDate(info.eodb_date.Value);
        this._Source.Add(info.eodb_date.Value, eodDbBackupByDate);
      }
      eodDbBackupByDate?.Add(info);
    }

    public void AddRange(IEnumerable<EodDbBackupView> infos)
    {
      foreach (EodDbBackupView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(DateTime key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<DateTime, EodDbBackupByDate>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(DateTime key, [MaybeNullWhen(false)] out EodDbBackupByDate value) => this.Source.TryGetValue(key, out value);
  }
}
