﻿// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryDetailByStatementNoDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryDetailByStatementNoDic : 
    BindableBase,
    IReadOnlyDictionary<long, InventoryDetailView>,
    IEnumerable<KeyValuePair<long, InventoryDetailView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, InventoryDetailView>>
  {
    private Dictionary<long, InventoryDetailView> _Source = new Dictionary<long, InventoryDetailView>();

    public IReadOnlyDictionary<long, InventoryDetailView> Source => (IReadOnlyDictionary<long, InventoryDetailView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<InventoryDetailView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public InventoryDetailView this[long key]
    {
      get
      {
        InventoryDetailView inventoryDetailView;
        return !this.Source.TryGetValue(key, out inventoryDetailView) ? (InventoryDetailView) null : inventoryDetailView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(InventoryDetailView info)
    {
      InventoryDetailView inventoryDetailView;
      if (!this._Source.TryGetValue(info.id_StatementNo, out inventoryDetailView))
      {
        inventoryDetailView = new InventoryDetailView();
        inventoryDetailView.id_StatementNo = info.id_StatementNo;
        this._Source.Add(info.id_StatementNo, inventoryDetailView);
      }
      inventoryDetailView?.Lt_History.Add(info);
    }

    public void AddRange(IEnumerable<InventoryDetailView> infos)
    {
      foreach (InventoryDetailView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, InventoryDetailView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out InventoryDetailView value) => this.Source.TryGetValue(key, out value);
  }
}
