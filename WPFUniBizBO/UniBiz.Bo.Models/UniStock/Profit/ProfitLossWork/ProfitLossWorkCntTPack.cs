// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.ProfitLossWorkCntTPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class ProfitLossWorkCntTPack : BindableBase
  {
    private string _WorkStoreCodeIn;
    private TProfitLossWorkCnt _WorkData;

    [JsonPropertyName("workStoreCodeIn")]
    public string WorkStoreCodeIn
    {
      get => this._WorkStoreCodeIn;
      set
      {
        this._WorkStoreCodeIn = value;
        this.Changed(nameof (WorkStoreCodeIn));
      }
    }

    [JsonPropertyName("workData")]
    public TProfitLossWorkCnt WorkData
    {
      get => this._WorkData;
      set
      {
        this._WorkData = value;
        this.Changed(nameof (WorkData));
      }
    }

    [JsonIgnore]
    public int WorkStoreCount
    {
      get
      {
        if (this.WorkData == null)
          return 0;
        if (!string.IsNullOrEmpty(this.WorkStoreCodeIn))
          return this.WorkStoreCodeIn.Split(',').Length;
        return this.WorkData.plwc_StoreCode <= 0 ? 0 : 1;
      }
    }

    public DateTime? WorkOriginDate => this.WorkData != null ? this.WorkData.plwc_OriginDate : new DateTime?();
  }
}
