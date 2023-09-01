// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.DefaultAbstractValidator`2
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using FluentValidation;

namespace UniBizBO.Common
{
  public class DefaultAbstractValidator<T, R> : AbstractValidator<R> where T : DefaultAbstractValidator<T, R>, new()
  {
    private static T _default;

    public static T Default => DefaultAbstractValidator<T, R>._default ?? (DefaultAbstractValidator<T, R>._default = new T());
  }
}
