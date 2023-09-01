// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryWork.InventoryWorkCntByKeyDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Inventory.InventoryWork
{
  public class InventoryWorkCntByKeyDic : 
    BindableBase,
    IReadOnlyDictionary<string, InventoryWorkCntView>,
    IEnumerable<KeyValuePair<string, InventoryWorkCntView>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, InventoryWorkCntView>>
  {
    private Dictionary<string, InventoryWorkCntView> _Source = new Dictionary<string, InventoryWorkCntView>();

    public IReadOnlyDictionary<string, InventoryWorkCntView> Source => (IReadOnlyDictionary<string, InventoryWorkCntView>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<InventoryWorkCntView> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public InventoryWorkCntView this[string key]
    {
      get
      {
        InventoryWorkCntView inventoryWorkCntView;
        return !this.Source.TryGetValue(key, out inventoryWorkCntView) ? (InventoryWorkCntView) null : inventoryWorkCntView;
      }
    }

    public void Clear() => this._Source.Clear();

    public void Add(InventoryWorkCntView info)
    {
      if (this._Source.TryGetValue(string.Format("{0}|{1}", (object) info.iwc_InventoryDateInt, (object) info.iwc_StoreCode), out InventoryWorkCntView _))
        return;
      InventoryWorkCntView inventoryWorkCntView = new InventoryWorkCntView();
      this._Source.Add(string.Format("{0}|{1}", (object) info.iwc_InventoryDateInt, (object) info.iwc_StoreCode), inventoryWorkCntView);
    }

    public void AddRange(IEnumerable<InventoryWorkCntView> infos)
    {
      foreach (InventoryWorkCntView info in infos)
        this.Add(info);
    }

    public void AddOrigin(InventoryWorkCntView info)
    {
      if (this._Source.TryGetValue(string.Format("{0}|{1}", (object) info.iwc_InventoryDateInt, (object) info.iwc_StoreCode), out InventoryWorkCntView _))
        return;
      InventoryWorkCntView inventoryWorkCntView = info;
      this._Source.Add(string.Format("{0}|{1}", (object) info.iwc_InventoryDateInt, (object) info.iwc_StoreCode), inventoryWorkCntView);
    }

    public void AddOriginRange(IEnumerable<InventoryWorkCntView> infos)
    {
      foreach (InventoryWorkCntView info in infos)
        this.Add(info);
    }

    public void AddOriginRange(IList<InventoryWorkCntView> infos)
    {
      foreach (InventoryWorkCntView info in (IEnumerable<InventoryWorkCntView>) infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, InventoryWorkCntView>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out InventoryWorkCntView value) => this.Source.TryGetValue(key, out value);
  }
}
