// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory.SupplierHistoryPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory
{
  public class SupplierHistoryPack : BindableBase, ICloneable
  {
    private IList<int> _Lt_WorkStore;
    private IList<SupplierHistoryView> _Lt_History;

    [JsonPropertyName("lt_WorkStore")]
    public IList<int> Lt_WorkStore
    {
      get => this._Lt_WorkStore ?? (this._Lt_WorkStore = (IList<int>) new List<int>());
      set
      {
        this._Lt_WorkStore = value;
        this.Changed(nameof (Lt_WorkStore));
      }
    }

    [JsonPropertyName("lt_History")]
    public IList<SupplierHistoryView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<SupplierHistoryView>) new List<SupplierHistoryView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public SupplierHistoryPack() => this.Clear();

    public void Clear()
    {
      this.Lt_WorkStore = (IList<int>) null;
      this.Lt_History = (IList<SupplierHistoryView>) null;
    }

    protected virtual SupplierHistoryPack CreateClone => new SupplierHistoryPack();

    public object Clone()
    {
      SupplierHistoryPack createClone = this.CreateClone;
      createClone.Lt_WorkStore = (IList<int>) null;
      if (this.Lt_WorkStore.Count > 0)
      {
        foreach (int num in (IEnumerable<int>) this.Lt_WorkStore)
          createClone.Lt_WorkStore.Add(num);
      }
      createClone.Lt_History = (IList<SupplierHistoryView>) null;
      if (this.Lt_History.Count > 0)
      {
        foreach (SupplierHistoryView supplierHistoryView in (IEnumerable<SupplierHistoryView>) this.Lt_History)
          createClone.Lt_History.Add(supplierHistoryView);
      }
      return (object) createClone;
    }

    public void PutData(SupplierHistoryPack pSource)
    {
      this.Lt_WorkStore = (IList<int>) null;
      if (pSource.Lt_WorkStore.Count > 0)
      {
        foreach (int num in (IEnumerable<int>) pSource.Lt_WorkStore)
          this.Lt_WorkStore.Add(num);
      }
      this.Lt_History = (IList<SupplierHistoryView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (SupplierHistoryView pSource1 in (IEnumerable<SupplierHistoryView>) pSource.Lt_History)
      {
        SupplierHistoryView supplierHistoryView = new SupplierHistoryView();
        supplierHistoryView.PutData(pSource1);
        this.Lt_History.Add(supplierHistoryView);
      }
    }
  }
}
