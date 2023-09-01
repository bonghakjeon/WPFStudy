// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLocLocationType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLocLocationType
  {
    [Description("-로케이션타입-")] None,
    [Description("일반")] Normal,
    [Description("입출고")] InOut,
    [Description("불량")] Abnormal,
  }
}
