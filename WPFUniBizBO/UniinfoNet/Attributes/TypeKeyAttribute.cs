// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.TypeKeyAttribute
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Reflection;

namespace UniinfoNet.Attributes
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
  public class TypeKeyAttribute : BaseAttribute
  {
    public string Key { get; set; }

    public TypeKeyAttribute(string key) => this.Key = key;

    public static string GetKey(Type type, bool inherit = false) => type.GetCustomAttribute<TypeKeyAttribute>(inherit)?.Key;

    public static string GetKey<T>(bool inherit = false) => TypeKeyAttribute.GetKey(typeof (T), inherit);
  }
}
