// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryHeaderByNoDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryHeaderByNoDic : 
    BindableBase,
    IReadOnlyDictionary<long, InventoryHeaderView>,
    IEnumerable<KeyValuePair<long, InventoryHeaderView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<long, InventoryHeaderView>>
  {
    private Dictionary<long, InventoryHeaderView> _Source = new Dictionary<long, InventoryHeaderView>();

    public IReadOnlyDictionary<long, InventoryHeaderView> Source => (IReadOnlyDictionary<long, InventoryHeaderView>) this._Source;

    public IEnumerable<long> Keys => this.Source.Keys;

    public IEnumerable<InventoryHeaderView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public InventoryHeaderView this[long key]
    {
      get
      {
        InventoryHeaderView inventoryHeaderView;
        return !this.Source.TryGetValue(key, out inventoryHeaderView) ? (InventoryHeaderView) null : inventoryHeaderView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(InventoryHeaderView info)
    {
      if (this._Source.TryGetValue(info.ih_StatementNo, out InventoryHeaderView _))
        return;
      InventoryHeaderView inventoryHeaderView = new InventoryHeaderView();
      this._Source.Add(info.ih_StatementNo, inventoryHeaderView);
    }

    public void AddRange(IEnumerable<InventoryHeaderView> infos)
    {
      foreach (InventoryHeaderView info in infos)
        this.Add(info);
    }

    public void AddOrigin(InventoryHeaderView info)
    {
      if (this._Source.TryGetValue(info.ih_StatementNo, out InventoryHeaderView _))
        return;
      InventoryHeaderView inventoryHeaderView = info;
      this._Source.Add(info.ih_StatementNo, inventoryHeaderView);
    }

    public void AddOriginRange(IEnumerable<InventoryHeaderView> infos)
    {
      foreach (InventoryHeaderView info in infos)
        this.Add(info);
    }

    public bool ContainsKey(long key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<long, InventoryHeaderView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(long key, [MaybeNullWhen(false)] out InventoryHeaderView value) => this.Source.TryGetValue(key, out value);
  }
}
