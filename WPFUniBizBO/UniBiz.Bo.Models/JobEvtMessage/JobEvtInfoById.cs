// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtInfoById
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtInfoById : ICollection<JobEvtInfo>, IEnumerable<JobEvtInfo>, IEnumerable
  {
    protected List<JobEvtInfo> Items { get; set; }

    public int Count => this.Items.Count;

    public string Id { get; set; }

    public bool IsReadOnly { get; }

    public JobEvtInfoById(string p_Id)
    {
      this.Id = p_Id;
      this.Items = new List<JobEvtInfo>();
    }

    public JobEvtInfoById(string p_Id, IEnumerable<JobEvtInfo> items)
      : this(p_Id)
    {
      this.Items.AddRange(items);
    }

    public JobEvtInfo this[string pId] => this.FirstOrDefault<JobEvtInfo>((Func<JobEvtInfo, bool>) (it => it.Id.Equals(pId)));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (JobEvtInfoById), (object) this.Id, (object) this.Count);

    public IEnumerator<JobEvtInfo> GetEnumerator() => (IEnumerator<JobEvtInfo>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(JobEvtInfo item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(JobEvtInfo item) => this.Items.Contains(item);

    public void CopyTo(JobEvtInfo[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(JobEvtInfo item) => this.Items.Remove(item);
  }
}
