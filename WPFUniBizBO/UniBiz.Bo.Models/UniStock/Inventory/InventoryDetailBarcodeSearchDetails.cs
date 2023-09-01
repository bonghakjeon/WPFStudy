// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryDetailBarcodeSearchDetails
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryDetailBarcodeSearchDetails : BindableBase
  {
    private string _id_BarCode;
    private long _id_BoxCode;

    public string id_BarCode
    {
      get => this._id_BarCode;
      set
      {
        this._id_BarCode = value;
        this.Changed(nameof (id_BarCode));
      }
    }

    public long id_BoxCode
    {
      get => this._id_BoxCode;
      set
      {
        this._id_BoxCode = value;
        this.Changed(nameof (id_BoxCode));
      }
    }
  }
}
