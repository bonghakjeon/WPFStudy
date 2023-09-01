// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.OuterConnAuthByProgKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  public class OuterConnAuthByProgKind : 
    BindableBase,
    ICollection<OuterConnAuthView>,
    IEnumerable<OuterConnAuthView>,
    IEnumerable
  {
    private List<OuterConnAuthView> _Items;

    public List<OuterConnAuthView> Items
    {
      get => this._Items ?? (this._Items = new List<OuterConnAuthView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int oca_ProgKind { get; set; }

    public bool IsReadOnly { get; }

    public OuterConnAuthByProgKind(int p_oca_ProgKind)
    {
      this.oca_ProgKind = p_oca_ProgKind;
      this.Items = new List<OuterConnAuthView>();
    }

    public OuterConnAuthByProgKind(int p_oca_ProgKind, IEnumerable<OuterConnAuthView> items)
      : this(p_oca_ProgKind)
    {
      this.Items.AddRange(items);
    }

    public OuterConnAuthView this[int pNumber] => this.FirstOrDefault<OuterConnAuthView>((Func<OuterConnAuthView, bool>) (it => it.oca_ProgKind == pNumber));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) "OuterConnAuthView", (object) this.oca_ProgKind, (object) this.Count);

    public IEnumerator<OuterConnAuthView> GetEnumerator() => (IEnumerator<OuterConnAuthView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(OuterConnAuthView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(OuterConnAuthView item) => this.Items.Contains(item);

    public void CopyTo(OuterConnAuthView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(OuterConnAuthView item) => this.Items.Remove(item);
  }
}
