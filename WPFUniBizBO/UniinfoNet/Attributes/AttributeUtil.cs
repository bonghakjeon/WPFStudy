// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.AttributeUtil
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


#nullable enable
namespace UniinfoNet.Attributes
{
  public class AttributeUtil
  {
    public static 
    #nullable disable
    (Type, TAttr)[] Get<TAttr>(Assembly asm, bool inherit = false, bool onlyFirst = true) where TAttr : Attribute
    {
      Type[] types = asm.GetTypes();
      return onlyFirst ? ((IEnumerable<Type>) types).AsParallel<Type>().AsOrdered<Type>().Select<Type, (Type, TAttr)>((Func<Type, (Type, TAttr)>) (t => (t, t.GetCustomAttribute<TAttr>(inherit)))).Where<(Type, TAttr)>((Func<(Type, TAttr), bool>) (v => (object) v.Item2 != null)).ToArray<(Type, TAttr)>() : ((IEnumerable<Type>) types).AsParallel<Type>().AsOrdered<Type>().SelectMany<Type, (Type, TAttr)>((Func<Type, IEnumerable<(Type, TAttr)>>) (t =>
      {
        IEnumerable<TAttr> customAttributes = t.GetCustomAttributes<TAttr>(inherit);
        return customAttributes == null ? (IEnumerable<(Type, TAttr)>) null : customAttributes.Select<TAttr, (Type, TAttr)>((Func<TAttr, (Type, TAttr)>) (a => (t, a)));
      })).ToArray<(Type, TAttr)>();
    }
  }
}
