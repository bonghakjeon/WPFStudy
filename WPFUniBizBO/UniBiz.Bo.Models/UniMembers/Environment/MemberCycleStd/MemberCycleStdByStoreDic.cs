// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd.MemberCycleStdByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd
{
  public class MemberCycleStdByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<int, MemberCycleStdView>,
    IEnumerable<KeyValuePair<int, MemberCycleStdView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, MemberCycleStdView>>
  {
    private Dictionary<int, MemberCycleStdView> _Source = new Dictionary<int, MemberCycleStdView>();

    public IReadOnlyDictionary<int, MemberCycleStdView> Source => (IReadOnlyDictionary<int, MemberCycleStdView>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<MemberCycleStdView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public MemberCycleStdView this[int key]
    {
      get
      {
        MemberCycleStdView memberCycleStdView;
        return !this.Source.TryGetValue(key, out memberCycleStdView) ? (MemberCycleStdView) null : memberCycleStdView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void AddOrigin(MemberCycleStdView info)
    {
      MemberCycleStdView memberCycleStdView;
      if (!this._Source.TryGetValue(info.mcs_StoreCode, out memberCycleStdView))
        this._Source.Add(info.mcs_StoreCode, info);
      memberCycleStdView?.Lt_History.Add(info);
    }

    public void AddOriginRange(IEnumerable<MemberCycleStdView> infos)
    {
      foreach (MemberCycleStdView info in infos)
        this.AddOrigin(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, MemberCycleStdView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out MemberCycleStdView value) => this.Source.TryGetValue(key, out value);
  }
}
