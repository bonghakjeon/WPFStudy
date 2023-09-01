// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Category.CategoryLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.Converter;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Category
{
  public class CategoryLevel : 
    BindableBase,
    ICollection<CategoryView>,
    IEnumerable<CategoryView>,
    IEnumerable
  {
    private List<CategoryView> _Items;

    public List<CategoryView> Items
    {
      get => this._Items ?? (this._Items = new List<CategoryView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int ctg_ID { get; set; }

    public bool IsReadOnly { get; }

    public CategoryLevel()
    {
    }

    public CategoryLevel(int p_ctg_ID) => this.ctg_ID = p_ctg_ID;

    public CategoryLevel(int p_ctg_ID, IEnumerable<CategoryView> items)
      : this(p_ctg_ID)
    {
      this.Items.AddRange(items);
    }

    public CategoryView this[int p_ctg_ID] => this.FirstOrDefault<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_ID == p_ctg_ID));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (CategoryLevel), (object) this.ctg_ID, (object) this.Count);

    public IEnumerator<CategoryView> GetEnumerator() => (IEnumerator<CategoryView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(CategoryView item)
    {
      switch (Enum2StrConverter.ToCategoryDepth(item.ctg_Depth))
      {
        case EnumCategoryDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumCategoryDepth.Lv2:
          this.Items.Where<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_ID == item.ctg_ParentsID)).FirstOrDefault<CategoryView>()?.Lt_Detail.Add(item);
          break;
        case EnumCategoryDepth.Lv3:
          CategoryView categoryView = this.Items.Where<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_ID == item.ctg_lv1_ID)).FirstOrDefault<CategoryView>();
          if (categoryView == null)
            break;
          categoryView.Lt_Detail.Where<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_ID == item.ctg_ParentsID)).FirstOrDefault<CategoryView>()?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<CategoryView> infos, bool p_is_level = false)
    {
      if (p_is_level)
      {
        foreach (CategoryView categoryView in infos.Where<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_Depth == 1)))
          this.Add(categoryView);
        foreach (CategoryView categoryView in infos.Where<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_Depth == 2)))
          this.Add(categoryView);
        foreach (CategoryView categoryView in infos.Where<CategoryView>((Func<CategoryView, bool>) (it => it.ctg_Depth == 3)))
          this.Add(categoryView);
      }
      else
      {
        foreach (CategoryView info in infos)
          this.Add(info);
      }
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(CategoryView item) => this.Items.Contains(item);

    public void CopyTo(CategoryView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(CategoryView item) => this.Items.Remove(item);
  }
}
