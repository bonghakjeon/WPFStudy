// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical.SaleByTimeDateVerticalByHourDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical
{
  public class SaleByTimeDateVerticalByHourDic : 
    BindableBase,
    IReadOnlyDictionary<int, SaleByTimeDateVerticalByHour>,
    IEnumerable<KeyValuePair<int, SaleByTimeDateVerticalByHour>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, SaleByTimeDateVerticalByHour>>
  {
    private Dictionary<int, SaleByTimeDateVerticalByHour> _Source = new Dictionary<int, SaleByTimeDateVerticalByHour>();

    public IReadOnlyDictionary<int, SaleByTimeDateVerticalByHour> Source => (IReadOnlyDictionary<int, SaleByTimeDateVerticalByHour>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<SaleByTimeDateVerticalByHour> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SaleByTimeDateVerticalByHour this[int key]
    {
      get
      {
        SaleByTimeDateVerticalByHour dateVerticalByHour;
        return !this.Source.TryGetValue(key, out dateVerticalByHour) ? (SaleByTimeDateVerticalByHour) null : dateVerticalByHour;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(SaleByTimeDateVertical info)
    {
      SaleByTimeDateVerticalByHour dateVerticalByHour;
      if (!this._Source.TryGetValue(info.sbt_Time, out dateVerticalByHour))
      {
        dateVerticalByHour = new SaleByTimeDateVerticalByHour(info.sbt_Time);
        this._Source.Add(info.sbt_Time, dateVerticalByHour);
      }
      dateVerticalByHour?.Add(info);
    }

    public void AddRange(IEnumerable<SaleByTimeDateVertical> infos)
    {
      foreach (SaleByTimeDateVertical info in infos)
        this.Add(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, SaleByTimeDateVerticalByHour>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out SaleByTimeDateVerticalByHour value) => this.Source.TryGetValue(key, out value);
  }
}
