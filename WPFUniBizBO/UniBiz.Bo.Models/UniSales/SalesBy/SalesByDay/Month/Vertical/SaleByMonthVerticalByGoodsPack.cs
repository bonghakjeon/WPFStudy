// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical.SaleByMonthVerticalByGoodsPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical
{
  public class SaleByMonthVerticalByGoodsPack : BindableBase
  {
    private IList<TGoods> _DataHeader;
    private SaleByMonthVerticalByGoodsDic _DataBody;

    [JsonPropertyName("dataHeader")]
    public IList<TGoods> DataHeader
    {
      get => this._DataHeader;
      set
      {
        this._DataHeader = value;
        this.Changed(nameof (DataHeader));
      }
    }

    [JsonPropertyName("dataBody")]
    public SaleByMonthVerticalByGoodsDic DataBody
    {
      get => this._DataBody;
      set
      {
        this._DataBody = value;
        this.Changed(nameof (DataBody));
      }
    }
  }
}
