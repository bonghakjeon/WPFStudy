// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date.ISalesByDayDate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniBiz.Bo.Models.Converter;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date
{
  public interface ISalesByDayDate
  {
    int row_number { get; set; }

    bool row_IsDataTypeTotalSum { get; }

    int sbd_SaleDays { get; set; }

    int sbd_StoreCode { get; set; }

    long sbd_SiteID { get; set; }

    double sbd_SaleQty { get; set; }

    double sbd_SaleQtyRule { get; set; }

    double sbd_SaleAmt { get; set; }

    double sbd_SaleAmtRule { get; set; }

    bool IsZero(EnumZeroCheck pCheckType);
  }
}
