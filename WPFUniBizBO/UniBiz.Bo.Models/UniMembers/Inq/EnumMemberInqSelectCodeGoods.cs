// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.EnumMemberInqSelectCodeGoods
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.UniMembers.Inq
{
  public enum EnumMemberInqSelectCodeGoods
  {
    [Description("-조회코드-")] NONE,
    [Description("대분류")] CATEGORY_LV1,
    [Description("중분류")] CATEGORY_LV2,
    [Description("소분류")] CATEGORY_LV3,
    [Description("상품")] GOODS,
  }
}
