// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.UniSite.UniSiteGroup
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.UniSite
{
  public class UniSiteGroup : 
    BindableBase,
    ICollection<UniSiteView>,
    IEnumerable<UniSiteView>,
    IEnumerable
  {
    private List<UniSiteView> _Items;

    public List<UniSiteView> Items
    {
      get => this._Items ?? (this._Items = new List<UniSiteView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public long ID { get; set; }

    public bool IsReadOnly { get; }

    public UniSiteGroup(long pID)
    {
      this.ID = pID;
      this.Items = new List<UniSiteView>();
    }

    public UniSiteGroup(long pID, IEnumerable<UniSiteView> items)
      : this(pID)
    {
      this.Items.AddRange(items);
    }

    public UniSiteView this[long pID] => this.FirstOrDefault<UniSiteView>((Func<UniSiteView, bool>) (it => it.uis_SiteID == pID));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (UniSiteGroup), (object) this.ID, (object) this.Count);

    public IEnumerator<UniSiteView> GetEnumerator() => (IEnumerator<UniSiteView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(UniSiteView item) => this.Items.Add(item);

    public void AddRange(IEnumerable<UniSiteView> infos)
    {
      foreach (UniSiteView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items?.Clear();

    public bool Contains(UniSiteView item) => this.Items.Contains(item);

    public void CopyTo(UniSiteView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(UniSiteView item) => this.Items.Remove(item);
  }
}
