// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.CommonCodeGroupDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  public class CommonCodeGroupDic : 
    BindableBase,
    IReadOnlyDictionary<int, CommonCodeGroup>,
    IEnumerable<KeyValuePair<int, CommonCodeGroup>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, CommonCodeGroup>>
  {
    private Dictionary<int, CommonCodeGroup> _Source = new Dictionary<int, CommonCodeGroup>();

    public IReadOnlyDictionary<int, CommonCodeGroup> Source => (IReadOnlyDictionary<int, CommonCodeGroup>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<CommonCodeGroup> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public CommonCodeGroup this[int key]
    {
      get
      {
        CommonCodeGroup commonCodeGroup;
        return !this.Source.TryGetValue(key, out commonCodeGroup) ? (CommonCodeGroup) null : commonCodeGroup;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(CommonCodeView info)
    {
      CommonCodeGroup commonCodeGroup;
      if (!this._Source.TryGetValue(info.comm_Type, out commonCodeGroup))
      {
        commonCodeGroup = new CommonCodeGroup(info.comm_Type);
        this._Source.Add(info.comm_Type, commonCodeGroup);
      }
      commonCodeGroup?.Add(info);
    }

    public void AddRange(IEnumerable<CommonCodeView> infos)
    {
      foreach (CommonCodeView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(int key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<int, CommonCodeGroup>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int key, [MaybeNullWhen(false)] out CommonCodeGroup value) => this.Source.TryGetValue(key, out value);
  }
}
