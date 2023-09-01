// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical.SaleByDayVerticalByCategoryTopPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.UniBase.Category;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical
{
  public class SaleByDayVerticalByCategoryTopPack : BindableBase
  {
    private IList<CategoryView> _DataHeader;
    private SaleByDayVerticalByCategoryTopDic _DataBody;

    [JsonPropertyName("dataHeader")]
    public IList<CategoryView> DataHeader
    {
      get => this._DataHeader;
      set
      {
        this._DataHeader = value;
        this.Changed(nameof (DataHeader));
      }
    }

    [JsonPropertyName("dataBody")]
    public SaleByDayVerticalByCategoryTopDic DataBody
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
