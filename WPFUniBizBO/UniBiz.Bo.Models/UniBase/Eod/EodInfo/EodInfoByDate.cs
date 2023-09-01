// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodInfo.EodInfoByDate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Eod.EodInfo
{
  public class EodInfoByDate : 
    BindableBase,
    ICollection<EodInfoView>,
    IEnumerable<EodInfoView>,
    IEnumerable
  {
    private List<EodInfoView> _Items;

    public List<EodInfoView> Items
    {
      get => this._Items ?? (this._Items = new List<EodInfoView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public DateTime eod_Date { get; set; }

    public bool IsReadOnly { get; }

    public EodInfoByDate(DateTime p_eod_Date)
    {
      this.eod_Date = p_eod_Date;
      this.Items = new List<EodInfoView>();
    }

    public EodInfoByDate(DateTime p_eod_Date, IEnumerable<EodInfoView> items)
      : this(p_eod_Date)
    {
      this.Items.AddRange(items);
    }

    public EodInfoView this[DateTime pValue] => this.FirstOrDefault<EodInfoView>((Func<EodInfoView, bool>) (it => it.eod_Date.Equals((object) pValue)));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) "EodInfoView", (object) this.eod_Date.ToString(), (object) this.Count);

    public IEnumerator<EodInfoView> GetEnumerator() => (IEnumerator<EodInfoView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(EodInfoView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(EodInfoView item) => this.Items.Contains(item);

    public void CopyTo(EodInfoView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(EodInfoView item) => this.Items.Remove(item);
  }
}
