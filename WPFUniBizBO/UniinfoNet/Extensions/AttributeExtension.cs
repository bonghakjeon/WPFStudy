// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.AttributeExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniinfoNet.Extensions
{
  public static class AttributeExtension
  {
    public static List<R> GetAttributeList<R>(this Type obj, bool inherit = false) where R : Attribute => obj.GetCustomAttributes<R>(inherit).ToList<R>();

    public static R GetAttribute<R>(this Type obj, bool inherit = false) where R : Attribute => obj.GetCustomAttributes<R>(inherit).FirstOrDefault<R>();

    public static bool HasAttribute<R>(this Type obj, bool inherit = false) where R : Attribute => obj.GetCustomAttributes<R>(inherit).Count<R>() > 0;
  }
}
