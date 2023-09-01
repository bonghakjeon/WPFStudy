// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.CategoryTagAttribute
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
  public class CategoryTagAttribute : BaseAttribute
  {
    public List<string> Categories { get; private set; }

    public CategoryTagAttribute(params string[] categories) => this.Categories = ((IEnumerable<string>) categories).ToList<string>();

    public static bool Contain(MemberInfo memberInfo, string category)
    {
      CategoryTagAttribute customAttribute = memberInfo.GetCustomAttribute<CategoryTagAttribute>();
      bool? nullable;
      if (customAttribute == null)
      {
        nullable = new bool?();
      }
      else
      {
        List<string> categories = customAttribute.Categories;
        nullable = categories != null ? new bool?(categories.Any<string>((Func<string, bool>) (s => s.Equals(category, StringComparison.OrdinalIgnoreCase)))) : new bool?();
      }
      return nullable.GetValueOrDefault();
    }
  }
}
