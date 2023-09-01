// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSupplierTypeNeo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSupplierTypeNeo
  {
    [Description("-거래형태-")] None = 0,
    [Description("직영")] DIRECT = 1,
    [Description("특정")] SPE = 3,
    [Description("임대")] LEA = 7,
  }
}
