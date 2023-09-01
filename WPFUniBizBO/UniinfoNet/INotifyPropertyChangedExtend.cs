// Decompiled with JetBrains decompiler
// Type: UniinfoNet.INotifyPropertyChangedExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace UniinfoNet
{
  public static class INotifyPropertyChangedExtension
  {
    public static void Changed<TProperty>(
      this INotifyPropertyChangedExtend obj,
      Expression<Func<TProperty>> property)
    {
      if (obj._EnablePropertyChanged)
        return;
      LambdaExpression lambdaExpression = (LambdaExpression) property;
      MemberInfo memberInfo = !(lambdaExpression.Body is UnaryExpression body) ? (lambdaExpression.Body as MemberExpression).Member : (body.Operand as MemberExpression).Member;
      obj.Changed(memberInfo.Name);
    }

    public static void Changed<TParent>(
      this TParent obj,
      params Expression<Func<TParent, object>>[] properties)
      where TParent : INotifyPropertyChangedExtend
    {
      if (obj._EnablePropertyChanged)
        return;
      foreach (LambdaExpression property in properties)
      {
        if (!(property.Body is NewExpression body))
          throw new ArgumentException();
        body.Members.Select<MemberInfo, string>((Func<MemberInfo, string>) (it => it.Name)).ToList<string>().ForEach((Action<string>) (it => obj.Changed(it)));
      }
    }
  }
}
