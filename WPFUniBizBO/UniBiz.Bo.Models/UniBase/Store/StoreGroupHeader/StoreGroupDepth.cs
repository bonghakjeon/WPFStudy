// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader.StoreGroupDepth
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader
{
  public class StoreGroupDepth : 
    BindableBase,
    ICollection<StoreGroupHeaderView>,
    IEnumerable<StoreGroupHeaderView>,
    IEnumerable
  {
    private List<StoreGroupHeaderView> _Items;

    public List<StoreGroupHeaderView> Items
    {
      get => this._Items ?? (this._Items = new List<StoreGroupHeaderView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int GroupCode { get; set; }

    public bool IsReadOnly { get; }

    public StoreGroupDepth() => this.Items = new List<StoreGroupHeaderView>();

    public StoreGroupDepth(int pGroupCode) => this.GroupCode = pGroupCode;

    public StoreGroupDepth(int pGroupCode, IEnumerable<StoreGroupHeaderView> items)
      : this(pGroupCode)
    {
      this.Items.AddRange(items);
    }

    public StoreGroupHeaderView this[int pGroupCode] => this.FirstOrDefault<StoreGroupHeaderView>((Func<StoreGroupHeaderView, bool>) (it => it.sgh_GroupCode == pGroupCode));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (StoreGroupDepth), (object) this.GroupCode, (object) this.Count);

    public IEnumerator<StoreGroupHeaderView> GetEnumerator() => (IEnumerator<StoreGroupHeaderView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(StoreGroupHeaderView item)
    {
      if (this.Contains(item))
        return;
      this.Items.Add(item);
    }

    public void AddRange(IEnumerable<StoreGroupHeaderView> infos)
    {
      if (infos == null)
        return;
      foreach (StoreGroupHeaderView info in infos)
        this.Add(info);
    }

    public void Add(StoreGroupDetailView item) => this.Items.Where<StoreGroupHeaderView>((Func<StoreGroupHeaderView, bool>) (it => it.sgh_GroupCode == item.sgd_GroupCode && it.sgh_SiteID == item.sgd_SiteID)).FirstOrDefault<StoreGroupHeaderView>()?.Lt_Details.Add(item);

    public void AddRange(IEnumerable<StoreGroupDetailView> infos)
    {
      if (infos == null)
        return;
      foreach (StoreGroupDetailView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(StoreGroupHeaderView item) => this.Items.Contains(item);

    public void CopyTo(StoreGroupHeaderView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(StoreGroupHeaderView item) => this.Items.Remove(item);
  }
}
