// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory.MemberTypeHistoryByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory
{
  public class MemberTypeHistoryByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<int, MemberTypeHistoryView>,
    IEnumerable<KeyValuePair<int, MemberTypeHistoryView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, MemberTypeHistoryView>>
  {
    private Dictionary<int, MemberTypeHistoryView> _Source = new Dictionary<int, MemberTypeHistoryView>();

    public IReadOnlyDictionary<int, MemberTypeHistoryView> Source => (IReadOnlyDictionary<int, MemberTypeHistoryView>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<MemberTypeHistoryView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public MemberTypeHistoryView this[int key]
    {
      get
      {
        MemberTypeHistoryView memberTypeHistoryView;
        return !this.Source.TryGetValue(key, out memberTypeHistoryView) ? (MemberTypeHistoryView) null : memberTypeHistoryView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void AddOrigin(MemberTypeHistoryView info)
    {
      MemberTypeHistoryView memberTypeHistoryView;
      if (!this._Source.TryGetValue(info.mth_StoreCode, out memberTypeHistoryView))
        this._Source.Add(info.mth_StoreCode, info);
      memberTypeHistoryView?.Lt_History.Add(info);
    }

    public void AddOriginRange(IEnumerable<MemberTypeHistoryView> infos)
    {
      foreach (MemberTypeHistoryView info in infos)
        this.AddOrigin(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, MemberTypeHistoryView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out MemberTypeHistoryView value) => this.Source.TryGetValue(key, out value);
  }
}
