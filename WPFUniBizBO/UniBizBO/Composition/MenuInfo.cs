// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.MenuInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using UniBizBO.Services;
using UniinfoNet;
using UniinfoNet.Clazz;

namespace UniBizBO.Composition
{
  public class MenuInfo : BindableBase
  {
    private string name;
    private string title;
    private int level;
    private int code;
    private string clazzName;
    private string iconPath;
    private object iconSource;

    public string Name
    {
      get => this.name;
      set
      {
        this.name = value;
        this.Changed(nameof (Name));
      }
    }

    public string Title
    {
      get => this.title;
      set
      {
        this.title = value;
        this.Changed(nameof (Title));
      }
    }

    public int Level
    {
      get => this.level;
      set
      {
        this.level = value;
        this.Changed(nameof (Level));
      }
    }

    public int Code
    {
      get => this.code;
      set
      {
        this.code = value;
        this.Changed(nameof (Code));
      }
    }

    public string ClazzName
    {
      get => this.clazzName;
      set
      {
        this.clazzName = value;
        this.Changed(nameof (ClazzName));
      }
    }

    public string IconPath
    {
      get => this.iconPath;
      set
      {
        this.iconPath = value;
        this.Changed(nameof (IconPath));
      }
    }

    public object IconSource
    {
      get => this.iconSource;
      set
      {
        this.iconSource = value;
        this.Changed(nameof (IconSource));
      }
    }

    public bool HasClazz => !string.IsNullOrWhiteSpace(this.ClazzName);

    public virtual Type GetImplementType(InheritClazzFinder finder)
    {
      finder.Get<IUbVM>(this.ClazzName, true);
      return finder.Get<IUbVM>(this.ClazzName, true);
    }

    public virtual T GetInstance<T>(InheritClazzFinder finder, IContainer container) where T : class
    {
      Type type = finder.Get<IUbVM>(this.ClazzName, true);
      if (!(type != (Type) null))
        return default (T);
      return container == null ? default (T) : container.Get<T>(type.FullName);
    }

    public override string ToString() => string.Format("{0}, {1}, {2}", (object) this.Name, (object) this.Level, (object) this.ClazzName);
  }
}
