// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.MenuInfo`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;

namespace UniBizBO.Composition
{
  public class MenuInfo<T> : MenuInfo
  {
    public BindableCollection<T> Children { get; } = new BindableCollection<T>();

    public bool HasChild => this.Children.Count > 0;

    public override string ToString() => "[" + typeof (T).Name + "] " + base.ToString();
  }
}
