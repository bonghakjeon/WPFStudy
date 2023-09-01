// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark.ProgMenuBookMarkByKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark
{
  public class ProgMenuBookMarkByKeyDic : 
    BindableBase,
    IReadOnlyDictionary<long, ProgMenuBookMarkView>,
    IEnumerable<KeyValuePair<long, ProgMenuBookMarkView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, ProgMenuBookMarkView>>
  {
    private Dictionary<long, ProgMenuBookMarkView> _Source = new Dictionary<long, ProgMenuBookMarkView>();

    public IReadOnlyDictionary<long, ProgMenuBookMarkView> Source => (IReadOnlyDictionary<long, ProgMenuBookMarkView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<ProgMenuBookMarkView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public ProgMenuBookMarkView this[long pKey]
    {
      get
      {
        ProgMenuBookMarkView menuBookMarkView;
        return !this.Source.TryGetValue(pKey, out menuBookMarkView) ? (ProgMenuBookMarkView) null : menuBookMarkView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(ProgMenuBookMarkView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.pmbm_ID, out ProgMenuBookMarkView _))
        return;
      ProgMenuBookMarkView menuBookMarkView = new ProgMenuBookMarkView();
      this._Source.Add(pInfo.pmbm_ID, menuBookMarkView);
    }

    public void AddOrigin(ProgMenuBookMarkView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.pmbm_ID, out ProgMenuBookMarkView _))
        return;
      ProgMenuBookMarkView menuBookMarkView = pInfo;
      this._Source.Add(pInfo.pmbm_ID, menuBookMarkView);
    }

    public void AddRange(IEnumerable<ProgMenuBookMarkView> pInfos)
    {
      foreach (ProgMenuBookMarkView pInfo in pInfos)
        this.Add(pInfo);
    }

    public void AddRange(IList<ProgMenuBookMarkView> pInfos)
    {
      foreach (ProgMenuBookMarkView pInfo in (IEnumerable<ProgMenuBookMarkView>) pInfos)
        this.Add(pInfo);
    }

    public void AddRangeOrigin(IEnumerable<ProgMenuBookMarkView> pInfos)
    {
      foreach (ProgMenuBookMarkView pInfo in pInfos)
        this.AddOrigin(pInfo);
    }

    public void AddRangeOrigin(IList<ProgMenuBookMarkView> pInfos)
    {
      foreach (ProgMenuBookMarkView pInfo in (IEnumerable<ProgMenuBookMarkView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(long pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<long, ProgMenuBookMarkView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long pKey, [MaybeNullWhen(false)] out ProgMenuBookMarkView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
