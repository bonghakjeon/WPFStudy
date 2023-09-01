// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.ExpressionExtensions
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Linq.Expressions;
using System.Reflection;

namespace UniinfoNet.Extensions
{
  public static class ExpressionExtensions
  {
    public static MemberInfo GetMemberInfo(this Expression expression)
    {
      LambdaExpression lambdaExpression = (LambdaExpression) expression;
      return lambdaExpression.Body is UnaryExpression body ? (body.Operand as MemberExpression).Member : (lambdaExpression.Body as MemberExpression).Member;
    }
  }
}
