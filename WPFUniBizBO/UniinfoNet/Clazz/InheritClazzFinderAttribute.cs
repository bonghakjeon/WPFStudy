// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Clazz.InheritClazzFinderAttribute
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using UniinfoNet.Extensions;

namespace UniinfoNet.Clazz
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public class InheritClazzFinderAttribute : Attribute
  {
    public bool IsFoundable { get; set; } = true;

    public InheritClazzFinderAttribute(bool isFoundable = true) => this.IsFoundable = isFoundable;

    public static bool CheckFoundable(Type t)
    {
      InheritClazzFinderAttribute attribute = t.GetAttribute<InheritClazzFinderAttribute>();
      return attribute == null || attribute.IsFoundable;
    }
  }
}
