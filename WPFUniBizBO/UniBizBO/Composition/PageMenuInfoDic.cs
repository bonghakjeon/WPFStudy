// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.PageMenuInfoDic
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBizBO.Composition
{
  public class PageMenuInfoDic : 
    BindableBase,
    IReadOnlyDictionary<int, PageMenuInfo>,
    IEnumerable<KeyValuePair<int, PageMenuInfo>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<int, PageMenuInfo>>
  {
    private Dictionary<int, PageMenuInfo> _Source = new Dictionary<int, PageMenuInfo>();

    public IReadOnlyDictionary<int, PageMenuInfo> Source => (IReadOnlyDictionary<int, PageMenuInfo>) this._Source;

    public IEnumerable<int> Keys => this.Source.Keys;

    public IEnumerable<PageMenuInfo> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public PageMenuInfo this[int pKey]
    {
      get
      {
        PageMenuInfo pageMenuInfo;
        return !this.Source.TryGetValue(pKey, out pageMenuInfo) ? (PageMenuInfo) null : pageMenuInfo;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(PageMenuInfo pInfo)
    {
      if (this._Source.TryGetValue(pInfo.Code, out PageMenuInfo _))
        return;
      PageMenuInfo pageMenuInfo = new PageMenuInfo();
      this._Source.Add(pInfo.Code, pageMenuInfo);
    }

    public void AddOrigin(PageMenuInfo pInfo)
    {
      if (this._Source.TryGetValue(pInfo.Code, out PageMenuInfo _))
        return;
      PageMenuInfo pageMenuInfo = pInfo;
      this._Source.Add(pInfo.Code, pageMenuInfo);
    }

    public void AddRange(IEnumerable<PageMenuInfo> pInfos)
    {
      foreach (PageMenuInfo pInfo in pInfos)
      {
        this.Add(pInfo);
        foreach (PageMenuInfo child1 in (Collection<PageMenuInfo>) pInfo.Children)
        {
          this.Add(child1);
          foreach (PageMenuInfo child2 in (Collection<PageMenuInfo>) child1.Children)
          {
            this.Add(child2);
            foreach (PageMenuInfo child3 in (Collection<PageMenuInfo>) child2.Children)
              this.Add(child3);
          }
        }
      }
    }

    public void AddRange(IList<PageMenuInfo> pInfos)
    {
      foreach (PageMenuInfo pInfo in (IEnumerable<PageMenuInfo>) pInfos)
      {
        this.Add(pInfo);
        foreach (PageMenuInfo child1 in (Collection<PageMenuInfo>) pInfo.Children)
        {
          this.Add(child1);
          foreach (PageMenuInfo child2 in (Collection<PageMenuInfo>) child1.Children)
          {
            this.Add(child2);
            foreach (PageMenuInfo child3 in (Collection<PageMenuInfo>) child2.Children)
              this.Add(child3);
          }
        }
      }
    }

    public void AddRangeOrigin(IEnumerable<PageMenuInfo> pInfos)
    {
      foreach (PageMenuInfo pInfo in pInfos)
      {
        this.AddOrigin(pInfo);
        foreach (PageMenuInfo child1 in (Collection<PageMenuInfo>) pInfo.Children)
        {
          this.AddOrigin(child1);
          foreach (PageMenuInfo child2 in (Collection<PageMenuInfo>) child1.Children)
          {
            this.AddOrigin(child2);
            foreach (PageMenuInfo child3 in (Collection<PageMenuInfo>) child2.Children)
              this.AddOrigin(child3);
          }
        }
      }
    }

    public void AddRangeOrigin(IList<PageMenuInfo> pInfos)
    {
      foreach (PageMenuInfo pInfo in (IEnumerable<PageMenuInfo>) pInfos)
      {
        this.AddOrigin(pInfo);
        foreach (PageMenuInfo child1 in (Collection<PageMenuInfo>) pInfo.Children)
        {
          this.AddOrigin(child1);
          foreach (PageMenuInfo child2 in (Collection<PageMenuInfo>) child1.Children)
          {
            this.AddOrigin(child2);
            foreach (PageMenuInfo child3 in (Collection<PageMenuInfo>) child2.Children)
              this.AddOrigin(child3);
          }
        }
      }
    }

    public bool ContainsKey(int pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<int, PageMenuInfo>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(int pKey, [MaybeNullWhen(false)] out PageMenuInfo pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
