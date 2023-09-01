// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierImage.SupplierImageKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierImage
{
  public class SupplierImageKind : 
    BindableBase,
    ICollection<SupplierImageView>,
    IEnumerable<SupplierImageView>,
    IEnumerable
  {
    private List<SupplierImageView> _Items;

    public List<SupplierImageView> Items
    {
      get => this._Items ?? (this._Items = new List<SupplierImageView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int sui_Supplier { get; set; }

    public bool IsReadOnly { get; }

    public SupplierImageKind()
    {
    }

    public SupplierImageKind(int p_sui_Supplier)
    {
      this.sui_Supplier = p_sui_Supplier;
      this.Items = new List<SupplierImageView>();
    }

    public SupplierImageKind(int p_sui_Supplier, IEnumerable<SupplierImageView> items)
      : this(p_sui_Supplier)
    {
      this.Items.AddRange(items);
    }

    public SupplierImageView this[int p_sui_Supplier] => this.FirstOrDefault<SupplierImageView>((Func<SupplierImageView, bool>) (it => it.sui_Supplier == p_sui_Supplier));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (SupplierImageKind), (object) this.sui_Supplier, (object) this.Count);

    public IEnumerator<SupplierImageView> GetEnumerator() => (IEnumerator<SupplierImageView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(SupplierImageView item)
    {
      if (this.Contains(item))
        return;
      this.Items.Add(item);
    }

    public void AddRange(IEnumerable<SupplierImageView> infos)
    {
      foreach (SupplierImageView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(SupplierImageView item) => this.Items.Contains(item);

    public void CopyTo(SupplierImageView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(SupplierImageView item) => this.Items.Remove(item);
  }
}
