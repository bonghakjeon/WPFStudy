// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentDetailAutoDeductionByAlternateKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentDetailAutoDeductionByAlternateKeyDic : 
    BindableBase,
    IReadOnlyDictionary<string, PaymentDetailAutoDeductionView>,
    IEnumerable<KeyValuePair<string, PaymentDetailAutoDeductionView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, PaymentDetailAutoDeductionView>>
  {
    private Dictionary<string, PaymentDetailAutoDeductionView> _Source = new Dictionary<string, PaymentDetailAutoDeductionView>();

    public IReadOnlyDictionary<string, PaymentDetailAutoDeductionView> Source => (IReadOnlyDictionary<string, PaymentDetailAutoDeductionView>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<PaymentDetailAutoDeductionView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public PaymentDetailAutoDeductionView this[string pKey]
    {
      get
      {
        PaymentDetailAutoDeductionView autoDeductionView;
        return !this.Source.TryGetValue(pKey, out autoDeductionView) ? (PaymentDetailAutoDeductionView) null : autoDeductionView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(PaymentDetailAutoDeductionView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.AlternateKeyCode, out PaymentDetailAutoDeductionView _))
        return;
      PaymentDetailAutoDeductionView autoDeductionView = new PaymentDetailAutoDeductionView();
      this._Source.Add(pInfo.AlternateKeyCode, autoDeductionView);
    }

    public void AddOrigin(PaymentDetailAutoDeductionView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.AlternateKeyCode, out PaymentDetailAutoDeductionView _))
        return;
      PaymentDetailAutoDeductionView autoDeductionView = pInfo;
      this._Source.Add(pInfo.AlternateKeyCode, autoDeductionView);
    }

    public void AddRange(IEnumerable<PaymentDetailAutoDeductionView> pInfos)
    {
      foreach (PaymentDetailAutoDeductionView pInfo in pInfos)
        this.Add(pInfo);
    }

    public void AddRange(IList<PaymentDetailAutoDeductionView> pInfos)
    {
      foreach (PaymentDetailAutoDeductionView pInfo in (IEnumerable<PaymentDetailAutoDeductionView>) pInfos)
        this.Add(pInfo);
    }

    public void AddRangeOrigin(IEnumerable<PaymentDetailAutoDeductionView> pInfos)
    {
      foreach (PaymentDetailAutoDeductionView pInfo in pInfos)
        this.AddOrigin(pInfo);
    }

    public void AddRangeOrigin(IList<PaymentDetailAutoDeductionView> pInfos)
    {
      foreach (PaymentDetailAutoDeductionView pInfo in (IEnumerable<PaymentDetailAutoDeductionView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(string pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<string, PaymentDetailAutoDeductionView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string pKey, [MaybeNullWhen(false)] out PaymentDetailAutoDeductionView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
