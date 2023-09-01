// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumLocLevel
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumLocLevel
  {
    [Description("-로케이션단계-")] None,
    [Description("창고")] Lv1,
    [Description("지역")] Lv2,
    [Description("열")] Lv3,
    [Description("단<2:2:2:2, 1:층(F),2:곤도라,3:층,4:열>")] Lv4,
  }
}
