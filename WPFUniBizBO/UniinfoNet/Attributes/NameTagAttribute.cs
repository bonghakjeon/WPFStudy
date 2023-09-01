// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.NameTagAttribute
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniinfoNet.Attributes
{
  [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
  public class NameTagAttribute : BaseAttribute
  {
    private static Dictionary<Type, object> enumCache = new Dictionary<Type, object>();
    private static Dictionary<Type, object> unknownEnumCache = new Dictionary<Type, object>();

    public string Name { get; private set; }

    public NameTagAttribute(string name) => this.Name = name;

    public static List<Tuple<string, T>> GetEnumValueAndNameTagTupleList<T>() where T : Enum
    {
      Type type = typeof (T);
      object nameTagTupleList;
      if (NameTagAttribute.enumCache.TryGetValue(type, out nameTagTupleList))
        return nameTagTupleList as List<Tuple<string, T>>;
      List<Tuple<string, T>> result = new List<Tuple<string, T>>();
      ((IEnumerable<FieldInfo>) type.GetFields()).Where<FieldInfo>((Func<FieldInfo, bool>) (it => it.FieldType.Equals(type))).ToList<FieldInfo>().ForEach((Action<FieldInfo>) (pInfo => result.Add(new Tuple<string, T>(pInfo.GetCustomAttribute<NameTagAttribute>(false)?.Name, (T) pInfo.GetValue((object) null)))));
      NameTagAttribute.enumCache.Add(type, (object) result);
      return result;
    }

    public static List<Tuple<string, object>> GetEnumValueAndNameTagTupleList(Type enumType)
    {
      if (!enumType.IsEnum)
        return (List<Tuple<string, object>>) null;
      object nameTagTupleList;
      if (NameTagAttribute.unknownEnumCache.TryGetValue(enumType, out nameTagTupleList))
        return nameTagTupleList as List<Tuple<string, object>>;
      List<Tuple<string, object>> result = new List<Tuple<string, object>>();
      ((IEnumerable<FieldInfo>) enumType.GetFields()).Where<FieldInfo>((Func<FieldInfo, bool>) (it => it.FieldType.Equals(enumType))).ToList<FieldInfo>().ForEach((Action<FieldInfo>) (pInfo => result.Add(new Tuple<string, object>(pInfo.GetCustomAttribute<NameTagAttribute>(false)?.Name, pInfo.GetValue((object) null)))));
      NameTagAttribute.unknownEnumCache.Add(enumType, (object) result);
      return result;
    }
  }
}
