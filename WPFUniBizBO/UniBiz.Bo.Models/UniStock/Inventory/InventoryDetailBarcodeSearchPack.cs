// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryDetailBarcodeSearchPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryDetailBarcodeSearchPack : BindableBase
  {
    private long _ih_SiteID;
    private int _ih_StoreCode;
    private DateTime? _ih_InventoryDate;
    private IList<InventoryDetailBarcodeSearchDetails> _Lt_Details;

    public long ih_SiteID
    {
      get => this._ih_SiteID;
      set
      {
        this._ih_SiteID = value;
        this.Changed(nameof (ih_SiteID));
      }
    }

    public int ih_StoreCode
    {
      get => this._ih_StoreCode;
      set
      {
        this._ih_StoreCode = value;
        this.Changed(nameof (ih_StoreCode));
      }
    }

    public DateTime? ih_InventoryDate
    {
      get => this._ih_InventoryDate;
      set
      {
        this._ih_InventoryDate = value;
        this.Changed(nameof (ih_InventoryDate));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<InventoryDetailBarcodeSearchDetails> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<InventoryDetailBarcodeSearchDetails>) new List<InventoryDetailBarcodeSearchDetails>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }
  }
}
