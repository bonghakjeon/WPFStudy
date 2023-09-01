// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu.ProgMenuLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu
{
  public class ProgMenuLevel : 
    BindableBase,
    ICollection<ProgMenuView>,
    IEnumerable<ProgMenuView>,
    IEnumerable
  {
    private List<ProgMenuView> _Items;

    public List<ProgMenuView> Items
    {
      get => this._Items ?? (this._Items = new List<ProgMenuView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int MenuCode { get; set; }

    public bool IsReadOnly { get; }

    public ProgMenuLevel()
    {
    }

    public ProgMenuLevel(int pMenuCode) => this.MenuCode = pMenuCode;

    public ProgMenuLevel(int pMenuCode, IEnumerable<ProgMenuView> items)
      : this(pMenuCode)
    {
      this.Items.AddRange(items);
    }

    [JsonIgnore]
    public ProgMenuView this[int pMenuCode] => this.FirstOrDefault<ProgMenuView>((Func<ProgMenuView, bool>) (it => it.pm_MenuCode == pMenuCode));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (ProgMenuLevel), (object) this.MenuCode, (object) this.Count);

    public IEnumerator<ProgMenuView> GetEnumerator() => (IEnumerator<ProgMenuView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(ProgMenuView item)
    {
      ProgMenuView progMenuView1 = this.Items.LastOrDefault<ProgMenuView>();
      switch (Enum2StrConverter.ToMenuDepth(item.pm_MenuDepth))
      {
        case EnumMenuDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumMenuDepth.Lv2:
          progMenuView1?.Lt_Detail.Add(item);
          break;
        case EnumMenuDepth.Lv3:
          if (progMenuView1 == null)
            break;
          progMenuView1.Lt_Detail.LastOrDefault<ProgMenuView>()?.Lt_Detail.Add(item);
          break;
        case EnumMenuDepth.Lv4:
          if (progMenuView1 == null)
            break;
          ProgMenuView progMenuView2 = progMenuView1.Lt_Detail.LastOrDefault<ProgMenuView>();
          if (progMenuView2 == null)
            break;
          progMenuView2.Lt_Detail.LastOrDefault<ProgMenuView>()?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<ProgMenuView> infos)
    {
      foreach (ProgMenuView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(ProgMenuView item) => this.Items.Contains(item);

    public void CopyTo(ProgMenuView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(ProgMenuView item) => this.Items.Remove(item);
  }
}
