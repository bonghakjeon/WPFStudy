// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberGroup.MemberGroupLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.Converter;
using UniBizUtil.Util;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberGroup
{
  public class MemberGroupLevel : 
    BindableBase,
    ICollection<MemberGroupView>,
    IEnumerable<MemberGroupView>,
    IEnumerable
  {
    private List<MemberGroupView> _Items;

    public List<MemberGroupView> Items
    {
      get => this._Items ?? (this._Items = new List<MemberGroupView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public string mg_GroupCode { get; set; }

    public bool IsReadOnly { get; }

    public MemberGroupLevel()
    {
    }

    public MemberGroupLevel(string p_mg_GroupCode)
      : this()
    {
      this.mg_GroupCode = p_mg_GroupCode;
    }

    public MemberGroupLevel(string p_mg_GroupCode, IEnumerable<MemberGroupView> items)
      : this(p_mg_GroupCode)
    {
      this.Items.AddRange(items);
    }

    public MemberGroupView this[string p_mg_GroupCode] => this.FirstOrDefault<MemberGroupView>((Func<MemberGroupView, bool>) (it => it.mg_GroupCode.Equals(p_mg_GroupCode)));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (MemberGroupLevel), (object) this.mg_GroupCode, (object) this.Count);

    public IEnumerator<MemberGroupView> GetEnumerator() => (IEnumerator<MemberGroupView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(MemberGroupView item)
    {
      switch (Enum2StrConverter.ToCategoryDepth(item.mg_GroupDepth))
      {
        case EnumCategoryDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumCategoryDepth.Lv2:
          this.Items.Where<MemberGroupView>((Func<MemberGroupView, bool>) (it => it.mg_GroupCode.ToLeft(3).Equals(item.mg_GroupCode.ToLeft(3)))).FirstOrDefault<MemberGroupView>()?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<MemberGroupView> infos, bool p_is_level = false)
    {
      if (p_is_level)
      {
        foreach (MemberGroupView memberGroupView in infos.Where<MemberGroupView>((Func<MemberGroupView, bool>) (it => it.mg_GroupDepth == 1)))
          this.Add(memberGroupView);
        foreach (MemberGroupView memberGroupView in infos.Where<MemberGroupView>((Func<MemberGroupView, bool>) (it => it.mg_GroupDepth == 2)))
          this.Add(memberGroupView);
      }
      else
      {
        foreach (MemberGroupView info in infos)
          this.Add(info);
      }
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(MemberGroupView item) => this.Items.Contains(item);

    public void CopyTo(MemberGroupView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(MemberGroupView item) => this.Items.Remove(item);
  }
}
