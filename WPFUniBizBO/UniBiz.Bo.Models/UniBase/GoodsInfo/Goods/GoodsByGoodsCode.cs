// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.Goods.GoodsByGoodsCode
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.Goods
{
  public class GoodsByGoodsCode : 
    BindableBase,
    ICollection<GoodsView>,
    IEnumerable<GoodsView>,
    IEnumerable
  {
    private List<GoodsView> _Items;

    public List<GoodsView> Items
    {
      get => this._Items ?? (this._Items = new List<GoodsView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public long gd_GoodsCode { get; set; }

    public bool IsReadOnly { get; }

    public GoodsByGoodsCode(long p_gd_GoodsCode)
    {
      this.gd_GoodsCode = p_gd_GoodsCode;
      this.Items = new List<GoodsView>();
    }

    public GoodsByGoodsCode(long p_gd_GoodsCode, IEnumerable<GoodsView> items)
      : this(p_gd_GoodsCode)
    {
      this.Items.AddRange(items);
    }

    public GoodsView this[long pNumber] => this.FirstOrDefault<GoodsView>((Func<GoodsView, bool>) (it => it.gd_GoodsCode == pNumber));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (GoodsByGoodsCode), (object) this.gd_GoodsCode, (object) this.Count);

    public IEnumerator<GoodsView> GetEnumerator() => (IEnumerator<GoodsView>) this.Items?.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(GoodsView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(GoodsView item) => this.Items.Contains(item);

    public void CopyTo(GoodsView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(GoodsView item) => this.Items.Remove(item);
  }
}
