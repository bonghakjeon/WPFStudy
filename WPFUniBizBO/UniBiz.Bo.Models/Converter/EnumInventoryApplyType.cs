// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumInventoryApplyType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumInventoryApplyType
  {
    [Description("-재고변환구분-")] None,
    [Description("변환")] Apply,
    [Description("미변환")] NotApply,
  }
}
