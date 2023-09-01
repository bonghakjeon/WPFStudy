// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp.ProgMenuPropLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.Converter;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp
{
  public class ProgMenuPropLevel : 
    BindableBase,
    ICollection<ProgMenuPropView>,
    IEnumerable<ProgMenuPropView>,
    IEnumerable
  {
    private List<ProgMenuPropView> _Items;

    public List<ProgMenuPropView> Items
    {
      get => this._Items ?? (this._Items = new List<ProgMenuPropView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int PropCode { get; set; }

    public bool IsReadOnly { get; }

    public ProgMenuPropLevel()
    {
    }

    public ProgMenuPropLevel(int pPropCode)
    {
      this.PropCode = pPropCode;
      this.Items = new List<ProgMenuPropView>();
    }

    public ProgMenuPropLevel(int pPropCode, IEnumerable<ProgMenuPropView> items)
      : this(pPropCode)
    {
      this.Items.AddRange(items);
    }

    public ProgMenuPropView this[int pPropCode] => this.FirstOrDefault<ProgMenuPropView>((Func<ProgMenuPropView, bool>) (it => it.pmp_PropCode == pPropCode));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (ProgMenuPropLevel), (object) this.PropCode, (object) this.Count);

    public IEnumerator<ProgMenuPropView> GetEnumerator() => (IEnumerator<ProgMenuPropView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(ProgMenuPropView item)
    {
      ProgMenuPropView progMenuPropView = this.Items.LastOrDefault<ProgMenuPropView>();
      switch (Enum2StrConverter.ToMenuPropDepth(item.pmp_PropDepth))
      {
        case EnumMenuPropDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumMenuPropDepth.Lv2:
          progMenuPropView?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<ProgMenuPropView> infos)
    {
      foreach (ProgMenuPropView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(ProgMenuPropView item) => this.Items.Contains(item);

    public void CopyTo(ProgMenuPropView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(ProgMenuPropView item) => this.Items.Remove(item);
  }
}
