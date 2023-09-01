// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryDetailDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryDetailDic : 
    BindableBase,
    IReadOnlyDictionary<string, InventoryDetailView>,
    IEnumerable<KeyValuePair<string, InventoryDetailView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, InventoryDetailView>>
  {
    private Dictionary<string, InventoryDetailView> _Source = new Dictionary<string, InventoryDetailView>();

    public IReadOnlyDictionary<string, InventoryDetailView> Source => (IReadOnlyDictionary<string, InventoryDetailView>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<InventoryDetailView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public InventoryDetailView this[string key]
    {
      get
      {
        InventoryDetailView inventoryDetailView;
        return !this.Source.TryGetValue(key, out inventoryDetailView) ? (InventoryDetailView) null : inventoryDetailView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void AddOrigin(InventoryDetailView info)
    {
      if (this._Source.TryGetValue(info.DicKeyString, out InventoryDetailView _))
        return;
      this._Source.Add(info.DicKeyString, info);
    }

    public void AddRangeOrigin(IEnumerable<InventoryDetailView> infos)
    {
      foreach (InventoryDetailView info in infos)
        this.AddOrigin(info);
    }

    public void AddRangeOrigin(IList<InventoryDetailView> pInfos)
    {
      foreach (InventoryDetailView pInfo in (IEnumerable<InventoryDetailView>) pInfos)
        this.AddOrigin(pInfo);
    }

    public bool ContainsKey(string pKey) => this.Source.ContainsKey(pKey);

    public IEnumerator<KeyValuePair<string, InventoryDetailView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string pKey, [MaybeNullWhen(false)] out InventoryDetailView pValue) => this.Source.TryGetValue(pKey, out pValue);
  }
}
