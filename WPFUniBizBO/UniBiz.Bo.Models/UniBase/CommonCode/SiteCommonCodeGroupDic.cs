// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.SiteCommonCodeGroupDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  public class SiteCommonCodeGroupDic : 
    BindableBase,
    IReadOnlyDictionary<long, CommonCodeGroupDic>,
    IEnumerable<KeyValuePair<long, CommonCodeGroupDic>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, CommonCodeGroupDic>>
  {
    private Dictionary<long, CommonCodeGroupDic> _Source = new Dictionary<long, CommonCodeGroupDic>();

    public IReadOnlyDictionary<long, CommonCodeGroupDic> Source => (IReadOnlyDictionary<long, CommonCodeGroupDic>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<CommonCodeGroupDic> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public CommonCodeGroupDic this[long key]
    {
      get
      {
        CommonCodeGroupDic commonCodeGroupDic;
        return !this.Source.TryGetValue(key, out commonCodeGroupDic) ? (CommonCodeGroupDic) null : commonCodeGroupDic;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(CommonCodeView info)
    {
      CommonCodeGroupDic commonCodeGroupDic;
      if (!this._Source.TryGetValue(info.comm_SiteID, out commonCodeGroupDic))
      {
        commonCodeGroupDic = new CommonCodeGroupDic();
        this._Source.Add(info.comm_SiteID, commonCodeGroupDic);
      }
      commonCodeGroupDic?.Add(info);
    }

    public void AddRange(IEnumerable<CommonCodeView> infos)
    {
      foreach (CommonCodeView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, CommonCodeGroupDic>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out CommonCodeGroupDic value) => this.Source.TryGetValue(key, out value);
  }
}
