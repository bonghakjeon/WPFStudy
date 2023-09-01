// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSupplierKind
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSupplierKind
  {
    [Description("-업체종류-")] None,
    [Description("직영")] DIRECT,
    [Description("가맹")] FRANCHISEE,
    [Description("매입처")] PURCHASE,
    [Description("매출처")] SALES,
    [Description("제휴거래처")] ALLIANCE,
  }
}
