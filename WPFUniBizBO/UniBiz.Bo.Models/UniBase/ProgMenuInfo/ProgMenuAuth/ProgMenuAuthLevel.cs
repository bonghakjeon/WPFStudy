// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth.ProgMenuAuthLevel
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth
{
  public class ProgMenuAuthLevel : 
    BindableBase,
    ICollection<ProgMenuAuthView>,
    IEnumerable<ProgMenuAuthView>,
    IEnumerable
  {
    private List<ProgMenuAuthView> _Items;

    public List<ProgMenuAuthView> Items
    {
      get => this._Items ?? (this._Items = new List<ProgMenuAuthView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public int MenuGroupID { get; set; }

    public int MenuCode { get; set; }

    public bool IsReadOnly { get; }

    public ProgMenuAuthLevel()
    {
    }

    public ProgMenuAuthLevel(int pMenuGroupID, int pMenuCode)
    {
      this.MenuGroupID = pMenuGroupID;
      this.MenuCode = pMenuCode;
    }

    public ProgMenuAuthLevel(int pMenuGroupID, int pMenuCode, IEnumerable<ProgMenuAuthView> items)
      : this(pMenuGroupID, pMenuCode)
    {
      this.Items.AddRange(items);
    }

    [JsonIgnore]
    public ProgMenuAuthView this[int pMenuGroupID, int pMenuCode] => this.FirstOrDefault<ProgMenuAuthView>((Func<ProgMenuAuthView, bool>) (it => it.pmA_MenuGroupID == pMenuGroupID && it.pmA_MenuCode == pMenuCode));

    public override string ToString() => string.Format("{0} [{1},{2}] Count : {3}", (object) nameof (ProgMenuAuthLevel), (object) this.MenuGroupID, (object) this.MenuCode, (object) this.Count);

    public IEnumerator<ProgMenuAuthView> GetEnumerator() => (IEnumerator<ProgMenuAuthView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(ProgMenuAuthView item)
    {
      ProgMenuAuthView progMenuAuthView1 = this.Items.LastOrDefault<ProgMenuAuthView>();
      switch (Enum2StrConverter.ToMenuDepth(item.pm_MenuDepth))
      {
        case EnumMenuDepth.Lv1:
          this.Items.Add(item);
          break;
        case EnumMenuDepth.Lv2:
          progMenuAuthView1?.Lt_Detail.Add(item);
          break;
        case EnumMenuDepth.Lv3:
          if (progMenuAuthView1 == null)
            break;
          progMenuAuthView1.Lt_Detail.LastOrDefault<ProgMenuAuthView>()?.Lt_Detail.Add(item);
          break;
        case EnumMenuDepth.Lv4:
          if (progMenuAuthView1 == null)
            break;
          ProgMenuAuthView progMenuAuthView2 = progMenuAuthView1.Lt_Detail.LastOrDefault<ProgMenuAuthView>();
          if (progMenuAuthView2 == null)
            break;
          progMenuAuthView2.Lt_Detail.LastOrDefault<ProgMenuAuthView>()?.Lt_Detail.Add(item);
          break;
      }
    }

    public void AddRange(IEnumerable<ProgMenuAuthView> infos)
    {
      foreach (ProgMenuAuthView info in infos)
        this.Add(info);
    }

    public void Clear() => this.Items.Clear();

    public bool Contains(ProgMenuAuthView item) => this.Items.Contains(item);

    public void CopyTo(ProgMenuAuthView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(ProgMenuAuthView item) => this.Items.Remove(item);
  }
}
