// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.ProgOptionGroup
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
  public class ProgOptionGroup : 
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

    public int Type { get; set; }

    public bool IsReadOnly { get; }

    public ProgOptionGroup(int pType) => this.Type = pType;

    public ProgOptionGroup(int typeNum, IEnumerable<ProgOptionView> items)
      : this(typeNum)
    {
      this.Items.AddRange(items);
    }

    public ProgOptionView this[int StoreCode] => this.FirstOrDefault<ProgOptionView>((Func<ProgOptionView, bool>) (it => it.opt_StoreCode == StoreCode));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (ProgOptionGroup), (object) this.Type, (object) this.Count);

    public IEnumerator<ProgOptionView> GetEnumerator() => (IEnumerator<ProgOptionView>) this.Items?.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(ProgOptionView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(ProgOptionView item) => this.Items.Contains(item);

    public void CopyTo(ProgOptionView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(ProgOptionView item) => this.Items.Remove(item);
  }
}
