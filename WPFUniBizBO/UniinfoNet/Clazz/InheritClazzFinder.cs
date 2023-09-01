// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Clazz.InheritClazzFinder
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


#nullable enable
namespace UniinfoNet.Clazz
{
  public class InheritClazzFinder : BindableBase
  {
    private 
    #nullable disable
    List<Assembly> assemblies;

    public List<Assembly> Assemblies
    {
      get => this.assemblies ?? (this.assemblies = new List<Assembly>());
      set
      {
        this.assemblies = value;
        this.Changed(nameof (Assemblies));
      }
    }

    public InheritClazzFinder(IEnumerable<Assembly> asms) => this.Assemblies = asms.ToList<Assembly>();

    public List<Type> GetList(Type service) => this.Assemblies.SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (it => (IEnumerable<Type>) InheritClazzFinder.GetList(it, service))).ToList<Type>();

    public List<Type> GetList<TService>() => this.GetList(typeof (TService));

    public Type Get(Type service, string implementClazzName, bool isFullName = false)
    {
      IEnumerable<Type> source = this.Assemblies.SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (it => (IEnumerable<Type>) InheritClazzFinder.GetList(it, service)));
      return (!isFullName ? source.Where<Type>((Func<Type, bool>) (it => it.Name.Equals(implementClazzName))) : source.Where<Type>((Func<Type, bool>) (it => it.FullName.Equals(implementClazzName)))).FirstOrDefault<Type>();
    }

    public Type Get<TService>(string implementClazzName, bool isFullName = false) => this.Get(typeof (TService), implementClazzName, isFullName);

    public static List<Type> GetList(Assembly asm, Type service) => ((IEnumerable<Type>) asm.GetTypes()).Where<Type>((Func<Type, bool>) (it => service.IsAssignableFrom(it))).Where<Type>((Func<Type, bool>) (it => InheritClazzFinderAttribute.CheckFoundable(it))).ToList<Type>();

    public static List<Type> GetList<TService>(Assembly asm) => InheritClazzFinder.GetList(asm, typeof (TService));

    public static Type Get(Assembly asm, Type service, string implementClazzName, bool isFullName = false) => isFullName ? InheritClazzFinder.GetList(asm, service).FirstOrDefault<Type>((Func<Type, bool>) (it => it.FullName.Equals(implementClazzName))) : InheritClazzFinder.GetList(asm, service).FirstOrDefault<Type>((Func<Type, bool>) (it => it.Name.Equals(implementClazzName)));

    public static Type Get<TService>(Assembly asm, string implementClazzName, bool isFullName = false) => InheritClazzFinder.Get(asm, typeof (TService), implementClazzName, isFullName);
  }
}
