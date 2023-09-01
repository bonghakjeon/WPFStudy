// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumSearchType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumSearchType
  {
    [Description("-조회타입-")] None,
    [Description("지점")] Store,
    [Description("팀")] Team,
    [Description("부서")] Dept,
    [Description("대분류")] CategoryTop,
    [Description("중분류")] CategoryMid,
    [Description("소분류")] CategoryBot,
    [Description("상품")] Goods,
    [Description("업체")] Supplier,
    [Description("제조사")] Maker,
    [Description("브랜드")] Brand,
  }
}
