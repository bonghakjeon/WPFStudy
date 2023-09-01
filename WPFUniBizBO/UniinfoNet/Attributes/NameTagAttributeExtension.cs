// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.NameTagAttributeExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniinfoNet.Attributes
{
  public static class NameTagAttributeExtension
  {
    public static string GetNameTag(this Enum value)
    {
      string name = value.ToString();
      NameTagAttribute[] customAttributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof (NameTagAttribute), false) as NameTagAttribute[];
      if (customAttributes.Length != 0)
        name = customAttributes[0].Name;
      return name;
    }

    public static Dictionary<string, string> GetNameTagDic(
      this Type obj,
      NameTagAttributeExtension.NameTagType type = NameTagAttributeExtension.NameTagType.Property)
    {
      Dictionary<string, string> resultDic = new Dictionary<string, string>();
      switch (type)
      {
        case NameTagAttributeExtension.NameTagType.Property:
          ((IEnumerable<PropertyInfo>) obj.GetProperties()).Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.CanWrite)).ToList<PropertyInfo>().ForEach((Action<PropertyInfo>) (pInfo =>
          {
            List<NameTagAttribute> list = ((IEnumerable<NameTagAttribute>) (pInfo.GetCustomAttributes(typeof (NameTagAttribute), false) as NameTagAttribute[])).ToList<NameTagAttribute>();
            string name = list.Count > 0 ? list[0].Name : (string) null;
            resultDic.Add(pInfo.Name, name);
          }));
          return resultDic;
        case NameTagAttributeExtension.NameTagType.Field:
          List<FieldInfo> list1 = ((IEnumerable<FieldInfo>) obj.GetFields()).ToList<FieldInfo>();
          if (obj.IsEnum)
            list1 = list1.Where<FieldInfo>((Func<FieldInfo, bool>) (it => it.FieldType.Equals(obj))).ToList<FieldInfo>();
          list1.ForEach((Action<FieldInfo>) (pInfo =>
          {
            List<NameTagAttribute> list2 = ((IEnumerable<NameTagAttribute>) (pInfo.GetCustomAttributes(typeof (NameTagAttribute), false) as NameTagAttribute[])).ToList<NameTagAttribute>();
            string name = list2.Count > 0 ? list2[0].Name : (string) null;
            resultDic.Add(pInfo.Name, name);
          }));
          return resultDic;
        default:
          return resultDic;
      }
    }

    public enum NameTagType
    {
      Property,
      Field,
    }
  }
}
