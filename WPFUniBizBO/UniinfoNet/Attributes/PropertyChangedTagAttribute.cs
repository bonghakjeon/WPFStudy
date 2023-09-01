// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.PropertyChangedTagAttribute
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniinfoNet.Attributes
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class PropertyChangedTagAttribute : BaseAttribute
  {
    private static Dictionary<string, List<(string mark, string name)>> cache = new Dictionary<string, List<(string, string)>>();

    public string Mark { get; private set; }

    public PropertyChangedTagAttribute() => this.Mark = "";

    public PropertyChangedTagAttribute(string mark) => this.Mark = mark;

    public static List<(string mark, string name)> GetList(Type type, bool isFindOnlyTag = true)
    {
      if (type == (Type) null)
        return new List<(string, string)>();
      Type type1 = type;
      List<(string, string)> list1;
      if (PropertyChangedTagAttribute.cache.TryGetValue(type1.FullName, out list1))
        return list1;
      List<MemberInfo> list2 = ((IEnumerable<MemberInfo>) type1.GetMembers(BindingFlags.Instance | BindingFlags.Public)).Where<MemberInfo>((Func<MemberInfo, bool>) (it => it.MemberType == MemberTypes.Property || it.MemberType == MemberTypes.Method)).ToList<MemberInfo>();
      List<(string, string)> result = new List<(string, string)>();
      list2.ToList<MemberInfo>().ForEach((Action<MemberInfo>) (it =>
      {
        PropertyChangedTagAttribute customAttribute = it.GetCustomAttribute<PropertyChangedTagAttribute>(true);
        if (customAttribute != null)
        {
          result.Add((customAttribute.Mark, it.Name));
        }
        else
        {
          if (isFindOnlyTag)
            return;
          result.Add(((string) null, it.Name));
        }
      }));
      PropertyChangedTagAttribute.cache.Add(type1.FullName, result);
      return result;
    }

    public static List<(string mark, string name)> GetList(object obj, bool isFindOnlyTag = true) => obj == null ? PropertyChangedTagAttribute.GetList((Type) null, isFindOnlyTag) : PropertyChangedTagAttribute.GetList(obj.GetType(), isFindOnlyTag);

    public static List<(string mark, string name)> GetList<T>(bool isFindOnlyTag = true) where T : class => PropertyChangedTagAttribute.GetList(typeof (T), isFindOnlyTag);
  }
}
