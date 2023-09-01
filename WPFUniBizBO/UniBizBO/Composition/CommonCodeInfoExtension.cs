// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.CommonCodeInfoExtension
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniBiz.Bo.Models.UniBase.CommonCode;

namespace UniBizBO.Composition
{
  public static class CommonCodeInfoExtension
  {
    public static UniBizBO.Composition.CommonCode ToCommonCodeInfo(this CommonCodeView o) => new UniBizBO.Composition.CommonCode().Apply(o);
  }
}
