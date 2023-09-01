// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementDetailBarcodeSearchPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementDetailBarcodeSearchPack : BindableBase
  {
    private long _sh_SiteID;
    private int _sh_StoreCode;
    private int _sh_Supplier;
    private DateTime? _sh_ConfirmDate;
    private bool _IsHistoryList;
    private IList<StatementDetailBarcodeSearchDetails> _Lt_Details;

    public long sh_SiteID
    {
      get => this._sh_SiteID;
      set
      {
        this._sh_SiteID = value;
        this.Changed(nameof (sh_SiteID));
      }
    }

    public int sh_StoreCode
    {
      get => this._sh_StoreCode;
      set
      {
        this._sh_StoreCode = value;
        this.Changed(nameof (sh_StoreCode));
      }
    }

    public int sh_Supplier
    {
      get => this._sh_Supplier;
      set
      {
        this._sh_Supplier = value;
        this.Changed(nameof (sh_Supplier));
      }
    }

    public DateTime? sh_ConfirmDate
    {
      get => this._sh_ConfirmDate;
      set
      {
        this._sh_ConfirmDate = value;
        this.Changed(nameof (sh_ConfirmDate));
      }
    }

    [JsonPropertyName("isHistoryList")]
    public bool IsHistoryList
    {
      get => this._IsHistoryList;
      set
      {
        this._IsHistoryList = value;
        this.Changed(nameof (IsHistoryList));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<StatementDetailBarcodeSearchDetails> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<StatementDetailBarcodeSearchDetails>) new List<StatementDetailBarcodeSearchDetails>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }
  }
}
