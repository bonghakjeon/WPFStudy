// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd.MemberGradeCalcStdByStoreDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd
{
  public class MemberGradeCalcStdByStoreDic : 
    BindableBase,
    IReadOnlyDictionary<int, MemberGradeCalcStdView>,
    IEnumerable<KeyValuePair<int, MemberGradeCalcStdView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, MemberGradeCalcStdView>>
  {
    private Dictionary<int, MemberGradeCalcStdView> _Source = new Dictionary<int, MemberGradeCalcStdView>();

    public IReadOnlyDictionary<int, MemberGradeCalcStdView> Source => (IReadOnlyDictionary<int, MemberGradeCalcStdView>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<MemberGradeCalcStdView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public MemberGradeCalcStdView this[int key]
    {
      get
      {
        MemberGradeCalcStdView gradeCalcStdView;
        return !this.Source.TryGetValue(key, out gradeCalcStdView) ? (MemberGradeCalcStdView) null : gradeCalcStdView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void AddOrigin(MemberGradeCalcStdView info)
    {
      MemberGradeCalcStdView gradeCalcStdView;
      if (!this._Source.TryGetValue(info.mgcs_StoreCode, out gradeCalcStdView))
        this._Source.Add(info.mgcs_StoreCode, info);
      gradeCalcStdView?.Lt_History.Add(info);
    }

    public void AddOriginRange(IEnumerable<MemberGradeCalcStdView> infos)
    {
      foreach (MemberGradeCalcStdView info in infos)
        this.AddOrigin(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, MemberGradeCalcStdView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out MemberGradeCalcStdView value) => this.Source.TryGetValue(key, out value);
  }
}
