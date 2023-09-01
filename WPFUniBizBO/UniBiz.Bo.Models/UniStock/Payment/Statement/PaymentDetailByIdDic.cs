// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentDetailByIdDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentDetailByIdDic : 
    BindableBase,
    IReadOnlyDictionary<long, PaymentDetailView>,
    IEnumerable<KeyValuePair<long, PaymentDetailView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, PaymentDetailView>>
  {
    private Dictionary<long, PaymentDetailView> _Source = new Dictionary<long, PaymentDetailView>();

    public IReadOnlyDictionary<long, PaymentDetailView> Source => (IReadOnlyDictionary<long, PaymentDetailView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<PaymentDetailView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public PaymentDetailView this[long key]
    {
      get
      {
        PaymentDetailView paymentDetailView;
        return !this.Source.TryGetValue(key, out paymentDetailView) ? (PaymentDetailView) null : paymentDetailView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(PaymentDetailView info)
    {
      PaymentDetailView paymentDetailView;
      if (!this._Source.TryGetValue(info.pd_PaymentID, out paymentDetailView))
      {
        paymentDetailView = new PaymentDetailView();
        paymentDetailView.pd_PaymentID = info.pd_PaymentID;
        this._Source.Add(info.pd_PaymentID, paymentDetailView);
      }
      paymentDetailView?.Lt_History.Add(info);
    }

    public void AddRange(IEnumerable<PaymentDetailView> infos)
    {
      foreach (PaymentDetailView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, PaymentDetailView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out PaymentDetailView value) => this.Source.TryGetValue(key, out value);
  }
}
