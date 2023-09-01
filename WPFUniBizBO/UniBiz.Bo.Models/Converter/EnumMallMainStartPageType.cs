// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumMallMainStartPageType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumMallMainStartPageType
  {
    [Description("-쇼핑몰 메인 페이지 타입-")] None,
    [Description("전단이미지")] LeafletImage,
    [Description("전단상품")] LeafletGoods,
    [Description("행사상품")] EventGoods,
    [Description("카테고리")] Category,
    [Description("이용안내")] InformationUse,
  }
}
