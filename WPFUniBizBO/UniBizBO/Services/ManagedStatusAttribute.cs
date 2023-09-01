// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.ManagedStatusAttribute
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniBizBO.Services
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class ManagedStatusAttribute : Attribute
  {
    public string Key { get; set; }

    public bool IsAutoSave { get; set; } = true;

    public bool IsAutoLoad { get; set; } = true;

    public Type RealType { get; set; }

    public ManagedStatusAttribute()
    {
    }

    public ManagedStatusAttribute(string key) => this.Key = key;

    public static System.Collections.Generic.List<ManagedStatusPropertyInfo> GetManagedStatusPropertyInfos<T>(
      T target)
      where T : class
    {
      return (object) target == null ? (System.Collections.Generic.List<ManagedStatusPropertyInfo>) null : ((IEnumerable<PropertyInfo>) target.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Select<PropertyInfo, ManagedStatusPropertyInfo>((Func<PropertyInfo, ManagedStatusPropertyInfo>) (it =>
      {
        ManagedStatusAttribute customAttribute = it.GetCustomAttribute<ManagedStatusAttribute>(true);
        if (customAttribute == null)
          return (ManagedStatusPropertyInfo) null;
        return new ManagedStatusPropertyInfo()
        {
          PInfo = it,
          ItemName = string.IsNullOrWhiteSpace(customAttribute.Key) ? it.Name : customAttribute.Key,
          RealType = customAttribute.RealType
        };
      })).Where<ManagedStatusPropertyInfo>((Func<ManagedStatusPropertyInfo, bool>) (it => it != null)).DistinctBy<ManagedStatusPropertyInfo, string>((Func<ManagedStatusPropertyInfo, string>) (it => it.ItemName)).ToList<ManagedStatusPropertyInfo>();
    }
  }
}
