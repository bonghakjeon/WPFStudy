// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentWorkByAlternateKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentWorkByAlternateKeyDic : 
    BindableBase,
    IReadOnlyDictionary<string, PaymentWork>,
    IEnumerable<KeyValuePair<string, PaymentWork>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, PaymentWork>>
  {
    private Dictionary<string, PaymentWork> _Source = new Dictionary<string, PaymentWork>();

    public IReadOnlyDictionary<string, PaymentWork> Source => (IReadOnlyDictionary<string, PaymentWork>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<PaymentWork> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public PaymentWork this[string pKey]
    {
      get
      {
        PaymentWork paymentWork;
        return !this.Source.TryGetValue(pKey, out paymentWork) ? (PaymentWork) null : paymentWork;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(PaymentWork pInfo)
    {
      if (this._Source.TryGetValue(pInfo.AlternateKeyCode, out PaymentWork _))
        return;
      PaymentWork paymentWork = new PaymentWork();
      this._Source.Add(pInfo.AlternateKeyCode, paymentWork);
    }

    public void AddOrigin(PaymentWork pInfo)
    {
      if (this._Source.TryGetValue(pInfo.AlternateKeyCode, out PaymentWork _))
        return;
      PaymentWork paymentWork = pInfo;
      this._Source.Add(pInfo.AlternateKeyCode, paymentWork);
    }

    public void AddOriginAutoDeduction(PaymentWork pInfo)
    {
      if (this._Source.TryGetValue(pInfo.AutoDeductionKeyCode, out PaymentWork _))
        return;
      PaymentWork paymentWork = pInfo;
      this._Source.Add(pInfo.AutoDeductionKeyCode, paymentWork);
    }

    public void AddRange(IEnumerable<PaymentWork> pInfos)
    {
      foreach (PaymentWork pInfo in pInfos)
        this.Add(pInfo);
    }

    public void AddRange(IList<PaymentWork> pInfos)
    {
      foreach (PaymentWork pInfo in (IEnumerable<PaymentWork>) pInfos)
        this.Add(pInfo);
    }

    public void AddRangeOrigin(IEnumerable<PaymentWork> pInfos)
    {
      foreach (PaymentWork pInfo in pInfos)
        this.AddOrigin(pInfo);
    }

    public void AddRangeOrigin(IList<PaymentWork> pInfos)
    {
      foreach (PaymentWork pInfo in (IEnumerable<PaymentWork>) pInfos)
        this.AddOrigin(pInfo);
    }

    public void AddRangeOriginAutoDeduction(IEnumerable<PaymentWork> pInfos)
    {
      foreach (PaymentWork pInfo in pInfos)
        this.AddOriginAutoDeduction(pInfo);
    }

    public void AddRangeOriginAutoDeduction(IList<PaymentWork> pInfos)
    {
      foreach (PaymentWork pInfo in (IEnumerable<PaymentWork>) pInfos)
        this.AddOriginAutoDeduction(pInfo);
    }

    public bool ContainsKey(string pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<string, PaymentWork>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string pKey, [MaybeNullWhen(false)] out PaymentWork pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
