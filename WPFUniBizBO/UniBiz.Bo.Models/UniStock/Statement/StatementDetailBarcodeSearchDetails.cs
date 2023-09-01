// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementDetailBarcodeSearchDetails
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementDetailBarcodeSearchDetails : BindableBase
  {
    private string _sd_BarCode;
    private long _sd_BoxCode;

    public string sd_BarCode
    {
      get => this._sd_BarCode;
      set
      {
        this._sd_BarCode = value;
        this.Changed(nameof (sd_BarCode));
      }
    }

    public long sd_BoxCode
    {
      get => this._sd_BoxCode;
      set
      {
        this._sd_BoxCode = value;
        this.Changed(nameof (sd_BoxCode));
      }
    }
  }
}
