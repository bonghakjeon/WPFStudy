// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Dept.DeptLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.Converter;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Dept
{
  public class DeptLevel : BindableBase, ICollection<DeptView>, IEnumerable<DeptView>, IEnumerable
  {
    private List<DeptView> _Items;

    public List<DeptView> Items
    {
      get => this._Items ?? (this._Items = new List<DeptView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int dpt_ID { get; set; }

    public bool IsReadOnly { get; }

    public DeptLevel()
    {
    }

    public DeptLevel(int p_dpt_ID)
    {
      this.dpt_ID = p_dpt_ID;
      this.Items = new List<DeptView>();
    }

    public DeptLevel(int p_dpt_ID, IEnumerable<DeptView> items)
      : this(p_dpt_ID)
    {
      this.Items.AddRange(items);
    }

    public DeptView this[int p_dpt_ID] => this.FirstOrDefault<DeptView>((Func<DeptView, bool>) (it => it.dpt_ID == p_dpt_ID));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (DeptLevel), (object) this.dpt_ID, (object) this.Count);

    public IEnumerator<DeptView> GetEnumerator() => (IEnumerator<DeptView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(DeptView item)
    {
      switch (Enum2StrConverter.ToDeptDepth(item.dpt_Depth))
      {
        case EnumDeptDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumDeptDepth.Lv2:
          this.Items.Where<DeptView>((Func<DeptView, bool>) (it => it.dpt_ID == item.dpt_ParentsID)).FirstOrDefault<DeptView>()?.Lt_Detail.Add(item);
          break;
        case EnumDeptDepth.Lv3:
          DeptView deptView = this.Items.Where<DeptView>((Func<DeptView, bool>) (it => it.dpt_ID == item.dpt_lv1_ID)).FirstOrDefault<DeptView>();
          if (deptView == null)
            break;
          deptView.Lt_Detail.Where<DeptView>((Func<DeptView, bool>) (it => it.dpt_ID == item.dpt_ParentsID)).FirstOrDefault<DeptView>()?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<DeptView> infos, bool p_is_level = false)
    {
      if (p_is_level)
      {
        foreach (DeptView deptView in infos.Where<DeptView>((Func<DeptView, bool>) (it => it.dpt_Depth == 1)))
          this.Add(deptView);
        foreach (DeptView deptView in infos.Where<DeptView>((Func<DeptView, bool>) (it => it.dpt_Depth == 2)))
          this.Add(deptView);
        foreach (DeptView deptView in infos.Where<DeptView>((Func<DeptView, bool>) (it => it.dpt_Depth == 3)))
          this.Add(deptView);
      }
      else
      {
        foreach (DeptView info in infos)
          this.Add(info);
      }
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(DeptView item) => this.Items.Contains(item);

    public void CopyTo(DeptView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(DeptView item) => this.Items.Remove(item);
  }
}
