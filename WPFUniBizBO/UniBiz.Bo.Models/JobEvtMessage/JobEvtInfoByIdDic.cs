// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtInfoByIdDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtInfoByIdDic : 
    BindableBase,
    IReadOnlyDictionary<string, JobEvtInfoById>,
    IEnumerable<KeyValuePair<string, JobEvtInfoById>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, JobEvtInfoById>>
  {
    private Dictionary<string, JobEvtInfoById> _Source = new Dictionary<string, JobEvtInfoById>();

    public IReadOnlyDictionary<string, JobEvtInfoById> Source => (IReadOnlyDictionary<string, JobEvtInfoById>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<JobEvtInfoById> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public JobEvtInfoById this[string key]
    {
      get
      {
        JobEvtInfoById jobEvtInfoById;
        return !this.Source.TryGetValue(key, out jobEvtInfoById) ? (JobEvtInfoById) null : jobEvtInfoById;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(JobEvtInfo info)
    {
      JobEvtInfoById jobEvtInfoById;
      if (!this._Source.TryGetValue(info.Id, out jobEvtInfoById))
      {
        jobEvtInfoById = new JobEvtInfoById(info.Id);
        this._Source.Add(info.Id, jobEvtInfoById);
      }
      jobEvtInfoById?.Add(info);
    }

    public void AddRange(IEnumerable<JobEvtInfo> infos)
    {
      foreach (JobEvtInfo info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, JobEvtInfoById>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out JobEvtInfoById value) => this.Source.TryGetValue(key, out value);

    public bool Remove(string p_ID) => this._Source.Remove(p_ID);

    public bool Remove(JobEvtInfoById pItem) => this._Source.Remove(pItem.Id);
  }
}
