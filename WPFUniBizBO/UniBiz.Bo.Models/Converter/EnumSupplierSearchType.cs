// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSupplierSearchType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSupplierSearchType
  {
    [Description("-조회타입-")] None,
    [Description("기간")] Date,
    [Description("일자")] Day,
    [Description("전표")] Statement,
    [Description("전표상세")] StatementDetail,
    [Description("상품")] Goods,
  }
}
