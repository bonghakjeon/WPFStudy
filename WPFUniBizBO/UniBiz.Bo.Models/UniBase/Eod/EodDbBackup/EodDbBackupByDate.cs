// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodDbBackup.EodDbBackupByDate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Eod.EodDbBackup
{
  public class EodDbBackupByDate : 
    BindableBase,
    ICollection<EodDbBackupView>,
    IEnumerable<EodDbBackupView>,
    IEnumerable
  {
    private List<EodDbBackupView> _Items;

    public List<EodDbBackupView> Items
    {
      get => this._Items ?? (this._Items = new List<EodDbBackupView>());
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
        this.Changed("Count");
      }
    }

    public int Count => this.Items.Count;

    public DateTime eodb_date { get; set; }

    public bool IsReadOnly { get; }

    public EodDbBackupByDate(DateTime p_eodb_date)
    {
      this.eodb_date = p_eodb_date;
      this.Items = new List<EodDbBackupView>();
    }

    public EodDbBackupByDate(DateTime p_eodb_date, IEnumerable<EodDbBackupView> items)
      : this(p_eodb_date)
    {
      this.Items.AddRange(items);
    }

    public EodDbBackupView this[DateTime pValue] => this.FirstOrDefault<EodDbBackupView>((Func<EodDbBackupView, bool>) (it => it.eodb_date.Equals((object) pValue)));

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) "EodDbBackupView", (object) this.eodb_date.ToString(), (object) this.Count);

    public IEnumerator<EodDbBackupView> GetEnumerator() => (IEnumerator<EodDbBackupView>) this.Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Items.GetEnumerator();

    public void Add(EodDbBackupView item) => this.Items.Add(item);

    public void Clear() => this.Items.Clear();

    public bool Contains(EodDbBackupView item) => this.Items.Contains(item);

    public void CopyTo(EodDbBackupView[] array, int arrayIndex) => this.Items.CopyTo(array, arrayIndex);

    public bool Remove(EodDbBackupView item) => this.Items.Remove(item);
  }
}
