// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.CommonCodeGroup
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  public class CommonCodeGroup : 
    BindableBase,
    ICollection<CommonCodeView>,
    IEnumerable<CommonCodeView>,
    IEnumerable
  {
    private List<CommonCodeView> _Items;

    public List<CommonCodeView> Items
    {
      get => this._Items ?? (this._Items = new List<CommonCodeView>());
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

    public CommonCodeGroup(int pType) => this.Type = pType;

    public CommonCodeGroup(int typeNum, IEnumerable<CommonCodeView> items)
      : this(typeNum)
    {
      this.Items.AddRange(items);
    }

    public CommonCodeView this[int p_comm_TypeNo] => this.FirstOrDefault<CommonCodeView>((Func<CommonCodeView, bool>) (it => it.comm_TypeNo == p_comm_TypeNo));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (CommonCodeGroup), (object) this.Type, (object) this.Count);

    public IEnumerator<CommonCodeView> GetEnumerator() => (IEnumerator<CommonCodeView>) this.Items?.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(CommonCodeView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(CommonCodeView item) => this.Items.Contains(item);

    public void CopyTo(CommonCodeView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(CommonCodeView item) => this.Items.Remove(item);
  }
}
