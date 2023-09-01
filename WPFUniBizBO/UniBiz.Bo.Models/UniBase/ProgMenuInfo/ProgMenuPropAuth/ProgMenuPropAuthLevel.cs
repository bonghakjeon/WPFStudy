// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth.ProgMenuPropAuthLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.Converter;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth
{
  public class ProgMenuPropAuthLevel : 
    BindableBase,
    ICollection<ProgMenuPropAuthView>,
    IEnumerable<ProgMenuPropAuthView>,
    IEnumerable
  {
    private List<ProgMenuPropAuthView> _Items;

    public List<ProgMenuPropAuthView> Items
    {
      get => this._Items ?? (this._Items = new List<ProgMenuPropAuthView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int MenuGroupID { get; set; }

    public int PropCode { get; set; }

    public bool IsReadOnly { get; }

    public ProgMenuPropAuthLevel()
    {
    }

    public ProgMenuPropAuthLevel(int pMenuGroupID, int pPropCode)
    {
      this.PropCode = pPropCode;
      this.Items = new List<ProgMenuPropAuthView>();
    }

    public ProgMenuPropAuthLevel(
      int pMenuGroupID,
      int pPropCode,
      IEnumerable<ProgMenuPropAuthView> items)
      : this(pMenuGroupID, pPropCode)
    {
      this.Items.AddRange(items);
    }

    public ProgMenuPropAuthView this[int pMenuGroupID, int pPropCode] => this.FirstOrDefault<ProgMenuPropAuthView>((Func<ProgMenuPropAuthView, bool>) (it => it.pmpA_MenuGroupID == pMenuGroupID && it.pmpA_PropCode == pPropCode));

    public override string ToString() => string.Format("{0} [{1},{2}] Count : {3}", (object) nameof (ProgMenuPropAuthLevel), (object) this.MenuGroupID, (object) this.PropCode, (object) this.Count);

    public IEnumerator<ProgMenuPropAuthView> GetEnumerator() => (IEnumerator<ProgMenuPropAuthView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(ProgMenuPropAuthView item)
    {
      switch (Enum2StrConverter.ToMenuPropDepth(item.pmp_PropDepth))
      {
        case EnumMenuPropDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumMenuPropDepth.Lv2:
          this.Items.Where<ProgMenuPropAuthView>((Func<ProgMenuPropAuthView, bool>) (it => it.pmp_PropDepth == 1 && it.pmp_TableID == item.pmp_TableID)).FirstOrDefault<ProgMenuPropAuthView>()?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<ProgMenuPropAuthView> infos)
    {
      foreach (ProgMenuPropAuthView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(ProgMenuPropAuthView item) => this.Items.Contains(item);

    public void CopyTo(ProgMenuPropAuthView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(ProgMenuPropAuthView item) => this.Items.Remove(item);
  }
}
