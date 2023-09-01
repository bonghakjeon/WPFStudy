// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentByCodeDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentByCodeDic : 
    BindableBase,
    IReadOnlyDictionary<long, PaymentView>,
    IEnumerable<KeyValuePair<long, PaymentView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, PaymentView>>
  {
    private Dictionary<long, PaymentView> _Source = new Dictionary<long, PaymentView>();

    public IReadOnlyDictionary<long, PaymentView> Source => (IReadOnlyDictionary<long, PaymentView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<PaymentView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public PaymentView this[long key]
    {
      get
      {
        PaymentView paymentView;
        return !this.Source.TryGetValue(key, out paymentView) ? (PaymentView) null : paymentView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(PaymentView info)
    {
      if (this._Source.TryGetValue(info.pay_Code, out PaymentView _))
        return;
      PaymentView paymentView = new PaymentView();
      paymentView.pay_Code = info.pay_Code;
      this._Source.Add(info.pay_Code, paymentView);
    }

    public void AddRange(IEnumerable<PaymentView> infos)
    {
      foreach (PaymentView info in infos)
        this.Add(info);
    }

    public void AddOrigin(PaymentView info)
    {
      if (this._Source.TryGetValue(info.pay_Code, out PaymentView _))
        return;
      this._Source.Add(info.pay_Code, info);
    }

    public void AddOriginRange(IEnumerable<PaymentView> infos)
    {
      foreach (PaymentView info in infos)
        this.AddOrigin(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, PaymentView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out PaymentView value) => this.Source.TryGetValue(key, out value);
  }
}
