// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory.GoodsHistoryByStore
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory
{
  public class GoodsHistoryByStore : 
    BindableBase,
    ICollection<GoodsHistoryView>,
    IEnumerable<GoodsHistoryView>,
    IEnumerable
  {
    private List<GoodsHistoryView> _Items;

    public List<GoodsHistoryView> Items
    {
      get => this._Items ?? (this._Items = new List<GoodsHistoryView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int gdh_StoreCode { get; set; }

    public bool IsReadOnly { get; }

    public GoodsHistoryByStore(int p_gdh_StoreCode)
    {
      this.gdh_StoreCode = p_gdh_StoreCode;
      this.Items = new List<GoodsHistoryView>();
    }

    public GoodsHistoryByStore(int p_gdh_StoreCode, IEnumerable<GoodsHistoryView> items)
      : this(p_gdh_StoreCode)
    {
      this.Items.AddRange(items);
    }

    public GoodsHistoryView this[int pNumber] => this.FirstOrDefault<GoodsHistoryView>((Func<GoodsHistoryView, bool>) (it => it.gdh_StoreCode == pNumber));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (GoodsHistoryByStore), (object) this.gdh_StoreCode, (object) this.Count);

    public IEnumerator<GoodsHistoryView> GetEnumerator() => (IEnumerator<GoodsHistoryView>) this.Items?.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(GoodsHistoryView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(GoodsHistoryView item) => this.Items.Contains(item);

    public void CopyTo(GoodsHistoryView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(GoodsHistoryView item) => this.Items.Remove(item);
  }
}
