// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.ProgOptionByStore
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgOption
{
  public class ProgOptionByStore : 
    BindableBase,
    ICollection<ProgOptionView>,
    IEnumerable<ProgOptionView>,
    IEnumerable
  {
    private List<ProgOptionView> _Items;

    public List<ProgOptionView> Items
    {
      get => this._Items ?? (this._Items = new List<ProgOptionView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int opt_StoreCode { get; set; }

    public bool IsReadOnly { get; }

    public ProgOptionByStore(int p_opt_StoreCode)
    {
      this.opt_StoreCode = p_opt_StoreCode;
      this.Items = new List<ProgOptionView>();
    }

    public ProgOptionByStore(int p_opt_StoreCode, IEnumerable<ProgOptionView> items)
      : this(p_opt_StoreCode)
    {
      this.Items.AddRange(items);
    }

    public ProgOptionView this[int pNumber] => this.FirstOrDefault<ProgOptionView>((Func<ProgOptionView, bool>) (it => it.opt_StoreCode == pNumber));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) "ProgOptionView", (object) this.opt_StoreCode, (object) this.Count);

    public IEnumerator<ProgOptionView> GetEnumerator() => (IEnumerator<ProgOptionView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(ProgOptionView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(ProgOptionView item) => this.Items.Contains(item);

    public void CopyTo(ProgOptionView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(ProgOptionView item) => this.Items.Remove(item);
  }
}
