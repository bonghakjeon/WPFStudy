// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Summary.PaymentMonthWorkPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Payment.Summary
{
  public class PaymentMonthWorkPack : BindableBase
  {
    private int _WorkStoreCode;
    private string _WorkStoreCodeIn;
    private DateTime? _WorkOriginDate;
    private bool _IsWorkDateType = true;
    private int _WorkSupplier;
    private DateTime? _sh_ConfirmDate_BEGIN_;
    private DateTime? _sh_ConfirmDate_END_;

    [JsonPropertyName("workStoreCode")]
    public int WorkStoreCode
    {
      get => this._WorkStoreCode;
      set
      {
        this._WorkStoreCode = value;
        this.Changed(nameof (WorkStoreCode));
        this.Changed("WorkStoreCount");
      }
    }

    [JsonPropertyName("workStoreCodeIn")]
    public string WorkStoreCodeIn
    {
      get => this._WorkStoreCodeIn;
      set
      {
        this._WorkStoreCodeIn = value;
        this.Changed(nameof (WorkStoreCodeIn));
        this.Changed("WorkStoreCount");
      }
    }

    [JsonIgnore]
    public int WorkStoreCount
    {
      get
      {
        if (!string.IsNullOrEmpty(this.WorkStoreCodeIn))
          return this.WorkStoreCodeIn.Split(',').Length + 1;
        return this.WorkStoreCode <= 0 ? 0 : 1;
      }
    }

    [JsonPropertyName("workOriginDate")]
    public DateTime? WorkOriginDate
    {
      get => this._WorkOriginDate;
      set
      {
        this._WorkOriginDate = value;
        this.Changed(nameof (WorkOriginDate));
      }
    }

    [JsonPropertyName("isWorkDateType")]
    public bool IsWorkDateType
    {
      get => this._IsWorkDateType;
      set
      {
        this._IsWorkDateType = value;
        this.Changed(nameof (IsWorkDateType));
      }
    }

    [JsonPropertyName("workSupplier")]
    public int WorkSupplier
    {
      get => this._WorkSupplier;
      set
      {
        this._WorkSupplier = value;
        this.Changed(nameof (WorkSupplier));
      }
    }

    public DateTime? sh_ConfirmDate_BEGIN_
    {
      get => this._sh_ConfirmDate_BEGIN_;
      set
      {
        this._sh_ConfirmDate_BEGIN_ = value;
        this.Changed(nameof (sh_ConfirmDate_BEGIN_));
      }
    }

    public DateTime? sh_ConfirmDate_END_
    {
      get => this._sh_ConfirmDate_END_;
      set
      {
        this._sh_ConfirmDate_END_ = value;
        this.Changed(nameof (sh_ConfirmDate_END_));
      }
    }
  }
}
