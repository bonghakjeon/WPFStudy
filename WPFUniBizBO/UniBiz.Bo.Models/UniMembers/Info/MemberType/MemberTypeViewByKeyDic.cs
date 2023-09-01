// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberType.MemberTypeViewByKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberType
{
  public class MemberTypeViewByKeyDic : 
    BindableBase,
    IReadOnlyDictionary<int, MemberTypeView>,
    IEnumerable<KeyValuePair<int, MemberTypeView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, MemberTypeView>>
  {
    private Dictionary<int, MemberTypeView> _Source = new Dictionary<int, MemberTypeView>();

    public IReadOnlyDictionary<int, MemberTypeView> Source => (IReadOnlyDictionary<int, MemberTypeView>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<MemberTypeView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public MemberTypeView this[int pKey]
    {
      get
      {
        MemberTypeView memberTypeView;
        return !this.Source.TryGetValue(pKey, out memberTypeView) ? (MemberTypeView) null : memberTypeView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(MemberTypeView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.mt_TypeCode, out MemberTypeView _))
        return;
      MemberTypeView memberTypeView = new MemberTypeView();
      this._Source.Add(pInfo.mt_TypeCode, memberTypeView);
    }

    public void AddOrigin(MemberTypeView pInfo)
    {
      if (this._Source.TryGetValue(pInfo.mt_TypeCode, out MemberTypeView _))
        return;
      MemberTypeView memberTypeView = pInfo;
      this._Source.Add(pInfo.mt_TypeCode, memberTypeView);
    }

    public void AddRange(IEnumerable<MemberTypeView> pInfos)
    {
      foreach (MemberTypeView pInfo in pInfos)
        this.Add(pInfo);
    }

    public void AddRange(IList<MemberTypeView> pInfos)
    {
      foreach (MemberTypeView pInfo in (IEnumerable<MemberTypeView>) pInfos)
        this.Add(pInfo);
    }

    public void AddRangeOrigin(IEnumerable<MemberTypeView> pInfos)
    {
      foreach (MemberTypeView pInfo in pInfos)
        this.AddOrigin(pInfo);
    }

    public void AddRangeOrigin(IList<MemberTypeView> pInfos)
    {
      foreach (MemberTypeView pInfo in (IEnumerable<MemberTypeView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(int pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<int, MemberTypeView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int pKey, [MaybeNullWhen(false)] out MemberTypeView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
